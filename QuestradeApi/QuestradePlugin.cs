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

        public Settings Settings { get; } = new Settings(nameof(QuestradePlugin), "Questrade");

        public string CallbackHostId { get; } = @"questrade";
        public string AuthorizationEndpoint { get; } = @"https://login.questrade.com/oauth2/authorize";
        public string TokenEndpoint { get; } = @"https://login.questrade.com/oauth2/token";
        public string ClientId => Settings["OAuthClientId"]?.ToString();

        public QuestradePlugin()
        {
            Settings.Add(new Setting("OAuthClientId", "OAuth Client Id"));            
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
    }
}
