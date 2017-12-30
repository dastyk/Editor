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
            this.fileTree = new System.Windows.Forms.TreeView();
            this.TreeViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TreeViewMenuAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItem_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileTree
            // 
            this.fileTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTree.Location = new System.Drawing.Point(-1, 0);
            this.fileTree.Name = "fileTree";
            this.fileTree.Size = new System.Drawing.Size(284, 259);
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
            // FileRegisterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.fileTree);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Editor.Properties.Settings.Default, "FileRegPos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = global::Editor.Properties.Settings.Default.FileRegPos;
            this.Name = "FileRegisterWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FileRegister";
            this.TreeViewMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView fileTree;
        private System.Windows.Forms.ContextMenuStrip TreeViewMenu;
        private System.Windows.Forms.ToolStripMenuItem TreeViewMenuAddFile;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripItem_Remove;
    }
}