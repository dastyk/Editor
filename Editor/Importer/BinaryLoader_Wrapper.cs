﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace Importer
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
        static extern UIntPtr CreateFileSystem(uint type);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C InitLoader_C(UIntPtr loader, String filePath, int mode);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C DestroyLoader(UIntPtr loader);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C CreateS_C(UIntPtr loader, String guid, String type, [In, MarshalAs(UnmanagedType.LPArray)] byte[] rdata, UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C CreateFromFile_C(UIntPtr loader, String path, String guid, String type);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C ReadS_C(UIntPtr loader, String guid, String type, [In, MarshalAs(UnmanagedType.LPArray)] byte[] rdata, UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C Read_C(UIntPtr loader, UInt32 guid, UInt32 type, [In, MarshalAs(UnmanagedType.LPArray)] byte[] rdata, UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C Destroy_C(UIntPtr loader, UInt32 guid, UInt32 type);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C DestroyS_C(UIntPtr loader, String guid, String type);
        [DllImport("ResourceHandler.dll")]
        static extern UInt32 GetNumberOfFiles_C(UIntPtr loader);
        [DllImport("ResourceHandler.dll")]
        static extern UInt32 GetNumberOfTypes_C(UIntPtr loader);
        [DllImport("ResourceHandler.dll")]
        static extern UInt32 GetNumberOfFilesOfType_C(UIntPtr loader, String type);
        [DllImport("ResourceHandler.dll")]
        static extern UInt64 GetTotalSizeOfAllFiles_C(UIntPtr loader);
        [DllImport("ResourceHandler.dll")]
        static extern bool Exist_C(UIntPtr loader, UInt32 guid, UInt32 type);
        [DllImport("ResourceHandler.dll")]
        static extern bool ExistS_C(UIntPtr loader, String guid, String type);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C GetSizeOfFile_C(UIntPtr loader, UInt32 guid, UInt32 type, ref UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C GetSizeOfFileS_C(UIntPtr loader, String guid, String type, ref UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C Defrag_C(UIntPtr loader);

        [StructLayout(LayoutKind.Sequential)]
        struct FILE_C
        {
            public UInt32 guid;
            public UInt32 type;
            public IntPtr guid_str;
            public IntPtr type_str;
            //public FILE_C()
            //{
            //    guid = 0;
            //    type = 0;
            //    guid_str = new StringBuilder(512);
            //    type_str = new StringBuilder(512);
            //}
           
        };
        [DllImport("ResourceHandler.dll")]
        static extern Error_C GetFiles_C(UIntPtr loader, IntPtr files, UInt32 numfiles);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C GetFile_C(UIntPtr loader, ref FILE_C file, String name, String type);
        [DllImport("ResourceHandler.dll")]
        static extern Error_C GetFilesOfType_C(UIntPtr loader, String type, IntPtr files, UInt32 numfiles);
        [DllImport("ResourceHandler.dll")]
        static extern float GetFragmentationRatio_C(UIntPtr loader);


      
        public BinaryLoader_Wrapper()
        {
            loader = UIntPtr.Zero;
            loader = CreateFileSystem(0);
        }
        public void Reset()
        {
            DestroyLoader(loader);
            loader = UIntPtr.Zero;
            loader = CreateFileSystem(0);

        }
        ~BinaryLoader_Wrapper()
        {
            if (loader != UIntPtr.Zero)
                DestroyLoader(loader);
        }
        public UIntPtr GetLoader()
        {
            return loader;
        }
        public Error InitLoader(String filePath, LoaderMode mode)
        {
            return InitLoader_C(loader, filePath, (int)mode);
         
        }
        public Error Shutdown()
        {
            var r = DestroyLoader(loader);
            loader = UIntPtr.Zero;
            return r;
        }
        public Error Create(String guid, String type, byte[] data, UInt64 size)
        {
            return CreateS_C(loader, guid, type, data, size);
        }
        public Error CreateFromFile(String path, String guid, String type)
        {
            return CreateFromFile_C(loader, path, guid, type);
        }
        public Error Destroy(UInt32 guid, UInt32 type)
        {
            return Destroy_C(loader, guid, type);
        }
        public Error Destroy(String guid, String type)
        {
            return DestroyS_C(loader, guid, type);
        }
        public UInt32 GetNumberOfFiles()
        {
            return GetNumberOfFiles_C(loader);
        }
        public UInt32 GetNumberOfTypes()
        {
            return GetNumberOfTypes_C(loader);
        }
        public UInt64 GetTotalSizeOfAllFiles()
        {
            return GetTotalSizeOfAllFiles_C(loader);
        }
        public bool Exist(UInt32 guid, UInt32 type)
        {
            return Exist_C(loader, guid, type);
        }
        public bool Exist(String guid, String type)
        {
            return ExistS_C(loader, guid, type);
        }
        public Error GetSizeOfFile(UInt32 guid, UInt32 type, ref UInt64 size)
        {
            return GetSizeOfFile_C(loader, guid, type, ref size);
        }
        public Error GetSizeOfFile(String guid, String type, ref UInt64 size)
        {
            return GetSizeOfFileS_C(loader, guid, type, ref size);
        }
        public Error Read(UInt32 guid, UInt32 type, byte[] data, UInt64 size)
        {
            return Read_C(loader, guid, type, data, size);
        }
        public Error Read(String guid, String type, byte[] data, UInt64 size)
        {
            return ReadS_C(loader, guid, type, data, size);
        }
        public Error Defrag()
        {
            return Defrag_C(loader);
        }
        public Error GetFiles(out List<LoaderFile> file_list)
        {
            var numFiles = GetNumberOfFiles();
            FILE_C[] files = new FILE_C[numFiles];
            var result = GetFiles_C(loader, Marshal.UnsafeAddrOfPinnedArrayElement(files, 0), numFiles);
            file_list = new List<LoaderFile>();
            if (result.errornr != 469503388u) // 469503388u == "Success"_hash
                return result;
            for (UInt32 i = 0; i < numFiles; i++)
            {
                file_list.Add(new LoaderFile
                {
                    guid = files[i].guid,
                    guid_str = Marshal.PtrToStringAnsi(files[i].guid_str),
                    type = files[i].type,
                    type_str = Marshal.PtrToStringAnsi(files[i].type_str)
                });
            }
            return result;
        }
        public Error GetFile(out LoaderFile file, String name, String type)
        {
            FILE_C cFile = new FILE_C();
            var r = GetFile_C(loader, ref cFile, name, type);
            if (r.errornr != 0)
            {
                file = new LoaderFile();
                return r;
            }
               
            file = new LoaderFile
            {
                guid =cFile.guid,
                guid_str = Marshal.PtrToStringAnsi(cFile.guid_str),
                type =cFile.type,
                type_str = Marshal.PtrToStringAnsi(cFile.type_str)
            };
            return r;
        }
        public UInt32 GetNumberOfFilesOfType(String type)
        {
            return GetNumberOfFilesOfType_C(loader, type);
        }

        public Error GetFilesOfType(String type, out List<LoaderFile> file_list)
        {
            var numFiles = GetNumberOfFilesOfType(type);
            FILE_C[] files = new FILE_C[numFiles];
            var result = GetFilesOfType_C(loader, type, Marshal.UnsafeAddrOfPinnedArrayElement(files, 0), numFiles);
            file_list = new List<LoaderFile>();
            if (result.errornr != 0)
                return result;
         
            for (UInt32 i = 0; i < numFiles; i++)
            {
                file_list.Add(new LoaderFile
                {
                    guid = files[i].guid,
                    guid_str = Marshal.PtrToStringAnsi(files[i].guid_str),
                    type = files[i].type,
                    type_str = Marshal.PtrToStringAnsi(files[i].type_str)
                });
            }
            return result;
        }

        public float GetFragmentationRatio()
        {
            return GetFragmentationRatio_C(loader);
        }
    }

}
