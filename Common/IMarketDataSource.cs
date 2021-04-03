using System;
using System.Collections.Generic;
using StockWatcher.Common.MarketData;

namespace StockWatcher.Common
{
    public interface IMarketDataSource : IPlugin
    {
        IOAuth OAuth { get; }
        DateTime GetTime();
        IEnumerable<ISymbol> Search(string prefix, int offset = 0);
        IEnumerable<IOption> GetOptions(ISymbol symbol, IEnumerable<IOptionFilter> filters);
    }
}
