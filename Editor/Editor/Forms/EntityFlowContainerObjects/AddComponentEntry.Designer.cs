namespace Editor.Forms.EntityFlowContainerObjects
{
    partial class AddComponentEntry
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ddl_Components = new System.Windows.Forms.ComboBox();
            this.bth_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ddl_Components
            // 
            this.ddl_Components.Dock = System.Windows.Forms.DockStyle.Top;
            this.ddl_Components.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Components.Location = new System.Drawing.Point(0, 0);
            this.ddl_Components.MaxLength = 100;
            this.ddl_Components.Name = "ddl_Components";
            this.ddl_Components.Size = new System.Drawing.Size(148, 21);
            this.ddl_Components.Sorted = true;
            this.ddl_Components.TabIndex = 0;
            // 
            // bth_Add
            // 
            this.bth_Add.Location = new System.Drawing.Point(4, 28);
            this.bth_Add.Name = "bth_Add";
            this.bth_Add.Size = new System.Drawing.Size(75, 23);
            this.bth_Add.TabIndex = 1;
            this.bth_Add.Text = "Add";
            this.bth_Add.UseVisualStyleBackColor = true;
            this.bth_Add.Click += new System.EventHandler(this.bth_Add_Click);
            // 
            // AddComponentEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.bth_Add);
            this.Controls.Add(this.ddl_Components);
            this.Name = "AddComponentEntry";
            this.Size = new System.Drawing.Size(148, 57);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddl_Components;
        private System.Windows.Forms.Button bth_Add;
    }
}
