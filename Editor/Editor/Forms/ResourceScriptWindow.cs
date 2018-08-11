using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Editor.Properties;
using Importer;
namespace Editor
{
    public partial class ResourceScriptWindow : Form
    {
        class Type
        {
            public Type(string name, bool pt = false)
            {
                this.name = name;

                this.passThrough = pt;
            }
            public string name;
            public bool passThrough;
            public MemoryType memoryType;

            public override string ToString()
            {
                return name;
            }
        }
        struct File
        {
            public String originalPath { get; set; }
        }
        Utilities.EditorWrapper wrapper;
        public ResourceScriptWindow(Utilities.EditorWrapper wrapper)
        {
            InitializeComponent();
            this.Size = Settings.Default.RScriptSize;
            this.wrapper = wrapper;


        }



        private void ResourceScriptWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
