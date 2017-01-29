namespace LodestoneScraping
{
    partial class mainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.parsingPanel = new System.Windows.Forms.Panel();
            this.parsingProgressLabel = new System.Windows.Forms.Label();
            this.parsingProgressBar = new System.Windows.Forms.ProgressBar();
            this.mainWebBrowser = new System.Windows.Forms.WebBrowser();
            this.browserStatusStrip = new System.Windows.Forms.StatusStrip();
            this.testToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.subWebBrowser = new System.Windows.Forms.WebBrowser();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.exportMessageLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.retainerListBox = new System.Windows.Forms.ListBox();
            this.selectedRetainerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setectedItemOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.characterInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.serverNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.characterNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.parsingPanel.SuspendLayout();
            this.browserStatusStrip.SuspendLayout();
            this.selectedRetainerContextMenuStrip.SuspendLayout();
            this.characterInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.IsSplitterFixed = true;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.parsingPanel);
            this.mainSplitContainer.Panel1.Controls.Add(this.mainWebBrowser);
            this.mainSplitContainer.Panel1.Controls.Add(this.browserStatusStrip);
            this.mainSplitContainer.Panel1.Controls.Add(this.urlTextBox);
            this.mainSplitContainer.Panel1.Controls.Add(this.subWebBrowser);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.selectAllCheckBox);
            this.mainSplitContainer.Panel2.Controls.Add(this.exportMessageLabel);
            this.mainSplitContainer.Panel2.Controls.Add(this.exportButton);
            this.mainSplitContainer.Panel2.Controls.Add(this.retainerListBox);
            this.mainSplitContainer.Panel2.Controls.Add(this.label3);
            this.mainSplitContainer.Panel2.Controls.Add(this.characterInfoGroupBox);
            this.mainSplitContainer.Size = new System.Drawing.Size(1264, 813);
            this.mainSplitContainer.SplitterDistance = 1024;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // parsingPanel
            // 
            this.parsingPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.parsingPanel.Controls.Add(this.parsingProgressLabel);
            this.parsingPanel.Controls.Add(this.parsingProgressBar);
            this.parsingPanel.Location = new System.Drawing.Point(382, 281);
            this.parsingPanel.Name = "parsingPanel";
            this.parsingPanel.Size = new System.Drawing.Size(500, 250);
            this.parsingPanel.TabIndex = 1;
            this.parsingPanel.Visible = false;
            // 
            // parsingProgressLabel
            // 
            this.parsingProgressLabel.AutoSize = true;
            this.parsingProgressLabel.Location = new System.Drawing.Point(74, 93);
            this.parsingProgressLabel.Name = "parsingProgressLabel";
            this.parsingProgressLabel.Size = new System.Drawing.Size(12, 15);
            this.parsingProgressLabel.TabIndex = 1;
            this.parsingProgressLabel.Text = "-";
            // 
            // parsingProgressBar
            // 
            this.parsingProgressBar.Location = new System.Drawing.Point(71, 111);
            this.parsingProgressBar.Name = "parsingProgressBar";
            this.parsingProgressBar.Size = new System.Drawing.Size(359, 28);
            this.parsingProgressBar.TabIndex = 0;
            // 
            // mainWebBrowser
            // 
            this.mainWebBrowser.AllowWebBrowserDrop = false;
            this.mainWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWebBrowser.Location = new System.Drawing.Point(0, 23);
            this.mainWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.mainWebBrowser.Name = "mainWebBrowser";
            this.mainWebBrowser.Size = new System.Drawing.Size(1024, 768);
            this.mainWebBrowser.TabIndex = 2;
            this.mainWebBrowser.Url = new System.Uri("http://jp.finalfantasyxiv.com/lodestone/", System.UriKind.Absolute);
            this.mainWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.mainWebBrowser_DocumentCompleted);
            this.mainWebBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.mainWebBrowser_Navigated);
            // 
            // browserStatusStrip
            // 
            this.browserStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripStatusLabel});
            this.browserStatusStrip.Location = new System.Drawing.Point(0, 791);
            this.browserStatusStrip.Name = "browserStatusStrip";
            this.browserStatusStrip.Size = new System.Drawing.Size(1024, 22);
            this.browserStatusStrip.TabIndex = 1;
            this.browserStatusStrip.Text = "statusStrip1";
            // 
            // testToolStripStatusLabel
            // 
            this.testToolStripStatusLabel.Name = "testToolStripStatusLabel";
            this.testToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // urlTextBox
            // 
            this.urlTextBox.BackColor = System.Drawing.Color.White;
            this.urlTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.urlTextBox.Location = new System.Drawing.Point(0, 0);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.ReadOnly = true;
            this.urlTextBox.Size = new System.Drawing.Size(1024, 23);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.TabStop = false;
            // 
            // subWebBrowser
            // 
            this.subWebBrowser.AllowWebBrowserDrop = false;
            this.subWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.subWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.subWebBrowser.Name = "subWebBrowser";
            this.subWebBrowser.Size = new System.Drawing.Size(1024, 813);
            this.subWebBrowser.TabIndex = 3;
            this.subWebBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.subWebBrowser.Visible = false;
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(151, 98);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(79, 19);
            this.selectAllCheckBox.TabIndex = 5;
            this.selectAllCheckBox.Text = "すべて選択";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.CheckedChanged += new System.EventHandler(this.selectAllCheckBox_CheckedChanged);
            // 
            // exportMessageLabel
            // 
            this.exportMessageLabel.BackColor = System.Drawing.Color.White;
            this.exportMessageLabel.Location = new System.Drawing.Point(6, 236);
            this.exportMessageLabel.Name = "exportMessageLabel";
            this.exportMessageLabel.Size = new System.Drawing.Size(153, 15);
            this.exportMessageLabel.TabIndex = 4;
            this.exportMessageLabel.Text = "選択中のデータを";
            this.exportMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(160, 232);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(70, 23);
            this.exportButton.TabIndex = 3;
            this.exportButton.Text = "エクスポート";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // retainerListBox
            // 
            this.retainerListBox.ContextMenuStrip = this.selectedRetainerContextMenuStrip;
            this.retainerListBox.FormattingEnabled = true;
            this.retainerListBox.HorizontalScrollbar = true;
            this.retainerListBox.ItemHeight = 15;
            this.retainerListBox.Location = new System.Drawing.Point(3, 117);
            this.retainerListBox.Name = "retainerListBox";
            this.retainerListBox.ScrollAlwaysVisible = true;
            this.retainerListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.retainerListBox.Size = new System.Drawing.Size(227, 109);
            this.retainerListBox.TabIndex = 2;
            this.retainerListBox.SelectedIndexChanged += new System.EventHandler(this.retainerListBox_SelectedIndexChanged);
            // 
            // selectedRetainerContextMenuStrip
            // 
            this.selectedRetainerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.toolStripSeparator1,
            this.setectedItemOptionToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.selectedRetainerContextMenuStrip.Name = "selectedRetainerContextMenuStrip";
            this.selectedRetainerContextMenuStrip.Size = new System.Drawing.Size(161, 76);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.updateToolStripMenuItem.Text = "データ更新";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // setectedItemOptionToolStripMenuItem
            // 
            this.setectedItemOptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.setectedItemOptionToolStripMenuItem.Name = "setectedItemOptionToolStripMenuItem";
            this.setectedItemOptionToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.setectedItemOptionToolStripMenuItem.Text = "選択中のデータ";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewToolStripMenuItem.Text = "表示";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "削除";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.clearToolStripMenuItem.Text = "クリア";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "取得済みデータ";
            // 
            // characterInfoGroupBox
            // 
            this.characterInfoGroupBox.Controls.Add(this.serverNameLabel);
            this.characterInfoGroupBox.Controls.Add(this.label2);
            this.characterInfoGroupBox.Controls.Add(this.characterNameLabel);
            this.characterInfoGroupBox.Controls.Add(this.label1);
            this.characterInfoGroupBox.Location = new System.Drawing.Point(3, 3);
            this.characterInfoGroupBox.Name = "characterInfoGroupBox";
            this.characterInfoGroupBox.Size = new System.Drawing.Size(227, 84);
            this.characterInfoGroupBox.TabIndex = 0;
            this.characterInfoGroupBox.TabStop = false;
            this.characterInfoGroupBox.Text = "選択中のキャラクター";
            // 
            // serverNameLabel
            // 
            this.serverNameLabel.AutoSize = true;
            this.serverNameLabel.Location = new System.Drawing.Point(88, 52);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(12, 15);
            this.serverNameLabel.TabIndex = 3;
            this.serverNameLabel.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "サーバー名:";
            // 
            // characterNameLabel
            // 
            this.characterNameLabel.AutoSize = true;
            this.characterNameLabel.Location = new System.Drawing.Point(88, 28);
            this.characterNameLabel.Name = "characterNameLabel";
            this.characterNameLabel.Size = new System.Drawing.Size(12, 15);
            this.characterNameLabel.TabIndex = 1;
            this.characterNameLabel.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "キャラクター名:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 813);
            this.Controls.Add(this.mainSplitContainer);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lodestone Scraping";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel1.PerformLayout();
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.parsingPanel.ResumeLayout(false);
            this.parsingPanel.PerformLayout();
            this.browserStatusStrip.ResumeLayout(false);
            this.browserStatusStrip.PerformLayout();
            this.selectedRetainerContextMenuStrip.ResumeLayout(false);
            this.characterInfoGroupBox.ResumeLayout(false);
            this.characterInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.WebBrowser mainWebBrowser;
        private System.Windows.Forms.StatusStrip browserStatusStrip;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.GroupBox characterInfoGroupBox;
        private System.Windows.Forms.Label serverNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label characterNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox retainerListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
        private System.Windows.Forms.Label exportMessageLabel;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Panel parsingPanel;
        private System.Windows.Forms.Label parsingProgressLabel;
        private System.Windows.Forms.ProgressBar parsingProgressBar;
        private System.Windows.Forms.WebBrowser subWebBrowser;
        private System.Windows.Forms.ToolStripStatusLabel testToolStripStatusLabel;
        private System.Windows.Forms.ContextMenuStrip selectedRetainerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem setectedItemOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

