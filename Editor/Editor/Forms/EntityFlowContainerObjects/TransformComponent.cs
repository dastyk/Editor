using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor.Forms.EntityFlowContainerObjects
{
    public partial class TransformComponent : UserControl
    {
        public TransformComponent()
        {
            InitializeComponent();
        }

        public override string ToString()
        {
            return "Transform";
        }

        private void bth_Remove_Click(object sender, EventArgs e)
        {

        }
    }
}
