﻿namespace Editor
{
    partial class SceneView
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
            this.sceneTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // sceneTree
            // 
            this.sceneTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneTree.Location = new System.Drawing.Point(0, 0);
            this.sceneTree.Name = "sceneTree";
            this.sceneTree.Size = new System.Drawing.Size(284, 261);
            this.sceneTree.TabIndex = 0;
            // 
            // SceneView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sceneTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SceneView";
            this.Text = "SceneView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView sceneTree;
    }
}