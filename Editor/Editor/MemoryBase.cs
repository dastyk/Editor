using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Editor
{
    public class MemoryBase
    {
        protected UIntPtr obj = UIntPtr.Zero;
        [DllImport("ECS.dll")]
        static extern void Delete_C(UIntPtr obj);

       public UIntPtr GetObj()
        {
            return obj;
        }

        ~MemoryBase()
        {
            if (obj != UIntPtr.Zero)
                Delete_C(obj);
        }
    }
}
