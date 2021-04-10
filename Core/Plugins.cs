using System.Collections.Generic;
using StockWatcher.Common;

namespace StockWatcher.Core
{
    public class Plugins
    {
        private Settings _settings;

        public List<PluginLibrary> Libraries { get; private set; }

        public Plugins(Settings settings)
        {
            _settings = settings;

            Libraries = _settings.Get<List<PluginLibrary>>(nameof(Plugins), nameof(Libraries));

            foreach (PluginLibrary pluginLibrary in Libraries)
            {
                pluginLibrary.Load();
            }
        }

        internal IEnumerable<T> GetInstances<T>() where T : class, IPlugin
        {
            List<T> result = new List<T>();

            foreach (PluginLibrary pluginLibrary in Libraries)
            {
                foreach (PluginClass pluginClass in pluginLibrary.Classes)
                {
                    if (pluginClass.Instance != null && typeof(T).IsAssignableFrom(pluginClass.Instance.GetType()) && !result.Contains((T)pluginClass.Instance))
                    {
                        foreach (PluginInterface pluginInterface in pluginClass.Interfaces)
                        {
                            if (pluginInterface.Enabled && pluginInterface.Type.Equals(typeof(T))) 
                            {
                                result.Add((T)pluginClass.Instance);
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void Save()
        {
            _settings.Set(nameof(Plugins), nameof(Libraries), Libraries);
        }

        public void AddLibrary(PluginLibrary library)
        {   
            Libraries.Add(library);            
        }

        public void Remove(PluginLibrary library)
        {
            Libraries.Remove(library);            
        }
    }
}
