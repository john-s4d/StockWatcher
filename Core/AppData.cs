using Newtonsoft.Json;
using System.IO;

namespace StockWatcher.Core
{
    public class AppData
    {
        private const string SUFFIX = "json";

        private string _path;

        public AppData(string path)
        {
            _path = path;
        }

        public T Read<T>(string label) where T : new()
        {
            string file = GetFilePath(label);
            return File.Exists(file) ? (T)JsonConvert.DeserializeObject(File.ReadAllText(file), typeof(T)) : new T();
        }

        public void Write<T>(string label, T data)
        {   
            File.WriteAllText(GetFilePath(label), JsonConvert.SerializeObject(data));
        }

        private string GetFilePath(string label)
        {
            return Path.Combine(_path, $"{label}.{SUFFIX}");
        }
    }
}