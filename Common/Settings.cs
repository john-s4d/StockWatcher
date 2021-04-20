﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common
{
    public class Settings 
    {

        private Dictionary<string, Setting> _settings = new Dictionary<string, Setting>();

        public string Name { get; }
        public string Label { get; }

        public Settings(string name, string label)
        {
            // TODO: validation on name
            Name = name;
            Label = label;
        }
        
        public IConvertible this[string label]
        {
            get { return Get(label); }
            set { Set(label, value); }
        }

        public IConvertible Get(string label) 
        {
            return _settings[label].Value;
        }

        public void Set(string label, IConvertible value)
        {
            _settings[label].Value = value;
        }

        public void Add(string label, string description, IConvertible value)
        {
            _settings.Add(label, new Setting(label, description, value));
        }

        public void Add(Setting setting)
        {
            _settings.Add(setting.Label, setting);
        }

        public bool Contains(Setting setting)
        {
            return _settings.ContainsKey(setting.Label);
        }
    }
}