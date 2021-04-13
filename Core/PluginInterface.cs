using System;
using Newtonsoft.Json;

namespace StockWatcher.Core
{
    public class PluginInterface
    {
        public event Action<PluginInterface, bool> OnEnabledChanged;

        public string Name { get; private set; }
        public string ShortName { get; private set; }

        [JsonIgnore]
        internal Type Type { get; private set; }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (value != _enabled)
                {
                    _enabled = value;
                    OnEnabledChanged?.Invoke(this, value);
                }
            }
        }

        private bool _enabled;

        public PluginInterface(string name)
        {
            Name = name;
        }

        public void LoadFrom(Type classType)
        {
            Type = classType.GetInterface(Name);
            ShortName = Type.Name;
        }
    }
}
