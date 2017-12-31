using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;
using System.Collections.Generic;
namespace DLLTest
{
    [TestClass]
    public class EntityManagerImportTest
    {


        [TestMethod]
        public void EntityManagerImport_Basic()
        {
            Editor.EntityManager em = new Editor.EntityManager();

            var e = em.Create();
            em.Destroy(e);
        }
    }
}
