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
        void ShowFileRegisterWindow()
        {
            fileRegisterWindow = new FileRegisterWindow(binaryLoader);
            fileRegisterWindow.MdiParent = this;
            fileRegisterWindow.Show();
            fileRegisterWindow.FormClosed += new System.Windows.Forms.FormClosedEventHandler(fileRegisterWindowClosed);
        }
        void fileRegisterWindowClosed(object sender, FormClosedEventArgs e)
        {
            toolStripItem_FileReg.Checked = false;
        }
        public EditorMainWindow()
        {
            InitializeComponent();

            if (Settings.Default.EditorMainSize != null)
                this.Size = Settings.Default.EditorMainSize;
            binaryLoader = new BinaryLoader_Wrapper();
            var r = binaryLoader.InitLoader("data.dat", LoaderMode.EDIT);
            if(r != 0)
            {
                MessageBox.Show("Could not init the binary file system", "Error: " + r.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            ShowFileRegisterWindow();
        }
        ~EditorMainWindow()
        {
            binaryLoader.Shutdown();
        }

        private void toolStripItem_FileReg_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripItem_FileReg.Checked)
            {
                ShowFileRegisterWindow();
            }
               
            else
                fileRegisterWindow.Close();
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

            // Save settings
            Settings.Default.Save();
        }
    }
}
