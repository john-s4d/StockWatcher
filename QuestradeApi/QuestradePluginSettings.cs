using StockWatcher.Common;
using System;

namespace StockWatcher.QuestradeApi
{
    public class QuestradePluginSettings : SettingsDictionary
    {
        public QuestradePluginSettings()
            : base(nameof(QuestradePluginSettings), "Questrade")
        {
            SetLabel(nameof(OAuthClientId), "OAuth Client Id");
        }

        public string OAuthRefreshToken { get; set; }
        public string OAuthClientId { get; set; } = @"jMIAshGEshehvrHCzd7l58HCsPQFYQ";        

        internal new void SetAction(string key, Action action)
        {
            base.SetAction(key, action);
        }
    }
}
