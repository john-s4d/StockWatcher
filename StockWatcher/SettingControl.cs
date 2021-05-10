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

namespace StockWatcher.UI
{
    public partial class SettingControl : UserControl
    {
        private Setting _setting;
        public SettingControl()
        {
            InitializeComponent();
        }

        public SettingControl(Setting setting)
            : this()
        {
            _setting = setting;            
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            _setting.DoAction();
        }

        private void SettingControl_Load(object sender, EventArgs e)
        {
            lblLabel.Text = _setting.Label;
            txtValue.Text = _setting.Value?.ToString();            
            ttDescription.SetToolTip(lblLabel, _setting.Description);
            btnAction.Visible = _setting.HasAction;
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            _setting.Value = txtValue.Text;
        }
    }
}
