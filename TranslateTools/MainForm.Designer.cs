
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
            this.btnNSC2Check = new System.Windows.Forms.Button();
            this.tabTranslate = new System.Windows.Forms.TabPage();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.btnOldVerBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMODCheckPath = new System.Windows.Forms.TextBox();
            this.btnTargetPathBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMODPath = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.trvMODTree = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1.SuspendLayout();
            this.tabCheck.SuspendLayout();
            this.tabSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(843, 562);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCheck
            // 
            this.tabCheck.Controls.Add(this.splitContainer1);
            this.tabCheck.Controls.Add(this.btnNSC2Check);
            this.tabCheck.Location = new System.Drawing.Point(4, 22);
            this.tabCheck.Name = "tabCheck";
            this.tabCheck.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheck.Size = new System.Drawing.Size(835, 536);
            this.tabCheck.TabIndex = 0;
            this.tabCheck.Text = "File Check";
            this.tabCheck.UseVisualStyleBackColor = true;
            // 
            // btnNSC2Check
            // 
            this.btnNSC2Check.Location = new System.Drawing.Point(8, 6);
            this.btnNSC2Check.Name = "btnNSC2Check";
            this.btnNSC2Check.Size = new System.Drawing.Size(109, 23);
            this.btnNSC2Check.TabIndex = 0;
            this.btnNSC2Check.Text = "Version File Check";
            this.btnNSC2Check.UseVisualStyleBackColor = true;
            this.btnNSC2Check.Click += new System.EventHandler(this.btnTargetCheck_Click);
            // 
            // tabTranslate
            // 
            this.tabTranslate.Location = new System.Drawing.Point(4, 22);
            this.tabTranslate.Name = "tabTranslate";
            this.tabTranslate.Padding = new System.Windows.Forms.Padding(3);
            this.tabTranslate.Size = new System.Drawing.Size(792, 424);
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
            this.tabSetting.Size = new System.Drawing.Size(792, 424);
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
            // trvMODTree
            // 
            this.trvMODTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMODTree.Location = new System.Drawing.Point(0, 0);
            this.trvMODTree.Name = "trvMODTree";
            this.trvMODTree.Size = new System.Drawing.Size(278, 501);
            this.trvMODTree.TabIndex = 1;
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
            this.splitContainer1.Size = new System.Drawing.Size(835, 501);
            this.splitContainer1.SplitterDistance = 278;
            this.splitContainer1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 562);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Stellaris MOD Translate Tools";
            this.tabControl1.ResumeLayout(false);
            this.tabCheck.ResumeLayout(false);
            this.tabSetting.ResumeLayout(false);
            this.tabSetting.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnNSC2Check;
        private System.Windows.Forms.Button btnOldVerBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMODCheckPath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TreeView trvMODTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

