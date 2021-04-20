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
        public SettingsManager Settings { get; internal set; }
        public PluginsManager Plugins { get; internal set; }

        public Program(AppDataManager appData)
        {
            Settings = new SettingsManager(appData);
            
            Settings.Add(new OAuthSettings());

            Plugins = new PluginsManager(appData, Settings);            
        }

        public bool OAuthHook(string[] args)
        {
            return OAuth.OAuthHook(Plugins.GetInstances<IOAuth>(), args, Settings.Get<OAuthSettings>().OAuthPipesTimeout).Result;
        }
    }
}
