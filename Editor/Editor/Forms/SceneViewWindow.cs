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
using Importer.Managers;
namespace Editor
{
    using Entity = UInt32;
    public partial class SceneViewWindow : Form
    {
        Utilities.EditorWrapper wrapper;
        Entity entityEditing = UInt32.MaxValue;
        List<LoaderFile> deletedScenes = new List<LoaderFile>();
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
        private void CreateSceneNode(LoaderFile file, TreeNode node, List<LoaderFile> scenes)
        {
            node.Text = file.guid_str;
            node.Name = file.guid_str;
            node.Tag = file;
            var childScenes = wrapper.managers.sceneManager.GetChildResourcesOfSceneResource(file.guid);
            foreach (UInt32 cs in childScenes)
            {
                foreach (var sf in scenes)
                {
                    if(cs == sf.guid)
                    {
                        var child = new TreeNode();
                        CreateSceneNode(sf, child, scenes);
                        node.Nodes.Add(child);
                        break;
                    }
                }
            }

        }
        public SceneViewWindow(Utilities.EditorWrapper wrapper)
        {
            InitializeComponent();
            this.wrapper = wrapper;
            wrapper.ChangeEvent += new Utilities.EditorChangeEventHandler(Changed);
            wrapper.SavedEvent += new Utilities.EditorSavedEventHandler(Saved);

            if (Settings.Default.EditorMainSize != null)
                this.Size = Settings.Default.SceneViewSize;
            splitContainer.SplitterDistance = Settings.Default.SceneViewSplitDistance;

            FixNodeHighlight(scenesTree);
            FixNodeHighlight(sceneTree);

            List<LoaderFile> scenes;
            var result = wrapper.binaryLoader.GetFilesOfType("Scene", out scenes);
           if(result.IsError())
            {
                result.ShowError(MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
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
                    CreateSceneNode(file, node, scenes);
                    scenesTree.Nodes.Add(node);
                }
            }
          
        }
        bool hasChanged = false;
        private void Changed(Utilities.ChangeType change)
        {
            if(change.HasFlag( Utilities.ChangeType.ENTITY))
            {
                hasChanged = true;
            }

        }
        private void Saved()
        {
            hasChanged = false;
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

        private TreeNode AddSceneNodeToScene(TreeNode parent, TreeNode child)
        {
            var ent = wrapper.managers.entityManager.Create();
            var f = (LoaderFile)parent.Tag;
            wrapper.managers.sceneManager.Create(ent, f.guid, f.type);
            var cs = wrapper.managers.entityManager.Create();
            var cf = (LoaderFile)child.Tag;
            wrapper.managers.sceneManager.Create(cs, child.Name);
            wrapper.managers.sceneManager.AddEntityToScene(ent, cs, child.Name);
            wrapper.managers.sceneManager.WriteComponent(wrapper.binaryLoader, ent, parent.Name);

            var nC = (TreeNode)child.Clone();
            parent.Nodes.Add(nC);
            return nC;
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
            bool found = false;
            if (r == DialogResult.OK)
            {
                TreeNode node = new TreeNode();
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
                        node = findIn[0];
                        found = true;
                    }
                }
                if (!found)
                {
                    var ent = wrapper.managers.entityManager.Create();
                    wrapper.managers.sceneManager.Create(ent, name);
                    wrapper.managers.sceneManager.WriteComponent(wrapper.binaryLoader, ent, name);
                    LoaderFile newFile;
                    wrapper.managers.entityManager.DestroyNow(ent);
                    var rr = wrapper.binaryLoader.GetFile(out newFile, name, "Scene");
                    if(rr.IsError())
                    {
                        rr.ShowError(MessageBoxButtons.OK, MessageBoxIcon.Warning, "File: " + name);
                        return;
                    }
                   
                    node.Tag = newFile;
                    node.Text = name;
                    node.Name = name;

                    for (int i = 0; i < deletedScenes.Count; i++)
                    {
                        if(deletedScenes[i].guid_str == node.Name)
                        {
                            deletedScenes.RemoveAt(i);
                            break;
                        }
                    }

                }
             
             
                if (parentNode == null)
                    scenesTree.Nodes.Add(node);
                else
                {

                    node = AddSceneNodeToScene(parentNode, node);

                }
             
                scenesTree.SelectedNode = node;
                if (parentNode != null)
                    parentNode.Expand();
                if (rename)
                {
                    scenesTree.LabelEdit = true;
                    scenesTree.SelectedNode.BeginEdit();
                }
                else
                {
                    wrapper.Changed(Utilities.ChangeType.ENTITY | Utilities.ChangeType.FILE);
                }


            }
        }
        void AddChildEnts(TreeNode node, Entity parent)
        {
            var ents = wrapper.managers.sceneManager.GetEntitiesInScene(parent);
            foreach (var ent in ents)
            {
                var childNode = new TreeNode();
                childNode.Text = ent.name;
                childNode.Name = ent.name;
                childNode.Tag = ent.entity;
                if (wrapper.managers.sceneManager.IsRegistered(ent.entity))
                {
                    AddChildEnts(childNode, ent.entity);
                    childNode.NodeFont = new Font(sceneTree.Font, FontStyle.Bold);
                }
                 
                node.Nodes.Add(childNode);
            }

        }
        private void scenesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //wrapper.Reset();
            var node = scenesTree.SelectedNode;
            sceneTree.Nodes.Clear();
            wrapper.entityViewWindow.Clear();
            var newNode = new TreeNode();

