using StockWatcher.Common;
using StockWatcher.Common.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockWatcher.QuestradeApi
{
    [PluginAttribute("Questrade API", "0.1.0.0", "Implementation of Questrade Brokerage and MarketData")]
    public class QuestradePlugin : IMarketDataSource, IBrokerage, IOAuth, ISettings
    {
        // *** IPlugin *** //
        public IPluginHost<IPlugin> Host { get; internal set; }

        public string Name { get; } = "Questrade";
        public bool Activated { get; internal set; }


        // *** ISettings *** //
        //public Settings Settings => _settings;        
        
        // *** IOAuth *** //
        public string CallbackHostId { get; } = @"questrade";
        public string AuthorizationEndpoint { get; } = @"https://login.questrade.com/oauth2/authorize";
        public string TokenEndpoint { get; } = @"https://login.questrade.com/oauth2/token";
        public string ClientId => _settings.OAuthClientId;

        public Settings Settings => _settings;


        // *** Instance *** //
        private QuestradePluginSettings _settings = new QuestradePluginSettings();

        public QuestradePlugin()
        {
            _settings.SetAction(nameof(_settings.OAuthClientId), DoGetRefreshToken);
        }

        private void DoGetRefreshToken()
        {
            _settings.SetValue(nameof(_settings.OAuthRefreshToken), (Host as IOAuthHost)?.GetRefreshToken(this, new CancellationToken()));            

            //_settings.SetValue(nameof(_settings.OAuthRefreshToken), (Host as IOAuthHost)?.GetRefreshToken(this, new CancellationToken()));

        }

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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Activate(IPluginHost<IPlugin> pluginHost)
        {
            if (Activated) { throw new InvalidOperationException("Plugin is already activated"); }
            if (pluginHost == null) { throw new ArgumentNullException(nameof(pluginHost)); }

            Host = pluginHost;

            Activated = true;            
        }
    }
}
