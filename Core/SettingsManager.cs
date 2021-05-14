using System;
using System.Collections.Generic;
using System.Reflection;
using StockWatcher.Common;
using System.Linq;

namespace StockWatcher.Core
{
    public class SettingsManager
    {
        public IReadOnlyCollection<Settings> Components => _components.AsReadOnly();

        private AppDataManager _appData;

        private List<Settings> _components;

        internal SettingsManager(AppDataManager appData, Program _core)
        {
            _appData = appData;

            Dictionary<string, Settings> components = new Dictionary<string, Settings>();

            // TODO: Loading/unloading a plugin from pluginform should trigger reloading the settings from those plugins

            // Get from the plugins first
            foreach (ISettingsPlugin settingsPlugin in _core.Plugins.Get<ISettingsPlugin>())
            {
                components.Add(settingsPlugin.Name, settingsPlugin.Settings);
            }

            // Override with the persisted settings
            foreach (ISettingsPlugin settingsPlugin in _appData.Read<List<Settings>>("settings"))
            {
                if (components.ContainsKey(settingsPlugin.Name))
                {
                    foreach(Setting setting in settingsPlugin.Settings)
                    {
                        components[settingsPlugin.Name].SetValue(setting.Name, setting.Value);
                        components[settingsPlugin.Name].SetAction(setting.Name, setting.Action);
                    }
                }
                else
                {
                    components.Add(settingsPlugin.Name, settingsPlugin.Settings);
                }
            }

            _components = components.Values.ToList();
        }

        internal void Add<T>(T settings) where T : Settings
        {
            _components.Add(settings);
        }

        internal T Get<T>()
            where T : Settings
        {
            T result = null;

            foreach (Settings settings in _components)
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

        /*
        internal Settings this[string name]
        {
            get { return Get(name); }
            set { Add(value); }
        }

        internal Settings Get(string componentName)
        {
            throw new NotImplementedException();
        }*/

        private void Save()
        {
            _appData.Write("settings", _components);
        }


    }
}
