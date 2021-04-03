using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common.MarketData
{
    public interface IEquity
    {
        ISymbol Symbol { get; }        
    }
}
