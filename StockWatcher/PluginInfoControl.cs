using StockWatcher.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockWatcher.UI
{
    public partial class PluginInfoControl : UserControl
    {
        public delegate void PluginEnabledStateChangedEventHandler(PluginInfoAttribute plugin, bool enabled);
        public event PluginEnabledStateChangedEventHandler PluginEnabledStateChanged;

        private PluginInfoAttribute _plugin;
        public PluginInfoControl()
        {
            InitializeComponent();
        }

        public PluginInfoControl(PluginInfoAttribute plugin, bool enabled)
            : this()
        {
            _plugin = plugin;
            cbEnabled.Checked = enabled;
            lbNameVer.Text = $"{plugin.Name} - {plugin.Version}";
            lbDescription.Text = plugin.Description;
        }

        private void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            PluginEnabledStateChanged?.Invoke(_plugin, cbEnabled.Checked);
        }
    }
}
