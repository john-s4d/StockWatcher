using Newtonsoft.Json;
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

            // SetEncrypted(nameof(OAuthRefreshToken)); // TODO: Implement Encryption
        }

        public string OAuthClientId { get; internal set; }        

        //[SettingEncrypted, SettingHidden]
        public string OAuthRefreshToken { get; internal set; }

        internal new void SetAction(string key, Action action)
        {
            base.SetAction(key, action);
        }
    }
}
