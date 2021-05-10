﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common
{
    public interface ILoggerHost : IPluginHost<ILogger>
    {
        Logger Logger { get; }
    }
}
