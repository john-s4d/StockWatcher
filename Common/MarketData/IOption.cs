using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common.MarketData
{
    public interface IOption
    {
        IEquity Equity { get; }
    }
}
