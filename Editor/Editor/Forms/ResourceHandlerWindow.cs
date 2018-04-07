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
    public partial class ResourceHandlerWindow : Form
    {
        class Type
        {
            public Type(string name, bool pt = false, LoaderFile file = new LoaderFile())
            {
                this.name = name;
                this.passThrough = pt;
                this.file = file;
            }
            public string name;
            public bool passThrough;
            public LoaderFile file;
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
        public ResourceHandlerWindow(Utilities.EditorWrapper wrapper)
        {
            InitializeComponent();
            this.Size = Settings.Default.RHWSize;
            this.wrapper = wrapper;

            var files = new List<LoaderFile>();
            wrapper.binaryLoader.GetFilesOfType("Passthrough", out files);
            foreach(LoaderFile f in files)
            {
                var nt = new Type(f.guid_str, true, f);
                handledTypes.Items.Add(nt);
            }

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            var nt = new Type("NewType");
            handledTypes.Items.Add(nt);
            handledTypes.SelectedItem = nt;

        }

        private void handledTypes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var i = handledTypes.IndexFromPoint(e.Location);
            if(i >= 0 && i < handledTypes.Items.Count)
            {
              //  BeginLabelEdit(handledTypes.Items[i] as Type, i);
            }
        }

        private void handledTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var current = handledTypes.SelectedItem as Type;
            if(current != null)
            {
                typeName.Text = current.name;
                cbPassThrough.Checked = current.passThrough;
            }


        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var file = openFileDialog1.FileName;
                wrapper.binaryLoader.CreateFromFile(file, typeName.Text, "Passthrough");
                var c = handledTypes.SelectedItem as Type;
                wrapper.binaryLoader.GetFile(out c.file, c.name, "Passthrough");
                c.passThrough = true;
                wrapper.Changed(Utilities.ChangeType.FILE);
            }
        }

        private void cbPassThrough_CheckedChanged(object sender, EventArgs e)
        {
            browseBtn.Enabled = cbPassThrough.Checked;
        }

        private void typeName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ResourceHandlerWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
