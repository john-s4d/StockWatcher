using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StockWatcher.Common
{
    public interface IOAuthHost : IPluginHost<IOAuthPlugin>
    {
        string GetRefreshToken(IOAuthPlugin oAuth, CancellationToken cancelationToken);

    }
}
