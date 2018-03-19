namespace ExcelCompare
{
    partial class OpenFileControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.path = new System.Windows.Forms.TextBox();
            this.Label = new System.Windows.Forms.Label();
            this.OpenDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // path
            // 
            this.path.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.path.Location = new System.Drawing.Point(100, 1);
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.Size = new System.Drawing.Size(174, 20);
            this.path.TabIndex = 0;
            this.path.TextChanged += new System.EventHandler(this.path_TextChanged);
            // 
            // Label
            // 
            this.Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label.Location = new System.Drawing.Point(3, 2);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(91, 17);
            this.Label.TabIndex = 1;
            this.Label.Text = "Document";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Label.Click += new System.EventHandler(this.Label_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.OpenDialog.Location = new System.Drawing.Point(251, 2);
            this.OpenDialog.Name = "OpenDialog";
            this.OpenDialog.Size = new System.Drawing.Size(22, 18);
            this.OpenDialog.TabIndex = 2;
            this.OpenDialog.Text = "...";
            this.OpenDialog.UseVisualStyleBackColor = true;
            this.OpenDialog.Click += new System.EventHandler(this.OpenDialog_Click);
            // 
            // OpenFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OpenDialog);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.path);
            this.Name = "OpenFileControl";
            this.Size = new System.Drawing.Size(277, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button OpenDialog;
    }
}
