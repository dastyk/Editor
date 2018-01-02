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
    public struct Vector
    {
        public float x, y, z;
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
        [DllImport("ECS.dll")]
        static extern void TransformManager_SetPosition_C(UIntPtr tm, Entity ent, Vector pos);
        [DllImport("ECS.dll")]
        static extern Vector TransformManager_GetPosition_C(UIntPtr tm, Entity ent);
        [DllImport("ECS.dll")]
        static extern void TransformManager_SetRotation_C(UIntPtr tm, Entity ent, Vector rot);
        [DllImport("ECS.dll")]
        static extern void TransformManager_GetRotation_NoReturn_C(UIntPtr tm, Entity ent, ref Vector rot);
        [DllImport("ECS.dll")]
        static extern void TransformManager_SetScale_C(UIntPtr tm, Entity ent, Vector scale);
        [DllImport("ECS.dll")]
        static extern void TransformManager_GetScale_NoReturn_C(UIntPtr tm, Entity ent, ref Vector scale);

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
        public void SetPosition(Entity ent, Vector pos)
        {
            TransformManager_SetPosition_C(obj, ent, pos);
        }
        public Vector GetPosition(Entity ent)
        {
            return TransformManager_GetPosition_C(obj, ent);
        }
        public void SetRotation(Entity ent, Vector rot)
        {
            TransformManager_SetRotation_C(obj, ent, rot);
        }
        public Vector GetRotation(Entity ent)
        {
            Vector rot = new Vector();
            TransformManager_GetRotation_NoReturn_C(obj, ent, ref rot);
            return rot;
        }
        public void SetScale(Entity ent, Vector scale)
        {
            TransformManager_SetScale_C(obj, ent, scale);
        }
        public Vector GetScale(Entity ent)
        {
            Vector scale = new Vector();
            TransformManager_GetScale_NoReturn_C(obj, ent, ref scale);
            return scale;
        }
    }
}
