using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Importer
{
   
    public class Error
    {
        public String errorMSG;
        public UInt32 errornr;
        public String file;
        public UInt32 line;
        public bool IsError()
        {
            return errornr.ToString() != "469503388";
        }
        public DialogResult ShowError(MessageBoxButtons btns, MessageBoxIcon icon, String extra = "")
        {
            return MessageBox.Show("Error: "
                      + errornr.ToString() + " " + errorMSG + "\nFile: "
                      + file + "\nLine :" + line.ToString() + "\n" + extra
                      , "Error", btns, icon);
        }
    };

    struct Error_C
    {
        public IntPtr errorMSG;
        public UInt32 errornr;
        public IntPtr file;
        public UInt32 line;
        public static implicit operator Error(Error_C o)  // implicit digit to byte conversion operator
        {
            var fe = new Error
            {
                errornr = o.errornr,
                line = o.line
            };
            if (o.errorMSG != IntPtr.Zero)
                fe.errorMSG = Marshal.PtrToStringAnsi(o.errorMSG);
            if (o.file != IntPtr.Zero)
                fe.file = Marshal.PtrToStringAnsi(o.file);
            return fe;
        }
    };

}
