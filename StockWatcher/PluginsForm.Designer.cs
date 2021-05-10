
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemoveLibrary = new System.Windows.Forms.Button();
            this.lbPath = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbTitleVer = new System.Windows.Forms.Label();
            this.flPluginClasses = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadLibrary = new System.Windows.Forms.Button();
            this.lbxLibraries = new System.Windows.Forms.ListBox();
            this.fdLoadLibrary = new System.Windows.Forms.OpenFileDialog();
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
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRemoveLibrary);
            this.panel2.Controls.Add(this.lbPath);
            this.panel2.Controls.Add(this.lbDescription);
            this.panel2.Controls.Add(this.lbTitleVer);
            this.panel2.Controls.Add(this.flPluginClasses);
            this.panel2.Controls.Add(this.btnLoadLibrary);
            this.panel2.Controls.Add(this.lbxLibraries);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1467, 809);
            this.panel2.TabIndex = 2;
            // 
            // btnRemoveLibrary
            // 
            this.btnRemoveLibrary.Location = new System.Drawing.Point(1335, 192);
            this.btnRemoveLibrary.Name = "btnRemoveLibrary";
            this.btnRemoveLibrary.Size = new System.Drawing.Size(120, 74);
            this.btnRemoveLibrary.TabIndex = 6;
            this.btnRemoveLibrary.Text = "Remove Library";
            this.btnRemoveLibrary.UseVisualStyleBackColor = true;
            this.btnRemoveLibrary.Visible = false;
            this.btnRemoveLibrary.Click += new System.EventHandler(this.btnRemoveLibrary_Click);
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(456, 222);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(0, 25);
            this.lbPath.TabIndex = 5;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(456, 196);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(0, 25);
            this.lbDescription.TabIndex = 4;
            // 
            // lbTitleVer
            // 
            this.lbTitleVer.AutoSize = true;
            this.lbTitleVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleVer.Location = new System.Drawing.Point(456, 172);
            this.lbTitleVer.Name = "lbTitleVer";
            this.lbTitleVer.Size = new System.Drawing.Size(0, 25);
            this.lbTitleVer.TabIndex = 3;
            // 
            // flPluginClasses
            // 
            this.flPluginClasses.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flPluginClasses.Location = new System.Drawing.Point(456, 272);
            this.flPluginClasses.Name = "flPluginClasses";
            this.flPluginClasses.Size = new System.Drawing.Size(998, 456);
            this.flPluginClasses.TabIndex = 2;
            // 
            // btnLoadLibrary
            // 
            this.btnLoadLibrary.Location = new System.Drawing.Point(60, 58);
            this.btnLoadLibrary.Name = "btnLoadLibrary";
            this.btnLoadLibrary.Size = new System.Drawing.Size(220, 50);
            this.btnLoadLibrary.TabIndex = 1;
            this.btnLoadLibrary.Text = "Load Library";
            this.btnLoadLibrary.UseVisualStyleBackColor = true;
            this.btnLoadLibrary.Click += new System.EventHandler(this.btnLoadLibrary_Click);
            // 
            // lbxLibraries
            // 
            this.lbxLibraries.DisplayMember = "Title";
            this.lbxLibraries.FormattingEnabled = true;
            this.lbxLibraries.ItemHeight = 24;
            this.lbxLibraries.Location = new System.Drawing.Point(60, 172);
            this.lbxLibraries.Name = "lbxLibraries";
            this.lbxLibraries.Size = new System.Drawing.Size(390, 556);
            this.lbxLibraries.TabIndex = 0;
            this.lbxLibraries.ValueMember = "AssemblyPath";
            this.lbxLibraries.SelectedIndexChanged += new System.EventHandler(this.lbLibraries_SelectedIndexChanged);
            // 
            // fdLoadLibrary
            // 
            this.fdLoadLibrary.Filter = "DLL files|*.dll|All files|*.*";
            this.fdLoadLibrary.FileOk += new System.ComponentModel.CancelEventHandler(this.fdLoadLibrary_FileOk);
            // 
            // PluginsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 831);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "PluginsForm";
            this.Text = "Plugins";
            this.Load += new System.EventHandler(this.PluginsForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lbxLibraries;
        private System.Windows.Forms.FlowLayoutPanel flPluginClasses;
        private System.Windows.Forms.Button btnLoadLibrary;
        private System.Windows.Forms.OpenFileDialog fdLoadLibrary;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbTitleVer;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.Button btnRemoveLibrary;
    }
}