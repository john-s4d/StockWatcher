using StockWatcher.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.Core
{
    public class OAuthSettings : Settings
    {
        public OAuthSettings()
            : base(nameof(OAuthSettings), "OAuth")
        { }

        public int OAuthPipesTimeout { get; private set; } = 10000;

    }
}
