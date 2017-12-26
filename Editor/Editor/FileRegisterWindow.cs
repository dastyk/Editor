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
    public partial class FileRegisterWindow : Form
    {
        BinaryLoader_Wrapper binaryLoader;
        public FileRegisterWindow(BinaryLoader_Wrapper binaryLoader_)
        {
            InitializeComponent();
            binaryLoader = binaryLoader_;
            List<LoaderFile> files;
            var r = binaryLoader.GetFiles(out files);
            if(r == 0)
            {
                TreeNode root = new TreeNode("Root");
                root.Name = "Root";
              
                for(int i = 0; i < files.Count; i++)
                {
                    TreeNode node = new TreeNode(files[i].guid_str);
                    node.Name = files[i].guid_str;
                    root.Nodes.Add(node);
                }
                fileTree.Nodes.Add(root);
            }
        }

        private void fileTree_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                TreeViewMenu.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private void TreeViewMenuAddFile_Click(object sender, EventArgs e)
        {
            AddFileWindow addFileWindow = new AddFileWindow();
            var r = addFileWindow.ShowDialog();
            if(r == DialogResult.OK)
            {
                var root = fileTree.Nodes[0];
                var rootNodes = root.Nodes;
                var type = rootNodes.Find(addFileWindow.type, false);
                if(type.Length == 0)
                {
                    TreeNode node = new TreeNode(addFileWindow.type);
                    node.Name = addFileWindow.type;
                    rootNodes.Add(node);
                }
                var typeNodes = rootNodes[addFileWindow.type].Nodes;

                var file = typeNodes.Find(addFileWindow.name, false);
                if(file.Length > 0)
                {
                    var result = MessageBox.Show("A file with this name already exists. Overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(result == DialogResult.No)
                    {
                        return;
                    }

                    binaryLoader.Destroy(addFileWindow.name, addFileWindow.type);
                    typeNodes.Remove(file[0]);
                }
                TreeNode fileNode = new TreeNode(addFileWindow.name);
                fileNode.Name = addFileWindow.name;
                typeNodes.Add(fileNode);
                binaryLoader.CreateFromFile(addFileWindow.file, addFileWindow.name, addFileWindow.type);
            }
        }
    }
}
