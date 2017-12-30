namespace Editor
{
    partial class AddSceneWindow
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_CANCEL = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(16, 48);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "Add";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_CANCEL
            // 
            this.btn_CANCEL.Location = new System.Drawing.Point(110, 48);
            this.btn_CANCEL.Name = "btn_CANCEL";
            this.btn_CANCEL.Size = new System.Drawing.Size(75, 23);
            this.btn_CANCEL.TabIndex = 1;
            this.btn_CANCEL.Text = "Cancel";
            this.btn_CANCEL.UseVisualStyleBackColor = true;
            this.btn_CANCEL.Click += new System.EventHandler(this.btn_CANCEL_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(54, 12);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(131, 20);
            this.tb_Name.TabIndex = 9;
            this.tb_Name.TextChanged += new System.EventHandler(this.tb_Name_TextChanged);
            // 
            // AddSceneWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(196, 83);
            this.ControlBox = false;
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_CANCEL);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddSceneWindow";
            this.Text = "Add Scene";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_CANCEL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Name;
    }
}