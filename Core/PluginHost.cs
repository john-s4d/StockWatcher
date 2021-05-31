using StockWatcher.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StockWatcher.Core
{
    internal class PluginHost :
                    IPluginHost<IPlugin>,
                    IBrokerageHost,
                    IIndicatorHost,
                    ILoggerHost,
                    IMarketDataSourceHost,
                    IOAuthHost,
                    ISettingsHost,
                    IStrategyHost
    {
        public Guid Id { get; } = Guid.NewGuid();
        
        
        
        private Program _core;

        public PluginHost(Program core)
        {   
            _core = core;
        }

        //** IOAuthHost **//
        public async Task<string> GetRefreshToken(IOAuthPlugin oauth, CancellationToken cancellationToken)
        {
            return await OAuth.GetRefreshToken(oauth, cancellationToken);
        }

        //** ILoggerHost **//
        public void Write(string message, LogLevel level = LogLevel.DEBUG)
        {
            throw new NotImplementedException();
        }

        public void Write(Exception e, LogLevel level = LogLevel.DEBUG)
        {
            throw new NotImplementedException();
        }

        public void Trace(LogLevel level = LogLevel.DEBUG)
        {
            throw new NotImplementedException();
        }

        public void Trace(string append, LogLevel level = LogLevel.DEBUG)
        {
            throw new NotImplementedException();
        }

        public void Dump(string message, object obj, LogLevel level = LogLevel.DEBUG)
        {
            throw new NotImplementedException();
        }
    }
}