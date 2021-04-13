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
    public partial class PluginInterfaceControl : UserControl
    {
        public event Action<PluginInterface, bool> OnPluginInterfaceEnabledChanged;

        private PluginInterface _pluginInterface;

        public PluginInterfaceControl()
        {
            InitializeComponent();
        }

        public PluginInterfaceControl(PluginInterface pluginInterface)
            : this()
        {
            _pluginInterface = pluginInterface;
            cbEnabled.Checked = pluginInterface.Enabled;
            cbEnabled.Text = pluginInterface.ShortName;
        }

        private void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _pluginInterface.Enabled = cbEnabled.Checked;
            OnPluginInterfaceEnabledChanged?.Invoke(_pluginInterface, cbEnabled.Checked);
        }
    }
}
