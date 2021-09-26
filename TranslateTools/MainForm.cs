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
        private delegate void AddNodeToNode(TreeNode parent, TreeNode child);
        private delegate void AddNodeToTreeView(TreeView treeView, TreeNode node);
        private AddNodeToNode addNodeToNode;
        private AddNodeToTreeView addNodeToTreeView;
        private Thread FileLoading;
        private ModDataBase Mod;
        private ModDataBase ModTranslate;

        public MainForm()
        {
            InitializeComponent();
            addNodeToNode = new AddNodeToNode(AddNodeToNodeMethod);
            addNodeToTreeView = new AddNodeToTreeView(AddNodeToTreeViewMethod);
            cboxOriginalLanguage.Items.Clear();
            cboxTargetLanguage.Items.Clear();
        }

        #region ButtonClick
        private void btnModLoad_Click(object sender, EventArgs e)
        {
            try
            {
                // Load Mod descriptor and localisation folders
                Mod = new ModDataBase(txtModPath.Text, true, false);
                lblUpdateTime.Text = $"Last Update: {Mod.ModifyTime:yyyy/MM/dd}";
                //var folder = Mod.GetFolders();
                //ModLanguage.GetFolderLanguage(folder[0].FolderPath);
            }
            catch(FileLoadException flex)
            {                
                // Show error message
                MessageBox.Show(flex.Message,"Original Mod files loading failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }           

            Text = "Stellaris Mod Translate Tools: " + Mod.ModName;

            FileLoading = new Thread(GenerateTree);
            TreeNode ModNode = new TreeNode(Mod.ModName);
            trvModTree.Nodes.Clear();
            trvModTree.Nodes.Add(ModNode);            
            for (int i = 0; i < 8; i++)
            {
                Language l = (Language)i;
                if (Mod.Folders.ContainsKey(l))
                {
                    cboxOriginalLanguage.Items.Add(l.ToString());
                }
                else
                {
                    cboxTargetLanguage.Items.Add(l.ToString());
                }
            }
            FileLoading.Start();
            cboxOriginalLanguage.SelectedIndex = 0;
            cboxTargetLanguage.SelectedIndex = 0;
        }

        private void btnOriginalPathBrowse_Click(object sender, EventArgs e)
        {
            ofdDescriptor.Title = "Select Original Mod Descriptor";
            if (ofdDescriptor.ShowDialog() == DialogResult.OK)
                txtModPath.Text = ofdDescriptor.FileName;
        }

        private void btnTargetPathBrowse_Click(object sender, EventArgs e)
        {
            ofdDescriptor.Title = "Select Translate Mod Descriptor";
            if (ofdDescriptor.ShowDialog() == DialogResult.OK)
                txtModTranslatePath.Text = ofdDescriptor.FileName;
        }

        private void btnCheckingFileBrowse_Click(object sender, EventArgs e)
        {
            string path = Path.GetExtension(txtModCheckPath.Text);            
            if (path == ".smodc")
            {
                path = Path.GetDirectoryName(txtModCheckPath.Text);
            }
            else
                path = txtModCheckPath.Text;

            if (Directory.Exists(path))
                sfdSMOF.InitialDirectory = path;
            
            if (sfdSMOF.ShowDialog() == DialogResult.OK)
                txtModCheckPath.Text = sfdSMOF.FileName;
        }
        #endregion
        
        private void AddNodeToTreeViewMethod(TreeView treeView, TreeNode child)
        {
            treeView.Nodes.Add(child);
        }

        private void AddNodeToNodeMethod(TreeNode parent,TreeNode child)
        {
            parent.Nodes.Add(child);
        }

        private void GenerateTree()
        {
            if (!File.Exists(txtModCheckPath.Text) && chbGenerateChecking.Checked)
            {
                if(MessageBox.Show("Checking file couldn't be found.\n" +
                    "Do you want to create new one?", "Version File Missing", MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    Mod.GenerateCheckingFile(txtModCheckPath.Text);
                }
            }
            else
            {

            }

            ModFolder[] ModFolders = Mod.GetFolders();
            ModFile[] ModFiles = ModFolders[0].GetFiles();
            foreach (var file in ModFiles)
            {
                TreeNode FileNode = new TreeNode(file.Name);
                FileNode.Name = file.Name;
                Invoke(addNodeToTreeView, trvModTree, FileNode);                
                ModProperty[] ModProperties = file.GetProperties();
                foreach (var property in ModProperties)
                {
                    TreeNode propertyNode = new TreeNode(property.Name);
                    propertyNode.Name = property.Name;
                    Invoke(addNodeToNode, FileNode, propertyNode);
                }
            }            
        }

        private void SelectNode(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void btnTranslateLoad_Click(object sender, EventArgs e)
        {
            try
            {
                // Load Translate Mod descriptor and localisation file
                ModTranslate = new ModDataBase(txtModTranslatePath.Text, true, true);
            }
            catch (FileLoadException flex)
            {
                // Show error message
                if (flex.InnerException is LocalisationMissingException)
                {
                    if (MessageBox.Show(flex.InnerException.Message + "\n Do you want create a new Mod?",
                        "Translate Mod files loading failed", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                        {
                            ModTranslate = new ModDataBase(folderBrowserDialog.SelectedPath, Mod.ModName + "_Translate");
                        }
                        else
                            return;
                    }
                }
                else
                {
                    MessageBox.Show(flex.InnerException.Message, "Translate Mod files loading failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }
    }
}
