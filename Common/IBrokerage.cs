using System;

namespace StockWatcher.Common
{
    public interface IBrokerage : IPlugin
    {
        DateTime GetTime();

    }
}
