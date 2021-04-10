
namespace StockWatcher.UI
{
    partial class PluginClassControl
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
            this.lbDescription = new System.Windows.Forms.Label();
            this.flPluginInterfaces = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lbNameVer
            // 
            this.lbNameVer.AutoSize = true;
            this.lbNameVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameVer.Location = new System.Drawing.Point(2, 0);
            this.lbNameVer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNameVer.Name = "lbNameVer";
            this.lbNameVer.Size = new System.Drawing.Size(87, 17);
            this.lbNameVer.TabIndex = 0;
            this.lbNameVer.Text = "lbNameVer";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(2, 18);
            this.lbDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(90, 17);
            this.lbDescription.TabIndex = 3;
            this.lbDescription.Text = "lbDescription";
            // 
            // flPluginInterfaces
            // 
            this.flPluginInterfaces.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flPluginInterfaces.Location = new System.Drawing.Point(5, 39);
            this.flPluginInterfaces.Name = "flPluginInterfaces";
            this.flPluginInterfaces.Size = new System.Drawing.Size(484, 102);
            this.flPluginInterfaces.TabIndex = 4;
            // 
            // PluginClassControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flPluginInterfaces);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbNameVer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PluginClassControl";
            this.Size = new System.Drawing.Size(492, 144);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNameVer;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.FlowLayoutPanel flPluginInterfaces;
    }
}
