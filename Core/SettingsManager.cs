using System;
using System.Collections.Generic;
using System.Reflection;
using StockWatcher.Common;

namespace StockWatcher.Core
{
    public class SettingsManager
    {
        private AppDataManager _appData;

        public IReadOnlyCollection<Settings> Components => _components.Values;

        private Dictionary<string, Settings> _components;
        
        internal Settings this[string name]
        {
            get { return Get(name); }
            set { Add(value); }
        }

        internal SettingsManager(AppDataManager appData)
        {
            _appData = appData;

            _components = _appData.Read<Dictionary<string, Settings>>("settings");
        }

        internal void Add<T>(T settings) where T : Settings
        {
            _components.Add(settings.Name, settings);
        }

        internal T Get<T>() where T : Settings            
        {
            T result = null;

            foreach(Settings settings in _components.Values)
            {
                if (settings.GetType().Equals(typeof(T)))
                {
                    if (result != null)
                    {
                        throw new Exception("Duplicate type found");
                    }
                    result = (T)settings;
                }
            }
            return result;
        }

        internal Settings Get(string componentName)
        {
            throw new NotImplementedException();
        }

        private void Save()
        {
            _appData.Write("settings", _components);
        }

       
    }
}
