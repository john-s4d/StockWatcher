using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common.Brokerage
{
    interface IExecution
    {
        IAccount Account { get; set; }
    }
}
