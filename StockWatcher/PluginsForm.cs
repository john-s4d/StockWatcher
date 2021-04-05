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

            foreach(PluginLibrary library in _plugins.Libraries)
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

            _plugins.Add(library);
        }

        private void lbLibraries_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (PluginInfo plugin in ((PluginLibrary)lbxLibraries.SelectedItem).Plugins)
            {
                PluginInfoControl control = new PluginInfoControl(plugin);                
                flPlugins.Controls.Add(control);
            }
        }

        private void btnRemoveLibrary_Click(object sender, EventArgs e)
        {
            PluginLibrary library = (PluginLibrary)lbxLibraries.SelectedItem;
            lbxLibraries.Items.Remove(lbxLibraries.SelectedItem);
            
            _plugins.Remove(library);            
        }
    }
}
