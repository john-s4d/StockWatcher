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
        internal Settings Settings { get; }        

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