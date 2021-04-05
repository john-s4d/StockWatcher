using StockWatcher.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.Core
{
    public class Plugins
    {
        private const string DATA_NAME = "plugins";
        private AppData _appdata;

        internal List<IOAuth> OAuth { get; } = new List<IOAuth>();
        internal List<IBrokerage> Brokerage { get; } = new List<IBrokerage>();
        internal List<IMarketDataSource> MarketDataSource { get; } = new List<IMarketDataSource>();
        internal List<IIndicator> Indicator { get; } = new List<IIndicator>();
        internal List<IStrategy> Strategy { get; } = new List<IStrategy>();

        public IEnumerable<PluginLibrary> Libraries { get { return _libraries; } }


        private List<PluginLibrary> _libraries = new List<PluginLibrary>();

        public Plugins(AppData appData)
        {
            _appdata = appData;
            LoadLibraries(_appdata.Read<List<PluginLibrary>>(DATA_NAME));
        }

        private void LoadLibraries(IEnumerable<PluginLibrary> libraries)
        {
            foreach (PluginLibrary library in libraries)
            {
                LoadLibrary(library);
            }
        }

        private void LoadLibrary(PluginLibrary library)
        {
            _libraries.Add(library);
            foreach (PluginInfo plugin in library.Plugins)
            {
                if (plugin.Enabled)
                {
                    Enable(plugin);
                }
                plugin.OnEnabled += Enable;
                plugin.OnDisabled += Disable;
            }
        }

        private void Enable(PluginInfo plugin)
        {
            if (plugin.Interfaces.Contains(typeof(IOAuth)))
            {
                OAuth.Add((IOAuth)Activator.CreateInstance(plugin.Class));
            }

            if (plugin.Interfaces.Contains(typeof(IBrokerage)))
            {
                Brokerage.Add((IBrokerage)Activator.CreateInstance(plugin.Class));
            }

            if (plugin.Interfaces.Contains(typeof(IMarketDataSource)))
            {
                MarketDataSource.Add((IMarketDataSource)Activator.CreateInstance(plugin.Class));
            }

            if (plugin.Interfaces.Contains(typeof(IIndicator)))
            {
                Indicator.Add((IIndicator)Activator.CreateInstance(plugin.Class));
            }

            if (plugin.Interfaces.Contains(typeof(IStrategy)))
            {
                Strategy.Add((IStrategy)Activator.CreateInstance(plugin.Class));
            }
        }

        private void Disable(PluginInfo plugin)
        {
            throw new NotImplementedException();
        }

        public void Add(PluginLibrary library)
        {
            LoadLibrary(library);
        }

        public void Remove(PluginLibrary library)
        {
            throw new NotImplementedException();
        }
    }
}
