namespace ExcelCompare
{
    partial class MainForm
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
            this.openFileControl2 = new ExcelCompare.OpenFileControl();
            this.openFileControl1 = new ExcelCompare.OpenFileControl();
            this.CompareBtn = new MetroFramework.Controls.MetroButton();
            this.genSpreadcBox = new MetroFramework.Controls.MetroCheckBox();
            this.openSpeadcBox = new MetroFramework.Controls.MetroCheckBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileControl2
            // 
            this.openFileControl2.Location = new System.Drawing.Point(23, 98);
            this.openFileControl2.Name = "openFileControl2";
            this.openFileControl2.Size = new System.Drawing.Size(427, 29);
            this.openFileControl2.TabIndex = 1;
            this.openFileControl2.Title = "Document:";
            // 
            // openFileControl1
            // 
            this.openFileControl1.Location = new System.Drawing.Point(23, 63);
            this.openFileControl1.Name = "openFileControl1";
            this.openFileControl1.Size = new System.Drawing.Size(427, 29);
            this.openFileControl1.TabIndex = 0;
            this.openFileControl1.Title = "Orginal Document:";
            // 
            // CompareBtn
            // 
            this.CompareBtn.Location = new System.Drawing.Point(746, 104);
            this.CompareBtn.Name = "CompareBtn";
            this.CompareBtn.Size = new System.Drawing.Size(75, 23);
            this.CompareBtn.TabIndex = 2;
            this.CompareBtn.Text = "Compare";
            this.CompareBtn.Click += new System.EventHandler(this.CompareBtn_Click);
            // 
            // genSpreadcBox
            // 
            this.genSpreadcBox.AutoSize = true;
            this.genSpreadcBox.Location = new System.Drawing.Point(681, 63);
            this.genSpreadcBox.Name = "genSpreadcBox";
            this.genSpreadcBox.Size = new System.Drawing.Size(137, 15);
            this.genSpreadcBox.TabIndex = 4;
            this.genSpreadcBox.Text = "Generate Spreadsheet";
            this.genSpreadcBox.UseVisualStyleBackColor = true;
            this.genSpreadcBox.CheckedChanged += new System.EventHandler(this.genSpreadcBox_CheckedChanged);
            // 
            // openSpeadcBox
            // 
            this.openSpeadcBox.AutoSize = true;
            this.openSpeadcBox.Enabled = false;
            this.openSpeadcBox.Location = new System.Drawing.Point(681, 84);
            this.openSpeadcBox.Name = "openSpeadcBox";
            this.openSpeadcBox.Size = new System.Drawing.Size(119, 15);
            this.openSpeadcBox.TabIndex = 5;
            this.openSpeadcBox.Text = "Open Spreadsheet";
            this.openSpeadcBox.UseVisualStyleBackColor = true;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Location = new System.Drawing.Point(23, 134);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Size = new System.Drawing.Size(802, 372);
            this.metroTabControl1.TabIndex = 6;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroRadioButton2);
            this.metroPanel1.Controls.Add(this.metroRadioButton1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(577, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(98, 52);
            this.metroPanel1.TabIndex = 7;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroRadioButton1
            // 
            this.metroRadioButton1.AutoSize = true;
            this.metroRadioButton1.Location = new System.Drawing.Point(4, 4);
            this.metroRadioButton1.Name = "metroRadioButton1";
            this.metroRadioButton1.Size = new System.Drawing.Size(55, 15);
            this.metroRadioButton1.TabIndex = 2;
            this.metroRadioButton1.TabStop = true;
            this.metroRadioButton1.Text = "Single";
            this.metroRadioButton1.UseVisualStyleBackColor = true;
            this.metroRadioButton1.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // metroRadioButton2
            // 
            this.metroRadioButton2.AutoSize = true;
            this.metroRadioButton2.Location = new System.Drawing.Point(4, 24);
            this.metroRadioButton2.Name = "metroRadioButton2";
            this.metroRadioButton2.Size = new System.Drawing.Size(86, 15);
            this.metroRadioButton2.TabIndex = 3;
            this.metroRadioButton2.TabStop = true;
            this.metroRadioButton2.Text = "Side by Side";
            this.metroRadioButton2.UseVisualStyleBackColor = true;
            this.metroRadioButton2.CheckedChanged += new System.EventHandler(this.CheckChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 529);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.openSpeadcBox);
            this.Controls.Add(this.genSpreadcBox);
            this.Controls.Add(this.CompareBtn);
            this.Controls.Add(this.openFileControl2);
            this.Controls.Add(this.openFileControl1);
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Spreadsheet Compare";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileControl openFileControl1;
        private OpenFileControl openFileControl2;
        private MetroFramework.Controls.MetroButton CompareBtn;
        private MetroFramework.Controls.MetroCheckBox genSpreadcBox;
        private MetroFramework.Controls.MetroCheckBox openSpeadcBox;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton2;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton1;
    }
}