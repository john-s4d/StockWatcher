using System;

namespace StockWatcher.Common
{   
    public interface IPlugin : IDisposable
    {
        IPluginHost<IPlugin> Host { get; }
        string Name { get; }        
        bool Activated { get; }

        void Activate(IPluginHost<IPlugin> pluginHost);
    }
}
