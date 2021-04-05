using Newtonsoft.Json;
using StockWatcher.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.Core
{   
    public class Settings : ISettings
    {
        private const string LABEL = "settings";

        private AppData _appdata;

        public int OAuthPipesTimeout { get; set; } = 10000;

        public Settings(AppData appData)
        {
            _appdata = appData;
        }
    }
}
