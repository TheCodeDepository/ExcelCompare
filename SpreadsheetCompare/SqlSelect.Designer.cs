namespace SpreadsheetCompare
{
    partial class SqlSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlSelect));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.connectionStringControl1 = new SpreadsheetCompare.Controls.ConnectionStringControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(23, 63);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.connectionStringControl1);
            this.splitContainer1.Size = new System.Drawing.Size(783, 329);
            this.splitContainer1.SplitterDistance = 391;
            this.splitContainer1.TabIndex = 3;
            // 
            // connectionStringControl1
            // 
            this.connectionStringControl1.Location = new System.Drawing.Point(3, 3);
            this.connectionStringControl1.Name = "connectionStringControl1";
            this.connectionStringControl1.ServerList = ((System.Collections.Generic.List<string>)(resources.GetObject("connectionStringControl1.ServerList")));
            this.connectionStringControl1.Size = new System.Drawing.Size(385, 318);
            this.connectionStringControl1.TabIndex = 0;
            this.connectionStringControl1.UseSelectable = true;
            // 
            // SqlSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 415);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SqlSelect";
            this.Text = "SQL Table Selection";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.ConnectionStringControl connectionStringControl1;
    }
}