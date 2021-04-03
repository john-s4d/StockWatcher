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

        public PluginsForm(Core.Plugins plugins)
            : this()
        {
            _plugins = plugins;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            PluginLibrary library = new PluginLibrary(fdLoadLibrary.FileName);
            lbLibraries.Items.Add(library);            
            lbLibraries.SelectedItem = library;

            lbTitleVer.Text = $"{library.Title} - {library.Version}";
            lbDescription.Text = library.Description;
            lbPath.Text = library.AssemblyPath;

            statusStrip1.Text = "Loaded Library";
            
        }

        private void btnLoadLibrary_Click(object sender, EventArgs e)
        {
            fdLoadLibrary.ShowDialog(this);
        }

        private void lbLibraries_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (IPlugin plugin in ((PluginLibrary)lbLibraries.SelectedItem).Plugins)
            {                
                flPlugins.Controls.Add(new PluginInfoControl(plugin));
            }
        }
    }
}
