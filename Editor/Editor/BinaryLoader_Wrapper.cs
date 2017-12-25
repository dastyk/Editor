using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace Editor
{
    public class BinaryLoader_Wrapper
    {
        UIntPtr loader;
        [DllImport("ResourceHandler.dll")]
        static extern UIntPtr CreateLoader(uint type);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 InitLoader_C(UIntPtr loader, String filePath, int mode);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 DestroyLoader(UIntPtr loader);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 CreateS_C(UIntPtr loader, String guid, String type, [In, MarshalAs(UnmanagedType.LPArray)] byte[] rdata, UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 Create_C(UIntPtr loader, UInt32 guid, UInt32 type, [In, MarshalAs(UnmanagedType.LPArray)] byte[] rdata, UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 ReadS_C(UIntPtr loader, String guid, String type, [In, MarshalAs(UnmanagedType.LPArray)] byte[] rdata, UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 Read_C(UIntPtr loader, UInt32 guid, UInt32 type, [In, MarshalAs(UnmanagedType.LPArray)] byte[] rdata, UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 Destroy_C(UIntPtr loader, UInt32 guid, UInt32 type);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 DestroyS_C(UIntPtr loader, String guid, String type);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 GetNumberOfFiles_C(UIntPtr loader);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 GetNumberOfTypes_C(UIntPtr loader);
        [DllImport("ResourceHandler.dll")]
        static extern Int64 GetTotalSizeOfAllFiles_C(UIntPtr loader);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 Exist_C(UIntPtr loader, UInt32 guid, UInt32 type);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 ExistS_C(UIntPtr loader, String guid, String type);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 GetSizeOfFile_C(UIntPtr loader, UInt32 guid, UInt32 type, ref UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 GetSizeOfFileS_C(UIntPtr loader, String guid, String type, ref UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 Defrag_C(UIntPtr loader);
        public BinaryLoader_Wrapper()
        {
            loader = CreateLoader(0);
        }
        ~BinaryLoader_Wrapper()
        {
            DestroyLoader(loader);
        }
        public Int32 InitLoader(String filePath, int mode)
        {
            return InitLoader_C(loader, filePath, mode);
        }
        public Int32 Create(String guid, String type, byte[] data, UInt64 size)
        {
            return CreateS_C(loader, guid, type, data, size);
        }
        public Int32 Create(UInt32 guid, UInt32 type, byte[] data, UInt64 size)
        {
            return Create_C(loader, guid, type, data, size);
        }
        public Int32 Destroy(UInt32 guid, UInt32 type)
        {
            return Destroy_C(loader, guid, type);
        }
        public Int32 Destroy(String guid, String type)
        {
            return DestroyS_C(loader, guid, type);
        }
        public Int32 GetNumberOfFiles()
        {
            return GetNumberOfFiles_C(loader);
        }
        public Int32 GetNumberOfTypes()
        {
            return GetNumberOfTypes_C(loader);
        }
        public Int64 GetTotalSizeOfAllFiles()
        {
            return GetTotalSizeOfAllFiles_C(loader);
        }
        public Int32 Exist(UInt32 guid, UInt32 type)
        {
            return Exist_C(loader, guid, type);
        }
        public Int32 Exist(String guid, String type)
        {
            return ExistS_C(loader, guid, type);
        }
        public Int32 GetSizeOfFile(UInt32 guid, UInt32 type, ref UInt64 size)
        {
            return GetSizeOfFile_C(loader, guid, type, ref size);
        }
        public Int32 GetSizeOfFile(String guid, String type, ref UInt64 size)
        {
            return GetSizeOfFileS_C(loader, guid, type, ref size);
        }
        public Int32 Read(UInt32 guid, UInt32 type, byte[] data, UInt64 size)
        {
            return Read_C(loader, guid, type, data, size);
        }
        public Int32 Read(String guid, String type, byte[] data, UInt64 size)
        {
            return ReadS_C(loader, guid, type, data, size);
        }
        public Int32 Defrag()
        {
            return Defrag_C(loader);
        }
    }

}
