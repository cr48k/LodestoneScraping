namespace LodestoneScraping
{
    partial class viewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.viewTabControl = new System.Windows.Forms.TabControl();
            this.summaryTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.viewTabControl.SuspendLayout();
            this.summaryTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewTabControl
            // 
            this.viewTabControl.Controls.Add(this.summaryTabPage);
            this.viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewTabControl.Location = new System.Drawing.Point(0, 0);
            this.viewTabControl.Name = "viewTabControl";
            this.viewTabControl.SelectedIndex = 0;
            this.viewTabControl.Size = new System.Drawing.Size(714, 534);
            this.viewTabControl.TabIndex = 0;
            // 
            // summaryTabPage
            // 
            this.summaryTabPage.Controls.Add(this.label1);
            this.summaryTabPage.Location = new System.Drawing.Point(4, 24);
            this.summaryTabPage.Name = "summaryTabPage";
            this.summaryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.summaryTabPage.Size = new System.Drawing.Size(706, 506);
            this.summaryTabPage.TabIndex = 0;
            this.summaryTabPage.Text = "概要";
            this.summaryTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "No data to show.";
            // 
            // viewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 534);
            this.Controls.Add(this.viewTabControl);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "viewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "viewForm";
            this.viewTabControl.ResumeLayout(false);
            this.summaryTabPage.ResumeLayout(false);
            this.summaryTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage summaryTabPage;
        private System.Windows.Forms.Label label1;
    }
}