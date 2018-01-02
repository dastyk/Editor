namespace Editor
{
    partial class SceneViewWindow
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
            this.scenesTree = new System.Windows.Forms.TreeView();
            this.cms_Scene = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsi_New = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.sceneTree = new System.Windows.Forms.TreeView();
            this.cms_NewEnt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsi_AddEntity = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Scene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.cms_NewEnt.SuspendLayout();
            this.SuspendLayout();
            // 
            // scenesTree
            // 
            this.scenesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scenesTree.HideSelection = false;
            this.scenesTree.HotTracking = true;
            this.scenesTree.Location = new System.Drawing.Point(0, 0);
            this.scenesTree.Name = "scenesTree";
            this.scenesTree.Size = new System.Drawing.Size(96, 257);
            this.scenesTree.TabIndex = 0;
            this.scenesTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.scenesTree_AfterLabelEdit);
            this.scenesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.scenesTree_AfterSelect);
            this.scenesTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sceneTree_MouseDown);
            // 
            // cms_Scene
            // 
            this.cms_Scene.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsi_New,
            this.toolStripMenuItem1,
            this.renameToolStripMenuItem,
            this.toolStripMenuItem3,
            this.deleteToolStripMenuItem});
            this.cms_Scene.Name = "contextMenuStrip1";
            this.cms_Scene.Size = new System.Drawing.Size(153, 104);
            // 
            // cmsi_New
            // 
            this.cmsi_New.Name = "cmsi_New";
            this.cmsi_New.Size = new System.Drawing.Size(152, 22);
            this.cmsi_New.Text = "New Scene";
            this.cmsi_New.Click += new System.EventHandler(this.cmsi_New_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::Editor.Properties.Settings.Default, "SceneViewSplitDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.scenesTree);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.sceneTree);
            this.splitContainer.Size = new System.Drawing.Size(284, 261);
            this.splitContainer.SplitterDistance = global::Editor.Properties.Settings.Default.SceneViewSplitDistance;
            this.splitContainer.TabIndex = 1;
            // 
            // sceneTree
            // 
            this.sceneTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneTree.HideSelection = false;
            this.sceneTree.HotTracking = true;
            this.sceneTree.Location = new System.Drawing.Point(0, 0);
            this.sceneTree.Name = "sceneTree";
            this.sceneTree.Size = new System.Drawing.Size(176, 257);
            this.sceneTree.TabIndex = 0;
            this.sceneTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.sceneTree_AfterSelect);
            this.sceneTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sceneTree_MouseDown_1);
            // 
            // cms_NewEnt
            // 
            this.cms_NewEnt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsi_AddEntity});
            this.cms_NewEnt.Name = "cms_NewEnt";
            this.cms_NewEnt.Size = new System.Drawing.Size(130, 26);
            // 
            // cmsi_AddEntity
            // 
            this.cmsi_AddEntity.Name = "cmsi_AddEntity";
            this.cmsi_AddEntity.Size = new System.Drawing.Size(129, 22);
            this.cmsi_AddEntity.Text = "Add Entity";
            this.cmsi_AddEntity.Click += new System.EventHandler(this.cmsi_AddEntity_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // SceneViewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.splitContainer);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Editor.Properties.Settings.Default, "SceneViewPos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = global::Editor.Properties.Settings.Default.SceneViewPos;
            this.Name = "SceneViewWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Scene View";
            this.cms_Scene.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.cms_NewEnt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView scenesTree;
        private System.Windows.Forms.ContextMenuStrip cms_Scene;
        private System.Windows.Forms.ToolStripMenuItem cmsi_New;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView sceneTree;
        private System.Windows.Forms.ContextMenuStrip cms_NewEnt;
        private System.Windows.Forms.ToolStripMenuItem cmsi_AddEntity;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}