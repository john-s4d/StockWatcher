using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace StockWatcher.Common
{
    public abstract class Settings 
    {
        private Dictionary<PropertyInfo, SettingDefinition> _definitions = new Dictionary<PropertyInfo, SettingDefinition>();

        public abstract string Name { get; }
        public abstract string Label { get; }

        public void SetAction(string settingName, Action action)
        {
            PropertyInfo property = GetPropertyInfo(settingName);

            if (!_definitions.ContainsKey(property))
            {
                _definitions.Add(property, new SettingDefinition(property.Name));
            }
            _definitions[property].Action = action;
        }

        private PropertyInfo GetPropertyInfo(string name)
        {
            return GetType().GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        }

    }
}
