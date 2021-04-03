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
        public Settings Settings { get; internal set; }
        public Plugins Plugins { get; internal set; }

        public Program(Settings settings)
        {
            Settings = settings;

            Plugins = new Plugins();
            // TODO: Load Plugins
        }

        public bool OAuthHook(string[] args)
        {
            return OAuth.OAuthHook(Plugins.OAuth.Values, args, Settings.OAuthPipesTimeout).Result;
        }
    }
}
