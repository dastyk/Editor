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
    public partial class AddComponentEntry : UserControl
    {
        FlowLayoutPanel flp_components;
        public AddComponentEntry(FlowLayoutPanel cp)
        {
            InitializeComponent();
            this.flp_components = cp;
            ddl_Components.Items.Add(new TransformComponent());
            ddl_Components.SelectedIndex = 0;
        }

        private void bth_Add_Click(object sender, EventArgs e)
        {
            if (ddl_Components.Items.Count > 0)
            {
                flp_components.Controls.Remove(this);
                Control ctrl = (Control)ddl_Components.Items[ddl_Components.SelectedIndex];
                flp_components.Controls.Add(ctrl);
                ddl_Components.Items.RemoveAt(ddl_Components.SelectedIndex);

                if (ddl_Components.Items.Count > 0)
                {
                    flp_components.Controls.Add(this);
                }

            }
        }
    }
}
