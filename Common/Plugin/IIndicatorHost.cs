﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common
{
    public interface IIndicatorHost : IPluginHost<IIndicator>
    {
    }
}
