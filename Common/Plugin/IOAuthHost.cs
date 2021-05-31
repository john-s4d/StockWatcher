using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockWatcher.Common
{
    public interface IOAuthHost : IPluginHost<IOAuthPlugin>
    {
        Task<string> GetRefreshToken(IOAuthPlugin oAuth, CancellationToken cancelationToken);

    }
}
