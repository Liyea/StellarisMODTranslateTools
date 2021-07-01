
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chboxGenerate = new System.Windows.Forms.CheckBox();
            this.btnVersionCheck = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxTargetLanguage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxOriginalLanguage = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvMODTree = new System.Windows.Forms.TreeView();
            this.btnMODLoad = new System.Windows.Forms.Button();
            this.tabTranslate = new System.Windows.Forms.TabPage();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.btnOldVerBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMODCheckPath = new System.Windows.Forms.TextBox();
            this.btnTargetPathBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMODPath = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
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
            this.tabCheck.Controls.Add(this.btnGenerate);
            this.tabCheck.Controls.Add(this.chboxGenerate);
            this.tabCheck.Controls.Add(this.btnVersionCheck);
            this.tabCheck.Controls.Add(this.label4);
            this.tabCheck.Controls.Add(this.cboxTargetLanguage);
            this.tabCheck.Controls.Add(this.label3);
            this.tabCheck.Controls.Add(this.cboxOriginalLanguage);
            this.tabCheck.Controls.Add(this.splitContainer1);
            this.tabCheck.Controls.Add(this.btnMODLoad);
            this.tabCheck.Location = new System.Drawing.Point(4, 22);
            this.tabCheck.Name = "tabCheck";
            this.tabCheck.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheck.Size = new System.Drawing.Size(1076, 536);
            this.tabCheck.TabIndex = 0;
            this.tabCheck.Text = "File Check";
            this.tabCheck.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(468, 6);
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
            // btnVersionCheck
            // 
            this.btnVersionCheck.Location = new System.Drawing.Point(123, 6);
            this.btnVersionCheck.Name = "btnVersionCheck";
            this.btnVersionCheck.Size = new System.Drawing.Size(109, 23);
            this.btnVersionCheck.TabIndex = 7;
            this.btnVersionCheck.Text = "Version File Check";
            this.btnVersionCheck.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(853, 11);
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
            this.cboxTargetLanguage.Location = new System.Drawing.Point(949, 8);
            this.cboxTargetLanguage.Name = "cboxTargetLanguage";
            this.cboxTargetLanguage.Size = new System.Drawing.Size(121, 20);
            this.cboxTargetLanguage.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(622, 11);
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
            this.cboxOriginalLanguage.Location = new System.Drawing.Point(726, 8);
            this.cboxOriginalLanguage.Name = "cboxOriginalLanguage";
            this.cboxOriginalLanguage.Size = new System.Drawing.Size(121, 20);
            this.cboxOriginalLanguage.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvMODTree);
            this.splitContainer1.Size = new System.Drawing.Size(1076, 501);
            this.splitContainer1.SplitterDistance = 358;
            this.splitContainer1.TabIndex = 2;
            // 
            // trvMODTree
            // 
            this.trvMODTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMODTree.Location = new System.Drawing.Point(0, 0);
            this.trvMODTree.Name = "trvMODTree";
            this.trvMODTree.Size = new System.Drawing.Size(358, 501);
            this.trvMODTree.TabIndex = 1;
            // 
            // btnMODLoad
            // 
            this.btnMODLoad.Location = new System.Drawing.Point(8, 6);
            this.btnMODLoad.Name = "btnMODLoad";
            this.btnMODLoad.Size = new System.Drawing.Size(109, 23);
            this.btnMODLoad.TabIndex = 0;
            this.btnMODLoad.Text = "MOD File Load";
            this.btnMODLoad.UseVisualStyleBackColor = true;
            this.btnMODLoad.Click += new System.EventHandler(this.btnTargetCheck_Click);
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
            this.tabSetting.Controls.Add(this.btnOldVerBrowse);
            this.tabSetting.Controls.Add(this.label2);
            this.tabSetting.Controls.Add(this.txtMODCheckPath);
            this.tabSetting.Controls.Add(this.btnTargetPathBrowse);
            this.tabSetting.Controls.Add(this.label1);
            this.tabSetting.Controls.Add(this.txtMODPath);
            this.tabSetting.Location = new System.Drawing.Point(4, 22);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Size = new System.Drawing.Size(1076, 536);
            this.tabSetting.TabIndex = 2;
            this.tabSetting.Text = "Settings";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // btnOldVerBrowse
            // 
            this.btnOldVerBrowse.Location = new System.Drawing.Point(440, 92);
            this.btnOldVerBrowse.Name = "btnOldVerBrowse";
            this.btnOldVerBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnOldVerBrowse.TabIndex = 14;
            this.btnOldVerBrowse.Text = "Browse";
            this.btnOldVerBrowse.UseVisualStyleBackColor = true;
            this.btnOldVerBrowse.Click += new System.EventHandler(this.btnOldVerBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "Target MOD Old Version File Path:";
            // 
            // txtMODCheckPath
            // 
            this.txtMODCheckPath.Location = new System.Drawing.Point(24, 92);
            this.txtMODCheckPath.Name = "txtMODCheckPath";
            this.txtMODCheckPath.Size = new System.Drawing.Size(410, 22);
            this.txtMODCheckPath.TabIndex = 12;
            this.txtMODCheckPath.Text = "C:\\Users\\Liyea\\Google 雲端硬碟\\NSCMOD\\NSC2 Checkfile\\MODCheckFile.smodc";
            // 
            // btnTargetPathBrowse
            // 
            this.btnTargetPathBrowse.Location = new System.Drawing.Point(440, 39);
            this.btnTargetPathBrowse.Name = "btnTargetPathBrowse";
            this.btnTargetPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnTargetPathBrowse.TabIndex = 11;
            this.btnTargetPathBrowse.Text = "Browse";
            this.btnTargetPathBrowse.UseVisualStyleBackColor = true;
            this.btnTargetPathBrowse.Click += new System.EventHandler(this.btnTargetPathBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Target MOD Folder Path:";
            // 
            // txtMODPath
            // 
            this.txtMODPath.Location = new System.Drawing.Point(24, 39);
            this.txtMODPath.Name = "txtMODPath";
            this.txtMODPath.Size = new System.Drawing.Size(410, 22);
            this.txtMODPath.TabIndex = 9;
            this.txtMODPath.Text = "D:\\SteamLibrary\\steamapps\\workshop\\content\\281990\\683230077";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.CheckFileExists = true;
            this.saveFileDialog.FileName = "MODCheck";
            this.saveFileDialog.Filter = "Stellaris MOD Check File|*.smoc";
            this.saveFileDialog.Title = "Save Check File";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 562);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(1100, 39);
            this.Name = "MainForm";
            this.Text = "Stellaris MOD Translate Tools";
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
        private System.Windows.Forms.Button btnTargetPathBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMODPath;
        private System.Windows.Forms.Button btnMODLoad;
        private System.Windows.Forms.Button btnOldVerBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMODCheckPath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TreeView trvMODTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxTargetLanguage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxOriginalLanguage;
        private System.Windows.Forms.Button btnVersionCheck;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chboxGenerate;
    }
}

