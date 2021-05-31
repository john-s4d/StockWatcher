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
    public class QuestradePlugin : IMarketDataSourcePlugin, IBrokeragePlugin, IOAuthPlugin, ISettingsPlugin, ILoggerPlugin
    {
        // *** IPlugin *** //
        public IPluginHost<IPlugin> Host { get; internal set; }

        public string Name { get; } = "Questrade";
        public bool Activated { get; internal set; }


        // *** IOAuth *** //
        public string CallbackHostId { get; } = @"questrade";
        public string AuthorizationEndpoint { get; } = @"https://login.questrade.com/oauth2/authorize";
        public string TokenEndpoint { get; } = @"https://login.questrade.com/oauth2/token";
        public string ClientId => _settings.OAuthClientId;

        // *** ISettings *** //        
        public SettingsDictionary Settings => _settings;

        
        // *** Instance *** //
        private QuestradePluginSettings _settings;
        private ILoggerHost _logger;

        public QuestradePlugin()
        {
            _settings = new QuestradePluginSettings();
            _settings.SetAction(nameof(_settings.OAuthClientId), DoGetRefreshToken);

            _logger = (Host as ILoggerHost);

        }

        private void DoGetRefreshToken()
        {   
            _settings[nameof(_settings.OAuthRefreshToken)] = (Host as IOAuthHost)?.GetRefreshToken(this, new CancellationToken()).Result;
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