            newNode.Text = node.Text + "  ";
            newNode.Name = node.Name;

            wrapper.managers.entityManager.DestroyAll(true);
           
            newNode.Tag = entityEditing = wrapper.managers.entityManager.Create();
            var lf = (LoaderFile)node.Tag;
            wrapper.managers.sceneManager.Create(entityEditing, lf.guid, lf.type);

            AddChildEnts(newNode, entityEditing);
           

            newNode.NodeFont = new Font(sceneTree.Font, FontStyle.Bold);
            sceneTree.Nodes.Add(newNode);
            sceneTree.SelectedNode = newNode;
            hasChanged = false;
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

                  
                }

                var ent = wrapper.managers.entityManager.Create();
                wrapper.managers.sceneManager.AddEntityToScene(parentEnt, ent, addEntitywindow.name);
                TreeNode node = new TreeNode();
                node.Text = addEntitywindow.name;
                node.Name = addEntitywindow.name;
                node.Tag = ent;
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
            sceneTree.Nodes[0].Expand();
            hasChanged = false;
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
            var findInOther = sceneTree.Nodes.Find(node.Name, true);

            deletedScenes.Add((LoaderFile)node.Tag);
            node = (TreeNode) node.Clone();
            node.Text = node.Name = e.Label;
            foreach (var onode in findInOther)
            {
                wrapper.managers.sceneManager.Rename((Entity)onode.Tag, node.Name);
                onode.Name = onode.Text = node.Name;

            }

            wrapper.Changed(Utilities.ChangeType.SCENE);
        }
        private void DeleteScene(TreeNode node)
        {

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
                var findO = scenesTree.Nodes.Find(node.Name, true);
                if(findO.Length == 0)
                    deletedScenes.Add((LoaderFile)node.Tag);

                var find = sceneTree.Nodes.Find(node.Name, true);
                foreach (var onode in find)
                {
                    if (onode.Parent == null)
                    {
                        sceneTree.Nodes.Clear();
                        wrapper.entityViewWindow.Clear();
                        wrapper.managers.entityManager.DestroyAll(true);
                    }
                    else
                    {
                        onode.Parent.Nodes.Remove(onode);
                        wrapper.managers.entityManager.DestroyNow((Entity)onode.Tag);
                    }
                }
            }
        }
        public String[] GetDeletedScenes()
        {
            var ret = new String[deletedScenes.Count];
            for (int i = 0; i < deletedScenes.Count; i++)
            {
                ret[i] = deletedScenes[i].guid_str;
            }
            deletedScenes.Clear();
            return ret;
        }

        private void scenesTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if(hasChanged)
            {
                var r = MessageBox.Show("Selecting a new node will undo any changes in the scene. Continue without saving?", "Change scene", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (r == DialogResult.Cancel)
                    e.Cancel = true;
                else if (r == DialogResult.No)
                {
                    wrapper.Save();
                }
                else
                    hasChanged = false;
            }
        }
    }
}
