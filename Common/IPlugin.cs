using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common
{
    public interface IPlugin
    {
        string Name { get; }
        Version Version { get; }
        string Description { get; }
    }
}
