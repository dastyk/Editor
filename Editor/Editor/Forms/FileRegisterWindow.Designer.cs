namespace Editor
{
    partial class FileRegisterWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileRegisterWindow));
            this.fileTree = new System.Windows.Forms.TreeView();
            this.TreeViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TreeViewMenuAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItem_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateUnused = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.defragButton = new System.Windows.Forms.ToolStripButton();
            this.TreeViewMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileTree
            // 
            this.fileTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTree.Location = new System.Drawing.Point(0, 25);
            this.fileTree.Name = "fileTree";
            this.fileTree.Size = new System.Drawing.Size(284, 236);
            this.fileTree.TabIndex = 0;
            this.fileTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fileTree_MouseDown);
            // 
            // TreeViewMenu
            // 
            this.TreeViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeViewMenuAddFile,
            this.addFilesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripItem_Remove});
            this.TreeViewMenu.Name = "TreeViewMenu";
            this.TreeViewMenu.Size = new System.Drawing.Size(123, 76);
            // 
            // TreeViewMenuAddFile
            // 
            this.TreeViewMenuAddFile.Name = "TreeViewMenuAddFile";
            this.TreeViewMenuAddFile.Size = new System.Drawing.Size(122, 22);
            this.TreeViewMenuAddFile.Text = "Add File";
            this.TreeViewMenuAddFile.Click += new System.EventHandler(this.TreeViewMenuAddFile_Click);
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.addFilesToolStripMenuItem.Text = "Add Files";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 6);
            // 
            // toolStripItem_Remove
            // 
            this.toolStripItem_Remove.Name = "toolStripItem_Remove";
            this.toolStripItem_Remove.Size = new System.Drawing.Size(122, 22);
            this.toolStripItem_Remove.Text = "Remove";
            this.toolStripItem_Remove.Click += new System.EventHandler(this.toolStripItem_Remove_Click);
            // 
            // UpdateUnused
            // 
            this.UpdateUnused.Tick += new System.EventHandler(this.UpdateUnused_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defragButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // defragButton
            // 
            this.defragButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.defragButton.Image = ((System.Drawing.Image)(resources.GetObject("defragButton.Image")));
            this.defragButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.defragButton.Name = "defragButton";
            this.defragButton.Size = new System.Drawing.Size(23, 22);
            this.defragButton.Text = "Defrag";
            this.defragButton.Click += new System.EventHandler(this.defragButton_Click);
            // 
            // FileRegisterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.fileTree);
            this.Controls.Add(this.toolStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Editor.Properties.Settings.Default, "FileRegPos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = global::Editor.Properties.Settings.Default.FileRegPos;
            this.Name = "FileRegisterWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "File Register";
            this.TreeViewMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView fileTree;
        private System.Windows.Forms.ContextMenuStrip TreeViewMenu;
        private System.Windows.Forms.ToolStripMenuItem TreeViewMenuAddFile;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_Remove;
        private System.Windows.Forms.Timer UpdateUnused;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton defragButton;
    }
}