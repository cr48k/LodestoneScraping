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
            this.templateTabControl = new System.Windows.Forms.TabControl();
            this.templateTabPage = new System.Windows.Forms.TabPage();
            this.templateTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // templateTabControl
            // 
            this.templateTabControl.Controls.Add(this.templateTabPage);
            this.templateTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateTabControl.Location = new System.Drawing.Point(0, 0);
            this.templateTabControl.Name = "templateTabControl";
            this.templateTabControl.SelectedIndex = 0;
            this.templateTabControl.Size = new System.Drawing.Size(739, 569);
            this.templateTabControl.TabIndex = 0;
            // 
            // templateTabPage
            // 
            this.templateTabPage.Location = new System.Drawing.Point(4, 24);
            this.templateTabPage.Name = "templateTabPage";
            this.templateTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.templateTabPage.Size = new System.Drawing.Size(731, 541);
            this.templateTabPage.TabIndex = 0;
            this.templateTabPage.Text = "リテイナー名";
            this.templateTabPage.UseVisualStyleBackColor = true;
            // 
            // viewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(739, 569);
            this.Controls.Add(this.templateTabControl);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "viewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "viewForm";
            this.templateTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl templateTabControl;
        private System.Windows.Forms.TabPage templateTabPage;
    }
}