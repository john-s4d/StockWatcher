using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StockWatcher.Common
{

    public delegate void RefreshTokenCallback(string token);
    public interface IOAuth : IPlugin
    {
        //event Action<IOAuth, CancellationToken, RefreshTokenCallback> GetRefreshToken;

        //IOAuthPluginHost OAuthPluginHost { get; }
        string ClientId { get; }
        string CallbackHostId { get; }
        string AuthorizationEndpoint { get; }
        string TokenEndpoint { get; }       

    }
}
