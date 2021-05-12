using System;

namespace StockWatcher.Common
{
    public class SettingDefinition
    {

        public delegate void ActionHandler();

        public string Label { get; }
        public string Description { get; }        

        public Action Action { get; internal set; }

        public SettingDefinition(string label)
        {
            Label = label;
        }

        public SettingDefinition(string label, string description)
            : this(label)
        {   
            Description = description;
        }

        public void DoAction()
        {
            Action?.Invoke();
        }
    }
}