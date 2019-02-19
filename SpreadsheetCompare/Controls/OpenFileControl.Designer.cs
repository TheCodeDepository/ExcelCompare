namespace SpreadsheetCompare
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
            this.label = new MetroFramework.Controls.MetroLabel();
            this.dialogBtn = new MetroFramework.Controls.MetroButton();
            this.pathTextBox = new MetroFramework.Controls.MetroTextBox();
            this.OpenSqlDialog = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(3, 5);
            this.label.MaximumSize = new System.Drawing.Size(120, 19);
            this.label.MinimumSize = new System.Drawing.Size(70, 19);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 0);
            this.label.Style = MetroFramework.MetroColorStyle.Black;
            this.label.TabIndex = 8;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dialogBtn
            // 
            this.dialogBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dialogBtn.Location = new System.Drawing.Point(348, 3);
            this.dialogBtn.Name = "dialogBtn";
            this.dialogBtn.Size = new System.Drawing.Size(27, 23);
            this.dialogBtn.TabIndex = 7;
            this.dialogBtn.Text = "...";
            this.dialogBtn.UseSelectable = true;
            this.dialogBtn.Click += new System.EventHandler(this.OpenDialog_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.pathTextBox.CustomButton.Image = null;
            this.pathTextBox.CustomButton.Location = new System.Drawing.Point(226, 1);
            this.pathTextBox.CustomButton.Name = "";
            this.pathTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.pathTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.pathTextBox.CustomButton.TabIndex = 1;
            this.pathTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.pathTextBox.CustomButton.UseSelectable = true;
            this.pathTextBox.CustomButton.Visible = false;
            this.pathTextBox.Enabled = false;
            this.pathTextBox.Lines = new string[0];
            this.pathTextBox.Location = new System.Drawing.Point(76, 3);
            this.pathTextBox.MaxLength = 32767;
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.PasswordChar = '\0';
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.pathTextBox.SelectedText = "";
            this.pathTextBox.SelectionLength = 0;
            this.pathTextBox.SelectionStart = 0;
            this.pathTextBox.ShortcutsEnabled = true;
            this.pathTextBox.Size = new System.Drawing.Size(248, 23);
            this.pathTextBox.TabIndex = 6;
            this.pathTextBox.UseSelectable = true;
            this.pathTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.pathTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.pathTextBox.TextChanged += new System.EventHandler(this.path_TextChanged);
            // 
            // OpenSqlDialog
            // 
            this.OpenSqlDialog.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OpenSqlDialog.Location = new System.Drawing.Point(322, 3);
            this.OpenSqlDialog.Name = "OpenSqlDialog";
            this.OpenSqlDialog.Size = new System.Drawing.Size(27, 23);
            this.OpenSqlDialog.TabIndex = 9;
            this.OpenSqlDialog.Text = "SQL";
            this.OpenSqlDialog.UseSelectable = true;
            this.OpenSqlDialog.Click += new System.EventHandler(this.OpenSqlDialog_Click);
            // 
            // OpenFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OpenSqlDialog);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dialogBtn);
            this.Controls.Add(this.pathTextBox);
            this.Name = "OpenFileControl";
            this.Size = new System.Drawing.Size(378, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel label;
        private MetroFramework.Controls.MetroButton dialogBtn;
        private MetroFramework.Controls.MetroTextBox pathTextBox;
        private MetroFramework.Controls.MetroButton OpenSqlDialog;
    }
}
