using System;
using System.Collections.Generic;
using StockWatcher.Common.MarketData;

namespace StockWatcher.Common
{
    public interface IMarketDataSourceHost : IPluginHost<IMarketDataSourcePlugin>
    {
        
    }
}
