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

        internal SettingsManager(AppDataManager appData, Program _core)
        {
            _appData = appData;

            // TODO: Loading/unloading a plugin from pluginform should trigger reloading the settings from those plugins
            Load(_core.Plugins.Get<ISettingsPlugin>());
        }

        internal void Load(IEnumerable<ISettingsPlugin> plugins)
        {

            Dictionary<string, Type> typeMap = new Dictionary<string, Type>();

            foreach (ISettingsPlugin settingsPlugin in plugins)
            {
                _components.Add(settingsPlugin.Settings.Name, settingsPlugin.Settings);
                typeMap.Add(settingsPlugin.Settings.Name, settingsPlugin.Settings.GetType());
            }

            // TODO: Get Types for other settings.

            Dictionary<string, SettingsDictionary> componentsPersisted = _appData.Read<Dictionary<string, SettingsDictionary>>("settings", new SettingsDictionaryJsonConverter(typeMap));

            // Override with the persisted settings
            foreach (string key in componentsPersisted.Keys)
            {
                if (_components.ContainsKey(key))
                {
                    foreach (Setting settingPersisted in componentsPersisted[key].Values)
                    {
                        _components[key][settingPersisted.Name] = settingPersisted.Value;
                    }
                }
                else
                {
                    _components.Add(key, componentsPersisted[key]);
                }
            }
        }




        internal void Add<T>(T settings) where T : SettingsDictionary
        {
            _components.Add(settings.Name, settings);
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
