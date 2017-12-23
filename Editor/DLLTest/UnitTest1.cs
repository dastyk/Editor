using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DLLTest
{
    [TestClass]
    public class UnitTest1
    {
        [DllImport("ResourceHandler.dll")]
        static extern UIntPtr CreateLoader(uint type);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 InitLoader(UIntPtr loader, String filePath, int mode);
        [TestMethod]
        public void TestMethod1()
        {
            UIntPtr bl;
            bl = CreateLoader(0);
            Assert.IsNotNull(bl, "Could not create binary loader");
            long result = InitLoader(bl, "test.dat", 0);
            Assert.IsTrue(result == 0, "Could not init Loader");
        }
    }
}
