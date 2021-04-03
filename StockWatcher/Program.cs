using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using StockWatcher.Core;

namespace StockWatcher.UI
{
    static class Program
    {
        private const string APPLICATION_NAME = "StockWatcher";
        private const string SETTINGS_FILENAME = "settings.json";

        private static Core.Program _core;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Core.Settings settings = Core.Settings.Load(Path.Combine(GetSettingsPath(), SETTINGS_FILENAME));

            _core = new Core.Program(settings);

            // Handling OAuth Callback
            if (_core.OAuthHook(args)) { return; } 

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(_core));
        }

        private static string GetSettingsPath()
        {
            string settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), APPLICATION_NAME);
            return Directory.Exists(settingsPath) ? settingsPath : Directory.CreateDirectory(settingsPath).FullName;
        }
    }
}
