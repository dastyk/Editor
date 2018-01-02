using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace EngineImporter.Managers
{
    using Entity = UInt32;
    public class ManagerBase : MemoryBase
    {
       
        [DllImport("ECS.dll")]
        static extern bool Manager_Base_IsRegistered_C(UIntPtr obj, Entity entity);
        [DllImport("ECS.dll")]
        static extern void Manager_Base_Destroy_C(UIntPtr obj, Entity entity);
        [DllImport("ECS.dll")]
        static extern void Manager_Base_CreateFromResourceG_C(UIntPtr obj, Entity entity, UInt32 guid, UInt32 type);
        [DllImport("ECS.dll")]
        static extern void Manager_Base_CreateFromResource_C(UIntPtr obj, Entity entity, String guid, String type);
        [DllImport("ECS.dll")]
        static extern UInt32 Manager_Base_GetNumberOfRegisteredEntities_C(UIntPtr obj);
        [DllImport("ECS.dll")]
        static extern void Manager_Base_GetRegisteredEntities_C(UIntPtr obj, IntPtr entities, UInt32 numEntities);
        [DllImport("ECS.dll")]
        static extern long Manager_Base_WriteComponent_C(UIntPtr obj, UIntPtr loader, Entity entity, String name, String type);
 
        public bool IsRegistered(Entity entity)
        {
            return Manager_Base_IsRegistered_C(obj, entity);
        }

        public void Destroy(Entity ent)
        {
            Manager_Base_Destroy_C(obj, ent);
        }
        public void Create(Entity ent, UInt32 guid, UInt32 type)
        {
            Manager_Base_CreateFromResourceG_C(obj, ent, guid, type);
        }
        public void Create(Entity ent, String guid, String type)
        {
            Manager_Base_CreateFromResource_C(obj, ent, guid, type);
        }

        public Entity[] GetRegisteredEntities()
        {
            UInt32 numEnts = Manager_Base_GetNumberOfRegisteredEntities_C(obj);
            var ents = new Entity[numEnts];

            Manager_Base_GetRegisteredEntities_C(obj, Marshal.UnsafeAddrOfPinnedArrayElement(ents, 0), numEnts);

            return ents;
        }
        public long WriteComponent(EngineImporter.BinaryLoader_Wrapper loader, Entity ent, String name, String type)
        {
           return  Manager_Base_WriteComponent_C(obj, loader.GetLoader(), ent, name, type);
        }
      

    }
}
