using System;
using System.ComponentModel;
using System.Reflection;

namespace StockWatcher.Common
{
    public class Setting : INotifyPropertyChanged
    {
        public string Name { get; internal set; } 
        public string Label { get; internal set; }             
        public Action OnAction { get; internal set; }

        private IConvertible _value;
        public IConvertible Value {
            get => _value;
            set
            {   
                if (_value != value)
                {
                    _value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void DoAction()
        {
            OnAction?.Invoke();
        }
    }
}