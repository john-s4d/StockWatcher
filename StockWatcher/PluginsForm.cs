using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            foreach (PluginLibrary library in _plugins.Libraries)
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
            PluginLibrary library = new PluginLibrary(fdLoadLibrary.FileName, true);
            lbxLibraries.Items.Add(library);
            lbxLibraries.SelectedItem = library;

            _plugins.AddLibrary(library);
            _plugins.Save();
        }

        private void lbLibraries_SelectedIndexChanged(object sender, EventArgs e)
        {   
            flPluginClasses.Controls.Clear();

            if (lbxLibraries.SelectedItem == null)
            {
                lbTitleVer.Text = lbDescription.Text = lbPath.Text = string.Empty;
                btnRemoveLibrary.Visible = false;
                return;
            }

            btnRemoveLibrary.Visible = true;

            PluginLibrary library = (PluginLibrary)lbxLibraries.SelectedItem;

            lbTitleVer.Text = $"{library.Title} - {library.Version}";
            lbDescription.Text = library.Description;
            lbPath.Text = library.AssemblyPath;            

            foreach (PluginClass pluginClass in (library.Classes))
            {
                PluginClassControl control = new PluginClassControl(pluginClass);
                control.OnPluginInterfaceEnabledChanged += Control_OnPluginInterfaceEnabledChanged;
                flPluginClasses.Controls.Add(control);
            }
        }

        private void Control_OnPluginInterfaceEnabledChanged(PluginInterface pluginInterface, bool enabled)
        {
            _plugins.Save();
        }

        private void btnRemoveLibrary_Click(object sender, EventArgs e)
        {
            PluginLibrary library = (PluginLibrary)lbxLibraries.SelectedItem;
            lbxLibraries.Items.Remove(lbxLibraries.SelectedItem);
            _plugins.Remove(library);
            _plugins.Save();
        }
    }
}
