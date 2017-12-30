using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Editor
{
    using Entity = UInt32;
    public class ManagerBase : MemoryBase
    {
       
        [DllImport("ECS.dll")]
        static extern bool Manager_Base_IsRegistered_C(UIntPtr obj, Entity entity);
        [DllImport("ECS.dll")]
        static extern void Manager_Base_Destroy_C(UIntPtr obj, Entity entity);


        public bool IsRegistered(Entity entity)
        {
            return Manager_Base_IsRegistered_C(obj, entity);
        }

        public void Destroy(Entity ent)
        {
            Manager_Base_Destroy_C(obj, ent);
        }
    }
}
