using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using StockWatcher.Common;

namespace StockWatcher.Core
{
    public class PluginClass
    {
        public event Action<PluginClass, bool> OnInstanceEnabledChanged;

        public string Name { get; set; }
        public List<PluginInterface> Interfaces { get; set; } = new List<PluginInterface>();

        [JsonIgnore]
        public IPlugin Instance { get; private set; }
        [JsonIgnore]
        public string Title { get; private set; }
        [JsonIgnore]
        public string Version { get; private set; }
        [JsonIgnore]
        public string Description { get; private set; }
        public bool Activated { get; internal set; }

        private Type _classType;

        [JsonConstructor]
        public PluginClass(string name, Assembly assembly = null, bool deepLoad = false)
        {
            Name = name;

            if (assembly != null)
            {
                LoadFrom(assembly, deepLoad);
            }
        }

        internal void LoadFrom(Assembly assembly)
        {
            LoadFrom(assembly, false);
        }

        private void LoadFrom(Assembly assembly, bool deepLoad)
        {
            _classType = assembly.GetType(Name);

            if (!Attribute.IsDefined(_classType, typeof(PluginAttribute))) { return; } // TODO: log an error or throw

            PluginAttribute attributes = _classType.GetCustomAttribute<PluginAttribute>();
            Title = attributes.Title;
            Description = attributes.Description;
            Version = attributes.Version;

            if (deepLoad)
            {
                foreach (Type interfaceType in _classType.GetInterfaces())
                {
                    if (!interfaceType.Equals(typeof(IPlugin)) && typeof(IPlugin).IsAssignableFrom(interfaceType))
                    {
                        PluginInterface pluginInterface = new PluginInterface(interfaceType.FullName);
                        Interfaces.Add(pluginInterface);
                    }
                }
            }

            foreach (PluginInterface pluginInterface in Interfaces)
            {
                pluginInterface.LoadFrom(_classType);
                PluginInterface_OnEnabledChanged(pluginInterface, pluginInterface.Enabled);
                pluginInterface.OnEnabledChanged += PluginInterface_OnEnabledChanged;
            }
        }

        private void PluginInterface_OnEnabledChanged(PluginInterface sender, bool enabled)
        {
            if (enabled && Instance == null)
            {
                Instance = (IPlugin)Activator.CreateInstance(_classType);
            }

            if (!enabled && Instance != null)
            {
                foreach (PluginInterface pluginInterface in Interfaces)
                {
                    if (pluginInterface != sender && pluginInterface.Enabled)
                    {
                        return;
                    }
                }
                Instance.Dispose();
                Instance = null;
            }
            OnInstanceEnabledChanged?.Invoke(this, enabled);
        }
    }
}
