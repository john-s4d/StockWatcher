using System;

namespace StockWatcher.Common
{
    public class Setting
    {
        public string Label { get; }
        public string Description { get; }
        public IConvertible Value { get; set; }  
        
        //public TypeCode ValueTypeCode { get; }   
        // TODO: Templated value setting, action on set, etc..
        
        public Setting(string label, string description)
        {
            Label = label;
            Description = description;
        }

        public Setting(string label, string description, IConvertible value)
            : this(label,description)
        {
            Value = value;
        }
    }
}