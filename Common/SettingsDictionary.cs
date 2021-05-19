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
    public class SettingsDictionary : IDictionary<string, IConvertible>
    {
        
        private Dictionary<string, Setting> _settings = new Dictionary<string, Setting>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<string, IConvertible> _values = new Dictionary<string, IConvertible>(StringComparer.OrdinalIgnoreCase);

        private const BindingFlags BINDING_FLAGS =
            BindingFlags.IgnoreCase |
            BindingFlags.DeclaredOnly |
            BindingFlags.Instance |
            BindingFlags.Public;//| 
           // BindingFlags.SetProperty;

        public virtual string Name { get; protected set; }

        [JsonIgnore]
        public virtual string Label { get; protected set; }

        [JsonIgnore]
        public IReadOnlyCollection<Setting> Settings => _settings.Values.ToList();

        [JsonIgnore]
        public ICollection<string> Keys => _values.Keys;

        [JsonIgnore]
        public ICollection<IConvertible> Values => _values.Values;
        [JsonIgnore]
        public int Count => _values.Count;
        [JsonIgnore]
        public bool IsReadOnly => false;

        public IConvertible this[string key]
        {
            get { return GetValue(key); }
            set { SetValue(key, value); }
        }

        public SettingsDictionary()
        {
            
            foreach (PropertyInfo property in GetProperties())
            {
                Add(property.Name, (IConvertible)property.GetValue(this));
            }
        }
        
        public SettingsDictionary(string name, string label)
            : this()
        {
            Name = name;
            Label = label;
        }

        private IConvertible GetValue(string key)
        {
            PropertyInfo property = GetProperty(key);
            IConvertible value = property == null ? _values[key] : (IConvertible)property.GetValue(this);

            // Assume that if the property has changed but _values did not, the property was set directly.
            // Set the value now. This isn't ideal, but better late than never.
            if (value != _values[key])
            {
                _values[key] = value;
            }
            return value;
        }

        private void SetValue(string key, IConvertible value)
        {
            PropertyInfo property = GetProperty(key);
            if (property != null && !property.CanWrite)
            {
                throw new InvalidOperationException($"Property '{key}' cannot be set.");
            }
            _settings[key].Value = value;
        }

        protected void SetAction(string key, Action action)
        {
            _settings[key].OnAction = action;
        }

        protected void SetLabel(string key, string label)
        {
            _settings[key].Label = label;
        }

        private PropertyInfo GetProperty(string key)
        {
            PropertyInfo property = GetType().GetProperty(key, BINDING_FLAGS);
            if (!IsReserved(property))
            {
                return property;
            }
            return property;
        }

        private IEnumerable<PropertyInfo> GetProperties()
        {
            Type type = GetType();
            foreach (PropertyInfo property in type.GetProperties(BINDING_FLAGS))
            {
                if (!IsReserved(property))
                {
                    yield return property;
                }
            }
        }

        // TODO: There must be a better way to ignore certain properties.
        public bool IsReserved(PropertyInfo property)
        {   
            return 
                property.Name.Equals(nameof(Name)) || 
                property.Name.Equals(nameof(Label)) || 
                property.Name.Equals(nameof(Settings)) ||
                property.Name.Equals(nameof(Keys)) ||
                property.Name.Equals(nameof(Count)) ||
                property.Name.Equals(nameof(Keys)) ||
                property.Name.Equals(nameof(Values)) ||
                property.Name.Equals(nameof(IsReadOnly)) ||
                property.Name.Equals("Item")
                ;
        }

        public void Add(string key, IConvertible value, string label)
        {
            Setting setting = new Setting()
            {
                Name = key,
                Value = value,
                Label = label
            };
            _settings.Add(key, setting);
            _values.Add(key, value);

            setting.PropertyChanged += OnValueChanged;
        }

        public void Add(string key, IConvertible value)
        {
            Add(key, value, key);
        }

        private void OnValueChanged(object sender, PropertyChangedEventArgs e)
        {
            Setting setting = (Setting)sender;
            PropertyInfo property = GetProperty(setting.Name);

            property?.SetValue(this, Convert.ChangeType(setting.Value, property.PropertyType));
            _values[setting.Name] = setting.Value;
        }

        public bool ContainsKey(string key)
        {
            return _values.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            if (_values.Remove(key))
            {
                _settings.Remove(key);
                GetProperty(key)?.SetValue(this, null);
                return true;
            }
            return false;
        }

        public bool TryGetValue(string key, out IConvertible value)
        {
            return _values.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, IConvertible> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _settings.Clear();
            _values.Clear();
            foreach (PropertyInfo property in GetProperties())
            {
                property.SetValue(this, null);
            }
        }

        public bool Contains(KeyValuePair<string, IConvertible> item)
        {
            return _values.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, IConvertible>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, IConvertible> item)
        {
            return _values.ContainsKey(item.Key) && _values[item.Key].Equals(item.Value) && Remove(item.Key);
            //return Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<string, IConvertible>> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _values.GetEnumerator();
        }
    }
}
