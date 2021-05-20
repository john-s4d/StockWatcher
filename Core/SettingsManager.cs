using System;
using System.Collections.Generic;
using System.Reflection;
using StockWatcher.Common;
using System.Linq;

namespace StockWatcher.Core
{
    public class SettingsManager
    {
        public IReadOnlyList<SettingsDictionary> Components => _components.Values.ToList();

        private AppDataManager _appData;

        private Dictionary<string, SettingsDictionary> _components = new Dictionary<string, SettingsDictionary>();
        Dictionary<string, Type> _typeMap = new Dictionary<string, Type>();

        internal SettingsManager(AppDataManager appData)
        {
            _appData = appData;
        }

        internal void Load()
        {
            Dictionary<string, SettingsDictionary> components = _appData.Read<Dictionary<string, SettingsDictionary>>("settings", new SettingsDictionaryJsonConverter(_typeMap));

            foreach (SettingsDictionary settings in components.Values)
            {
                Merge(settings);
            }
        }

        internal void Merge(IEnumerable<ISettingsPlugin> plugins)
        {
            foreach (ISettingsPlugin settingsPlugin in plugins)
            {
                Merge(settingsPlugin.Settings);
            }
        }

        internal void Merge<T>(T settings)
            where T : SettingsDictionary, new()
        {
            if (!_typeMap.ContainsKey(settings.Name))
            {
                _typeMap.Add(settings.Name, settings.GetType());
            }

            if (!_components.ContainsKey(settings.Name))
            {
                _components.Add(settings.Name, settings);
                //_components.Add(settings.Name, (SettingsDictionary)Activator.CreateInstance(settings.GetType()));
            }

            foreach (string key in settings.Keys.ToList())
            {
                SettingsDictionary component = _components[settings.Name];

                if (!component.ContainsKey(key))
                {
                    component.Add(key, settings[key]);
                }

                component[key] = settings[key];
            }


            
        }

        internal T Get<T>()
            where T : SettingsDictionary
        {
            //return (T)_components[typeof(T)];

            T result = null;

            foreach (SettingsDictionary settings in _components.Values)
            {
                if (settings.GetType().Equals(typeof(T)))
                {
                    if (result != null)
                    {
                        throw new Exception("Duplicate type found");
                    }
                    result = (T)settings;
                }
            }
            return result;
        }

        public void Save()
        {
            _appData.Write("settings", _components);
        }
    }
}
