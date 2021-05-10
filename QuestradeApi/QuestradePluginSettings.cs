using StockWatcher.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.QuestradeApi
{
    public class QuestradePluginSettings : Settings
    {
        public override string Name { get; } = nameof(QuestradePluginSettings);
        public override string Label { get; } = "QuestradePluginSettings";

        public string OAuthClientId { get; internal set; }

    }
}
