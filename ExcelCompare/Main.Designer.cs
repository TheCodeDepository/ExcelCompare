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
            this.ResultView = new System.Windows.Forms.DataGridView();
            this.Output = new ExcelCompare.SaveFileControl();
            this.FileTwo = new ExcelCompare.OpenFileControl();
            this.FileOne = new ExcelCompare.OpenFileControl();
            ((System.ComponentModel.ISupportInitialize)(this.ResultView)).BeginInit();
            this.SuspendLayout();
            // 
            // CompareBtn
            // 
            this.CompareBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CompareBtn.Enabled = false;
            this.CompareBtn.Location = new System.Drawing.Point(523, 13);
            this.CompareBtn.Name = "CompareBtn";
            this.CompareBtn.Size = new System.Drawing.Size(90, 80);
            this.CompareBtn.TabIndex = 2;
            this.CompareBtn.Text = "Compare";
            this.CompareBtn.UseVisualStyleBackColor = true;
            this.CompareBtn.Click += new System.EventHandler(this.CompareBtn_Click);
            // 
            // ResultView
            // 
            this.ResultView.AllowUserToAddRows = false;
            this.ResultView.AllowUserToDeleteRows = false;
            this.ResultView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultView.Location = new System.Drawing.Point(13, 115);
            this.ResultView.Name = "ResultView";
            this.ResultView.Size = new System.Drawing.Size(600, 353);
            this.ResultView.TabIndex = 5;
            // 
            // Output
            // 
            this.Output.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Output.Location = new System.Drawing.Point(12, 71);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(504, 22);
            this.Output.TabIndex = 4;
            this.Output.Title = "Output:";
            this.Output.Leave += new System.EventHandler(this.CheckDocumentsEvt);
            // 
            // FileTwo
            // 
            this.FileTwo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTwo.Location = new System.Drawing.Point(13, 42);
            this.FileTwo.Name = "FileTwo";
            this.FileTwo.Size = new System.Drawing.Size(503, 22);
            this.FileTwo.TabIndex = 1;
            this.FileTwo.Title = "Document Two:";
            this.FileTwo.Leave += new System.EventHandler(this.CheckDocumentsEvt);
            // 
            // FileOne
            // 
            this.FileOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileOne.Location = new System.Drawing.Point(13, 13);
            this.FileOne.Name = "FileOne";
            this.FileOne.Size = new System.Drawing.Size(503, 22);
            this.FileOne.TabIndex = 0;
            this.FileOne.Title = "Document One:";
            this.FileOne.Leave += new System.EventHandler(this.CheckDocumentsEvt);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 480);
            this.Controls.Add(this.ResultView);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.CompareBtn);
            this.Controls.Add(this.FileTwo);
            this.Controls.Add(this.FileOne);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(533, 145);
            this.Name = "Main";
            this.Text = "Excel Compare";
            ((System.ComponentModel.ISupportInitialize)(this.ResultView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenFileControl FileOne;
        private OpenFileControl FileTwo;
        private System.Windows.Forms.Button CompareBtn;
        private SaveFileControl Output;
        private System.Windows.Forms.DataGridView ResultView;
    }
}

