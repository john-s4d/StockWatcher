using System;
using System.Collections.Generic;
using System.Reflection;

namespace StockWatcher.Core
{
    public partial class Settings
    {

        private AppData _appData;
        private Dictionary<string, object> _settings; 

        public Settings(AppData appData)
        {
            _appData = appData;

            // Dictionary is Case Insensitive
            _settings = new Dictionary<string, object>(_appData.Read<Dictionary<string, object>>(nameof(Settings)), StringComparer.OrdinalIgnoreCase);

            bool changed = false;

            // Sync properties and dictionary
            foreach (PropertyInfo property in typeof(Settings).GetProperties())
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
            PropertyInfo property = typeof(Settings).GetProperty(settingName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property != null)
            {
                property.SetValue(this, Convert.ChangeType(value, property.PropertyType));
            }

            Save();
        }

        private void Save()
        {
            _appData.Write(nameof(Settings), _settings);
        }
    }
}
