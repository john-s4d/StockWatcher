using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockWatcher.Common;
using StockWatcher.Core;

namespace StockWatcher.UI
{
    public partial class PluginsForm : Form
    {
        Plugins _plugins;

        public PluginsForm()
        {
            InitializeComponent();
        }

        public PluginsForm(Plugins plugins)
            : this()
        {
            _plugins = plugins;
            foreach(PluginLibrary library in _plugins.GetLibraries())
            {
                lbxLibraries.Items.Add(library);
            }
        }

        private void btnLoadLibrary_Click(object sender, EventArgs e)
        {
            fdLoadLibrary.ShowDialog(this);
        }

        private void fdLoadLibrary_FileOk(object sender, CancelEventArgs e)
        {
            PluginLibrary library = new PluginLibrary(fdLoadLibrary.FileName);
            lbxLibraries.Items.Add(library);            
            lbxLibraries.SelectedItem = library;

            lbTitleVer.Text = $"{library.Title} - {library.Version}";
            lbDescription.Text = library.Description;
            lbPath.Text = library.AssemblyPath;

            _plugins.Load(library);
        }

        private void lbLibraries_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (PluginInfoAttribute plugin in ((PluginLibrary)lbxLibraries.SelectedItem).Plugins)
            {
                PluginInfoControl control = new PluginInfoControl(plugin, _plugins.IsEnabled(plugin));
                control.PluginEnabledStateChanged += pluginEnabledChanged;
                flPlugins.Controls.Add(control);
            }
        }

        private void pluginEnabledChanged(PluginInfoAttribute plugin, bool enabled)
        {
            _plugins.SetEnabled(plugin, enabled);
        }

        private void btnRemoveLibrary_Click(object sender, EventArgs e)
        {
            PluginLibrary library = (PluginLibrary)lbxLibraries.SelectedItem;
            _plugins.Remove(library);
            lbxLibraries.Items.Remove(lbxLibraries.SelectedItem);
        }
    }
}
