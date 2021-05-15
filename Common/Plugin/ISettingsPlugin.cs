using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common
{
    public interface ISettingsPlugin : IPlugin
    {   
        SettingsContainer Settings { get; }
    }
}
