using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace DLLTest
{
    [TestClass]
    public class BinaryLoaderWrapperTest
    {
       

        [TestMethod]
        public void BinaryLoader_Wrapper_DLLImport_Test()
        {
            File.Delete("test.dat");
            {
                {
                    Importer.BinaryLoader_Wrapper bl = new Importer.BinaryLoader_Wrapper();
                    var result = bl.InitLoader("test.dat", Importer.LoaderMode.EDIT);
                    Assert.AreEqual(469503388u, result.errornr, "Could not init Loader");

                    string file = "Test File";
                    result = bl.Create("TestFile", "Test", Encoding.ASCII.GetBytes(file), 9);
                   Assert.AreEqual(469503388u, result.errornr, "Could not create TestFile, Error: " + result.ToString());

                    string file2 = "Test File2";
                    result = bl.Create("TestFile2", "Test", Encoding.ASCII.GetBytes(file2), 10);
                    Assert.AreEqual(469503388u, result.errornr, "Could not create TestFile2, Error: " + result.ToString());


                    Assert.AreEqual(2u, bl.GetNumberOfFiles(), "Not 2 files");
                    Assert.AreEqual(1u, bl.GetNumberOfTypes(), "Not 1 type");

                    Assert.IsTrue(bl.Exist("TestFile", "Test"), "TestFile did not exist");
                    Assert.IsTrue(bl.Exist("TestFile2", "Test"), "TestFile2 did not exist");

                    UInt64 size = 0;
                    Assert.AreEqual(469503388u, bl.GetSizeOfFile("TestFile", "Test", ref size).errornr , "Could not get size of TestFile");
           
                    byte[] data = new byte[size];
                    Assert.AreEqual(469503388u, bl.Read("TestFile", "Test", data, size).errornr, "Could not read TestFile");
                    Assert.AreEqual("Test File", Encoding.ASCII.GetString(data));

                    size = 0;
                    Assert.AreEqual(469503388u, bl.GetSizeOfFile("TestFile2", "Test", ref size).errornr, "Could not get size of TestFile2");
                    Assert.AreEqual(10u, size, "Size of TestFile was not 10");

                    data = new byte[size];
                    Assert.AreEqual(469503388u, bl.Read("TestFile2", "Test", data, size).errornr, "Could not read TestFile2");
                    Assert.AreEqual("Test File2", Encoding.ASCII.GetString(data));


                    Assert.AreEqual(2u, bl.GetNumberOfFiles(), "Not 2 files");
                    Assert.AreEqual(1u, bl.GetNumberOfTypes(), "Not 1 type");

                    Assert.IsTrue(bl.Exist("TestFile", "Test"), "TestFile did not exist");
                    Assert.IsTrue(bl.Exist("TestFile2", "Test"), "TestFile2 did not exist");

                    List<Importer.LoaderFile> files;
                    result = bl.GetFiles(out files);
                    Assert.AreEqual(469503388u, result.errornr, "Could not get all files");
                    Assert.AreEqual(2, files.Count);
                    Assert.AreEqual("TestFile",  files[0].guid_str);
                    Assert.AreEqual("TestFile2", files[1].guid_str);


                    result = bl.Destroy("TestFile", "Test");
                    Assert.AreEqual(469503388u, result.errornr, "Could not destroy TestFile");
                    Assert.AreEqual(1u, bl.GetNumberOfFiles());
              

                    using (BinaryWriter writer = new BinaryWriter(File.Open("test.txt", FileMode.Create)))
                    {
                        writer.Write(1337);
                    }

                    result = bl.CreateFromFile("test.txt", "TestFileTxt", "Test");
                   Assert.AreEqual(469503388u, result.errornr, "Could not create from file");


                    Assert.AreEqual(2u, bl.GetNumberOfFiles(), "Files 2 before reinit");
                    bl.Shutdown();
                }
                {
                    Importer.BinaryLoader_Wrapper bl = new Importer.BinaryLoader_Wrapper();
                    var result = bl.InitLoader("test.dat", Importer.LoaderMode.EDIT);
                   Assert.AreEqual(469503388u, result.errornr, "Could not reinit");

                    Assert.AreEqual(2u, bl.GetNumberOfFiles(), "No files after reinit");

                    UInt64 size = 0;
                    result = bl.GetSizeOfFile("TestFileTxt", "Test", ref size);
                   Assert.AreEqual(469503388u, result.errornr, "Could not get size of file");
                    Assert.AreEqual(Convert.ToUInt64(sizeof(int)), size);
                    var data = new byte[size];
                    result = bl.Read("TestFileTxt", "Test", data, size);
                    int leet = 0;
                    leet = BitConverter.ToInt32(data, 0);
                    Assert.AreEqual(1337, leet);
                    bl.Shutdown();
                }
            }
        }
    }
}
