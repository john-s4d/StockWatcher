using System;

namespace StockWatcher.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class PluginInfoAttribute : Attribute
    {
        public PluginInfoAttribute(PluginType pluginType, string name, Version version, string description)
        {
            PluginType = pluginType;
            Name = name;
            Version = version;
            Description = description;
        }

        public PluginInfoAttribute(PluginType pluginType, string name, string version, string description)
            : this(pluginType, name, new Version(version), description)
        { }

        public PluginType PluginType { get; private set; }
        public string Name { get; private set; }
        public Version Version { get; private set; }
        public string Description { get; private set; }
    }

    public enum PluginType
    {
        Other = 0,
        Brokerage = 1,
        Indicator = 2,
        MarketData = 4,
        OAuth = 8,
        Strategy = 16
    }
}
