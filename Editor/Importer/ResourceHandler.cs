using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Importer
{
    public enum MemoryType : byte
    {
        RAM,
        VRAM
    }
    public class ResourceHandler
    {
        UIntPtr obj;
        UIntPtr threadPool;
        BinaryLoader_Wrapper loader;

        [DllImport("ResourceHandler.dll")]
        static extern UIntPtr CreateThreadPool(UInt32 numThreads);
        [DllImport("ResourceHandler.dll")]
        static extern UIntPtr CreateResourceHandler(UIntPtr loader, UIntPtr tp);
        [DllImport("ResourceHandler.dll")]
        static extern void DestroyThreadPool(UIntPtr tp);
        [DllImport("ResourceHandler.dll")]
        static extern UIntPtr DestroyResourceHandler(UIntPtr rh);
        [DllImport("ResourceHandler.dll")]
        static extern File_Error_C ResourceHandler_CreateType(UIntPtr rh, String type, MemoryType memoryType, String passthrough);

        public ResourceHandler(BinaryLoader_Wrapper l)
        {
            loader = l;
            threadPool = CreateThreadPool(4);
            obj = CreateResourceHandler(loader.GetLoader(), threadPool);
        }
        public void Reset()
        {
            DestroyResourceHandler(obj);
            DestroyThreadPool(threadPool);
            threadPool = CreateThreadPool(4);
            obj = CreateResourceHandler(loader.GetLoader(), threadPool);
        }
        public File_Error CreateType(String type, MemoryType memoryType, String passtrough)
        {
            return ResourceHandler_CreateType(obj, type, memoryType, passtrough);
        }
        ~ResourceHandler()
        {
            DestroyResourceHandler(obj);
            DestroyThreadPool(threadPool);
        }
    }
}
