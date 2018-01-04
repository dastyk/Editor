using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Interop;
namespace EngineImporter
{
   public class Renderer
    {
         struct Graphics_Error
        {
           public IntPtr errorMSG;
           public Int32 errornr;
           public IntPtr file;
            public Int32 line;
        };
        enum WindowState : byte
        {
            WINDOWED,
		    FULLSCREEN,
		    FULLSCREEN_BORDERLESS
        };
        [StructLayout(LayoutKind.Sequential)]
         struct Resolution
        {
           public  UInt32 width;
            public UInt32 height;
        };
        [StructLayout(LayoutKind.Sequential)]
         struct RendererInitializationInfo
        {
           public UIntPtr windowHandle;
           public  WindowState windowState;
           public  UInt32 bufferCount;
           public  Resolution resolution;
            public byte vsync;
        };
        UIntPtr obj;
        [DllImport("Graphics.dll")]
        static extern UIntPtr CreateRenderer(uint type, RendererInitializationInfo ii);
        [DllImport("Graphics.dll")]
        static extern Graphics_Error Renderer_Initialize_C(UIntPtr obj);
        [DllImport("Graphics.dll")]
        static extern void Renderer_Shutdown_C(UIntPtr obj);
         [DllImport("Graphics.dll")]
        static extern void Renderer_Pause_C(UIntPtr obj);
        [DllImport("Graphics.dll")]
        static extern Graphics_Error Renderer_Start_C(UIntPtr obj);

        [DllImport("Graphics.dll")]
        static extern Graphics_Error Renderer_UpdateSettings_C(UIntPtr obj, RendererInitializationInfo ii);
        [DllImport("Graphics.dll")]
        static extern RendererInitializationInfo Renderer_GetSettings_C(UIntPtr obj);

        public Renderer()
        {
            RendererInitializationInfo ii;
            Window window = Window.GetWindow(this);
            var wih = new WindowInteropHelper(window);
            IntPtr hWnd = wih.Handle;
            ii.windowHandle
            obj = CreateRenderer(0, ii);
        }
    }
}
