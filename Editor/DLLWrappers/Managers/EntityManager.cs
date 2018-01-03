using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace EngineImporter.Managers
{
    using Entity = UInt32;
    public class EntityManager : MemoryBase
    {
        [DllImport("ECS.dll")]
        static extern UIntPtr EntityManager_CreateEntityManager_C();
        [DllImport("ECS.dll")]
        static extern Entity EntityManager_Create_C(UIntPtr obj);
        [DllImport("ECS.dll")]
        static extern void EntityManager_Destroy_C(UIntPtr obj, Entity ent);
        [DllImport("ECS.dll")]
        static extern void EntityManager_DestroyNow_C(UIntPtr obj, Entity ent);
        [DllImport("ECS.dll")]
        static extern void EntityManager_DestroyAll_C(UIntPtr obj, bool immediate);
        [DllImport("ECS.dll")]
        static extern void EntityManager_RegisterManagerForDestroyNow_C(UIntPtr obj, UIntPtr mb);

        
        public EntityManager()
        {
            obj = EntityManager_CreateEntityManager_C();
        }
        public Entity Create()
        {
            return EntityManager_Create_C(obj);
        }
        public void Destroy(Entity entity)
        {
            EntityManager_Destroy_C(obj, entity);
        }
        public void DestroyNow(Entity entity)
        {
            EntityManager_DestroyNow_C(obj, entity);
        }
        public void RegisterForDestroyNow(ManagerBase manager)
        {
            EntityManager_RegisterManagerForDestroyNow_C(obj, manager.GetObj());
        }
        public void DestroyAll(bool immediate)
        {
            EntityManager_DestroyAll_C(obj, immediate);
        }
    }
}
