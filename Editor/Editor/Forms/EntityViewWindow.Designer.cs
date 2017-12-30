namespace Editor
{
    partial class EntityViewWindow
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
            this.entityComponents = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // entityComponents
            // 
            this.entityComponents.AutoScroll = true;
            this.entityComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityComponents.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.entityComponents.Location = new System.Drawing.Point(0, 0);
            this.entityComponents.Name = "entityComponents";
            this.entityComponents.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.entityComponents.Size = new System.Drawing.Size(284, 261);
            this.entityComponents.TabIndex = 0;
            this.entityComponents.WrapContents = false;
            this.entityComponents.ClientSizeChanged += new System.EventHandler(this.entityComponents_ClientSizeChanged);
            this.entityComponents.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.entityComponents_ControlAdded);
            // 
            // EntityViewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.entityComponents);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Editor.Properties.Settings.Default, "EntityViewPos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = global::Editor.Properties.Settings.Default.EntityViewPos;
            this.Name = "EntityViewWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Entity View";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel entityComponents;
    }
}