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
                    EngineImporter.BinaryLoader_Wrapper bl = new EngineImporter.BinaryLoader_Wrapper();
                    long result = bl.InitLoader("test.dat", EngineImporter.LoaderMode.EDIT);
                    Assert.IsTrue(result == 0, "Could not init Loader");

                    string file = "Test File";
                    result = bl.Create("TestFile", "Test", Encoding.ASCII.GetBytes(file), 9);
                    Assert.IsTrue(result == 0, "Could not create TestFile, Error: " + result.ToString());

                    string file2 = "Test File2";
                    result = bl.Create("TestFile2", "Test", Encoding.ASCII.GetBytes(file2), 10);
                    Assert.IsTrue(result == 0, "Could not create TestFile2, Error: " + result.ToString());


                    Assert.IsTrue(bl.GetNumberOfFiles() == 2, "Not 2 files");
                    Assert.IsTrue(bl.GetNumberOfTypes() == 1, "Not 1 type");
                
                    Assert.IsTrue(bl.Exist("TestFile", "Test") == 1, "TestFile did not exist");
                    Assert.IsTrue(bl.Exist("TestFile2", "Test") == 1, "TestFile2 did not exist");

                    UInt64 size = 0;
                    Assert.IsTrue(bl.GetSizeOfFile("TestFile", "Test", ref size) == 0, "Could not get size of TestFile");
           
                    byte[] data = new byte[size];
                    Assert.IsTrue(bl.Read("TestFile", "Test", data, size) == 0, "Could not read TestFile");
                    Assert.IsTrue(Encoding.ASCII.GetString(data) == "Test File", "Data in TestFile was " + Encoding.ASCII.GetString(data));

                    size = 0;
                    Assert.IsTrue(bl.GetSizeOfFile("TestFile2", "Test", ref size) == 0, "Could not get size of TestFile2");
                    Assert.IsTrue(size == 10, "Size of TestFile was not 10");

                    data = new byte[size];
                    Assert.IsTrue(bl.Read("TestFile2", "Test", data, size) == 0, "Could not read TestFile2");
                    Assert.IsTrue(Encoding.ASCII.GetString(data) == "Test File2", "Data in TestFile2 was " + Encoding.ASCII.GetString(data));

                 

                    List<EngineImporter.LoaderFile> files;
                    result = bl.GetFiles(out files);
                    Assert.IsTrue(result == 0, "Could not get all files");
                    Assert.IsTrue(files.Count == 2, "Files count not 2");
                    Assert.IsTrue(files[0].guid_str == "TestFile", "files was not TestFile");
                    Assert.IsTrue(files[1].guid_str == "TestFile2", "files was not TestFile2");


                    result = bl.Destroy("TestFile", "Test");
                    Assert.IsTrue(result == 0, "Could not destroy TestFile");
                    Assert.IsTrue(bl.GetNumberOfFiles() == 1, "Number of files was not 1");
              

                    using (BinaryWriter writer = new BinaryWriter(File.Open("test.txt", FileMode.Create)))
                    {
                        writer.Write(1337);
                    }

                    result = bl.CreateFromFile("test.txt", "TestFileTxt", "Test");
                    Assert.IsTrue(result == 0, "Could not create from file");


                    Assert.IsTrue(bl.GetNumberOfFiles() == 2, "Files 2 before reinit");
                    bl.Shutdown();
                }
                {
                    EngineImporter.BinaryLoader_Wrapper bl = new EngineImporter.BinaryLoader_Wrapper();
                    var result = bl.InitLoader("test.dat", EngineImporter.LoaderMode.EDIT);
                    Assert.IsTrue(result == 0, "Could not reinit");

                    Assert.IsTrue(bl.GetNumberOfFiles() == 2, "No files after reinit");

                    UInt64 size = 0;
                    result = bl.GetSizeOfFile("TestFileTxt", "Test", ref size);
                    Assert.IsTrue(result == 0, "Could not get size of file");
                    Assert.IsTrue(size == sizeof(int), "Not size of int");
                    var data = new byte[size];
                    result = bl.Read("TestFileTxt", "Test", data, size);
                    int leet = 0;
                    leet = BitConverter.ToInt32(data, 0);
                    Assert.IsTrue(leet == 1337, "leet not 1337");
                    bl.Shutdown();
                }
            }
        }
    }
}
