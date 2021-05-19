using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using StockWatcher.Common;

namespace StockWatcher.Core
{
    public class AppDataManager
    {
        // TODO: Implement read/write sync locks to prevent contention or race conditions

        private const string SUFFIX = "json";        

        private JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
        {
            //TypeNameHandling = TypeNameHandling.Auto,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        };

        private string _path;

        public AppDataManager(string path)
        {
            _path = path;
        }

        internal T Read<T>(string label)
            where T : new()
        {
            string file = GetFilePath(label);

            return File.Exists(file) ? (T)JsonConvert.DeserializeObject(File.ReadAllText(file), typeof(T), _serializerSettings) : new T();
        }

        internal T Read<T>(string label, JsonConverter converter)
            where T : new()
        {
            string file = GetFilePath(label);

            return File.Exists(file) ? (T)JsonConvert.DeserializeObject(File.ReadAllText(file), typeof(T), converter) : new T();

        }

        public void Write<T>(string label, T data)
            where T : new()
        {
            File.WriteAllText(GetFilePath(label), JsonConvert.SerializeObject(data, _serializerSettings));
        }

        

        private string GetFilePath(string label)
        {
            return Path.Combine(_path, $"{label}.{SUFFIX}").ToLower();
        }
    }
}