using System;
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
  
    public partial class EditorMainWindow : Form
    {
        Utilities.EditorWrapper wrapper;
        void fileRegisterWindowClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing)
                return;
            toolStripItem_FileReg.Checked = false;
            e.Cancel = true;
        }
   
        void sceneViewWindowClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing)
                return;
            toolStripItem_SceneView.Checked = false;
            e.Cancel = true;
        }
     
        void EntityViewWindowClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing)
                return;
            toolStripItem_EntityView.Checked = false;
            e.Cancel = true;
        }

        public EditorMainWindow()
        {
            
            InitializeComponent();

            wrapper = new Utilities.EditorWrapper();

            if (Settings.Default.EditorMainSize != null)
                this.Size = Settings.Default.EditorMainSize;

            wrapper.fileRegisterWindow.MdiParent = this;
            wrapper.fileRegisterWindow.FormClosing += new System.Windows.Forms.FormClosingEventHandler(fileRegisterWindowClosing);

            wrapper.entityViewWindow.MdiParent = this;
            wrapper.entityViewWindow.FormClosing += new System.Windows.Forms.FormClosingEventHandler(EntityViewWindowClosing);

            wrapper.sceneViewWindow.MdiParent = this;
            wrapper.sceneViewWindow.FormClosing += new System.Windows.Forms.FormClosingEventHandler(sceneViewWindowClosing);

            wrapper.renderWindow.MdiParent = this;

            toolStripItem_FileReg.Checked = Settings.Default.FileRegVisible;
            toolStripItem_SceneView.Checked = Settings.Default.SceneViewVisible;
            toolStripItem_EntityView.Checked = Settings.Default.EntityViewVisible;
            renderWindowToolStripMenuItem.Checked = Settings.Default.RenderWindowVis;



        }
        ~EditorMainWindow()
        {
            wrapper.binaryLoader.Shutdown();
        }

    

        private void EditorMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Copy window size to app settings
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.EditorMainSize = this.Size;
            }
            else
            {
                Settings.Default.EditorMainSize = this.RestoreBounds.Size;
            }

            Settings.Default.FileRegSize = wrapper.fileRegisterWindow.Size;
            Settings.Default.SceneViewSize = wrapper.sceneViewWindow.Size;
            Settings.Default.EntityViewSize = wrapper.entityViewWindow.Size;
            Settings.Default.RenderWindowSize = wrapper.renderWindow.Size;

            Settings.Default.Save();
            e.Cancel = false;
        }
        private void toolStripItem_FileReg_CheckedChanged(object sender, EventArgs e)
        {
           Settings.Default.FileRegVisible = wrapper.fileRegisterWindow.Visible = toolStripItem_FileReg.Checked;
            wrapper.fileRegisterWindow.Location = Settings.Default.FileRegPos;

        }

        private void toolStripItem_SceneView_CheckedChanged_1(object sender, EventArgs e)
        {
            Settings.Default.SceneViewVisible = wrapper.sceneViewWindow.Visible = toolStripItem_SceneView.Checked;
            wrapper.sceneViewWindow.Location = Settings.Default.SceneViewPos;
        }

        private void toolStripItem_EntityView_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.EntityViewVisible = wrapper.entityViewWindow.Visible = toolStripItem_EntityView.Checked;
            wrapper.entityViewWindow.Location = Settings.Default.EntityViewPos;
        }
      
        private void Save()
        {

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wrapper.Save();
            statusLabelSaved.Visible = true;
            SavedTimer.Start();
        }

        private void tsbtn_save_Click(object sender, EventArgs e)
        {
            wrapper.Save();
            statusLabelSaved.Visible = true;
            SavedTimer.Start();
        }

        private void SavedTimer_Tick(object sender, EventArgs e)
        {
            statusLabelSaved.Visible = false;
            SavedTimer.Stop();
        }

        private void renderWindowToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.RenderWindowVis =  wrapper.renderWindow.Visible = renderWindowToolStripMenuItem.Checked;
          
        }
    }
}
