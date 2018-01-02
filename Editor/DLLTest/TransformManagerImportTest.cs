﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DLLTest
{
    [TestClass]
    public class TransformManagerImportTest
    {
        [TestMethod]
        public void TransformManagerImport_Basic()
        {
            var em = new EngineImporter.Managers.EntityManager();
            var tm = new EngineImporter.Managers.TransformManager(em);

            var e = em.Create();
            tm.Create(e);
            tm.IsRegistered(e);
            tm.Destroy(e);
        }
    }
}