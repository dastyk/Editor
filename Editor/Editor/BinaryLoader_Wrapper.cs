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
        static extern Int32 InitLoader(UIntPtr loader, String filePath, int mode);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 CreateS(UIntPtr loader, String guid, String type, [In, MarshalAs(UnmanagedType.LPArray)] byte[] rdata, UInt64 size);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 GetNumberOfFiles(UIntPtr loader);
        [DllImport("ResourceHandler.dll")]
        static extern Int32 GetNumberOfTypes(UIntPtr loader);
        [DllImport("ResourceHandler.dll")]
        static extern Int64 GetTotalSizeOfAllFiles(UIntPtr loader);
        BinaryLoader_Wrapper(uint type)
        {
            loader = CreateLoader(type);
        }
        public Int32 InitLoader(String filePath, int mode)
        {
            return InitLoader(loader, filePath, mode);
        }
    }
}
