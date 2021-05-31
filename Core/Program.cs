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
        public PluginsManager Plugins { get; } = new PluginsManager();
        public SettingsManager Settings { get; } = new SettingsManager();
        public LoggingManager Logger { get; } = new LoggingManager();

        public Program(AppDataManager appData)
        {
            Plugins.Load(appData, this);
            
            Settings.Merge(new OAuthSettings());
            Settings.Merge(Plugins.Get<ISettingsPlugin>());

            Settings.Load(appData);
        }

        public bool OAuthHook(string[] args)
        {

            //string[] args1 = { @"stockwatcher://callback.questrade/?code=cWHowIcA_IEphU8JGr1fQ-PvIXxqm7Ho0&state=p%3d5e3734f6-050e-485d-afd3-27e314f39b0c" };
            return OAuth.OAuthHook(Plugins.Get<IOAuthPlugin>(), args, Settings.Get<OAuthSettings>().OAuthPipesTimeout).Result;
        }
    }
}
