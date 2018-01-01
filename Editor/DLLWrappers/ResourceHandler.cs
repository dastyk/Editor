using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DLLWrappers
{
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
       
        public ResourceHandler(BinaryLoader_Wrapper l)
        {
            loader = l;
            threadPool = CreateThreadPool(4);
            obj = CreateResourceHandler(loader.GetLoader(), threadPool);
        }
        ~ResourceHandler()
        {
            DestroyResourceHandler(obj);
            DestroyThreadPool(threadPool);
        }
    }
}
