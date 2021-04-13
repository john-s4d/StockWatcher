using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common
{
    public interface ISettings : IPlugin
    {
        Dictionary<string, IConvertible> Settings { get; }
    }
}
