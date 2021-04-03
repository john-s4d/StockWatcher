using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common.MarketData
{
    interface IQuote
    {
        IEnumerable<ISymbol> Securities { get; }
    }
}
