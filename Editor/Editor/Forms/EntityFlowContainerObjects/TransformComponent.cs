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
    using Entity = UInt32;
    public partial class TransformComponent : UserControl, ComponentBase
    {
        Entity entity;
        Manager.TransformManager manager;
        event DeleteEventHandler OnDelete;
        public TransformComponent(Entity entity, Manager.TransformManager tm)
        {
            InitializeComponent();
            this.entity = entity;
            manager = tm;
        }
        public ManagerBase GetManager()
        {
            return manager;         
        }
        public void Added()
        {
            manager.Create(entity);
        }
        public void ReadInfo()
        {

        }
        public void RegisterDelete(DeleteEventHandler deleteEventHandler)
        {
            OnDelete += deleteEventHandler;
        }
        public override string ToString()
        {
            return "Transform";
        }

        private void bth_Remove_Click(object sender, EventArgs e)
        {
            if (OnDelete == null) return;
            OnDelete(this);
        }
    }
}
