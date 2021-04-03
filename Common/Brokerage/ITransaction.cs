using System;
using System.Collections.Generic;
using System.Text;


namespace StockWatcher.Common.Brokerage
{
    interface ITransaction
    {
        DateTime TradeDate { get; }
        DateTime TransactionDate { get; }
        DateTime SettlementDate { get; }

    }
}
