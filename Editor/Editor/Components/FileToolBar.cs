using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLWrappers.Managers;
namespace Editor.Components
{
    public partial class FileToolBar : Component
    {
        Collection managers;
        DLLWrappers.BinaryLoader_Wrapper loader;
        SceneViewWindow sceneViewWindow;
        public FileToolBar(Control.ControlCollection controlCollection, Collection managers)
        {

            this.managers = managers;
       
            InitializeComponent();
            controlCollection.Add(this.toolBar);
        }
        public void SetLoader(DLLWrappers.BinaryLoader_Wrapper l)
        {
            loader = l;
        }
        public void SetSceneView(SceneViewWindow sceneViewWindow)
        {
            this.sceneViewWindow = sceneViewWindow;
        }
        public FileToolBar(IContainer container)
        {
            container.Add(this);
      
            InitializeComponent();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var scenes = managers.sceneManager.GetRegisteredEntities();
            foreach(UInt32 ent in scenes)
            {

                var r = managers.sceneManager.WriteComponent(loader, ent, managers.sceneManager.GetNameOfScene(ent), "Scene");
                if(r != 0)
                {
                    MessageBox.Show("Could not write scene component", "Error: " + r.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
