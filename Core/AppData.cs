using System.IO;
using Newtonsoft.Json;

namespace StockWatcher.Core
{
    public class AppData
    {
        // TODO: Implement read/write sync locks to prevent contention or race conditions

        private const string SUFFIX = "json";
        private const Formatting FORMATTING = Formatting.Indented;

        private string _path;

        public AppData(string path)
        {
            _path = path;
        }

        internal T Read<T>(string label)
            where T : new()
        {
            string file = GetFilePath(label);
            return File.Exists(file) ? (T)JsonConvert.DeserializeObject(File.ReadAllText(file), typeof(T)) : new T();
        }

        public void Write<T>(string label, T data)
            where T : new()
        {
            File.WriteAllText(GetFilePath(label), JsonConvert.SerializeObject(data, FORMATTING));
        }

        private string GetFilePath(string label)
        {
            return Path.Combine(_path, $"{label}.{SUFFIX}").ToLower();
        }
    }
}