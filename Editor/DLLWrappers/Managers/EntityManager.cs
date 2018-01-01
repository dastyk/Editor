using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DLLWrappers.Managers
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
    }
}
