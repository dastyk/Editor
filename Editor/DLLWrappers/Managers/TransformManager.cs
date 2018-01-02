using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace EngineImporter.Managers
{

    using Entity = UInt32;

    [StructLayout(LayoutKind.Sequential)]
    public class Vector
    {
        public float x = 0.0f, y = 0.0f, z = 0.0f;
    }
    public class TransformManager : ManagerBase
    {
        EntityManager entityManager;
        [StructLayout(LayoutKind.Sequential)]
        struct InitInfo
        {
            public UIntPtr entityManager { get; set; }
            public UIntPtr pNext { get; set; }
        }
       
        [DllImport("ECS.dll")]
        static extern UIntPtr TransformManager_CreateTransformManager_C(InitInfo ii);
        [DllImport("ECS.dll")]
        static extern void TransformManager_Create_C(UIntPtr tm, Entity ent, Vector pos, Vector rot, Vector scale);
        
        public TransformManager(EntityManager em)
        {
            entityManager = em;
            InitInfo ii = new InitInfo { entityManager = em.GetObj(), pNext = UIntPtr.Zero };
            obj = TransformManager_CreateTransformManager_C(ii);
            em.RegisterForDestroyNow(this);
        }
        public void Create(Entity ent)
        {
            TransformManager_Create_C(obj, ent, new Vector(), new Vector(), new Vector());
        }
    }
}
