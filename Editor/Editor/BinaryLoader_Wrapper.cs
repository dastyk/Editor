using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace Editor
{
    public enum LoaderMode
    {
        EDIT,
        READ
    }

    public struct LoaderFile
    {
        public UInt32 guid { get; set; }
        public UInt32 type { get; set; }
        public String guid_str { get; set; }
        public String type_str { get; set; }
    }
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

        //[StructLayout(LayoutKind.Sequential)]
        //struct FILE_C
        //{
        //    public UInt32 guid;
        //    public UInt32 type;
        //    public IntPtr guid_str;
        //    public IntPtr type_str;
        //};
        //[DllImport("ResourceHandler.dll")]
        //static extern Int32 GetFiles_C(UIntPtr loader, out IntPtr files, out UInt32 numfiles);

        public BinaryLoader_Wrapper()
        {
            loader = CreateLoader(0);
        }
        ~BinaryLoader_Wrapper()
        {
            DestroyLoader(loader);
        }
        public Int32 InitLoader(String filePath, LoaderMode mode)
        {
            return InitLoader_C(loader, filePath, (int)mode);
        }
        public Int32 Create(String guid, String type, byte[] data, UInt64 size)
        {
            return CreateS_C(loader, guid, type, data, size);
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
        public Int32 GetFiles(out List<LoaderFile> file_list)
        {
            IntPtr files = IntPtr.Zero;
            UInt32 numFiles = 0;
            Int32 result = 0;// GetFiles_C(loader, out files, out numFiles);
            file_list = new List<LoaderFile>();
            if (numFiles == 0)
            {
                
                return result;
            }
            
         //   var dataEntrySize = Marshal.SizeOf(typeof(FILE_C));
            //var arrayValue = files;
            //for (var i = 0; i < numFiles; i++)
            //{
            //    FILE_C cur = (FILE_C)Marshal.PtrToStructure(arrayValue, typeof(FILE_C));
            //    LoaderFile lf = new LoaderFile { guid = cur.guid, type = cur.type };
            //    lf.guid_str = Marshal.PtrToStringUni(cur.guid_str);
            //    Marshal.FreeCoTaskMem(cur.guid_str);
            //    lf.type_str = Marshal.PtrToStringUni(cur.type_str);
            //    Marshal.FreeCoTaskMem(cur.type_str);
            //    file_list.Add(lf);

            //    arrayValue = new IntPtr(arrayValue.ToInt32() + dataEntrySize);
            //}
            //Marshal.FreeCoTaskMem(files);
            return result;
        }
    }

}
