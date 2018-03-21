namespace ExcelCompare
{
    partial class Main
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
            this.CompareBtn = new System.Windows.Forms.Button();
            this.Output = new ExcelCompare.SaveFileControl();
            this.FileTwo = new ExcelCompare.OpenFileControl();
            this.FileOne = new ExcelCompare.OpenFileControl();
            this.SuspendLayout();
            // 
            // CompareBtn
            // 
            this.CompareBtn.Enabled = false;
            this.CompareBtn.Location = new System.Drawing.Point(415, 13);
            this.CompareBtn.Name = "CompareBtn";
            this.CompareBtn.Size = new System.Drawing.Size(90, 80);
            this.CompareBtn.TabIndex = 2;
            this.CompareBtn.Text = "Compare";
            this.CompareBtn.UseVisualStyleBackColor = true;
            this.CompareBtn.Click += new System.EventHandler(this.CompareBtn_Click);
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(12, 71);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(396, 22);
            this.Output.TabIndex = 4;
            this.Output.Title = "Output:";
            this.Output.Leave += new System.EventHandler(this.CheckDocumentsEvt);
            // 
            // FileTwo
            // 
            this.FileTwo.Location = new System.Drawing.Point(13, 42);
            this.FileTwo.Name = "FileTwo";
            this.FileTwo.Size = new System.Drawing.Size(395, 22);
            this.FileTwo.TabIndex = 1;
            this.FileTwo.Title = "Document Two:";
            this.FileTwo.Leave += new System.EventHandler(this.CheckDocumentsEvt);
            // 
            // FileOne
            // 
            this.FileOne.Location = new System.Drawing.Point(13, 13);
            this.FileOne.Name = "FileOne";
            this.FileOne.Size = new System.Drawing.Size(395, 22);
            this.FileOne.TabIndex = 0;
            this.FileOne.Title = "Document One:";
            this.FileOne.Leave += new System.EventHandler(this.CheckDocumentsEvt);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 106);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.CompareBtn);
            this.Controls.Add(this.FileTwo);
            this.Controls.Add(this.FileOne);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(533, 145);
            this.MinimumSize = new System.Drawing.Size(533, 145);
            this.Name = "Main";
            this.Text = "Excel Compare";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenFileControl FileOne;
        private OpenFileControl FileTwo;
        private System.Windows.Forms.Button CompareBtn;
        private SaveFileControl Output;
    }
}

