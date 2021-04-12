using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.Core
{
    public partial class Settings
    {
        public int OAuthPipesTimeout { get; set; } = 10000;
    }
}
