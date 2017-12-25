using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class AddFileWindow : Form
    {
        public string file { get; set; }
        public string type { get; set; }
        public AddFileWindow()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
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

        }

        private void tb_File_TextChanged(object sender, EventArgs e)
        {
            file = tb_File.Text;
        }

        private void cb_Type_TextUpdate(object sender, EventArgs e)
        {
            type = cb_Type.Text;
        }
    }
}
