using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using StockWatcher.Common;

namespace StockWatcher.Core
{
    public class PluginLibrary
    {
        public string AssemblyPath { get; }
        public Guid Guid { get; }
        public string Title { get; }
        public string Description { get; }
        public Version Version { get; }
        public string Company { get; }
        public List<PluginInfo> Plugins { get; }
        public PluginLibrary(string assemblyPath)
        {
            Assembly library = Assembly.LoadFrom(assemblyPath);

            AssemblyPath = library.Location;
            Guid = new Guid(library.GetCustomAttribute<GuidAttribute>().Value);
            Version = new Version(library.GetCustomAttribute<AssemblyFileVersionAttribute>().Version);
            Title = library.GetCustomAttribute<AssemblyTitleAttribute>().Title;
            Description = library.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            Company = library.GetCustomAttribute<AssemblyCompanyAttribute>().Company;

            Plugins = new List<PluginInfo>();

            foreach (Type pluginClass in library.GetTypes())
            {
                if (pluginClass.IsPublic && pluginClass.GetInterface(typeof(IPlugin).FullName, true) != null)
                {
                    if (Attribute.IsDefined(pluginClass, typeof(PluginAttribute)))
                    {   
                        Plugins.Add(new PluginInfo(pluginClass));
                    }
                    else
                    {
                        // TODO: Log error - plugin not properly defined.
                    }
                }
            }
        }
    }
}