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
            this.TreeViewMenuAddFile});
            this.TreeViewMenu.Name = "TreeViewMenu";
            this.TreeViewMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // TreeViewMenuAddFile
            // 
            this.TreeViewMenuAddFile.Name = "TreeViewMenuAddFile";
            this.TreeViewMenuAddFile.Size = new System.Drawing.Size(152, 22);
            this.TreeViewMenuAddFile.Text = "Add File";
            this.TreeViewMenuAddFile.Click += new System.EventHandler(this.TreeViewMenuAddFile_Click);
            // 
            // FileRegisterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.fileTree);
            this.Name = "FileRegisterWindow";
            this.Text = "FileRegisterWindow";
            this.TreeViewMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView fileTree;
        private System.Windows.Forms.ContextMenuStrip TreeViewMenu;
        private System.Windows.Forms.ToolStripMenuItem TreeViewMenuAddFile;
    }
}