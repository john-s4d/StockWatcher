using StockWatcher.Common;
using System;

namespace StockWatcher.QuestradeApi
{
    public class QuestradePluginSettings : SettingsDictionary
    {
        public override string Name { get; } = nameof(QuestradePluginSettings);
        public override string Label { get; } = "Questrade Plugin";

        public string OAuthRefreshToken { get; set; }

        public string OAuthClientId { get; set; } = @"jMIAshGEshehvrHCzd7l58HCsPQFYQ";

        public QuestradePluginSettings()
        {
            SetLabel(nameof(OAuthClientId), "OAuth Client Id");
        }

        internal new void SetAction(string key, Action action)
        {
            base.SetAction(key, action);
        }
    }
}
