using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StockWatcher.Common;
using StockWatcher.Core;

namespace StockWatcher.UI
{
    public partial class SettingsForm : Form
    {
        private SettingsManager _settings;

        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(SettingsManager settings)
            : this()
        {
            _settings = settings;

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            foreach(SettingsDictionary settings in _settings.Components)
            {
                lbCategories.Items.Add(settings);
            }
            lbCategories.SelectedItem = _settings.Components[0];
        }

        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpSettings.Controls.Clear();

            SettingsDictionary selectedSettings = (SettingsDictionary)lbCategories.SelectedItem;

            foreach (Setting setting in selectedSettings.Settings)
            {
                SettingControl settingControl = new SettingControl(setting);
                settingControl.Leave += SettingControl_Leave;
                flpSettings.Controls.Add(settingControl);
            }
        }

        private void SettingControl_Leave(object sender, EventArgs e)
        {
            _settings.Save();
        }
    }
}
