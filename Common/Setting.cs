using System;
using System.Reflection;

namespace StockWatcher.Common
{
    public class Setting
    {
        public delegate void ActionHandler();

        public Action Action { get; internal set; }        
        public string Label { get; internal set; }

        public PropertyInfo Property { get;}
        public Settings Settings { get; }        
        //public bool IsSecret { get;  }

        public IConvertible Value
        {
            get { return Settings.GetValue(Property); }
            set { Settings.SetValue(Property, Value); }
        }

        public Setting(Settings settings, PropertyInfo property)
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