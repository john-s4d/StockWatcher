using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common.Brokerage
{
    interface IPosition
    {
        IAccount Account { get; set; }
    }
}
