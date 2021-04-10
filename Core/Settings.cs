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

        internal T Get<T>(string component, string label)
             where T : new()
        {
            IDictionary<string, T> data = _appdata.Read<T>(component);
            return data != null && data.ContainsKey(label) ? data[label] : new T();
        }

        internal void Set<T>(string component, string label, T value)
            where T: new()
        {
            IDictionary<string, T> data = _appdata.Read<T>(component);
            data = data == null ? new Dictionary<string, T>() : data;
            data[label] = value;
            _appdata.Write<T>(component, data);
        }
    }
}
