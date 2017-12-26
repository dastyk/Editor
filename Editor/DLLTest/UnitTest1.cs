using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;
using System.Collections.Generic;
namespace DLLTest
{
    [TestClass]
    public class UnitTest1
    {
       

        [TestMethod]
        public void BinaryLoader_Wrapper_DLLImport_Test()
        {
            File.Delete("test.dat");
            {

                Editor.BinaryLoader_Wrapper bl = new Editor.BinaryLoader_Wrapper();
                long result = bl.InitLoader("test.dat", Editor.LoaderMode.EDIT);
                Assert.IsTrue(result == 0, "Could not init Loader");

                string file = "Test File";
                result = bl.Create("TestFile", "Test", Encoding.ASCII.GetBytes(file), 9);
                Assert.IsTrue(result == 0, "Could not create TestFile, Error: " + result.ToString());

                string file2 = "Test File2";
                result = bl.Create("TestFile2", "Test", Encoding.ASCII.GetBytes(file2), 10);
                Assert.IsTrue(result == 0, "Could not create TestFile2, Error: " + result.ToString());
               
               
                Assert.IsTrue(bl.GetNumberOfFiles() == 2, "Not 2 files");
                Assert.IsTrue(bl.GetNumberOfTypes() == 1, "Not 1 type");
                Assert.IsTrue(bl.GetTotalSizeOfAllFiles() == 19, "Total size was not 19");

                Assert.IsTrue(bl.Exist("TestFile", "Test") == 1, "TestFile did not exist");
                Assert.IsTrue(bl.Exist("TestFile2", "Test") == 1, "TestFile2 did not exist");

                UInt64 size = 0;
                Assert.IsTrue(bl.GetSizeOfFile("TestFile", "Test", ref size) == 0, "Could not get size of TestFile");
                Assert.IsTrue(size == 9, "Size of TestFile was not 9");
            
                byte[] data = new byte[size];
                Assert.IsTrue(bl.Read("TestFile", "Test", data, size) == 0, "Could not read TestFile");
                Assert.IsTrue(Encoding.ASCII.GetString(data) == "Test File", "Data in TestFile was " + Encoding.ASCII.GetString(data));

                 size = 0;
                Assert.IsTrue(bl.GetSizeOfFile("TestFile2", "Test", ref size) == 0, "Could not get size of TestFile2");
                Assert.IsTrue(size == 10, "Size of TestFile was not 10");

                data = new byte[size];
                Assert.IsTrue(bl.Read("TestFile2", "Test", data, size) == 0, "Could not read TestFile2");
                Assert.IsTrue(Encoding.ASCII.GetString(data) == "Test File2", "Data in TestFile2 was " + Encoding.ASCII.GetString(data));

                Assert.IsTrue(bl.GetTotalSizeOfAllFiles() == 19, "Total size of all files was not 19");


                List<Editor.LoaderFile> files;
                result = bl.GetFiles(out files);
                Assert.IsTrue(result == 0, "Could not get all files");
                Assert.IsTrue(files.Count == 2, "Files count not 2");
                Assert.IsTrue(files[0].guid_str == "TestFile", "files was not TestFile");
                Assert.IsTrue(files[1].guid_str == "TestFile2", "files was not TestFile2");


                result = bl.Destroy("TestFile", "Test");
                Assert.IsTrue(result == 0, "Could not destroy TestFile");
                Assert.IsTrue(bl.GetNumberOfFiles() == 1, "Number of files was not 1");
                Assert.IsTrue(bl.GetTotalSizeOfAllFiles() == 10, "Total size of all fiels was not 10 after deleting TestFile");



                using (BinaryWriter writer = new BinaryWriter(File.Open("test.txt", FileMode.Create)))
                {
                    writer.Write(1337);
                }

                result = bl.CreateFromFile("test.txt", "TestFileTxt", "Test");
                Assert.IsTrue(result == 0, "Could not create from file");
                size = 0;
                result = bl.GetSizeOfFile("TestFileTxt", "Test", ref size);
                Assert.IsTrue(size == sizeof(int), "Not size of int");
                data = new byte[size];

                result = bl.Read("TestFileTxt", "Test", data, size);
                int leet = 0;
                leet = BitConverter.ToInt32(data, 0);
                Assert.IsTrue(leet == 1337, "leet not 1337");

            }
        }
    }
}
