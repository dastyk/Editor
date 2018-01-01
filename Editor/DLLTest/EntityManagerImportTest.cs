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
            DLLWrappers.Managers.EntityManager em = new DLLWrappers.Managers.EntityManager();

            var e = em.Create();
            em.Destroy(e);
        }
    }
}
