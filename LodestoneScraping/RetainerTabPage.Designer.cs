namespace LodestoneScraping
{
    partial class RetainerTabPage
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.retainerIdLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.retainerNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.retainerOwnerLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.retainerServerLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.retainerGilLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.retainerLastUpdateLabel = new System.Windows.Forms.Label();
            this.borderLineLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.itemDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 476);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // retainerIdLabel
            // 
            this.retainerIdLabel.AutoSize = true;
            this.retainerIdLabel.Location = new System.Drawing.Point(35, 476);
            this.retainerIdLabel.Name = "retainerIdLabel";
            this.retainerIdLabel.Size = new System.Drawing.Size(12, 15);
            this.retainerIdLabel.TabIndex = 1;
            this.retainerIdLabel.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "リテイナー名:";
            // 
            // retainerNameLabel
            // 
            this.retainerNameLabel.AutoSize = true;
            this.retainerNameLabel.Location = new System.Drawing.Point(78, 9);
            this.retainerNameLabel.Name = "retainerNameLabel";
            this.retainerNameLabel.Size = new System.Drawing.Size(12, 15);
            this.retainerNameLabel.TabIndex = 3;
            this.retainerNameLabel.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "オーナー:";
            // 
            // retainerOwnerLabel
            // 
            this.retainerOwnerLabel.Location = new System.Drawing.Point(221, 33);
            this.retainerOwnerLabel.Name = "retainerOwnerLabel";
            this.retainerOwnerLabel.Size = new System.Drawing.Size(255, 15);
            this.retainerOwnerLabel.TabIndex = 5;
            this.retainerOwnerLabel.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "サーバー:";
            // 
            // retainerServerLabel
            // 
            this.retainerServerLabel.Location = new System.Drawing.Point(61, 33);
            this.retainerServerLabel.Name = "retainerServerLabel";
            this.retainerServerLabel.Size = new System.Drawing.Size(97, 15);
            this.retainerServerLabel.TabIndex = 7;
            this.retainerServerLabel.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(482, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "所持ギル数:";
            // 
            // retainerGilLabel
            // 
            this.retainerGilLabel.Location = new System.Drawing.Point(556, 9);
            this.retainerGilLabel.Name = "retainerGilLabel";
            this.retainerGilLabel.Size = new System.Drawing.Size(141, 15);
            this.retainerGilLabel.TabIndex = 9;
            this.retainerGilLabel.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(482, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "更新日時:";
            // 
            // retainerLastUpdateLabel
            // 
            this.retainerLastUpdateLabel.Location = new System.Drawing.Point(548, 33);
            this.retainerLastUpdateLabel.Name = "retainerLastUpdateLabel";
            this.retainerLastUpdateLabel.Size = new System.Drawing.Size(149, 15);
            this.retainerLastUpdateLabel.TabIndex = 11;
            this.retainerLastUpdateLabel.Text = "-";
            // 
            // borderLineLabel
            // 
            this.borderLineLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderLineLabel.Location = new System.Drawing.Point(0, 60);
            this.borderLineLabel.Name = "borderLineLabel";
            this.borderLineLabel.Size = new System.Drawing.Size(700, 1);
            this.borderLineLabel.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "アイテムリスト:";
            // 
            // itemDataGridView
            // 
            this.itemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemDataGridView.Location = new System.Drawing.Point(15, 102);
            this.itemDataGridView.Name = "itemDataGridView";
            this.itemDataGridView.RowTemplate.Height = 21;
            this.itemDataGridView.Size = new System.Drawing.Size(673, 362);
            this.itemDataGridView.TabIndex = 15;
            // 
            // RetainerTabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.itemDataGridView);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.borderLineLabel);
            this.Controls.Add(this.retainerLastUpdateLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.retainerGilLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.retainerServerLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.retainerOwnerLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.retainerNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.retainerIdLabel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RetainerTabPage";
            this.Size = new System.Drawing.Size(700, 500);
            this.Load += new System.EventHandler(this.RetainerTabPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label retainerIdLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label retainerNameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label retainerOwnerLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label retainerServerLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label retainerGilLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label retainerLastUpdateLabel;
        private System.Windows.Forms.Label borderLineLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView itemDataGridView;
    }
}
