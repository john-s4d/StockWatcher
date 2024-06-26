﻿using System;
using System.Collections.Generic;
using System.Threading;
using StockWatcher.Common;

namespace StockWatcher.Core
{
    public class PluginsManager
    {
        private AppDataManager _appData;        

        //public event Action<IPlugin, bool> OnInstanceEnabledChanged;

        public IReadOnlyCollection<PluginLibrary> Libraries => _libraries.AsReadOnly();

        private List<PluginLibrary> _libraries;

        public PluginsManager() { }

        public void Load(AppDataManager appData, Program core)
        {
            _appData = appData;            

            _libraries = _appData.Read<List<PluginLibrary>>("plugins");

            foreach (PluginLibrary pluginLibrary in _libraries)
            {
                pluginLibrary.Load();
            }

            // Hookup Hosts
            foreach (PluginClass pluginClass in GetPluginClassesHavingEnabledInterfaces())
            {
                //pluginClass.OnInstanceEnabledChanged += PluginClass_OnInstanceEnabledChanged;

                foreach (PluginInterface pluginInterface in pluginClass.Interfaces)
                {
                    if (pluginInterface.Enabled && !pluginClass.Instance.Activated)
                    {   
                        pluginClass.Instance.Activate(new PluginHost(core));
                    }
                }
            }
        }

        /*
        private void PluginClass_OnInstanceEnabledChanged(PluginClass plugin, bool enabled)
        {
            if (typeof(ISettingsPlugin).IsAssignableFrom(plugin.GetType()))
            {
                _core.Settings.Merge(plugin as ISettingsPlugin);
            }
        }*/

        internal List<T> Get<T>(string name = null)
            where T : class, IPlugin
        {
            List<T> result = new List<T>();

            foreach (PluginClass pluginClass in GetPluginClassesHavingEnabledInterfaces())
            {
                foreach (PluginInterface pluginInterface in pluginClass.Interfaces)
                {
                    if (pluginInterface.Enabled && pluginInterface.Type.Equals(typeof(T)))
                    {
                        if (name == null || pluginClass.Name.Equals(name))
                        {
                            result.Add((T)pluginClass.Instance);
                        }
                        if (name != null)
                        {
                            return result;
                        }
                        break;
                    }
                }
            }
            return result;
        }

        private IEnumerable<PluginClass> GetPluginClassesHavingEnabledInterfaces()
        {
            List<PluginClass> result = new List<PluginClass>();

            foreach (PluginLibrary pluginLibrary in _libraries)
            {
                foreach (PluginClass pluginClass in pluginLibrary.Classes)
                {
                    if (pluginClass.Instance != null && typeof(IPlugin).IsAssignableFrom(pluginClass.Instance.GetType()) && !result.Contains(pluginClass))
                    {
                        foreach (PluginInterface pluginInterface in pluginClass.Interfaces)
                        {
                            if (pluginInterface.Enabled)
                            {
                                result.Add(pluginClass);
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void Save()
        {
            _appData.Write("plugins", _libraries);
        }

        public void AddLibrary(PluginLibrary library)
        {
            _libraries.Add(library);
        }

        public void Remove(PluginLibrary library)
        {
            _libraries.Remove(library);
        }
    }
}
