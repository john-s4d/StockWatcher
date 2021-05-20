using StockWatcher.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.Core
{
    public class OAuthSettings : SettingsDictionary
    {           
        public int OAuthPipesTimeout { get; set; } = 20000;

        public OAuthSettings()
            : base(nameof(OAuthSettings), "OAuth")
        {
            SetLabel(nameof(OAuthPipesTimeout), "OAuth Pipes Timeout (ms)");
        }
    }
}
