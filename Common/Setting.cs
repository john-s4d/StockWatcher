using System;
using System.Reflection;

namespace StockWatcher.Common
{
    public class Setting
    {
        public delegate void ActionHandler();

        public Action Action { get; internal set; }

        public string Name => Property.Name;
        public string Label { get; internal set; }

        internal PropertyInfo Property { get;}
        internal SettingsContainer Settings { get; }        

        public IConvertible Value
        {
            get { return Settings[Name].Value; }
            set { Settings[Name].Value = Value; }
        }

        public Setting(SettingsContainer settings, PropertyInfo property)
        {
            Settings = settings;
            Property = property;            
        }

        public void DoAction()
        {
            Action?.Invoke();
        }
    }
}