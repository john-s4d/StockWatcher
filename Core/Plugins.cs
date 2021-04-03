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
        internal IDictionary<string, IOAuth> OAuth { get; }
        internal IDictionary<string, IBrokerage> Brokerage { get; }
        internal IDictionary<string, IMarketDataSource> MarketDataSource { get; }
        internal IDictionary<string, IIndicator> Indicator { get; }

        public Plugins()
        {
            OAuth = new Dictionary<string, IOAuth>();
        }

        public void Load(List<string> pluginFiles)
        {
            
        }
    }
}
