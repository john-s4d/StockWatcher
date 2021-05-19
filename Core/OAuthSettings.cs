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
        public override string Name { get; protected set; } = nameof(OAuthSettings);
        public override string Label { get; protected set; } = "OAuth";
        public int OAuthPipesTimeout { get; set; } = 20000;

        public OAuthSettings()
        {
            SetLabel(nameof(OAuthPipesTimeout), "OAuth Pipes Timeout (ms)");
        }

    }
}
