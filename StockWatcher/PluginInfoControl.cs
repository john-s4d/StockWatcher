using StockWatcher.Core;
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
        private PluginInfo _plugin;
        public PluginInfoControl()
        {
            InitializeComponent();
        }

        public PluginInfoControl(PluginInfo plugin)
            : this()
        {
            _plugin = plugin;
            cbEnabled.Checked = plugin.Enabled;
            lbNameVer.Text = $"{plugin.Name} - {plugin.Version}";
            lbDescription.Text = plugin.Description;
        }

        private void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _plugin.Enabled = cbEnabled.Checked;
        }
    }
}
