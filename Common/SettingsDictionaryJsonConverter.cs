using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace StockWatcher.Common
{
    public class SettingsDictionaryJsonConverter : JsonConverter
    {
        private Dictionary<string, Type> _typeMap;
        public SettingsDictionaryJsonConverter(Dictionary<string,Type> typeMap)
        {
            _typeMap = typeMap;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(SettingsDictionary)) return true;
            if (objectType == typeof(IConvertible)) return true;
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(SettingsDictionary))
            {
                SettingsDictionary target;
                if (_typeMap.ContainsKey(reader.Path))
                {   
                    target = (SettingsDictionary)Activator.CreateInstance(_typeMap[reader.Path]);
                } 
                else
                {
                    target = new SettingsDictionary();
                }                
                serializer.Populate(reader, target);
                return target;
            }
            if (objectType == typeof(IConvertible))
            {   
                return (IConvertible)reader.Value;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
