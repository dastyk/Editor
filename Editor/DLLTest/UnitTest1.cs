using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;
namespace DLLTest
{
    [TestClass]
    public class UnitTest1
    {
       

        [TestMethod]
        public void TestMethod1()
        {
            File.Delete("test.dat");
            {
                UIntPtr bl;
                bl = CreateLoader(0);
                Assert.IsNotNull(bl, "Could not create binary loader");
                long result = InitLoader(bl, "test.dat", 0);
                Assert.IsTrue(result == 0, "Could not init Loader");

                string file = "Test File";
                result = CreateS(bl, "TestFile", "Test", Encoding.ASCII.GetBytes(file), 9);
                Assert.IsTrue(result == 0, "Could not create TestFile, Error: " + result.ToString());
                string file2 = "Test File2";
                result = CreateS(bl, "TestFile2", "Test", Encoding.ASCII.GetBytes(file2), 10);
                Assert.IsTrue(result == 0, "Could not create TestFile2, Error: " + result.ToString());
                Assert.IsTrue(GetNumberOfFiles(bl) == 2, "Not 2 files");
                Assert.IsTrue(GetNumberOfTypes(bl) == 1, "Not 1 type");
                Assert.IsTrue(GetTotalSizeOfAllFiles(bl) == 19, "Total size was not 19");
            }
        }
    }
}
