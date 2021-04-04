using StockWatcher.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.QuestradeApi
{
    [PluginInfo(PluginType.OAuth, "Questrade OAuth", "0.1.0.0", "Implementation of Questrade OAuth")]
    public class OAuth : IOAuth
    {
        public OAuth() { }

        public string ClientId => @"jMIAshGEshehvrHCzd7l58HCsPQFYQ";
        public string AuthorizationEndpoint => @"https://login.questrade.com/oauth2/authorize";
        public string TokenEndpoint => @"https://login.questrade.com/oauth2/token";
        string IOAuth.CallbackHostId => @"questrade";

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
