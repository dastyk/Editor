using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Importer;
using Importer.Managers;
using System.Windows.Forms;
namespace Editor.Utilities
{
    [Flags]public enum ChangeType
    {
        NONE = 0,
        ENTITY = 1 << 0,
        SCENE = 1 << 1,
        FILE = 1 << 2
    }
    public delegate void EditorChangeEventHandler(ChangeType changeType);
    public delegate void EditorSavedEventHandler();
    public class EditorWrapper
    {
        public BinaryLoader_Wrapper binaryLoader;
        public FileRegisterWindow fileRegisterWindow;
        public SceneViewWindow sceneViewWindow;
        public EntityViewWindow entityViewWindow;
        public Forms.RenderWindow renderWindow;
       
        public ResourceHandler resourceHandler;
        public Collection managers = new Collection();
        public event EditorChangeEventHandler ChangeEvent;
        public event EditorSavedEventHandler SavedEvent;
        public EditorWrapper()
        {
            binaryLoader = new BinaryLoader_Wrapper();
            var r = binaryLoader.InitLoader("data.dat", LoaderMode.EDIT);
            if (r != 0)
            {
                MessageBox.Show("Could not init the binary file system", "Error: " + r.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            resourceHandler = new ResourceHandler(binaryLoader);
            renderWindow = new Forms.RenderWindow(this);
           
            managers.entityManager = new EntityManager();
            managers.transformManager = new TransformManager(managers.entityManager);
            managers.sceneManager = new SceneManager(managers.entityManager, managers.transformManager);

            fileRegisterWindow = new FileRegisterWindow(this);

            entityViewWindow = new EntityViewWindow(this);

            sceneViewWindow = new SceneViewWindow(this);

            SavedEvent();
        }
        public void Changed(Utilities.ChangeType changeType)
        {
            ChangeEvent(changeType);
        }
        public void Reset()
        {
        
            resourceHandler.Reset();


        }
        public void Save()
        {
            var scenes = managers.sceneManager.GetRegisteredEntities();

            for (int i = 0; i < scenes.Length; i++)
            {
                var ent = scenes[i];
                var r = managers.sceneManager.WriteComponent(binaryLoader, ent, managers.sceneManager.GetNameOfScene(ent));
                if (r != 0)
                {
                    MessageBox.Show("Could not write scene component", "Error: " + r.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             
            }
            var names = sceneViewWindow.GetDeletedScenes();
            fileRegisterWindow.RemoveFiles(names, "Scene");

            SavedEvent();
        }
    }
}
