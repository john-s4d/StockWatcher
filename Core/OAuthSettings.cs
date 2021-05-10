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
        public override string Name { get; } = nameof(OAuthSettings);
        public override string Label { get; } = "OAuth";

        public int OAuthPipesTimeout { get; } = 20000;        
    }
}
