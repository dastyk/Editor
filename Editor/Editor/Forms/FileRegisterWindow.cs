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
using EngineImporter;
namespace Editor
{
    public partial class FileRegisterWindow : Form
    {
        struct File
        {
            public String originalPath { get; set; }
        }
        Utilities.EditorWrapper wrapper;
        public FileRegisterWindow(Utilities.EditorWrapper wrapper)
        {
            InitializeComponent();

            if (Settings.Default.EditorMainSize != null)
                this.Size = Settings.Default.FileRegSize;

            this.wrapper = wrapper;
            ReadFiles();
        }
        public void RemoveFilesThatDoNotMatch(String[] names, String type)
        {
            List<LoaderFile> files;
            var r = wrapper.binaryLoader.GetFilesOfType(type, out files);
            if (r != 0)
            {
                MessageBox.Show("Could not get files of type: " + type, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach(LoaderFile f in files)
            {
                if (Array.Find(names, n => n == f.guid_str) == null)
                {
                    wrapper.binaryLoader.Destroy(f.guid_str, type);
                }
            }
            
        }
        private void ReadFiles()
        {
            List<LoaderFile> files;
            var r = wrapper.binaryLoader.GetFiles(out files);
            if (r == 0)
            {
                TreeNode root = new TreeNode("Root");
                root.Name = "Root";

                for (int i = 0; i < files.Count; i++)
                {
                    var typeNodes = root.Nodes.Find(files[i].type_str, false);
                    TreeNode typeNode;
                    if (typeNodes.Length == 0)
                    {
                        typeNode = new TreeNode(files[i].type_str);
                        typeNode.Name = files[i].type_str;
                        root.Nodes.Add(typeNode);
                    }

                    typeNode = root.Nodes[files[i].type_str];

                    TreeNode node = new TreeNode(files[i].guid_str);
                    node.Name = files[i].guid_str;
                    node.Tag = new File();
                    File f = (File)node.Tag;
                    f.originalPath = "";
                    typeNode.Nodes.Add(node);
                }
                fileTree.Nodes.Add(root);
            }
            fileTree.Nodes["Root"].Expand();
        }
        public void Reset()
        {
            fileTree.Nodes.Clear();
            ReadFiles();
        }
        private void fileTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var node = fileTree.GetNodeAt(new Point(e.X, e.Y));
                if(node != null)
                {
                    fileTree.SelectedNode = node;
                }
                TreeViewMenu.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private void TreeViewMenuAddFile_Click(object sender, EventArgs e)
        {
            AddFileWindow addFileWindow = new AddFileWindow();
            addFileWindow.Location = Cursor.Position;
            addFileWindow.StartPosition = FormStartPosition.Manual;
            var r = addFileWindow.ShowDialog();
            if (r == DialogResult.OK)
            {
                var root = fileTree.Nodes[0];
                var rootNodes = root.Nodes;
                var type = rootNodes.Find(addFileWindow.type, false);
                if (type.Length == 0)
                {
                    TreeNode node = new TreeNode(addFileWindow.type);
                    node.Name = addFileWindow.type;
                    rootNodes.Add(node);
                }
                var typeNode = rootNodes[addFileWindow.type];
                var typeNodes = rootNodes[addFileWindow.type].Nodes;

                var file = typeNodes.Find(addFileWindow.name, false);
                if(file.Length > 0)
                {
                    var result = MessageBox.Show("A file with this name already exists. Overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(result == DialogResult.No)
                    {
                        return;
                    }

                    wrapper.binaryLoader.Destroy(addFileWindow.name, addFileWindow.type);
                    typeNodes.Remove(file[0]);
                }
                TreeNode fileNode = new TreeNode(addFileWindow.name);
                fileNode.Name = addFileWindow.name;
               
                var cresult = wrapper.binaryLoader.CreateFromFile(addFileWindow.file, addFileWindow.name, addFileWindow.type);
                if(cresult != 0)
                {
                    MessageBox.Show("Could not add file", "Error: " + cresult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                typeNodes.Add(fileNode);
                typeNode.Expand();
                fileTree.SelectedNode = fileNode;
            }
        }


        private void toolStripItem_Remove_Click(object sender, EventArgs e)
        {
            var sel = fileTree.SelectedNode;
            if(sel.Tag != null)
            {
                var r = MessageBox.Show("Are you sure you want to delete " + sel.Text + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(r == DialogResult.Yes)
                {
                    var result = wrapper.binaryLoader.Destroy(sel.Name, sel.Parent.Name);
                    if(result != 0)
                    {
                        MessageBox.Show("Could not delete file", "Error: " + result.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sel.Parent.Nodes.Remove(sel);
                }
            }
        }
    }
}
