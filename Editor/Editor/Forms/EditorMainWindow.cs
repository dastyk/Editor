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
using DLLWrappers;
using DLLWrappers.Managers;

namespace Editor
{
  
    public partial class EditorMainWindow : Form
    {
        BinaryLoader_Wrapper binaryLoader;
        FileRegisterWindow fileRegisterWindow;
        SceneViewWindow sceneViewWindow;
        EntityViewWindow entityViewWindow;
        ResourceHandler resourceHandler;
        Collection managers = new Collection();
        Components.FileToolBar fileToolBar;
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

            fileToolBar = new Components.FileToolBar(this.Controls, managers);
            InitializeComponent();

            if (Settings.Default.EditorMainSize != null)
                this.Size = Settings.Default.EditorMainSize;

            binaryLoader = new BinaryLoader_Wrapper();
            var r = binaryLoader.InitLoader("data.dat", LoaderMode.EDIT);
            if (r != 0)
            {
                MessageBox.Show("Could not init the binary file system", "Error: " + r.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            resourceHandler = new ResourceHandler(binaryLoader);

            managers.entityManager = new EntityManager();
            managers.transformManager = new TransformManager(managers.entityManager);
            managers.sceneManager = new SceneManager(managers.entityManager, managers.transformManager);
            
            fileRegisterWindow = new FileRegisterWindow(binaryLoader);
            fileRegisterWindow.MdiParent = this;
            fileRegisterWindow.FormClosing += new System.Windows.Forms.FormClosingEventHandler(fileRegisterWindowClosing);

            entityViewWindow = new EntityViewWindow(binaryLoader, managers);
            entityViewWindow.MdiParent = this;
            entityViewWindow.FormClosing += new System.Windows.Forms.FormClosingEventHandler(EntityViewWindowClosing);

            sceneViewWindow = new SceneViewWindow(binaryLoader, managers, entityViewWindow);
            sceneViewWindow.MdiParent = this;
            sceneViewWindow.FormClosing += new System.Windows.Forms.FormClosingEventHandler(sceneViewWindowClosing);

            fileToolBar.SetLoader(binaryLoader);
            fileToolBar.SetSceneView(sceneViewWindow);

            toolStripItem_FileReg.Checked = Settings.Default.FileRegVisible;
            toolStripItem_SceneView.Checked = Settings.Default.SceneViewVisible;
            toolStripItem_EntityView.Checked = Settings.Default.EntityViewVisible;
          
         
        }
        ~EditorMainWindow()
        {
            binaryLoader.Shutdown();
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

            Settings.Default.FileRegSize = fileRegisterWindow.Size;
            Settings.Default.SceneViewSize = sceneViewWindow.Size;
            Settings.Default.EntityViewSize = entityViewWindow.Size;

            Settings.Default.Save();
            e.Cancel = false;
        }
        private void toolStripItem_FileReg_CheckedChanged(object sender, EventArgs e)
        {
           Settings.Default.FileRegVisible = fileRegisterWindow.Visible = toolStripItem_FileReg.Checked;
            fileRegisterWindow.Location = Settings.Default.FileRegPos;

        }

        private void toolStripItem_SceneView_CheckedChanged_1(object sender, EventArgs e)
        {
            Settings.Default.SceneViewVisible = sceneViewWindow.Visible = toolStripItem_SceneView.Checked;
            sceneViewWindow.Location = Settings.Default.SceneViewPos;
        }

        private void toolStripItem_EntityView_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.EntityViewVisible = entityViewWindow.Visible = toolStripItem_EntityView.Checked;
            entityViewWindow.Location = Settings.Default.EntityViewPos;
        }
    }
}
