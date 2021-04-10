using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace StockWatcher.Core
{
    public class AppData
    {
        private const string SUFFIX = "json";
        private const Formatting FORMATTING = Formatting.Indented;

        private string _path;

        public AppData(string path)
        {
            _path = path;            
        }

        public Dictionary<string,T> Read<T>(string label)
        {
            string file = GetFilePath(label);
            return File.Exists(file) ? (Dictionary<string, T>)JsonConvert.DeserializeObject(File.ReadAllText(file), typeof(IDictionary<string,T>)) : new Dictionary<string,T>();
        }

        public void Write<T>(string label, IDictionary<string,T> data)
        {   
            // TODO: Async with read lock
            File.WriteAllText(GetFilePath(label), JsonConvert.SerializeObject(data, FORMATTING));
        }

        private string GetFilePath(string label)
        {
            return Path.Combine(_path, $"{label}.{SUFFIX}").ToLower();
        }
    }
}