using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class EditorMainWindow : Form
    {
        BinaryLoader_Wrapper binaryLoader;
        FileRegisterWindow fileRegisterWindow;
        public EditorMainWindow()
        {
            InitializeComponent();

            binaryLoader = new BinaryLoader_Wrapper();

            fileRegisterWindow = new FileRegisterWindow();
            fileRegisterWindow.MdiParent = this;
            fileRegisterWindow.Show();
        }
    }
}
