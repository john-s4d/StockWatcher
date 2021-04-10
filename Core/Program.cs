using StockWatcher.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockWatcher.Core
{
    public class Program
    {
        //public AppData AppData { get; internal set; }
        public Settings Settings { get; internal set; }
        public Plugins Plugins { get; internal set; }

        public Program(AppData appData)
        {
            Settings = new Settings(appData);
            Plugins = new Plugins(Settings);            
        }

        public bool OAuthHook(string[] args)
        {
            return OAuth.OAuthHook(Plugins.GetInstances<IOAuth>(), args, Settings.OAuthPipesTimeout).Result;
        }
    }
}
