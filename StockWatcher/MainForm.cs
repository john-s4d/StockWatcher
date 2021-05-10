using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockWatcher.Core;

namespace StockWatcher.UI
{
    public partial class MainForm : Form
    {
        Core.Program _core;

        public MainForm(Core.Program core)
        {
            _core = core;
            InitializeComponent();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm(_core.Settings).Show(this);
        }

        private void pluginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PluginsForm(_core.Plugins).Show(this);
        }
    }
}