using System;

namespace StockWatcher.Common
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class PluginAttribute : Attribute
    {
        public PluginAttribute() { }

        public PluginAttribute(string title, Version version, string description)
            : this()
        {
            Title = title;
            Version = version.ToString(); // Ensure version is valid
            Description = description;
        }

        public PluginAttribute(string title, string version, string description)
            : this(title, new Version(version), description)
        { }

        public string Title { get; private set; }
        public string Version { get; private set; }
        public string Description { get; private set; }
    }
}
