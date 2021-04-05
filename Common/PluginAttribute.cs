using System;

namespace StockWatcher.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class PluginAttribute : Attribute
    {
        public PluginAttribute() { }

        public PluginAttribute(string name, Version version, string description)
            : this()
        {
            Name = name;
            Version = version;
            Description = description;
        }

        public PluginAttribute(string name, string version, string description)
            : this(name, new Version(version), description)
        { }

        public string Name { get; private set; }
        public Version Version { get; private set; }
        public string Description { get; private set; }
    }
}
