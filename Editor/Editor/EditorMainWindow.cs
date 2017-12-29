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
namespace Editor
{
  
    public partial class EditorMainWindow : Form
    {
        BinaryLoader_Wrapper binaryLoader;
        FileRegisterWindow fileRegisterWindow;
        SceneSelector sceneSelector;
        SceneView sceneView;
        void fileRegisterWindowClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing)
                return;
            toolStripItem_FileReg.Checked = false;
            e.Cancel = true;
        }
   
        void sceneSelectorClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing)
                return;
            toolStripItem_SceneS.Checked = false;
            e.Cancel = true;
        }
     
        void sceneViewClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing)
                return;
            toolStripItem_SceneView.Checked = false;
            e.Cancel = true;
        }

        public EditorMainWindow()
        {
            InitializeComponent();

            if (Settings.Default.EditorMainSize != null)
                this.Size = Settings.Default.EditorMainSize;

            binaryLoader = new BinaryLoader_Wrapper();
            var r = binaryLoader.InitLoader("data.dat", LoaderMode.EDIT);
            if (r != 0)
            {
                MessageBox.Show("Could not init the binary file system", "Error: " + r.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            fileRegisterWindow = new FileRegisterWindow(binaryLoader);
            fileRegisterWindow.MdiParent = this;
            fileRegisterWindow.FormClosing += new System.Windows.Forms.FormClosingEventHandler(fileRegisterWindowClosing);


            sceneSelector = new SceneSelector(binaryLoader);
            sceneSelector.MdiParent = this;
            sceneSelector.FormClosing += new System.Windows.Forms.FormClosingEventHandler(sceneSelectorClosing);


            sceneView = new SceneView(binaryLoader);
            sceneView.MdiParent = this;
            sceneView.FormClosing += new System.Windows.Forms.FormClosingEventHandler(sceneViewClosing);


            toolStripItem_FileReg.Checked = Settings.Default.FileRegVisible;
            toolStripItem_SceneS.Checked = Settings.Default.SceneSelVisible;
            toolStripItem_SceneView.Checked = Settings.Default.SceneViewVisible;
          
         
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
            Settings.Default.SceneSelectorSize = sceneSelector.Size;

            Settings.Default.Save();
            e.Cancel = false;
        }
        private void toolStripItem_FileReg_CheckedChanged(object sender, EventArgs e)
        {
           Settings.Default.FileRegVisible = fileRegisterWindow.Visible = toolStripItem_FileReg.Checked;
            fileRegisterWindow.Location = Settings.Default.FileRegPos;

        }

        private void toolStripItem_SceneS_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.SceneSelVisible = sceneSelector.Visible = toolStripItem_SceneS.Checked;
            sceneSelector.Location = Settings.Default.SceneSelectorPos;
        }

        private void toolStripItem_SceneView_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.FileRegVisible = sceneView.Visible = toolStripItem_SceneView.Checked;
            sceneView.Location = Settings.Default.SceneViewPos;
        }
    }
}
