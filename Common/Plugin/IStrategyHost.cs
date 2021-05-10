using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common
{
    public interface IStrategyHost : IPluginHost<IStrategy>
    {
    }
}
