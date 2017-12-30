namespace Editor
{
    partial class AddFileWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_File = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(42, 101);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "Add";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_CANCEL
            // 
            this.btn_CANCEL.Location = new System.Drawing.Point(158, 101);
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
            this.label3.Location = new System.Drawing.Point(4, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(42, 44);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(191, 20);
            this.tb_Name.TabIndex = 9;
            this.tb_Name.TextChanged += new System.EventHandler(this.tb_Name_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type";
            // 
            // cb_Type
            // 
            this.cb_Type.FormattingEnabled = true;
            this.cb_Type.Location = new System.Drawing.Point(132, 73);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Size = new System.Drawing.Size(101, 21);
            this.cb_Type.TabIndex = 4;
            this.cb_Type.TextUpdate += new System.EventHandler(this.cb_Type_TextUpdate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File";
            // 
            // tb_File
            // 
            this.tb_File.Location = new System.Drawing.Point(42, 13);
            this.tb_File.Name = "tb_File";
            this.tb_File.Size = new System.Drawing.Size(191, 20);
            this.tb_File.TabIndex = 6;
            this.tb_File.TextChanged += new System.EventHandler(this.tb_File_TextChanged);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(239, 12);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 7;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // AddFileWindow
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btn_CANCEL;
            this.ClientSize = new System.Drawing.Size(326, 145);
            this.ControlBox = false;
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.tb_File);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_Type);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_CANCEL);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddFileWindow";
            this.Text = "AddFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_CANCEL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_File;
        private System.Windows.Forms.Button btn_Browse;
    }
}