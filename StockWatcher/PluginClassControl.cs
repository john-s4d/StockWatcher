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
    public partial class PluginClassControl : UserControl
    {
        public event Action<PluginInterface, bool> OnPluginInterfaceEnabledChanged;

        private PluginClass _pluginClass;
        public PluginClassControl()
        {
            InitializeComponent();
        }

        public PluginClassControl(PluginClass pluginClass)
            : this()
        {
            _pluginClass = pluginClass;

            lbNameVer.Text = $"{pluginClass.Name} - {pluginClass.Version}";
            lbDescription.Text = pluginClass.Description;

            foreach(PluginInterface pluginInterface in pluginClass.Interfaces)
            {
                PluginInterfaceControl control = new PluginInterfaceControl(pluginInterface);
                control.OnPluginInterfaceEnabledChanged += Control_OnPluginInterfaceEnabledChanged;
                flPluginInterfaces.Controls.Add(control);
            }
        }

        private void Control_OnPluginInterfaceEnabledChanged(PluginInterface pluginInterface, bool enabled)
        {
            OnPluginInterfaceEnabledChanged?.Invoke(pluginInterface, enabled);
        }
    }
}
