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
    public partial class SettingsForm : Form
    {
        private Core.Settings _settings;

        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(Core.Settings settings)
            : this()
        {
            _settings = settings;

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
