﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows;

namespace Importer
{
   public class Renderer
    {
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
           public  IntPtr windowHandle;
           public  WindowState windowState;
           public  UInt32 bufferCount;
           public  Resolution resolution;
            public byte vsync;
        };
        UIntPtr obj = UIntPtr.Zero;
        [DllImport("Graphics.dll")]
        static extern UIntPtr CreateRenderer(uint type, RendererInitializationInfo ii);
        [DllImport("Graphics.dll")]
        static extern Error_C Renderer_Initialize_C(UIntPtr obj);
        [DllImport("Graphics.dll")]
        static extern void Renderer_Shutdown_C(UIntPtr obj);
         [DllImport("Graphics.dll")]
        static extern void Renderer_Pause_C(UIntPtr obj);
        [DllImport("Graphics.dll")]
        static extern Error_C Renderer_Start_C(UIntPtr obj);

        [DllImport("Graphics.dll")]
        static extern Error_C Renderer_UpdateSettings_C(UIntPtr obj, RendererInitializationInfo ii);
        [DllImport("Graphics.dll")]
        static extern RendererInitializationInfo Renderer_GetSettings_C(UIntPtr obj);
        RendererInitializationInfo ii;
        public Renderer(System.Windows.Forms.Control window)
        {

            ii.windowHandle = window.Handle;
            ii.windowState = WindowState.WINDOWED;
            ii.vsync = 1;
            ii.resolution = new Resolution { width = Convert.ToUInt32(window.Width), height = Convert.ToUInt32(window.Height) };
            ii.bufferCount = 2;
            obj = CreateRenderer(0, ii);

        }
        public Error Init()
        {
            return Renderer_Initialize_C(obj);

            /*if (r.errornr != 0)
            {
                String msg = Marshal.PtrToStringAnsi(r.errorMSG);
                String file = Marshal.PtrToStringAnsi(r.file);
                MessageBox.Show("Could not create renderer\nError: "
                    + r.errornr.ToString() + ": " + msg + "\nFile: "
                    + file + "\nLine :" + r.line.ToString()
                    , "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }*/
        }

        public Error UpdateSettings(System.Windows.Forms.Control window)
        {
            ii.windowHandle = window.Handle;
            ii.resolution = new Resolution { width = Convert.ToUInt32(window.Width), height = Convert.ToUInt32(window.Height) };

            return Renderer_UpdateSettings_C(obj, ii);
           /* if (r.errornr != 0)
            {
                String msg = Marshal.PtrToStringAnsi(r.errorMSG);
                String file = Marshal.PtrToStringAnsi(r.file);
                MessageBox.Show("Could not create renderer\nError: "
                    + r.errornr.ToString() + ": " + msg + "\nFile: "
                    + file + "\nLine :" + r.line.ToString()
                    , "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }*/
        }
        public Error Start()
        {
            return Renderer_Start_C(obj);
           /* if (r.errornr != 0)
            {
                String msg = Marshal.PtrToStringAnsi(r.errorMSG);
                String file = Marshal.PtrToStringAnsi(r.file);
                MessageBox.Show("Could not create renderer\nError: "
                    + r.errornr.ToString() + ": " + msg + "\nFile: "
                    + file + "\nLine :" + r.line.ToString()
                    , "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }*/
        }
        public void Pause()
        {
            Renderer_Pause_C(obj);
        }
        ~Renderer()
        {
            Renderer_Shutdown_C(obj);
        }
    }
}
