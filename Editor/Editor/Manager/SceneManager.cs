using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Editor
{
    using Entity = UInt32;
    public class SceneManager : ManagerBase
    {
       
        EntityManager entityManager;
        [StructLayout(LayoutKind.Sequential)]
        struct InitInfo
        {
            public UIntPtr entityManager { get; set; }
            public UIntPtr pNext { get; set; }
        }

        [DllImport("ECS.dll")]
        static extern UIntPtr SceneManager_CreateSceneManager_C(InitInfo ii);
        [DllImport("ECS.dll")]
        static extern void SceneManager_Create_C(UIntPtr obj, Entity ent, String name);
        [DllImport("ECS.dll")]
        static extern void SceneManager_AddEntityToScene_C(UIntPtr obj, Entity scene, Entity entity);

        public SceneManager(EntityManager em)
        {
            entityManager = em;
            InitInfo ii = new InitInfo { entityManager = em.GetObj(), pNext = UIntPtr.Zero };
            obj = SceneManager_CreateSceneManager_C(ii);
        }
        public void Create(Entity entity, String name)
        {
            SceneManager_Create_C(obj, entity, name);
        }
        public void AddEntityToScene(Entity scene, Entity entity)
        {
            SceneManager_AddEntityToScene_C(obj, scene, entity);
        }
    }
}
