namespace Editor.Forms.EntityFlowContainerObjects
{
    partial class TransformComponent
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.posZ = new System.Windows.Forms.MaskedTextBox();
            this.posY = new System.Windows.Forms.MaskedTextBox();
            this.posX = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.scaleZ = new System.Windows.Forms.MaskedTextBox();
            this.scaleY = new System.Windows.Forms.MaskedTextBox();
            this.scaleX = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bth_Remove = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "z";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.posZ);
            this.panel1.Controls.Add(this.posY);
            this.panel1.Controls.Add(this.posX);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 57);
            this.panel1.TabIndex = 7;
            // 
            // posZ
            // 
            this.posZ.Location = new System.Drawing.Point(164, 26);
            this.posZ.Mask = "#999.999";
            this.posZ.Name = "posZ";
            this.posZ.PromptChar = '0';
            this.posZ.Size = new System.Drawing.Size(51, 20);
            this.posZ.TabIndex = 9;
            this.posZ.TextChanged += new System.EventHandler(this.posChanged);
            // 
            // posY
            // 
            this.posY.Location = new System.Drawing.Point(107, 26);
            this.posY.Mask = "#999.999";
            this.posY.Name = "posY";
            this.posY.PromptChar = '0';
            this.posY.Size = new System.Drawing.Size(51, 20);
            this.posY.TabIndex = 8;
            this.posY.TextChanged += new System.EventHandler(this.posChanged);
            // 
            // posX
            // 
            this.posX.Location = new System.Drawing.Point(50, 26);
            this.posX.Mask = "#999.999";
            this.posX.Name = "posX";
            this.posX.PromptChar = '0';
            this.posX.Size = new System.Drawing.Size(51, 20);
            this.posX.TabIndex = 7;
            this.posX.TextChanged += new System.EventHandler(this.posChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.scaleZ);
            this.panel2.Controls.Add(this.scaleY);
            this.panel2.Controls.Add(this.scaleX);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(3, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 57);
            this.panel2.TabIndex = 10;
            // 
            // scaleZ
            // 
            this.scaleZ.Location = new System.Drawing.Point(164, 26);
            this.scaleZ.Mask = "#999.999";
            this.scaleZ.Name = "scaleZ";
            this.scaleZ.PromptChar = '0';
            this.scaleZ.Size = new System.Drawing.Size(51, 20);
            this.scaleZ.TabIndex = 9;
            this.scaleZ.TextChanged += new System.EventHandler(this.scaleChanged);
            // 
            // scaleY
            // 
            this.scaleY.Location = new System.Drawing.Point(107, 26);
            this.scaleY.Mask = "#999.999";
            this.scaleY.Name = "scaleY";
            this.scaleY.PromptChar = '0';
            this.scaleY.Size = new System.Drawing.Size(51, 20);
            this.scaleY.TabIndex = 8;
            this.scaleY.TextChanged += new System.EventHandler(this.scaleChanged);
            // 
            // scaleX
            // 
            this.scaleX.Location = new System.Drawing.Point(50, 26);
            this.scaleX.Mask = "#999.999";
            this.scaleX.Name = "scaleX";
            this.scaleX.PromptChar = '0';
            this.scaleX.Size = new System.Drawing.Size(51, 20);
            this.scaleX.TabIndex = 7;
            this.scaleX.TextChanged += new System.EventHandler(this.scaleChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "z";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Scale";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "x";
            // 
            // bth_Remove
            // 
            this.bth_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bth_Remove.Location = new System.Drawing.Point(271, 5);
            this.bth_Remove.Name = "bth_Remove";
            this.bth_Remove.Size = new System.Drawing.Size(25, 25);
            this.bth_Remove.TabIndex = 11;
            this.bth_Remove.Text = "X";
            this.bth_Remove.UseVisualStyleBackColor = true;
            this.bth_Remove.Click += new System.EventHandler(this.bth_Remove_Click);
            // 
            // TransformComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.bth_Remove);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TransformComponent";
            this.Size = new System.Drawing.Size(301, 126);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox posZ;
        private System.Windows.Forms.MaskedTextBox posY;
        private System.Windows.Forms.MaskedTextBox posX;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox scaleZ;
        private System.Windows.Forms.MaskedTextBox scaleY;
        private System.Windows.Forms.MaskedTextBox scaleX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bth_Remove;
    }
}
