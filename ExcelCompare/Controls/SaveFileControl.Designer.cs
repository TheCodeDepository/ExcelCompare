namespace ExcelCompare
{
    partial class SaveFileControl
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
            this.SaveDialog = new System.Windows.Forms.Button();
            this.Label = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaveDialog
            // 
            this.SaveDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.SaveDialog.Location = new System.Drawing.Point(251, 2);
            this.SaveDialog.Name = "SaveDialog";
            this.SaveDialog.Size = new System.Drawing.Size(22, 18);
            this.SaveDialog.TabIndex = 5;
            this.SaveDialog.Text = "...";
            this.SaveDialog.UseVisualStyleBackColor = true;
            this.SaveDialog.Click += new System.EventHandler(this.SaveDialog_Click);
            // 
            // Label
            // 
            this.Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label.Location = new System.Drawing.Point(3, 2);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(91, 17);
            this.Label.TabIndex = 4;
            this.Label.Text = "Document";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.path.TabIndex = 3;
            // 
            // SaveFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SaveDialog);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.path);
            this.Name = "SaveFileControl";
            this.Size = new System.Drawing.Size(277, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveDialog;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.TextBox path;
    }
}
