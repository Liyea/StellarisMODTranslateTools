using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TranslateTools
{
    public partial class MainForm : Form
    {
        private delegate void MODDataBaseInput(MODDataBase mod);
        private delegate void AddTreeNode(TreeNode parent, TreeNode child);
        private MODDataBaseInput NodeSet;
        private AddTreeNode AddNode;
        private Thread FileLoading;
        private MODDataBase MOD;        

        public MainForm()
        {
            InitializeComponent();
            NodeSet = new MODDataBaseInput(NodeSetMethod);
            AddNode = new AddTreeNode(AddNodeMethod);
            cboxOriginalLanguage.Items.Clear();
            cboxTargetLanguage.Items.Clear();
        }

        private void btnTargetPathBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "Select NSC2 MOD root folder";
            if (folderBrowserDialog.ShowDialog() != DialogResult.Cancel)
                txtMODPath.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnTargetCheck_Click(object sender, EventArgs e)
        {
            trvMODTree.Nodes.Clear();
            MOD = new MODDataBase(txtMODPath.Text);
            Text = "Stellaris MOD Translate Tools: " + MOD.MODName;
            FileLoading = new Thread(LoadMOD);
            TreeNode MODNode = new TreeNode(MOD.MODName);
            trvMODTree.Nodes.Add(MODNode);            
            for (int i = 0; i < 8; i++)
            {
                Language l = (Language)i;
                if (MOD.Folders.ContainsKey(l))
                {
                    cboxOriginalLanguage.Items.Add(l.ToString());
                }
                else
                {
                    cboxTargetLanguage.Items.Add(l.ToString());
                }
            }
            cboxOriginalLanguage.SelectedIndex = 0;
            cboxTargetLanguage.SelectedIndex = 0;
            FileLoading.Start();
        }

        private void btnOldVerBrowse_Click(object sender, EventArgs e)
        {
            int pathlength = txtMODCheckPath.Text.Length;
            string path = txtMODCheckPath.Text.Substring(pathlength - 3);
            if (path == ".smodc")
            {
                pathlength = txtMODCheckPath.Text.LastIndexOf('\\');
                path = txtMODCheckPath.Text.Substring(0, pathlength);
            }
            else
                path = txtMODCheckPath.Text;
            if (Directory.Exists(path))
                saveFileDialog.InitialDirectory = path;
            
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                txtMODCheckPath.Text = saveFileDialog.FileName;
        }

        private void NodeSetMethod(MODDataBase mod)
        {

        }

        private void AddNodeMethod(TreeNode parent,TreeNode child)
        {
            parent.Nodes.Add(child);
        }

        private void LoadMOD()
        {
            TreeNode MODNode = trvMODTree.Nodes[0];
            MODNode.Tag = MOD;
            MODFolder[] MODFolders = MOD.GetFolders();
            foreach (var folder in MODFolders)
            {
                TreeNode FolderNode = new TreeNode(folder.Language.ToString() + "(Original)");
                FolderNode.Name = folder.Language.ToString();
                Invoke(AddNode, MODNode, FolderNode);
                FolderNode.Tag = folder;
                folder.LoadFiles();
                MODFile[] MODFiles = folder.GetFiles();
                foreach (var file in MODFiles)
                {
                    TreeNode FileNode = new TreeNode(file.Name);
                    FileNode.Name = file.Name;
                    Invoke(AddNode, FolderNode, FileNode);
                    FileNode.Tag = file;
                    MODProperty[] MODProperties = file.GetProperties();
                    foreach (var property in MODProperties)
                    {
                        TreeNode propertyNode = new TreeNode(property.Name);
                        propertyNode.Name = property.Name;
                        Invoke(AddNode, FileNode, propertyNode);
                        propertyNode.Tag = property;
                    }
                }                
            }
        }
    }
}
