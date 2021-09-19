
namespace TranslateTools
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCheck = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chboxGenerate = new System.Windows.Forms.CheckBox();
            this.btnLoadCheck = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxTargetLanguage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxOriginalLanguage = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvModTree = new System.Windows.Forms.TreeView();
            this.btnModLoad = new System.Windows.Forms.Button();
            this.tabTranslate = new System.Windows.Forms.TabPage();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.btnTargetPathBrowse = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModTranslatePath = new System.Windows.Forms.TextBox();
            this.btnCheckingFileBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModCheckPath = new System.Windows.Forms.TextBox();
            this.btnOriginalPathBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModPath = new System.Windows.Forms.TextBox();
            this.sfdSMOF = new System.Windows.Forms.SaveFileDialog();
            this.ofdDescriptor = new System.Windows.Forms.OpenFileDialog();
            this.sfdDescriptor = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCheck);
            this.tabControl1.Controls.Add(this.tabTranslate);
            this.tabControl1.Controls.Add(this.tabSetting);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1084, 562);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCheck
            // 
            this.tabCheck.Controls.Add(this.button1);
            this.tabCheck.Controls.Add(this.btnGenerate);
            this.tabCheck.Controls.Add(this.chboxGenerate);
            this.tabCheck.Controls.Add(this.btnLoadCheck);
            this.tabCheck.Controls.Add(this.label4);
            this.tabCheck.Controls.Add(this.cboxTargetLanguage);
            this.tabCheck.Controls.Add(this.label3);
            this.tabCheck.Controls.Add(this.cboxOriginalLanguage);
            this.tabCheck.Controls.Add(this.splitContainer1);
            this.tabCheck.Controls.Add(this.btnModLoad);
            this.tabCheck.Location = new System.Drawing.Point(4, 22);
            this.tabCheck.Name = "tabCheck";
            this.tabCheck.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheck.Size = new System.Drawing.Size(1076, 536);
            this.tabCheck.TabIndex = 0;
            this.tabCheck.Text = "File Check";
            this.tabCheck.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Load Translate File ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(688, 30);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(148, 23);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate Target Language";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // chboxGenerate
            // 
            this.chboxGenerate.AutoSize = true;
            this.chboxGenerate.Location = new System.Drawing.Point(238, 10);
            this.chboxGenerate.Name = "chboxGenerate";
            this.chboxGenerate.Size = new System.Drawing.Size(124, 16);
            this.chboxGenerate.TabIndex = 8;
            this.chboxGenerate.Text = "Generate Version File";
            this.chboxGenerate.UseVisualStyleBackColor = true;
            // 
            // btnLoadCheck
            // 
            this.btnLoadCheck.Enabled = false;
            this.btnLoadCheck.Location = new System.Drawing.Point(123, 6);
            this.btnLoadCheck.Name = "btnLoadCheck";
            this.btnLoadCheck.Size = new System.Drawing.Size(109, 23);
            this.btnLoadCheck.TabIndex = 7;
            this.btnLoadCheck.Text = "Load Check File";
            this.btnLoadCheck.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(851, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Target Language: ";
            // 
            // cboxTargetLanguage
            // 
            this.cboxTargetLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxTargetLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTargetLanguage.FormattingEnabled = true;
            this.cboxTargetLanguage.Items.AddRange(new object[] {
            "BrazPor",
            "English",
            "French",
            "German",
            "Polish",
            "Russian",
            "Simple Chinese",
            "Spanish"});
            this.cboxTargetLanguage.Location = new System.Drawing.Point(947, 32);
            this.cboxTargetLanguage.Name = "cboxTargetLanguage";
            this.cboxTargetLanguage.Size = new System.Drawing.Size(121, 20);
            this.cboxTargetLanguage.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(843, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Original Language: ";
            // 
            // cboxOriginalLanguage
            // 
            this.cboxOriginalLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxOriginalLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxOriginalLanguage.FormattingEnabled = true;
            this.cboxOriginalLanguage.Items.AddRange(new object[] {
            "BrazPor",
            "English",
            "French",
            "German",
            "Polish",
            "Russian",
            "Simple Chinese",
            "Spanish"});
            this.cboxOriginalLanguage.Location = new System.Drawing.Point(947, 6);
            this.cboxOriginalLanguage.Name = "cboxOriginalLanguage";
            this.cboxOriginalLanguage.Size = new System.Drawing.Size(121, 20);
            this.cboxOriginalLanguage.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 62);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvModTree);
            this.splitContainer1.Size = new System.Drawing.Size(1076, 474);
            this.splitContainer1.SplitterDistance = 358;
            this.splitContainer1.TabIndex = 2;
            // 
            // trvMODTree
            // 
            this.trvModTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvModTree.Location = new System.Drawing.Point(0, 0);
            this.trvModTree.Name = "trvModTree";
            this.trvModTree.Size = new System.Drawing.Size(358, 474);
            this.trvModTree.TabIndex = 1;
            this.trvModTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SelectNode);
            // 
            // btnMODLoad
            // 
            this.btnModLoad.Location = new System.Drawing.Point(8, 6);
            this.btnModLoad.Name = "btnModLoad";
            this.btnModLoad.Size = new System.Drawing.Size(109, 23);
            this.btnModLoad.TabIndex = 0;
            this.btnModLoad.Text = "Load Mod File ";
            this.btnModLoad.UseVisualStyleBackColor = true;
            this.btnModLoad.Click += new System.EventHandler(this.btnTargetCheck_Click);
            // 
            // tabTranslate
            // 
            this.tabTranslate.Location = new System.Drawing.Point(4, 22);
            this.tabTranslate.Name = "tabTranslate";
            this.tabTranslate.Padding = new System.Windows.Forms.Padding(3);
            this.tabTranslate.Size = new System.Drawing.Size(1076, 536);
            this.tabTranslate.TabIndex = 1;
            this.tabTranslate.Text = "Translate";
            this.tabTranslate.UseVisualStyleBackColor = true;
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.btnTargetPathBrowse);
            this.tabSetting.Controls.Add(this.label5);
            this.tabSetting.Controls.Add(this.txtModTranslatePath);
            this.tabSetting.Controls.Add(this.btnCheckingFileBrowse);
            this.tabSetting.Controls.Add(this.label2);
            this.tabSetting.Controls.Add(this.txtModCheckPath);
            this.tabSetting.Controls.Add(this.btnOriginalPathBrowse);
            this.tabSetting.Controls.Add(this.label1);
            this.tabSetting.Controls.Add(this.txtModPath);
            this.tabSetting.Location = new System.Drawing.Point(4, 22);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Size = new System.Drawing.Size(1076, 536);
            this.tabSetting.TabIndex = 2;
            this.tabSetting.Text = "Settings";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // btnTargetPathBrowse
            // 
            this.btnTargetPathBrowse.Location = new System.Drawing.Point(440, 145);
            this.btnTargetPathBrowse.Name = "btnTargetPathBrowse";
            this.btnTargetPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnTargetPathBrowse.TabIndex = 17;
            this.btnTargetPathBrowse.Text = "Browse";
            this.btnTargetPathBrowse.UseVisualStyleBackColor = true;
            this.btnTargetPathBrowse.Click += new System.EventHandler(this.btnTargetPathBrowse_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "Translate Mod Descriptor file:";
            // 
            // txtMODTranslatePath
            // 
            this.txtModTranslatePath.Location = new System.Drawing.Point(24, 145);
            this.txtModTranslatePath.Name = "txtModTranslatePath";
            this.txtModTranslatePath.Size = new System.Drawing.Size(410, 22);
            this.txtModTranslatePath.TabIndex = 15;
            this.txtModTranslatePath.Text = "C:\\Users\\Liyea\\OneDrive\\Documents\\Paradox Interactive\\Stellaris\\mod\\nsc2cn.mod";
            // 
            // btnCheckingFileBrowse
            // 
            this.btnCheckingFileBrowse.Location = new System.Drawing.Point(440, 92);
            this.btnCheckingFileBrowse.Name = "btnCheckingFileBrowse";
            this.btnCheckingFileBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnCheckingFileBrowse.TabIndex = 14;
            this.btnCheckingFileBrowse.Text = "Browse";
            this.btnCheckingFileBrowse.UseVisualStyleBackColor = true;
            this.btnCheckingFileBrowse.Click += new System.EventHandler(this.btnCheckingFileBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mod Checking File Path:";
            // 
            // txtMODCheckPath
            // 
            this.txtModCheckPath.Location = new System.Drawing.Point(24, 92);
            this.txtModCheckPath.Name = "txtModCheckPath";
            this.txtModCheckPath.Size = new System.Drawing.Size(410, 22);
            this.txtModCheckPath.TabIndex = 12;
            this.txtModCheckPath.Text = "C:\\Users\\Liyea\\Google 雲端硬碟\\NSCMOD\\NSC2 Checkfile\\MODCheckFile.smodc";
            // 
            // btnOriginalPathBrowse
            // 
            this.btnOriginalPathBrowse.Location = new System.Drawing.Point(440, 39);
            this.btnOriginalPathBrowse.Name = "btnOriginalPathBrowse";
            this.btnOriginalPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnOriginalPathBrowse.TabIndex = 11;
            this.btnOriginalPathBrowse.Text = "Browse";
            this.btnOriginalPathBrowse.UseVisualStyleBackColor = true;
            this.btnOriginalPathBrowse.Click += new System.EventHandler(this.btnOriginalPathBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Original Mod Descriptor file:";
            // 
            // txtMODPath
            // 
            this.txtModPath.Location = new System.Drawing.Point(24, 39);
            this.txtModPath.Name = "txtModPath";
            this.txtModPath.Size = new System.Drawing.Size(410, 22);
            this.txtModPath.TabIndex = 9;
            this.txtModPath.Text = "D:\\SteamLibrary\\steamapps\\workshop\\content\\281990\\683230077\\descriptor.mod";
            // 
            // sfdSMOF
            // 
            this.sfdSMOF.CheckFileExists = true;
            this.sfdSMOF.FileName = "ModCheck";
            this.sfdSMOF.Filter = "Stellaris mod Check File|*.smoc";
            this.sfdSMOF.Title = "Save Check File";
            // 
            // ofdDescriptor
            // 
            this.ofdDescriptor.DefaultExt = "mod";
            this.ofdDescriptor.FileName = "descriptor.mod";
            this.ofdDescriptor.Filter = "Stellaris mod file|*.mod";
            // 
            // sfdDescriptor
            // 
            this.sfdDescriptor.CheckFileExists = true;
            this.sfdDescriptor.DefaultExt = "mod";
            this.sfdDescriptor.FileName = "ModCheck";
            this.sfdDescriptor.Filter = "Stellaris mod file|*.mod";
            this.sfdDescriptor.Title = "Save Check File";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 562);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(1100, 39);
            this.Name = "MainForm";
            this.Text = "Stellaris Mod Translate Tools";
            this.tabControl1.ResumeLayout(false);
            this.tabCheck.ResumeLayout(false);
            this.tabCheck.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabSetting.ResumeLayout(false);
            this.tabSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCheck;
        private System.Windows.Forms.TabPage tabTranslate;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.Button btnOriginalPathBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModPath;
        private System.Windows.Forms.Button btnModLoad;
        private System.Windows.Forms.Button btnCheckingFileBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModCheckPath;
        private System.Windows.Forms.SaveFileDialog sfdSMOF;
        private System.Windows.Forms.TreeView trvModTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxTargetLanguage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxOriginalLanguage;
        private System.Windows.Forms.Button btnLoadCheck;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chboxGenerate;
        private System.Windows.Forms.OpenFileDialog ofdDescriptor;
        private System.Windows.Forms.Button btnTargetPathBrowse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModTranslatePath;
        private System.Windows.Forms.SaveFileDialog sfdDescriptor;
        private System.Windows.Forms.Button button1;
    }
}

