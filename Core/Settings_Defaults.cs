using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.Core
{
    public partial class Settings
    {
        // These properties all should have private setters. Callers should use Set() method instead, to keep the values synchronized. Private getters optional.
        public int OAuthPipesTimeout { get; private set; } = 10000;
    }
}
