﻿using System;
using System.Collections.Generic;
using System.Reflection;
using StockWatcher.Common;

namespace StockWatcher.Core
{
    public class SettingsManager
    {
        private AppDataManager _appData;
        //private Dictionary<string, object> _settings;

        public IReadOnlyCollection<Settings> Components => _components.Values;

        private Dictionary<string, Settings> _components;
        
        internal Settings this[string name]
        {
            get { return Get(name); }
            set { Add(value); }
        }

        internal SettingsManager(AppDataManager appData)
        {
            _appData = appData;

            _components = _appData.Read<Dictionary<string, Settings>>("settings");
        }

        internal void Add<T>(T settings) where T : Settings
        {
            _components.Add(settings.Name, settings);
        }

        internal T Get<T>() where T : Settings            
        {
            T result = null;

            foreach(Settings settings in _components.Values)
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

        internal Settings Get(string componentName)
        {
            throw new NotImplementedException();
        }

        private void Save()
        {
            _appData.Write("settings", _components);
        }

        /*
        public SettingsManager(AppDataManager appData)
        {
            _appData = appData;

            // Dictionary is Case Insensitive
            _settings = new Dictionary<string, object>(_appData.Read<Dictionary<string, object>>(nameof(SettingsManager)), StringComparer.OrdinalIgnoreCase);

            bool changed = false;

            // Sync properties and dictionary
            foreach (PropertyInfo property in typeof(SettingsManager).GetProperties())
            {
                if (property.CanRead && property.CanWrite)
                {
                    if (_settings.ContainsKey(property.Name))
                    {
                        property.SetValue(this, Convert.ChangeType(_settings[property.Name], property.PropertyType));
                    }
                    else
                    {
                        _settings.Add(property.Name.ToLower(), property.GetValue(this));
                        changed = true;
                    }
                }
            }
            if (changed)
            {
                Save();
            }
        }

       

        public T Get<T>(string settingName)
            where T : IConvertible
        {
            return _settings.ContainsKey(settingName) ? (T)Convert.ChangeType(_settings[settingName], typeof(T)) : default(T);
        }

        public void Set<T>(string settingName, T value)
            where T : IConvertible
        {
            // Set the local dictionary
            if (_settings.ContainsKey(settingName))
            {
                if (value.Equals(Convert.ChangeType(_settings[settingName], value.GetType())))
                {
                    return; // value didn't change
                }
                _settings[settingName] = value;
            }
            else
            {
                _settings.Add(settingName, value);
            }

            // Set the property
            PropertyInfo property = typeof(SettingsManager).GetProperty(settingName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property != null)
            {
                property.SetValue(this, Convert.ChangeType(value, property.PropertyType));
            }

            Save();
        }

        private void Save()
        {
            _appData.Write(nameof(SettingsManager), _settings);
        }*/
    }
}