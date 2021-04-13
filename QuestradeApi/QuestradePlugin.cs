using StockWatcher.Common;
using StockWatcher.Common.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.QuestradeApi
{
    [PluginAttribute("Questrade API", "0.1.0.0", "Implementation of Questrade Brokerage and MarketData")]
    public class QuestradePlugin : IMarketDataSource, IBrokerage, IOAuth, ISettings
    {
        private bool disposedValue;

        public string ClientId => throw new NotImplementedException();

        public string CallbackHostId => throw new NotImplementedException();

        public string AuthorizationEndpoint => throw new NotImplementedException();

        public string TokenEndpoint => throw new NotImplementedException();

        public Dictionary<string, IConvertible> Settings => throw new NotImplementedException();

        public IEnumerable<IOption> GetOptions(ISymbol symbol, IEnumerable<IOptionFilter> filters)
        {
            throw new NotImplementedException();
        }

        public DateTime GetTime()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISymbol> Search(string prefix, int offset = 0)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~QuestradePlugin()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
