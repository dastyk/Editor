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
using EngineImporter.Managers;
namespace Editor
{
    public partial class SceneViewWindow : Form
    {
        Utilities.EditorWrapper wrapper;

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
            var entInScene = wrapper.managers.sceneManager.GetEntitiesInScene(file.entity);
            foreach (EntityInfo ei in entInScene)
            {
                if (wrapper.managers.sceneManager.IsRegistered(ei.entity))
                {
                    var child = new TreeNode();
                    CreateSceneNode(ei, type, child);
                    node.Nodes.Add(child);
                }
            }

        }
        private void CreateSceneNode(LoaderFile file, TreeNode node)
        {
            var ent = wrapper.managers.entityManager.Create();
            wrapper.managers.sceneManager.Create(ent, file.guid, file.type);
            node.Text = file.guid_str;
            node.Name = file.guid_str;
            node.Tag = ent;
            var entInScene = wrapper.managers.sceneManager.GetEntitiesInScene(ent);
            foreach (EntityInfo ei in entInScene)
            {
                if (wrapper.managers.sceneManager.IsRegistered(ei.entity))
                {
                    var child = new TreeNode();
                    CreateSceneNode(ei, file.type_str, child);
                    node.Nodes.Add(child);
                }
            }

        }
        public SceneViewWindow(Utilities.EditorWrapper wrapper)
        {
            InitializeComponent();
            this.wrapper = wrapper;
            if (Settings.Default.EditorMainSize != null)
                this.Size = Settings.Default.SceneViewSize;
            splitContainer.SplitterDistance = Settings.Default.SceneViewSplitDistance;

            FixNodeHighlight(scenesTree);
            FixNodeHighlight(sceneTree);

            List<LoaderFile> scenes;
            var result = wrapper.binaryLoader.GetFilesOfType("Scene", out scenes);
            //if(result != 0)
            //{
            //    MessageBox.Show("Error when fetching scenes from file system", "Error: " + result.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            if (result == 0)
            {
                List<LoaderFile> cleared = new List<LoaderFile>(scenes);
                foreach (LoaderFile file in scenes)
                {
                    var inscene = wrapper.managers.sceneManager.GetChildResourcesOfSceneResource(file.guid);
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
                scenesTree.SelectedNode = scenesTree.GetNodeAt(new Point(e.X, e.Y));
                if (scenesTree.SelectedNode == null)
                    renameToolStripMenuItem.Enabled = false;
                else
                    renameToolStripMenuItem.Enabled = true;
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
            var name = addSceneWindow.name;
            bool rename = false;
            UInt32 ent = UInt32.MaxValue;
            if (r == DialogResult.OK)
            {
                var findIn = scenesTree.Nodes.Find(addSceneWindow.name, true);
                if (findIn.Length > 0)
                {
                    var findinR = MessageBox.Show("A scene with this name already exists. Yes, use existing scene. No, rename the scene", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (findinR == DialogResult.Cancel)
                        return;
                    if (findinR == DialogResult.No)
                    {

                        int count = 0;

                        while (!rename)
                        {
                            if (scenesTree.Nodes.Find(name + "_" + count.ToString(), true).Length == 0)
                            {
                                name += "_" + count.ToString();
                                rename = true;
                            }
                            count++;
                        }


                    }
                    else if (findinR == DialogResult.Yes)
                    {
                        ent = (UInt32)findIn[0].Tag;
                    }
                }

                if (ent == UInt32.MaxValue)
                {
                    ent = wrapper.managers.entityManager.Create();
                    wrapper.managers.sceneManager.Create(ent, name);
                }
                TreeNode node = new TreeNode();
                node.Text = name;
                node.Name = name;

                node.Tag = ent;


                TreeNodeCollection treeNodeCollection;
                if (parentNode == null)
                    treeNodeCollection = scenesTree.Nodes;
                else
                {
                    treeNodeCollection = parentNode.Nodes;
                    var parentEnt = (UInt32)parentNode.Tag;
                    wrapper.managers.sceneManager.AddEntityToScene(parentEnt, ent, name);
                }
                treeNodeCollection.Add(node);
                scenesTree.SelectedNode = node;
                if (parentNode != null)
                    parentNode.Expand();
                if (rename)
                {
                    scenesTree.LabelEdit = true;
                    scenesTree.SelectedNode.BeginEdit();
                }

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
            sceneTree.SelectedNode = newNode;
        }

        private void cmsi_AddEntity_Click(object sender, EventArgs e)
        {
            if (sceneTree.Nodes.Count == 0)
                return;
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
                if (!wrapper.managers.sceneManager.IsRegistered(parentEnt))
                {
                    var conR = MessageBox.Show("Entity must be a scene. Convert to scene?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (conR == DialogResult.No)
                        return;

                    wrapper.managers.sceneManager.Create(parentEnt, parentNode.Name);
                    var inS = scenesTree.Nodes.Find(parentNode.Name, true);
                    var newS = new TreeNode();
                    newS.Text = parentNode.Text;
                    newS.Name = parentNode.Name;
                    newS.Tag = parentNode.Tag;
                    inS[0].Nodes.Add(newS);
                }

                var ent = wrapper.managers.entityManager.Create();
                TreeNode node = new TreeNode();
                node.Text = addEntitywindow.name;
                node.Name = addEntitywindow.name;
                node.Tag = wrapper.managers.entityManager.Create();
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
            wrapper.entityViewWindow.SetEntity(ent);
        }

        public TreeNodeCollection GetRootNodes()
        {
            return scenesTree.Nodes;
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scenesTree.LabelEdit = true;
            scenesTree.SelectedNode.BeginEdit();
        }

        private void scenesTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var node = scenesTree.SelectedNode;
            if (node == null)
            {
                e.CancelEdit = true;
                scenesTree.LabelEdit = false;
                return;
            }
            if(e.Label == null)
            {
                scenesTree.LabelEdit = false;
                e.CancelEdit = true;
                return;
            }
            if (e.Label == "")
            {
                var r = MessageBox.Show("Name can not be empty", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                e.CancelEdit = true;
                if (r == DialogResult.Cancel)
                {
                    scenesTree.LabelEdit = false;
                    e.CancelEdit = true;
                    return;
                }

                scenesTree.SelectedNode.BeginEdit();
                return;
            }
            var find = scenesTree.Nodes.Find(e.Label, true);
            if(find.Length > 0)
            {
                var r = MessageBox.Show("Name " + e.Label + " is already taken", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                e.CancelEdit = true;
                if (r == DialogResult.Cancel)
                {
                    scenesTree.LabelEdit = false;
                    e.CancelEdit = true;
                    return;
                }

                scenesTree.SelectedNode.BeginEdit();
                return;
            }

            scenesTree.SelectedNode.EndEdit(false);
            scenesTree.LabelEdit = false;
            node.Name = node.Text = e.Label;
            wrapper.managers.sceneManager.Rename((UInt32)node.Tag, node.Text);
            if (node.Parent != null)
                wrapper.managers.sceneManager.RenameEntityInScene((UInt32)node.Parent.Tag, (UInt32)node.Tag, node.Name);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = scenesTree.SelectedNode;
           var r=  MessageBox.Show("Delete scene " + node.Text + "?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if(r == DialogResult.OK)
            {
                if (node.Parent == null)
                    scenesTree.Nodes.Remove(node);
                else
                    node.Parent.Nodes.Remove(node);
                wrapper.managers.entityManager.DestroyNow((UInt32)node.Tag);
                    
            }
        }
    }
}
