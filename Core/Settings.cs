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
        public List<string> PluginDirectories { get; set; }
        public int OAuthPipesTimeout { get; set; } = 10000;

        public void Save(string settingsFile)
        {
            string content = JsonConvert.SerializeObject(this);
            File.WriteAllText(settingsFile, content);
        }

        public static Settings Load(string settingsFile)
        {
            if (File.Exists(settingsFile))
            {   
                return (Settings)JsonConvert.DeserializeObject(File.ReadAllText(settingsFile), typeof(Settings));
            }
            // TODO: Log settings file was not found, loading default
            return new Settings();
        }
    }
}
