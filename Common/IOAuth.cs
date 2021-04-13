using System;
using System.Collections.Generic;
using System.Text;

namespace StockWatcher.Common
{
    public interface IOAuth : IPlugin
    {
        string ClientId { get; }
        string CallbackHostId { get; }
        string AuthorizationEndpoint { get; }
        string TokenEndpoint { get; }

    }
}
