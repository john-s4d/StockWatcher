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

        public string OAuthClientId { get; }        

        //[SettingEncrypted]
        internal string OAuthRefreshToken { get; }

        internal new void SetAction(string key, Action action)
        {
            base.SetAction(key, action);
        }
    }
}
