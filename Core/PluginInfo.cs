using System;
using System.Collections.Generic;
using System.Reflection;
using StockWatcher.Common;

namespace StockWatcher.Core
{
    public class PluginInfo
    {
        public event Action<PluginInfo> OnEnabled;
        public event Action<PluginInfo> OnDisabled;

        public Type Class { get; private set; }
        public IEnumerable<Type> Interfaces { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Version Version { get; private set; }

        private bool _enabled;

        public PluginInfo(Type pluginClass)
        {
            PluginAttribute attributes = pluginClass.GetCustomAttribute<PluginAttribute>();
            Name = attributes.Name;
            Description = attributes.Description;
            Version = attributes.Version;
            Class = pluginClass;
            Interfaces = pluginClass.GetInterfaces();
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (value != _enabled)
                {
                    _enabled = value;
                    if (value)
                    {
                        OnEnabled?.Invoke(this);
                    }
                    else
                    {
                        OnDisabled?.Invoke(this);
                    }
                }
            }
        }
    }
}
