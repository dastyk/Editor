using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DLLTest
{
    [TestClass]
    public class TransformManagerImportTest
    {
        [TestMethod]
        public void TransformManagerImport_Basic()
        {
            var em = new Editor.EntityManager();
            var tm = new Editor.Manager.TransformManager(em);

            var e = em.Create();
            tm.Create(e);
            tm.IsRegistered(e);
            tm.Destroy(e);
        }
    }
}
