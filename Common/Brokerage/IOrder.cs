using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common.Brokerage
{
    interface IOrder
    {
        IAccount Account { get; set; }
    }
}
