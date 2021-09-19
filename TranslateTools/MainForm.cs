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
        private ModDataBase MOD;
        private ModDataBase MODTranslate;

        public MainForm()
        {
            InitializeComponent();
            addNodeToNode = new AddNodeToNode(AddNodeToNodeMethod);
            addNodeToTreeView = new AddNodeToTreeView(AddNodeToTreeViewMethod);
            cboxOriginalLanguage.Items.Clear();
            cboxTargetLanguage.Items.Clear();
        }

        #region ButtonClick
        private void btnTargetCheck_Click(object sender, EventArgs e)
        {
            try
            {
                // Load MOD descriptor and localisation folders
                MOD = new ModDataBase(txtMODPath.Text);
            }
            catch(FileLoadException flex)
            {                
                // Show error message
                MessageBox.Show(flex.Message,"Original MOD files loading failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Load Translate MOD descriptor and localisation file
                MODTranslate = new ModDataBase(txtMODTranslatePath.Text);
            }
            catch (FileLoadException flex)
            {
                // Show error message
                if (flex.InnerException is DescriptorWithoutFoldersException)
                {
                    if( MessageBox.Show(flex.InnerException.Message+"\n Do you want create a new MOD?", 
                        "Translate MOD files loading failed", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                        {
                            MODTranslate = new ModDataBase(folderBrowserDialog.SelectedPath, MOD.ModName + "_Translate");
                        }
                        else
                            return;
                    }
                    
                }
                else
                {
                    MessageBox.Show(flex.InnerException.Message, "Translate MOD files loading failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            Text = "Stellaris MOD Translate Tools: " + MOD.ModName;

            FileLoading = new Thread(GenerateTree);
            TreeNode MODNode = new TreeNode(MOD.ModName);
            trvMODTree.Nodes.Clear();
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
            FileLoading.Start();
            cboxOriginalLanguage.SelectedIndex = 0;
            cboxTargetLanguage.SelectedIndex = 0;
        }

        private void btnOriginalPathBrowse_Click(object sender, EventArgs e)
        {
            ofdDescriptor.Title = "Select Original MOD Descriptor";
            if (ofdDescriptor.ShowDialog() == DialogResult.OK)
                txtMODPath.Text = ofdDescriptor.FileName;
        }

        private void btnTargetPathBrowse_Click(object sender, EventArgs e)
        {
            ofdDescriptor.Title = "Select Translate MOD Descriptor";
            if (ofdDescriptor.ShowDialog() == DialogResult.OK)
                txtMODTranslatePath.Text = ofdDescriptor.FileName;
        }

        private void btnOldVerBrowse_Click(object sender, EventArgs e)
        {
            string path = Path.GetExtension(txtMODCheckPath.Text);            
            if (path == ".smodc")
            {
                path = Path.GetDirectoryName(txtMODCheckPath.Text);
            }
            else
                path = txtMODCheckPath.Text;

            if (Directory.Exists(path))
                sfdSMOF.InitialDirectory = path;
            
            if (sfdSMOF.ShowDialog() == DialogResult.OK)
                txtMODCheckPath.Text = sfdSMOF.FileName;
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
            if (!File.Exists(txtMODCheckPath.Text))
            {
                if(MessageBox.Show("Version file couldn't be found.\n" +
                    "Do you want to create new one?", "Version File Missing", MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    MOD.GenerateCheckingFile(txtMODCheckPath.Text);
                }
            }
            else
            {

            }

            ModFolder[] MODFolders = MOD.GetFolders();
            ModFile[] MODFiles = MODFolders[0].GetFiles();
            foreach (var file in MODFiles)
            {
                TreeNode FileNode = new TreeNode(file.Name);
                FileNode.Name = file.Name;
                Invoke(addNodeToTreeView, trvMODTree, FileNode);                
                ModProperty[] MODProperties = file.GetProperties();
                foreach (var property in MODProperties)
                {
                    TreeNode propertyNode = new TreeNode(property.Name);
                    propertyNode.Name = property.Name;
                    Invoke(addNodeToNode, FileNode, propertyNode);
                }
            }
            . 
        }

        private void SelectNode(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
    }
}
