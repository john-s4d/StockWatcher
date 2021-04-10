using StockWatcher.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.QuestradeApi
{
    [Plugin("Questrade OAuth", "0.1.0.0", "Implementation of Questrade OAuth")]
    public class OAuth : IOAuth
    {
        private bool disposedValue;

        public OAuth() { }

        public string ClientId => @"jMIAshGEshehvrHCzd7l58HCsPQFYQ";
        public string AuthorizationEndpoint => @"https://login.questrade.com/oauth2/authorize";
        public string TokenEndpoint => @"https://login.questrade.com/oauth2/token";
        string IOAuth.CallbackHostId => @"questrade";

        public void Initialize()
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
        // ~OAuth()
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
