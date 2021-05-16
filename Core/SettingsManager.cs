using System;
using System.Collections.Generic;
using System.Reflection;
using StockWatcher.Common;
using System.Linq;

namespace StockWatcher.Core
{
    public class SettingsManager
    {
        public IReadOnlyCollection<SettingsDictionary> Components => _components.AsReadOnly();

        private AppDataManager _appData;

        private List<SettingsDictionary> _components;

        internal SettingsManager(AppDataManager appData, Program _core)
        {
            _appData = appData;

            Dictionary<string, SettingsDictionary> components = new Dictionary<string, SettingsDictionary>();

            // TODO: Loading/unloading a plugin from pluginform should trigger reloading the settings from those plugins

            // Get from the plugins first
            foreach (ISettingsPlugin settingsPlugin in _core.Plugins.Get<ISettingsPlugin>())
            {
                components.Add(settingsPlugin.Name, settingsPlugin.Settings);
            }

            // Override with the persisted settings
            foreach (ISettingsPlugin settingsPlugin in _appData.Read<List<SettingsDictionary>>("settings"))
            {
                if (components.ContainsKey(settingsPlugin.Name))
                {
                    foreach(Setting setting in settingsPlugin.Settings.Values)
                    {
                        components[settingsPlugin.Name][setting.Name] = setting.Value;
                        //components[settingsPlugin.Name][setting.Name].Action = setting.Action;
                    }
                }
                else
                {
                    components.Add(settingsPlugin.Name, settingsPlugin.Settings);
                }
            }

            _components = components.Values.ToList();
        }

        internal void Add<T>(T settings) where T : SettingsDictionary
        {
            _components.Add(settings);
        }

        internal T Get<T>()
            where T : SettingsDictionary
        {
            T result = null;

            foreach (SettingsDictionary settings in _components)
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

        private void Save()
        {
            _appData.Write("settings", _components);
        }


    }
}
