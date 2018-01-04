namespace Editor
{
    partial class EditorMainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorMainWindow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelSaved = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip_File = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Windows = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItem_FileReg = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItem_SceneView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItem_EntityView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_save = new System.Windows.Forms.ToolStripButton();
            this.SavedTimer = new System.Windows.Forms.Timer(this.components);
            this.renderWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelSaved});
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip";
            // 
            // statusLabelSaved
            // 
            this.statusLabelSaved.Name = "statusLabelSaved";
            this.statusLabelSaved.Size = new System.Drawing.Size(38, 17);
            this.statusLabelSaved.Text = "Saved";
            this.statusLabelSaved.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_File,
            this.toolStrip_Windows});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip";
            // 
            // toolStrip_File
            // 
            this.toolStrip_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.toolStrip_File.Name = "toolStrip_File";
            this.toolStrip_File.Size = new System.Drawing.Size(37, 20);
            this.toolStrip_File.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // toolStrip_Windows
            // 
            this.toolStrip_Windows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripItem_FileReg,
            this.toolStripItem_SceneView,
            this.toolStripItem_EntityView,
            this.renderWindowToolStripMenuItem});
            this.toolStrip_Windows.Name = "toolStrip_Windows";
            this.toolStrip_Windows.Size = new System.Drawing.Size(68, 20);
            this.toolStrip_Windows.Text = "Windows";
            // 
            // toolStripItem_FileReg
            // 
            this.toolStripItem_FileReg.CheckOnClick = true;
            this.toolStripItem_FileReg.Name = "toolStripItem_FileReg";
            this.toolStripItem_FileReg.Size = new System.Drawing.Size(158, 22);
            this.toolStripItem_FileReg.Text = "File Register";
            this.toolStripItem_FileReg.CheckedChanged += new System.EventHandler(this.toolStripItem_FileReg_CheckedChanged);
            // 
            // toolStripItem_SceneView
            // 
            this.toolStripItem_SceneView.CheckOnClick = true;
            this.toolStripItem_SceneView.Name = "toolStripItem_SceneView";
            this.toolStripItem_SceneView.Size = new System.Drawing.Size(158, 22);
            this.toolStripItem_SceneView.Text = "Scene View";
            this.toolStripItem_SceneView.CheckedChanged += new System.EventHandler(this.toolStripItem_SceneView_CheckedChanged_1);
            // 
            // toolStripItem_EntityView
            // 
            this.toolStripItem_EntityView.CheckOnClick = true;
            this.toolStripItem_EntityView.Name = "toolStripItem_EntityView";
            this.toolStripItem_EntityView.Size = new System.Drawing.Size(158, 22);
            this.toolStripItem_EntityView.Text = "Entity View";
            this.toolStripItem_EntityView.CheckedChanged += new System.EventHandler(this.toolStripItem_EntityView_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_save});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtn_save
            // 
            this.tsbtn_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_save.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_save.Image")));
            this.tsbtn_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_save.Name = "tsbtn_save";
            this.tsbtn_save.Size = new System.Drawing.Size(23, 22);
            this.tsbtn_save.Text = "tsbtn_save";
            this.tsbtn_save.Click += new System.EventHandler(this.tsbtn_save_Click);
            // 
            // SavedTimer
            // 
            this.SavedTimer.Interval = 2000;
            this.SavedTimer.Tick += new System.EventHandler(this.SavedTimer_Tick);
            // 
            // renderWindowToolStripMenuItem
            // 
            this.renderWindowToolStripMenuItem.CheckOnClick = true;
            this.renderWindowToolStripMenuItem.Name = "renderWindowToolStripMenuItem";
            this.renderWindowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.renderWindowToolStripMenuItem.Text = "Render Window";
            this.renderWindowToolStripMenuItem.CheckedChanged += new System.EventHandler(this.renderWindowToolStripMenuItem_CheckedChanged);
            // 
            // EditorMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Editor.Properties.Settings.Default, "EditorMainPos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Location = global::Editor.Properties.Settings.Default.EditorMainPos;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditorMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorMainWindow_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_File;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_Windows;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_FileReg;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_SceneView;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_EntityView;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtn_save;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelSaved;
        private System.Windows.Forms.Timer SavedTimer;
        private System.Windows.Forms.ToolStripMenuItem renderWindowToolStripMenuItem;
    }
}

