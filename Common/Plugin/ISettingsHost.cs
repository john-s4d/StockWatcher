using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common
{
    public interface ISettingsHost : IPluginHost<ISettings>
    {
        //Settings Settings { get; }
    }
}
