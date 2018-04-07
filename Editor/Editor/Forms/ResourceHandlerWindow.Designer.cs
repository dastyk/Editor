namespace Editor
{
    partial class ResourceHandlerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceHandlerWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewPassthrough = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.handledTypes = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.typeName = new System.Windows.Forms.TextBox();
            this.cbPassThrough = new System.Windows.Forms.CheckBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator6,
            this.toolStripSeparator7,
            this.addNewPassthrough,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(346, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New Type";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // addNewPassthrough
            // 
            this.addNewPassthrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addNewPassthrough.Image = ((System.Drawing.Image)(resources.GetObject("addNewPassthrough.Image")));
            this.addNewPassthrough.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNewPassthrough.Name = "addNewPassthrough";
            this.addNewPassthrough.Size = new System.Drawing.Size(23, 22);
            this.addNewPassthrough.Text = "Add Passthrough";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // handledTypes
            // 
            this.handledTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.handledTypes.FormattingEnabled = true;
            this.handledTypes.Location = new System.Drawing.Point(0, 0);
            this.handledTypes.Name = "handledTypes";
            this.handledTypes.Size = new System.Drawing.Size(160, 374);
            this.handledTypes.TabIndex = 1;
            this.handledTypes.SelectedIndexChanged += new System.EventHandler(this.handledTypes_SelectedIndexChanged);
            this.handledTypes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.handledTypes_MouseDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::Editor.Properties.Settings.Default, "RHWSplit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.handledTypes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.typeName);
            this.splitContainer1.Panel2.Controls.Add(this.cbPassThrough);
            this.splitContainer1.Panel2.Controls.Add(this.browseBtn);
            this.splitContainer1.Size = new System.Drawing.Size(346, 376);
            this.splitContainer1.SplitterDistance = global::Editor.Properties.Settings.Default.RHWSplit;
            this.splitContainer1.TabIndex = 2;
            // 
            // typeName
            // 
            this.typeName.Location = new System.Drawing.Point(7, 5);
            this.typeName.Name = "typeName";
            this.typeName.Size = new System.Drawing.Size(166, 20);
            this.typeName.TabIndex = 4;
            this.typeName.TextChanged += new System.EventHandler(this.typeName_TextChanged);
            // 
            // cbPassThrough
            // 
            this.cbPassThrough.AutoSize = true;
            this.cbPassThrough.Location = new System.Drawing.Point(7, 31);
            this.cbPassThrough.Name = "cbPassThrough";
            this.cbPassThrough.Size = new System.Drawing.Size(85, 17);
            this.cbPassThrough.TabIndex = 3;
            this.cbPassThrough.Text = "Passthrough";
            this.cbPassThrough.UseVisualStyleBackColor = true;
            this.cbPassThrough.CheckedChanged += new System.EventHandler(this.cbPassThrough_CheckedChanged);
            // 
            // browseBtn
            // 
            this.browseBtn.Enabled = false;
            this.browseBtn.Location = new System.Drawing.Point(98, 27);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // ResourceHandlerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 401);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Editor.Properties.Settings.Default, "RHWPos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = global::Editor.Properties.Settings.Default.RHWPos;
            this.Name = "ResourceHandlerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Resource Handler";
            this.Load += new System.EventHandler(this.ResourceHandlerWindow_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip TreeViewMenu;
        private System.Windows.Forms.ToolStripMenuItem TreeViewMenuAddFile;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_Remove;
        private System.Windows.Forms.Timer UpdateUnused;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ListBox handledTypes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton addNewPassthrough;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.CheckBox cbPassThrough;
        private System.Windows.Forms.TextBox typeName;
    }
}