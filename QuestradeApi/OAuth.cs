using StockWatcher.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.QuestradeApi
{
    public class OAuth : IOAuth
    {
        public OAuth() { }

        public string ClientId => @"jMIAshGEshehvrHCzd7l58HCsPQFYQ";
        public string AuthorizationEndpoint => @"https://login.questrade.com/oauth2/authorize";
        public string TokenEndpoint => @"https://login.questrade.com/oauth2/token";

        public string Name { get; } = "Questrade Oauth";

        public Version Version { get; } = new Version(0, 1, 0);

        public string Description { get; } = "An implementation of Questrade OAuth";

        public bool Enabled { get; set; }

        string IOAuth.CallbackHostId => @"questrade";

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
