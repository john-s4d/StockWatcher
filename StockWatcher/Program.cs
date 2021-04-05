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

        private static Core.Program _core;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Core.AppData appData = new Core.AppData(GetAppDataPath());

            _core = new Core.Program(appData);

            // Handling OAuth Callback
            if (_core.OAuthHook(args)) { return; } 

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(_core));
        }

        private static string GetAppDataPath()
        {
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), APPLICATION_NAME);
            return Directory.Exists(appDataPath) ? appDataPath : Directory.CreateDirectory(appDataPath).FullName;
        }
    }
}
