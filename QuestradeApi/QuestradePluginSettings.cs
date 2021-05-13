using StockWatcher.Common;

namespace StockWatcher.QuestradeApi
{
    public class QuestradePluginSettings : Settings
    {
        public override string Name { get; } = nameof(QuestradePluginSettings);
        public override string Label { get; } = "Questrade Plugin";

        public string OAuthRefreshToken { get; set; }

        public string OAuthClientId { get; set; } = @"jMIAshGEshehvrHCzd7l58HCsPQFYQ";

        public QuestradePluginSettings()
        {
            Define(nameof(OAuthRefreshToken));
            Define(nameof(OAuthClientId), "OAuth Client Id");
        }
    }
}
