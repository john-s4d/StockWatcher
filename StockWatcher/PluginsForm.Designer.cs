
namespace StockWatcher.UI
{
    partial class PluginsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flPlugins = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadLibrary = new System.Windows.Forms.Button();
            this.lbLibraries = new System.Windows.Forms.ListBox();
            this.fdLoadLibrary = new System.Windows.Forms.OpenFileDialog();
            this.lbTitleVer = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbPath = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Location = new System.Drawing.Point(0, 809);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1467, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 729);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1467, 80);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1024, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(888, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbPath);
            this.panel2.Controls.Add(this.lbDescription);
            this.panel2.Controls.Add(this.lbTitleVer);
            this.panel2.Controls.Add(this.flPlugins);
            this.panel2.Controls.Add(this.btnLoadLibrary);
            this.panel2.Controls.Add(this.lbLibraries);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1467, 729);
            this.panel2.TabIndex = 2;
            // 
            // flPlugins
            // 
            this.flPlugins.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flPlugins.Location = new System.Drawing.Point(457, 272);
            this.flPlugins.Name = "flPlugins";
            this.flPlugins.Size = new System.Drawing.Size(998, 288);
            this.flPlugins.TabIndex = 2;
            // 
            // btnLoadLibrary
            // 
            this.btnLoadLibrary.Location = new System.Drawing.Point(60, 58);
            this.btnLoadLibrary.Name = "btnLoadLibrary";
            this.btnLoadLibrary.Size = new System.Drawing.Size(220, 49);
            this.btnLoadLibrary.TabIndex = 1;
            this.btnLoadLibrary.Text = "Load Library";
            this.btnLoadLibrary.UseVisualStyleBackColor = true;
            this.btnLoadLibrary.Click += new System.EventHandler(this.btnLoadLibrary_Click);
            // 
            // lbLibraries
            // 
            this.lbLibraries.DisplayMember = "Title";
            this.lbLibraries.FormattingEnabled = true;
            this.lbLibraries.ItemHeight = 24;
            this.lbLibraries.Location = new System.Drawing.Point(60, 172);
            this.lbLibraries.Name = "lbLibraries";
            this.lbLibraries.Size = new System.Drawing.Size(390, 388);
            this.lbLibraries.TabIndex = 0;
            this.lbLibraries.ValueMember = "AssemblyPath";
            this.lbLibraries.SelectedIndexChanged += new System.EventHandler(this.lbLibraries_SelectedIndexChanged);
            // 
            // fdLoadLibrary
            // 
            this.fdLoadLibrary.Filter = "DLL files|*.dll|All files|*.*";
            this.fdLoadLibrary.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // lbTitleVer
            // 
            this.lbTitleVer.AutoSize = true;
            this.lbTitleVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleVer.Location = new System.Drawing.Point(457, 172);
            this.lbTitleVer.Name = "lbTitleVer";
            this.lbTitleVer.Size = new System.Drawing.Size(147, 35);
            this.lbTitleVer.TabIndex = 3;
            this.lbTitleVer.Text = "lbTitleVer";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(456, 197);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(174, 35);
            this.lbDescription.TabIndex = 4;
            this.lbDescription.Text = "lbDescription";
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(456, 222);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(94, 35);
            this.lbPath.TabIndex = 5;
            this.lbPath.Text = "lbPath";
            // 
            // PluginsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 831);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PluginsForm";
            this.Text = "Plugins";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lbLibraries;
        private System.Windows.Forms.FlowLayoutPanel flPlugins;
        private System.Windows.Forms.Button btnLoadLibrary;
        private System.Windows.Forms.OpenFileDialog fdLoadLibrary;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbTitleVer;
        private System.Windows.Forms.Label lbPath;
    }
}