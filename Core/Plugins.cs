using System.Collections.Generic;
using StockWatcher.Common;

namespace StockWatcher.Core
{
    public class Plugins
    {
        private AppData _appData;

        public List<PluginLibrary> Libraries { get; private set; }

        public Plugins(AppData appData)
        {
            _appData = appData;

            Libraries = _appData.Read<List<PluginLibrary>>(nameof(Plugins));

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
            _appData.Write(nameof(Plugins), Libraries);
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
