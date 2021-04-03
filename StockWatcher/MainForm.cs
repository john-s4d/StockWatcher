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

        SettingsForm _settings;
        PluginsForm _plugins;
        

        public MainForm(Core.Program core)
        {
            _core = core;
            InitializeComponent();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settings = _settings == null ? new SettingsForm(_core.Settings) : _settings;
            _settings.Show(this);
        }

        private void pluginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _plugins = _plugins == null ? new PluginsForm(_core.Plugins) : _plugins;
            _plugins.Show(this);
        }
    }
}