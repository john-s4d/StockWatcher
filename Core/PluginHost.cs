using StockWatcher.Common;
using System;
using System.Threading;

namespace StockWatcher.Core
{
    internal class PluginHost : 
        IPluginHost<IPlugin>, 
        IBrokerageHost, IIndicatorHost, ILoggerHost, IMarketDataSourceHost, IOAuthHost, ISettingsHost, IStrategyHost
        
        
    {
        public PluginHost(IPlugin instance)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public Logger Logger => throw new System.NotImplementedException();
        public SettingsContainer Settings ;

        

        public string GetRefreshToken(IOAuthPlugin oauth, CancellationToken cancellationToken)
        {   
           return OAuth.GetRefreshToken(oauth, cancellationToken).Result;
        }
    }
}