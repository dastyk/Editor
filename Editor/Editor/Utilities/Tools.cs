using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineImporter;
using EngineImporter.Managers;
using System.Windows.Forms;
namespace Editor.Utilities
{
    public class EditorWrapper
    {
        public BinaryLoader_Wrapper binaryLoader;
        public FileRegisterWindow fileRegisterWindow;
        public SceneViewWindow sceneViewWindow;
        public EntityViewWindow entityViewWindow;
        public ResourceHandler resourceHandler;
        public Collection managers = new Collection();
        public EditorWrapper()
        {
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

            fileRegisterWindow = new FileRegisterWindow(this);
         
            entityViewWindow = new EntityViewWindow(this);
          
            sceneViewWindow = new SceneViewWindow(this);
           

        }
        public void Save()
        {
            var scenes = managers.sceneManager.GetRegisteredEntities();
            var names = new string[scenes.Length];

            for (int i = 0; i < scenes.Length; i++)
            {
                var ent = scenes[i];
                var r = managers.sceneManager.WriteComponent(binaryLoader, ent, managers.sceneManager.GetNameOfScene(ent), "Scene");
                if (r != 0)
                {
                    MessageBox.Show("Could not write scene component", "Error: " + r.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                names[i] = managers.sceneManager.GetNameOfScene(ent);
            }
            fileRegisterWindow.RemoveFilesThatDoNotMatch(names, "Scene");

            fileRegisterWindow.Reset();
        }
    }
}
