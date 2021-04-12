using System;
using System.Collections.Generic;
using System.Reflection;

namespace StockWatcher.Core
{
    public partial class Settings
    {

        private AppData _appData;
        private Dictionary<string, object> _values;

        public Settings(AppData appData)
        {
            _appData = appData;

            _values = _appData.Read<Dictionary<string, object>>(nameof(Settings));

            bool changed = false;

            foreach (PropertyInfo property in typeof(Settings).GetProperties())
            {
                if (property.Name != "Item" && property.CanRead && property.CanWrite)
                {
                    string propertyName = property.Name.ToLower();

                    if (_values.ContainsKey(propertyName))
                    {
                        property.SetValue(this, Convert.ChangeType(_values[propertyName], property.PropertyType));
                    }
                    else
                    {
                        _values.Add(propertyName, property.GetValue(this));
                        changed = true;
                    }
                }
            }
            if (changed)
            {
                Save();
            }
        }

        public T Get<T>(string label)
            where T : IConvertible
        {
            label = label.ToLower();
            return _values.ContainsKey(label) ? (T)Convert.ChangeType(_values[label], typeof(T)) : default(T);
        }

        public void Set<T>(string label, T value)
            where T : IConvertible
        {

            if (label == "Item")
            {
                throw new ArgumentException("Cannot set property Item.", nameof(label));
            }

            PropertyInfo property = typeof(Settings).GetProperty(label);

            label = label.ToLower();

            // Set the local dictionary
            if (_values.ContainsKey(label))
            {
                if (value.Equals(Convert.ChangeType(_values[label], value.GetType())))
                {
                    return; // value didn't change
                }
                _values[label] = value;
            }
            else
            {
                _values.Add(label, value);
            }

            // Set the property
            if (property != null)
            {
                property.SetValue(this, Convert.ChangeType(value, property.PropertyType));
            }

            Save();
        }

        private void Save()
        {
            _appData.Write(nameof(Settings), _values);
        }
    }
}
