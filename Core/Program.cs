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
        public PluginsManager Plugins { get; internal set; }
        public SettingsManager Settings { get; internal set; }

        public Program(AppDataManager appData)
        {
            Plugins = new PluginsManager(appData);
            Settings = new SettingsManager(appData);

            Plugins.Load();

            Settings.Merge(Plugins.Get<ISettingsPlugin>());
            Settings.Merge(new OAuthSettings());
            Settings.Load();
        }

        public bool OAuthHook(string[] args)
        {

            //string[] args1 = { @"stockwatcher://callback.questrade/?code=cWHowIcA_IEphU8JGr1fQ-PvIXxqm7Ho0&state=p%3d5e3734f6-050e-485d-afd3-27e314f39b0c" };
            return OAuth.OAuthHook(Plugins.Get<IOAuthPlugin>(), args, Settings.Get<OAuthSettings>().OAuthPipesTimeout).Result;
        }
    }
}
