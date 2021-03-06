﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Editor.Properties;
using Importer;
using Importer.Managers;
namespace Editor
{
    using Entity = UInt32;
    public partial class EntityViewWindow : Form
    {
        Entity entity;
        Utilities.EditorWrapper wrapper;
        public EntityViewWindow(Utilities.EditorWrapper wrapper)
        {
            InitializeComponent();
            this.wrapper = wrapper;
            this.Size = Settings.Default.EntityViewSize;
            //Forms.EntityFlowContainerObjects.AddComponentEntry addComponentEntry1 = new Forms.EntityFlowContainerObjects.AddComponentEntry();
            //addComponentEntry1.Width = Settings.Default.EntityFlowContWidth;
            //entityComponents.Controls.Add(addComponentEntry1);

        }
        public void SetEntity(Entity ent)
        {
            entity = ent;
            entityComponents.Controls.Clear();
            var addComponentEntry = new Forms.EntityFlowContainerObjects.AddComponentEntry(entityComponents,ent, wrapper);
          
        }
        public void Clear()
        {
            entityComponents.Controls.Clear();
        }
        private void entityComponents_ClientSizeChanged(object sender, EventArgs e)
        {
            Settings.Default.EntityFlowContWidth = entityComponents.ClientSize.Width - 6;
            Settings.Default.Save();
            foreach (Control ctrl in entityComponents.Controls)
            {
                ctrl.Width = Settings.Default.EntityFlowContWidth;
            }
        }

        private void entityComponents_ControlAdded(object sender, ControlEventArgs e)
        {
            foreach (Control ctrl in entityComponents.Controls)
            {
                ctrl.Width = Settings.Default.EntityFlowContWidth;
            }
        }
    }
}
