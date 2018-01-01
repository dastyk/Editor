using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace DLLWrappers.Managers
{
    using Entity = UInt32;
    public class EntityInfo
    {
        public String name;
        public Entity entity;
    }
    public class SceneManager : ManagerBase
    {
       
        EntityManager entityManager;
        [StructLayout(LayoutKind.Sequential)]
        struct InitInfo
        {
            public UIntPtr entityManager { get; set; }
            public UIntPtr transformManager { get; set; }
            public UIntPtr pNext { get; set; }
        }

        [DllImport("ECS.dll")]
        static extern UIntPtr SceneManager_CreateSceneManager_C(InitInfo ii);
        [DllImport("ECS.dll")]
        static extern void SceneManager_Create_C(UIntPtr obj, Entity ent, String name);
        [DllImport("ECS.dll")]
        static extern void SceneManager_AddNamedEntityToScene_C(UIntPtr obj, Entity scene, Entity entity, String name);
        [DllImport("ECS.dll")]
        static extern void SceneManager_GetNameOfEntityInScene_C(UIntPtr obj, Entity scene, Entity entity, String name);
        [DllImport("ECS.dll")]
        static extern IntPtr SceneManager_GetNameOfEntityInScene_C(UIntPtr obj, Entity scene, Entity entity);
        [DllImport("ECS.dll")]
        static extern void SceneManager_GetEntitiesInScene_C(UIntPtr obj, Entity scene, IntPtr entities);
        [DllImport("ECS.dll")]
        static extern UInt32 SceneManager_GetNumberOfEntitiesInScene_C(UIntPtr obj, Entity scene);
        [DllImport("ECS.dll")]
        static extern IntPtr SceneManager_GetNameOfScene_C(UIntPtr obj, Entity scene);
        [DllImport("ECS.dll")]
        static extern UInt32 SceneManager_GetNumberOfChildResourcesOfSceneResource_C(UIntPtr obj, UInt32 guid);
        [DllImport("ECS.dll")]
        static extern void SceneManager_GetChildResourcesOfSceneResource_C(UIntPtr obj, UInt32 guid, UInt32[] arr, UInt32 numResources);
        [DllImport("ECS.dll")]
        static extern void SceneManager_RegisterManager_C(UIntPtr obj, UIntPtr mb);


        public SceneManager(EntityManager em, TransformManager tm)
        {
            entityManager = em;
            InitInfo ii = new InitInfo { entityManager = em.GetObj(), transformManager = tm.GetObj(), pNext = UIntPtr.Zero };
            obj = SceneManager_CreateSceneManager_C(ii);
            SceneManager_RegisterManager_C(obj, tm.GetObj());
        }
        public void Create(Entity entity, String name)
        {
            SceneManager_Create_C(obj, entity, name);
        }
        public void AddEntityToScene(Entity scene, Entity entity, String name)
        {
            SceneManager_AddNamedEntityToScene_C(obj, scene, entity, name);
        }
        public EntityInfo[] GetEntitiesInScene(Entity scene)
        {
            var numEnts = SceneManager_GetNumberOfEntitiesInScene_C(obj, scene);
            var entInfo = new EntityInfo[numEnts];
            var ents = new Entity[numEnts];
            SceneManager_GetEntitiesInScene_C(obj, scene, Marshal.UnsafeAddrOfPinnedArrayElement(ents, 0));
            for (int i = 0; i < numEnts; i++)
            {
                entInfo[i] = new EntityInfo {
                    name = Marshal.PtrToStringAnsi(SceneManager_GetNameOfEntityInScene_C(obj, scene, ents[i])),
                    entity = ents[i]};
            }
            return entInfo;
        }

        public String GetNameOfScene(Entity scene)
        {

            return Marshal.PtrToStringAnsi(SceneManager_GetNameOfScene_C(obj, scene));
         
        }

        public UInt32[] GetChildResourcesOfSceneResource(UInt32 guid)
        {
            UInt32 numR = SceneManager_GetNumberOfChildResourcesOfSceneResource_C(obj, guid);
            var res = new UInt32[numR];
            SceneManager_GetChildResourcesOfSceneResource_C(obj, guid, res, numR);
            return res;
        }
    }
}
