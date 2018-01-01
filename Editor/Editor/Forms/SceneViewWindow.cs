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
using DLLWrappers;
using DLLWrappers.Managers;
namespace Editor
{
    public partial class SceneViewWindow : Form
    {
        BinaryLoader_Wrapper bl;
        Collection managers;
        EntityViewWindow entityViewWindow;

        void FixNodeHighlight(TreeView treeView)
        {
            treeView.HideSelection = false;
            treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView.DrawNode += (o, e) =>
            {
                if (!e.Node.TreeView.Focused && e.Node == e.Node.TreeView.SelectedNode)
                {
                    Font treeFont = e.Node.NodeFont ?? e.Node.TreeView.Font;
                    e.Graphics.FillRectangle(Brushes.Gray, e.Bounds);
                    ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, SystemColors.HighlightText, SystemColors.Highlight);
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, treeFont, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
                }
                else
                    e.DrawDefault = true;
            };
            treeView.MouseDown += (o, e) =>
            {
                TreeNode node = treeView.GetNodeAt(e.X, e.Y);
                if (node != null && node.Bounds.Contains(e.X, e.Y))
                    treeView.SelectedNode = node;
            };
        }
        private void CreateSceneNode(EntityInfo file, String type, TreeNode node)
        {
            node.Text = file.name;
            node.Name = file.name;
            node.Tag = file.entity;
            var entInScene = managers.sceneManager.GetEntitiesInScene(file.entity);
            foreach (EntityInfo ei in entInScene)
            {
                if (managers.sceneManager.IsRegistered(ei.entity))
                {
                    var child = new TreeNode();
                    CreateSceneNode(ei, type, child);
                    node.Nodes.Add(child);
                }
            }

        }
        private void CreateSceneNode(LoaderFile file, TreeNode node)
        {
            var ent = managers.entityManager.Create();
            managers.sceneManager.Create(ent, file.guid, file.type);
            node.Text = file.guid_str;
            node.Name = file.guid_str;
            node.Tag = ent;
            var entInScene = managers.sceneManager.GetEntitiesInScene(ent);
            foreach (EntityInfo ei in entInScene)
            {
                if (managers.sceneManager.IsRegistered(ei.entity))
                {
                    var child = new TreeNode();
                    CreateSceneNode(ei, file.type_str, child);
                    node.Nodes.Add(child);
                }
            }

        }
        public SceneViewWindow(BinaryLoader_Wrapper bl, Collection managers, EntityViewWindow evw)
        {
            InitializeComponent();
            this.bl = bl;
            this.managers = managers;
            entityViewWindow = evw;
            if (Settings.Default.EditorMainSize != null)
                this.Size = Settings.Default.SceneViewSize;
            splitContainer.SplitterDistance = Settings.Default.SceneViewSplitDistance;

            FixNodeHighlight(scenesTree);
            FixNodeHighlight(sceneTree);

            List<LoaderFile> scenes;
            var result = bl.GetFilesOfType("Scene", out scenes);
            //if(result != 0)
            //{
            //    MessageBox.Show("Error when fetching scenes from file system", "Error: " + result.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            if(result == 0)
            {
                List<LoaderFile> cleared = new List<LoaderFile>(scenes);
                foreach (LoaderFile file in scenes)
                {
                    var inscene = managers.sceneManager.GetChildResourcesOfSceneResource(file.guid);
                    foreach (UInt32 guid in inscene)
                    {
                        foreach (LoaderFile file2 in cleared)
                        {
                            if (file2.guid == guid)
                            {
                                cleared.Remove(file2);
                                break;
                            }
                                
                        }


                    }
                }
               
                foreach (LoaderFile file in cleared)
                {
                    var node = new TreeNode();
                    CreateSceneNode(file, node);
                    scenesTree.Nodes.Add(node);
                }
            }
        }

        private void sceneTree_MouseDown(object sender, MouseEventArgs e)
        {
   
            if (e.Button == MouseButtons.Right)
            {
                    scenesTree.SelectedNode = scenesTree.GetNodeAt(new Point(e.X,e.Y));
                cms_Scene.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private void cmsi_New_Click(object sender, EventArgs e)
        {
            AddEntitywindow addSceneWindow = new AddEntitywindow();
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
                managers.sceneManager.Create(ent, addSceneWindow.name);

               
                TreeNodeCollection treeNodeCollection;
                if (parentNode == null)
                    treeNodeCollection = scenesTree.Nodes;
                else
                {
                    treeNodeCollection = parentNode.Nodes;
                    var parentEnt = (UInt32)parentNode.Tag;
                    managers.sceneManager.AddEntityToScene(parentEnt, ent, addSceneWindow.name);
                }
                treeNodeCollection.Add(node);
                scenesTree.SelectedNode = node;
                if (parentNode != null)
                     parentNode.Expand();
            }
          
        }

        private void scenesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = scenesTree.SelectedNode;
            sceneTree.Nodes.Clear();
            var newNode = new TreeNode();
          
            newNode.Text = node.Text + "  ";
            newNode.Name = node.Name;
            newNode.Tag = node.Tag;
            newNode.NodeFont = new Font(sceneTree.Font, FontStyle.Bold);

            sceneTree.Nodes.Add(newNode);

        }

        private void cmsi_AddEntity_Click(object sender, EventArgs e)
        {
            var parentNode = sceneTree.SelectedNode;
            if (parentNode == null)
            {
                parentNode = sceneTree.Nodes[0];
            }
            AddEntitywindow addEntitywindow = new AddEntitywindow();
            addEntitywindow.Location = Cursor.Position;
            addEntitywindow.StartPosition = FormStartPosition.Manual;

            var r = addEntitywindow.ShowDialog();
            if (r == DialogResult.OK)
            {
                var parentEnt = (UInt32)parentNode.Tag;
                if (!managers.sceneManager.IsRegistered(parentEnt))
                {
                    var conR = MessageBox.Show("Entity must be a scene. Convert to scene?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (conR != DialogResult.Yes)
                    {
                        return;
                    }

                    managers.sceneManager.Create(parentEnt, parentNode.Name);
                }

                var ent = managers.entityManager.Create();
                TreeNode node = new TreeNode();
                node.Text = addEntitywindow.name;
                node.Name = addEntitywindow.name;
                node.Tag = managers.entityManager.Create();
                parentNode.Nodes.Add(node);
                parentNode.Expand();

                sceneTree.SelectedNode = node;

            }
        }

        private void sceneTree_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (sceneTree.Nodes.Count > 0)
                if (e.Button == MouseButtons.Right)
                {
                    sceneTree.SelectedNode = sceneTree.GetNodeAt(new Point(e.X, e.Y));
                    cms_NewEnt.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
                }
        }

        private void sceneTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = sceneTree.SelectedNode;
            var ent = (UInt32)node.Tag;
            entityViewWindow.SetEntity(ent);
        }

        public TreeNodeCollection GetRootNodes()
        {
            return scenesTree.Nodes;
        }
    }
}
