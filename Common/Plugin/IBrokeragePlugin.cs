using System;

namespace StockWatcher.Common
{
    public interface IBrokeragePlugin : IPlugin
    {
        DateTime GetTime();

    }
}
