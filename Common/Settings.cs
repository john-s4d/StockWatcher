using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace StockWatcher.Common
{
    public abstract class Settings : IEnumerable<Setting>, INotifyPropertyChanged
    {
        private Dictionary<PropertyInfo, Setting> _settings = new Dictionary<PropertyInfo, Setting>();        

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract string Name { get; }

        public abstract string Label { get; }

        public void SetValue(string name, IConvertible value)
        {
            SetValue(GetProperty(name), value);            
        }

        internal void SetValue(PropertyInfo property, IConvertible value)
        {   
            property.SetValue(this, value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property.Name));
        }

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
            GetSetting(name).Action = action;
        }

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

            if (!_settings.TryGetValue(property, out setting))
            {
                setting = new Setting(this, property);
                _settings.Add(property, setting);
            }
            
            return setting;
        }

        public IEnumerator<Setting> GetEnumerator()
        {
            return _settings.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _settings.Values.GetEnumerator();
        }
    }
}
