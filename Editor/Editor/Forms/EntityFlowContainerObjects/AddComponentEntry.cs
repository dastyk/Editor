using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLWrappers.Managers;
namespace Editor.Forms.EntityFlowContainerObjects
{
    using Entity = UInt32;

    public partial class AddComponentEntry : UserControl
    {
        Entity entity;
        FlowLayoutPanel flp_components;
        Collection managers;
        public AddComponentEntry(FlowLayoutPanel cp, Entity entity, Collection managers)
        {
            InitializeComponent();
            this.flp_components = cp;
            this.managers = managers;
            this.entity = entity;
            ddl_Components.Items.Add(new TransformComponent(entity, managers.transformManager));

            ddl_Components.SelectedIndex = 0;
            
           for(int i = ddl_Components.Items.Count - 1; i >= 0; i--)
            {
                var c = (ComponentBase)ddl_Components.Items[i];
                var manager = c.GetManager();
                c.RegisterDelete(new DeleteEventHandler(ComponentDeleted));
                if (manager.IsRegistered(entity))
                {
                    c.ReadInfo();

                    Control ctrl = (Control)ddl_Components.Items[i];
                    flp_components.Controls.Add(ctrl);
                    ddl_Components.Items.RemoveAt(i);
                }
            }
               

                  
       

            if(ddl_Components.Items.Count>0)
                flp_components.Controls.Add(this);

        }
        private void ComponentDeleted(object sender)
        {
            ddl_Components.Items.Add(sender);
            if (ddl_Components.Items.Count == 1)
                ddl_Components.SelectedIndex = 0;
            flp_components.Controls.Remove((Control)sender);
            var c = (ComponentBase)sender;
            var manager = c.GetManager();
            manager.Destroy(entity);
            if (flp_components.Controls.Count == 0)
                flp_components.Controls.Add(this);
        }

        private void bth_Add_Click(object sender, EventArgs e)
        {
            if (ddl_Components.Items.Count > 0)
            {
                flp_components.Controls.Remove(this);
                Control ctrl = (Control)ddl_Components.Items[ddl_Components.SelectedIndex];
                flp_components.Controls.Add(ctrl);
                var comp = (ComponentBase)ctrl;
                comp.Added();
                ddl_Components.Items.RemoveAt(ddl_Components.SelectedIndex);

                if (ddl_Components.Items.Count > 0)
                {
                    flp_components.Controls.Add(this);
                }

            }
        }
    }
}
