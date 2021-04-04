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
        internal Dictionary<string, IOAuth> OAuth { get; } = new Dictionary<string, IOAuth>();
        internal Dictionary<string, IBrokerage> Brokerage { get; } = new Dictionary<string, IBrokerage>();
        internal Dictionary<string, IMarketDataSource> MarketDataSource { get; } = new Dictionary<string, IMarketDataSource>();
        internal Dictionary<string, IIndicator> Indicator { get; } = new Dictionary<string, IIndicator>();
        internal Dictionary<string, IStrategy> Strategy { get; } = new Dictionary<string, IStrategy>();

        public Plugins() { }

        public IEnumerable<PluginLibrary> GetLibraries()
        {
            throw new NotImplementedException();
        }

        public void Load(PluginLibrary library)
        {
            throw new NotImplementedException();
        }

        public void Remove(PluginLibrary library)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(PluginInfoAttribute plugin)
        {
            throw new NotImplementedException();
        }

        public void SetEnabled(PluginInfoAttribute plugin, bool enabled)
        {
            throw new NotImplementedException();
        }
    }
}
