using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DLLTest
{
    [TestClass]
    public class SceneManagerImportTest
    {
        [TestMethod]
        public void SceneManagerImport_Basic()
        {
            var em = new Importer.Managers.EntityManager();
            var tm = new Importer.Managers.TransformManager(em);
            var sm = new Importer.Managers.SceneManager(em, tm);

            var e = em.Create();
            sm.Create(e, "Name");
            sm.IsRegistered(e);
            var ne = em.Create();
            sm.AddEntityToScene(e, ne, "Entity");
        }
    }
}
