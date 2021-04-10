using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using StockWatcher.Common;

namespace StockWatcher.Core
{
    public class PluginLibrary
    {
        public string AssemblyPath { get; }
        public List<PluginClass> Classes { get; } = new List<PluginClass>();

        private Assembly _assembly;

        [JsonIgnore]
        public string Title { get; private set; }
        [JsonIgnore]
        public string Version { get; private set; }
        [JsonIgnore]
        public string Description { get; private set; }

        [JsonConstructor]
        public PluginLibrary(string assemblyPath, bool deepLoad = false)
        {
            AssemblyPath = assemblyPath;

            if (deepLoad)
            {
                Load(true);
            }
        }

        internal void Load()
        {
            Load(false);
        }

        private void Load(bool deepLoad)
        {
            _assembly = Assembly.LoadFrom(AssemblyPath);

            Title = _assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
            Version = new Version(_assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version).ToString(); // Ensure this version string is correct format 
            Description = _assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;

            if (deepLoad)
            {
                foreach (Type classType in _assembly.GetTypes())
                {
                    if (classType.IsPublic && classType.GetInterface(typeof(IPlugin).FullName, true) != null)
                    {
                        Classes.Add(new PluginClass(classType.FullName, _assembly, deepLoad));
                    }
                }
            }

            foreach (PluginClass pluginClass in Classes)
            {
                pluginClass.LoadFrom(_assembly);
            }
        }
    }
}
