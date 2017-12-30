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
namespace Editor
{
    public partial class SceneViewWindow : Form
    {
        BinaryLoader_Wrapper bl;
        Manager.Collection managers;
        public SceneViewWindow(BinaryLoader_Wrapper bl, Manager.Collection managers)
        {
            InitializeComponent();
            this.bl = bl;
            this.managers = managers;

            if (Settings.Default.EditorMainSize != null)
                this.Size = Settings.Default.SceneViewSize;
            splitContainer.SplitterDistance = Settings.Default.SceneViewSplitDistance;
      
        }

        private void sceneTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                    scenesTree.SelectedNode = scenesTree.GetNodeAt(Cursor.Position);
                cms_Scene.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private void cmsi_New_Click(object sender, EventArgs e)
        {
            AddSceneWindow addSceneWindow = new AddSceneWindow();
            addSceneWindow.Location = Cursor.Position;
            addSceneWindow.StartPosition = FormStartPosition.Manual;
            var parentNode = scenesTree.SelectedNode;
            var r = addSceneWindow.ShowDialog();
            if(r == DialogResult.OK)
            {
                TreeNode node = new TreeNode();
                node.Text = addSceneWindow.name;
                node.Name = addSceneWindow.name;
                var ent =  managers.entityManager.Create();
                node.Tag = ent;
                managers.sceneManager.Create(ent);

               
                TreeNodeCollection treeNodeCollection;
                if (parentNode == null)
                    treeNodeCollection = scenesTree.Nodes;
                else
                {
                    treeNodeCollection = parentNode.Nodes;
                    var parentEnt = (UInt32)parentNode.Tag;
                    managers.sceneManager.AddEntityToScene(parentEnt, ent);
                }
                treeNodeCollection.Add(node);
                scenesTree.SelectedNode = node;
            }
          
        }

        private void scenesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = scenesTree.SelectedNode;
            sceneTree.Nodes.Clear();
            var newNode = new TreeNode(node.Text);
            sceneTree.Nodes.Add(newNode);
        }

        private void cmsi_AddEntity_Click(object sender, EventArgs e)
        {

        }

        private void sceneTree_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
    
                    sceneTree.SelectedNode = sceneTree.GetNodeAt(Cursor.Position);
                cms_NewEnt.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }
    }
}
