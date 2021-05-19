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
            
            btnAction.Visible = _setting.OnAction != null;
            //ttDescription.SetToolTip(lblLabel, _setting.Description);
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (_setting.Value == null || _setting.Value.ToString() != txtValue.Text)
            {
                _setting.Value = txtValue.Text;                
            }
        }
    }
}
