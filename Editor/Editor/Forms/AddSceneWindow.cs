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
    public partial class AddSceneWindow : Form
    {
        public string name { get; set; }
        public AddSceneWindow()
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
      
       
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_CANCEL_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void tb_Name_TextChanged(object sender, EventArgs e)
        {
            name = tb_Name.Text;
        }
    }
}
