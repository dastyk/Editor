using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor
{
    public partial class AddFileWindow : Form
    {
        public string file { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public AddFileWindow()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if(name == null || name == "")
            {
                MessageBox.Show("Name can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(type == null || type == "")
            {
                MessageBox.Show("Type can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!File.Exists(file))
            {
                MessageBox.Show("File does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_CANCEL_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tb_File.Text = openFileDialog1.FileName;
            }
        }

        private void tb_File_TextChanged(object sender, EventArgs e)
        {
            file = tb_File.Text;
        }

        private void cb_Type_TextUpdate(object sender, EventArgs e)
        {
            type = cb_Type.Text;
        }

        private void tb_Name_TextChanged(object sender, EventArgs e)
        {
            name = tb_Name.Text;
        }
    }
}
