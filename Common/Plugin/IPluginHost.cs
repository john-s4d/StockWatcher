using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StockWatcher.Common
{
    public interface IPluginHost<T>
        where T : IPlugin
    {
        Guid Id { get; }
    }
}
