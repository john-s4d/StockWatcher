using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Linq;

namespace StockWatcher.Common
{
    public abstract class SettingsContainer : IDictionary<string, Setting>, INotifyPropertyChanged
    {

        private Dictionary<string, PropertyInfo> _properties = new Dictionary<string, PropertyInfo>();
        private Dictionary<string, Setting> _settings = new Dictionary<string, Setting>();

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract string Name { get; }

        public abstract string Label { get; }

        public ICollection<string> Keys => _settings.Keys;

        public ICollection<Setting> Values => _settings.Values;

        public int Count => _settings.Count;

        public bool IsReadOnly => true;

        public Setting this[string key]
        {
            get => _settings[key];
            set => throw new NotSupportedException(); // _settings[key] = value;
        }

        /*
        public void SetValue(string name, IConvertible value)
        {
            PropertyInfo property = GetProperty(name);
            if (property != null)
            {
                property.SetValue(this, value);
            }            
            SetValue(GetProperty(name), value);
        }

        internal void SetValue(PropertyInfo property, IConvertible value)
        {
            property.SetValue(this, value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property.Name));
        }*/
        /*
        internal IConvertible GetValue(PropertyInfo property)
        {
            return (IConvertible)property.GetValue(this);
        }

        public IConvertible GetValue(string name)
        {
            return GetValue(GetProperty(name));
        }

        public void SetAction(string name, Action action)
        {
            this[name].Action = action;            
        }
        */
        public void Define(string name, string label)
        {
            Setting setting = GetSetting(name);
            setting.Label = label;
        }

        public void Define(string name)
        {
            _ = GetSetting(name);
        }

        private PropertyInfo GetProperty(string name)
        {
            return GetType().GetProperty(name);
        }

        private Setting GetSetting(string name)
        {
            return GetSetting(GetProperty(name));
        }

        private Setting GetSetting(PropertyInfo property)
        {
            Setting setting;

            if (!_settings.TryGetValue(property.Name, out setting))
            {
                setting = new Setting(this, property);
                _settings.Add(property.Name, setting);
            }

            return setting;
        }
        /*
        public IEnumerator<Setting> GetEnumerator()
        {
            return _settings.Values.GetEnumerator();
        }*/

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _settings.Values.GetEnumerator();
        }

        public void Add(string key, Setting value)
        {   
            _properties.Add(key, GetProperty(key));
            _settings.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _settings.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            _properties.Remove(key);
            return _settings.Remove(key);
        }

        public bool TryGetValue(string key, out Setting value)
        {
            return _settings.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, Setting> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _properties.Clear();
            _settings.Clear();
        }

        public bool Contains(KeyValuePair<string, Setting> item)
        {
            return _settings.ContainsKey(item.Key);
        }

        public void CopyTo(KeyValuePair<string, Setting>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, Setting> item)
        {
            _properties.Remove(item.Key);
            return _settings.Remove(item.Key);

        }

        IEnumerator<KeyValuePair<string, Setting>> IEnumerable<KeyValuePair<string, Setting>>.GetEnumerator()
        {
            return _settings.GetEnumerator();
        }

    }
}
