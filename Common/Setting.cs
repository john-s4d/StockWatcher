using System;

namespace StockWatcher.Common
{
    public class Setting
    {

        public delegate void ActionHandler();

        public string Label { get; }
        public string Description { get; }
        public IConvertible Value { get; set; }

        private ActionHandler _onAction;

        public bool HasAction { get { return _onAction != null; } }

        public Setting(string label)
        {
            Label = label;
        }

        public Setting(string label, string description)
            : this(label)
        {   
            Description = description;
        }

        public void SetAction(ActionHandler actionHandler)
        {
            _onAction = actionHandler;
        }

        /*
        public Setting(string label, string description, ActionHandler actionHandler)
            : this(label, description)
        {   
            _onAction = actionHandler;
        }
        
        public Setting(string label, string description, IConvertible value)
            : this(label,description)
        {
            Value = value;
        }*/



        public void DoAction()
        {
            _onAction?.Invoke();
        }
    }

    public enum SettingType
    {
        OAuthClientId
    }
}