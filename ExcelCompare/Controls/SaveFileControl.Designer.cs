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
            this.dialogBtn = new MetroFramework.Controls.MetroButton();
            this.pathTextBox = new MetroFramework.Controls.MetroTextBox();
            this.label = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // dialogBtn
            // 
            this.dialogBtn.Location = new System.Drawing.Point(402, 3);
            this.dialogBtn.Name = "dialogBtn";
            this.dialogBtn.Size = new System.Drawing.Size(24, 23);
            this.dialogBtn.TabIndex = 1;
            this.dialogBtn.Text = "...";
            this.dialogBtn.Click += new System.EventHandler(this.SaveDialog_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.Location = new System.Drawing.Point(129, 3);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pathTextBox.Size = new System.Drawing.Size(274, 23);
            this.pathTextBox.TabIndex = 0;
            this.pathTextBox.TextChanged += new System.EventHandler(this.path_TextChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(4, 4);
            this.label.MaximumSize = new System.Drawing.Size(120, 19);
            this.label.MinimumSize = new System.Drawing.Size(120, 19);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(120, 19);
            this.label.TabIndex = 2;
            this.label.Text = "Orginal Document:";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SaveFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.dialogBtn);
            this.Name = "SaveFileControl";
            this.Size = new System.Drawing.Size(430, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton dialogBtn;
        private MetroFramework.Controls.MetroTextBox pathTextBox;
        private MetroFramework.Controls.MetroLabel label;
    }
}
