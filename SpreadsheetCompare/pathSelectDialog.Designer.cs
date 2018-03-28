namespace SpreadsheetCompare
{
    partial class pathSelectDialog
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
            this.labellbl = new MetroFramework.Controls.MetroLabel();
            this.pathTextBox = new MetroFramework.Controls.MetroTextBox();
            this.dialogBtn = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // labellbl
            // 
            this.labellbl.Location = new System.Drawing.Point(4, 3);
            this.labellbl.Name = "labellbl";
            this.labellbl.Size = new System.Drawing.Size(125, 23);
            this.labellbl.TabIndex = 0;
            this.labellbl.Text = "label";
            this.labellbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pathTextBox
            // 
            // 
            // 
            // 
            this.pathTextBox.CustomButton.Image = null;
            this.pathTextBox.CustomButton.Location = new System.Drawing.Point(335, 1);
            this.pathTextBox.CustomButton.Name = "";
            this.pathTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.pathTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.pathTextBox.CustomButton.TabIndex = 1;
            this.pathTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.pathTextBox.CustomButton.UseSelectable = true;
            this.pathTextBox.CustomButton.Visible = false;
            this.pathTextBox.Lines = new string[] {
        "metroTextBox1"};
            this.pathTextBox.Location = new System.Drawing.Point(135, 4);
            this.pathTextBox.MaxLength = 32767;
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.PasswordChar = '\0';
            this.pathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.pathTextBox.SelectedText = "";
            this.pathTextBox.SelectionLength = 0;
            this.pathTextBox.SelectionStart = 0;
            this.pathTextBox.ShortcutsEnabled = true;
            this.pathTextBox.Size = new System.Drawing.Size(357, 23);
            this.pathTextBox.TabIndex = 1;
            this.pathTextBox.Text = "metroTextBox1";
            this.pathTextBox.UseSelectable = true;
            this.pathTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.pathTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.pathTextBox.TextChanged += new System.EventHandler(this.pathTextBox_TextChanged);
            // 
            // dialogBtn
            // 
            this.dialogBtn.BackColor = System.Drawing.Color.White;
            this.dialogBtn.Location = new System.Drawing.Point(490, 4);
            this.dialogBtn.Name = "dialogBtn";
            this.dialogBtn.Size = new System.Drawing.Size(23, 23);
            this.dialogBtn.TabIndex = 2;
            this.dialogBtn.Text = "...";
            this.dialogBtn.UseSelectable = true;
            this.dialogBtn.Click += new System.EventHandler(this.dialogBtn_Click);
            // 
            // pathSelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dialogBtn);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.labellbl);
            this.Name = "pathSelectDialog";
            this.Size = new System.Drawing.Size(518, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel labellbl;
        private MetroFramework.Controls.MetroTextBox pathTextBox;
        private MetroFramework.Controls.MetroButton dialogBtn;
    }
}
