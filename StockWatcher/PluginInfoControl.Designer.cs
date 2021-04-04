
namespace StockWatcher.UI
{
    partial class PluginInfoControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbNameVer = new System.Windows.Forms.Label();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNameVer
            // 
            this.lbNameVer.AutoSize = true;
            this.lbNameVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameVer.Location = new System.Drawing.Point(31, 0);
            this.lbNameVer.Name = "lbNameVer";
            this.lbNameVer.Size = new System.Drawing.Size(119, 25);
            this.lbNameVer.TabIndex = 0;
            this.lbNameVer.Text = "lbNameVer";
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(3, 3);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(22, 21);
            this.cbEnabled.TabIndex = 2;
            this.cbEnabled.UseVisualStyleBackColor = true;
            this.cbEnabled.CheckedChanged += new System.EventHandler(this.cbEnabled_CheckedChanged);
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(3, 27);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(124, 25);
            this.lbDescription.TabIndex = 3;
            this.lbDescription.Text = "lbDescription";
            // 
            // PluginInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.cbEnabled);
            this.Controls.Add(this.lbNameVer);
            this.Name = "PluginInfoControl";
            this.Size = new System.Drawing.Size(501, 72);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNameVer;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.Label lbDescription;
    }
}
