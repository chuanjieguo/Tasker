namespace Tasker
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.wbContent = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbContent
            // 
            this.wbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbContent.Location = new System.Drawing.Point(0, 0);
            this.wbContent.Margin = new System.Windows.Forms.Padding(4);
            this.wbContent.MinimumSize = new System.Drawing.Size(30, 30);
            this.wbContent.Name = "wbContent";
            this.wbContent.ScriptErrorsSuppressed = true;
            this.wbContent.Size = new System.Drawing.Size(927, 525);
            this.wbContent.TabIndex = 0;
            this.wbContent.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbContent_DocumentCompleted);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(927, 525);
            this.Controls.Add(this.wbContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.Text = "玲娜贝儿提醒您~";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbContent;
    }
}