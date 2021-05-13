using System;

namespace StockWatcher.Common
{
    public class SettingAttribute : Attribute
    {
        public bool Secret { get; set; }
        public bool ReadOnly { get; set; }
    }
}