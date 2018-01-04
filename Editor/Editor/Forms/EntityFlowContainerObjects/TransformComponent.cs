using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Importer.Managers;
using System.Globalization;

namespace Editor.Forms.EntityFlowContainerObjects
{
    using Entity = UInt32;
    public partial class TransformComponent : UserControl, ComponentBase
    {
        Entity entity;
        Utilities.EditorWrapper wrapper;
        event DeleteEventHandler OnDelete;
        public TransformComponent(Entity entity,Utilities.EditorWrapper wrapper)
        {
            this.wrapper = wrapper;
            InitializeComponent();
            this.entity = entity;
        }
        public ManagerBase GetManager()
        {
            return wrapper.managers.transformManager;         
        }
        public void Added()
        {
            wrapper.managers.transformManager.Create(entity);
        }
        private String ToString(float v)
        {
            if (v < 0.0f)
                return v.ToString("#000.000");
            else
                return v.ToString("0000.000");
        }
        public void ReadInfo()
        {
            var pos = wrapper.managers.transformManager.GetPosition(entity);
            posX.Text = ToString(pos.x);
            posY.Text = ToString(pos.y);
            posZ.Text = ToString(pos.z);
            var scale = wrapper.managers.transformManager.GetScale(entity);
            scaleX.Text = ToString(scale.x);
            scaleY.Text = ToString(scale.x);
            scaleZ.Text = ToString(scale.x);
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
        private float ToFloat(String str)
        {
            var x = str.Replace(' ', '0');
            if (x[x.Length - 1] == Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                x = x.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + "0");
            return Convert.ToSingle(x);
        }
        private void posChanged(object sender, EventArgs e)
        {
            Vector pos;
            pos.x = ToFloat(posX.Text);
            pos.y = ToFloat(posY.Text);
            pos.z = ToFloat(posZ.Text);
            wrapper.managers.transformManager.SetPosition(entity, pos);
            wrapper.Changed(Utilities.ChangeType.ENTITY);
        }
        private void scaleChanged(object sender, EventArgs e)
        {
            Vector scale;
            scale.x = ToFloat(scaleX.Text);
            scale.y = ToFloat(scaleY.Text);
            scale.z = ToFloat(scaleZ.Text);
            wrapper.managers.transformManager.SetScale(entity, scale);
            wrapper.Changed(Utilities.ChangeType.ENTITY);
        }
    }
}
