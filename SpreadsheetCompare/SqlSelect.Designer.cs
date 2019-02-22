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
            this.selectionDone = new MetroFramework.Controls.MetroButton();
            this.cancelBtn = new MetroFramework.Controls.MetroButton();
            this.HoldingPanel = new MetroFramework.Controls.MetroPanel();
            this.TestConnectionBtn = new MetroFramework.Controls.MetroButton();
            this.DatabaseSelectionPanel = new MetroFramework.Controls.MetroPanel();
            this.DatabaseCbo = new System.Windows.Forms.ComboBox();
            this.databaseGrpLbl = new MetroFramework.Controls.MetroLabel();
            this.databaseLbl = new MetroFramework.Controls.MetroLabel();
            this.ServerLoginPanel = new MetroFramework.Controls.MetroPanel();
            this.ServerCbo = new System.Windows.Forms.ComboBox();
            this.serverGrpLbl = new MetroFramework.Controls.MetroLabel();
            this.SaveCreds = new MetroFramework.Controls.MetroCheckBox();
            this.UsernameTxt = new MetroFramework.Controls.MetroTextBox();
            this.passwordLbl = new MetroFramework.Controls.MetroLabel();
            this.PasswordTxt = new MetroFramework.Controls.MetroTextBox();
            this.usernameLbl = new MetroFramework.Controls.MetroLabel();
            this.serverLbl = new MetroFramework.Controls.MetroLabel();
            this.AuthTypePanel = new MetroFramework.Controls.MetroPanel();
            this.WinAuth = new MetroFramework.Controls.MetroRadioButton();
            this.SQLAuthRadio = new MetroFramework.Controls.MetroRadioButton();
            this.refreshServersWorker = new System.ComponentModel.BackgroundWorker();
            this.refreshDatabasesWorker = new System.ComponentModel.BackgroundWorker();
            this.HoldingPanel.SuspendLayout();
            this.DatabaseSelectionPanel.SuspendLayout();
            this.ServerLoginPanel.SuspendLayout();
            this.AuthTypePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectionDone
            // 
            this.selectionDone.Location = new System.Drawing.Point(284, 285);
            this.selectionDone.Name = "selectionDone";
            this.selectionDone.Size = new System.Drawing.Size(63, 23);
            this.selectionDone.TabIndex = 8;
            this.selectionDone.Text = "Done";
            this.selectionDone.UseSelectable = true;
            this.selectionDone.Click += new System.EventHandler(this.selectionDone_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(209, 285);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(63, 23);
            this.cancelBtn.TabIndex = 14;
            this.cancelBtn.TabStop = false;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseSelectable = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // HoldingPanel
            // 
            this.HoldingPanel.Controls.Add(this.cancelBtn);
            this.HoldingPanel.Controls.Add(this.selectionDone);
            this.HoldingPanel.Controls.Add(this.TestConnectionBtn);
            this.HoldingPanel.Controls.Add(this.DatabaseSelectionPanel);
            this.HoldingPanel.Controls.Add(this.ServerLoginPanel);
            this.HoldingPanel.Controls.Add(this.AuthTypePanel);
            this.HoldingPanel.HorizontalScrollbarBarColor = true;
            this.HoldingPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.HoldingPanel.HorizontalScrollbarSize = 10;
            this.HoldingPanel.Location = new System.Drawing.Point(23, 63);
            this.HoldingPanel.Name = "HoldingPanel";
            this.HoldingPanel.Size = new System.Drawing.Size(357, 318);
            this.HoldingPanel.TabIndex = 15;
            this.HoldingPanel.VerticalScrollbarBarColor = true;
            this.HoldingPanel.VerticalScrollbarHighlightOnWheel = false;
            this.HoldingPanel.VerticalScrollbarSize = 10;
            // 
            // TestConnectionBtn
            // 
            this.TestConnectionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TestConnectionBtn.Location = new System.Drawing.Point(10, 285);
            this.TestConnectionBtn.Margin = new System.Windows.Forms.Padding(10);
            this.TestConnectionBtn.Name = "TestConnectionBtn";
            this.TestConnectionBtn.Size = new System.Drawing.Size(138, 23);
            this.TestConnectionBtn.TabIndex = 7;
            this.TestConnectionBtn.Text = "Test Connection";
            this.TestConnectionBtn.UseSelectable = true;
            this.TestConnectionBtn.Click += new System.EventHandler(this.TestConnectionBtn_Click);
            // 
            // DatabaseSelectionPanel
            // 
            this.DatabaseSelectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabaseSelectionPanel.Controls.Add(this.DatabaseCbo);
            this.DatabaseSelectionPanel.Controls.Add(this.databaseGrpLbl);
            this.DatabaseSelectionPanel.Controls.Add(this.databaseLbl);
            this.DatabaseSelectionPanel.HorizontalScrollbarBarColor = true;
            this.DatabaseSelectionPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.DatabaseSelectionPanel.HorizontalScrollbarSize = 10;
            this.DatabaseSelectionPanel.Location = new System.Drawing.Point(4, 205);
            this.DatabaseSelectionPanel.Name = "DatabaseSelectionPanel";
            this.DatabaseSelectionPanel.Size = new System.Drawing.Size(350, 72);
            this.DatabaseSelectionPanel.TabIndex = 11;
            this.DatabaseSelectionPanel.VerticalScrollbarBarColor = true;
            this.DatabaseSelectionPanel.VerticalScrollbarHighlightOnWheel = false;
            this.DatabaseSelectionPanel.VerticalScrollbarSize = 10;
            // 
            // DatabaseCbo
            // 
            this.DatabaseCbo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.DatabaseCbo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DatabaseCbo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DatabaseCbo.FormattingEnabled = true;
            this.DatabaseCbo.Location = new System.Drawing.Point(83, 35);
            this.DatabaseCbo.Name = "DatabaseCbo";
            this.DatabaseCbo.Size = new System.Drawing.Size(260, 23);
            this.DatabaseCbo.TabIndex = 8;
            this.DatabaseCbo.Click += new System.EventHandler(this.DatabaseCbo_Click);
            // 
            // databaseGrpLbl
            // 
            this.databaseGrpLbl.AutoSize = true;
            this.databaseGrpLbl.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.databaseGrpLbl.Location = new System.Drawing.Point(3, 5);
            this.databaseGrpLbl.Name = "databaseGrpLbl";
            this.databaseGrpLbl.Size = new System.Drawing.Size(124, 19);
            this.databaseGrpLbl.TabIndex = 10;
            this.databaseGrpLbl.Text = "Database Selection";
            // 
            // databaseLbl
            // 
            this.databaseLbl.AutoSize = true;
            this.databaseLbl.Location = new System.Drawing.Point(14, 37);
            this.databaseLbl.Name = "databaseLbl";
            this.databaseLbl.Size = new System.Drawing.Size(63, 19);
            this.databaseLbl.TabIndex = 2;
            this.databaseLbl.Text = "Database";
            // 
            // ServerLoginPanel
            // 
            this.ServerLoginPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerLoginPanel.Controls.Add(this.ServerCbo);
            this.ServerLoginPanel.Controls.Add(this.serverGrpLbl);
            this.ServerLoginPanel.Controls.Add(this.SaveCreds);
            this.ServerLoginPanel.Controls.Add(this.UsernameTxt);
            this.ServerLoginPanel.Controls.Add(this.passwordLbl);
            this.ServerLoginPanel.Controls.Add(this.PasswordTxt);
            this.ServerLoginPanel.Controls.Add(this.usernameLbl);
            this.ServerLoginPanel.Controls.Add(this.serverLbl);
            this.ServerLoginPanel.HorizontalScrollbarBarColor = true;
            this.ServerLoginPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ServerLoginPanel.HorizontalScrollbarSize = 10;
            this.ServerLoginPanel.Location = new System.Drawing.Point(4, 56);
            this.ServerLoginPanel.Name = "ServerLoginPanel";
            this.ServerLoginPanel.Size = new System.Drawing.Size(350, 143);
            this.ServerLoginPanel.TabIndex = 9;
            this.ServerLoginPanel.VerticalScrollbarBarColor = true;
            this.ServerLoginPanel.VerticalScrollbarHighlightOnWheel = false;
            this.ServerLoginPanel.VerticalScrollbarSize = 10;
            // 
            // ServerCbo
            // 
            this.ServerCbo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.ServerCbo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ServerCbo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ServerCbo.FormattingEnabled = true;
            this.ServerCbo.Location = new System.Drawing.Point(83, 33);
            this.ServerCbo.Name = "ServerCbo";
            this.ServerCbo.Size = new System.Drawing.Size(260, 23);
            this.ServerCbo.TabIndex = 2;
            this.ServerCbo.SelectedIndexChanged += new System.EventHandler(this.ServerCbo_SelectedIndexChanged);
            // 
            // serverGrpLbl
            // 
            this.serverGrpLbl.AutoSize = true;
            this.serverGrpLbl.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.serverGrpLbl.Location = new System.Drawing.Point(3, 3);
            this.serverGrpLbl.Name = "serverGrpLbl";
            this.serverGrpLbl.Size = new System.Drawing.Size(85, 19);
            this.serverGrpLbl.TabIndex = 4;
            this.serverGrpLbl.Text = "Server Login";
            // 
            // SaveCreds
            // 
            this.SaveCreds.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SaveCreds.AutoSize = true;
            this.SaveCreds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveCreds.Location = new System.Drawing.Point(226, 123);
            this.SaveCreds.Name = "SaveCreds";
            this.SaveCreds.Size = new System.Drawing.Size(109, 15);
            this.SaveCreds.TabIndex = 5;
            this.SaveCreds.Text = "Save Credentials";
            this.SaveCreds.UseSelectable = true;
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.UsernameTxt.CustomButton.Image = null;
            this.UsernameTxt.CustomButton.Location = new System.Drawing.Point(239, 1);
            this.UsernameTxt.CustomButton.Name = "";
            this.UsernameTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.UsernameTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.UsernameTxt.CustomButton.TabIndex = 1;
            this.UsernameTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UsernameTxt.CustomButton.UseSelectable = true;
            this.UsernameTxt.CustomButton.Visible = false;
            this.UsernameTxt.Enabled = false;
            this.UsernameTxt.Lines = new string[0];
            this.UsernameTxt.Location = new System.Drawing.Point(83, 65);
            this.UsernameTxt.MaxLength = 32767;
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.PasswordChar = '\0';
            this.UsernameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UsernameTxt.SelectedText = "";
            this.UsernameTxt.SelectionLength = 0;
            this.UsernameTxt.SelectionStart = 0;
            this.UsernameTxt.ShortcutsEnabled = true;
            this.UsernameTxt.Size = new System.Drawing.Size(261, 23);
            this.UsernameTxt.TabIndex = 3;
            this.UsernameTxt.UseSelectable = true;
            this.UsernameTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.UsernameTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // passwordLbl
            // 
            this.passwordLbl.Location = new System.Drawing.Point(3, 91);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(74, 23);
            this.passwordLbl.TabIndex = 7;
            this.passwordLbl.Text = "Password";
            this.passwordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.PasswordTxt.CustomButton.Image = null;
            this.PasswordTxt.CustomButton.Location = new System.Drawing.Point(239, 1);
            this.PasswordTxt.CustomButton.Name = "";
            this.PasswordTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.PasswordTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PasswordTxt.CustomButton.TabIndex = 1;
            this.PasswordTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PasswordTxt.CustomButton.UseSelectable = true;
            this.PasswordTxt.CustomButton.Visible = false;
            this.PasswordTxt.Enabled = false;
            this.PasswordTxt.Lines = new string[0];
            this.PasswordTxt.Location = new System.Drawing.Point(83, 94);
            this.PasswordTxt.MaxLength = 32767;
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '●';
            this.PasswordTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PasswordTxt.SelectedText = "";
            this.PasswordTxt.SelectionLength = 0;
            this.PasswordTxt.SelectionStart = 0;
            this.PasswordTxt.ShortcutsEnabled = true;
            this.PasswordTxt.Size = new System.Drawing.Size(261, 23);
            this.PasswordTxt.TabIndex = 4;
            this.PasswordTxt.UseSelectable = true;
            this.PasswordTxt.UseSystemPasswordChar = true;
            this.PasswordTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PasswordTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // usernameLbl
            // 
            this.usernameLbl.Location = new System.Drawing.Point(3, 62);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(74, 23);
            this.usernameLbl.TabIndex = 6;
            this.usernameLbl.Text = "Username";
            this.usernameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverLbl
            // 
            this.serverLbl.Location = new System.Drawing.Point(3, 33);
            this.serverLbl.Name = "serverLbl";
            this.serverLbl.Size = new System.Drawing.Size(74, 23);
            this.serverLbl.TabIndex = 5;
            this.serverLbl.Text = "Server";
            this.serverLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AuthTypePanel
            // 
            this.AuthTypePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthTypePanel.Controls.Add(this.WinAuth);
            this.AuthTypePanel.Controls.Add(this.SQLAuthRadio);
            this.AuthTypePanel.HorizontalScrollbarBarColor = true;
            this.AuthTypePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.AuthTypePanel.HorizontalScrollbarSize = 10;
            this.AuthTypePanel.Location = new System.Drawing.Point(4, 4);
            this.AuthTypePanel.Name = "AuthTypePanel";
            this.AuthTypePanel.Size = new System.Drawing.Size(350, 46);
            this.AuthTypePanel.TabIndex = 8;
            this.AuthTypePanel.VerticalScrollbarBarColor = true;
            this.AuthTypePanel.VerticalScrollbarHighlightOnWheel = false;
            this.AuthTypePanel.VerticalScrollbarSize = 10;
            // 
            // WinAuth
            // 
            this.WinAuth.AutoSize = true;
            this.WinAuth.Checked = true;
            this.WinAuth.Location = new System.Drawing.Point(21, 16);
            this.WinAuth.Name = "WinAuth";
            this.WinAuth.Size = new System.Drawing.Size(154, 15);
            this.WinAuth.TabIndex = 0;
            this.WinAuth.TabStop = true;
            this.WinAuth.Text = "Windows Authentication";
            this.WinAuth.UseSelectable = true;
            this.WinAuth.CheckedChanged += new System.EventHandler(this.WinAuth_CheckedChanged);
            // 
            // SQLAuthRadio
            // 
            this.SQLAuthRadio.AutoSize = true;
            this.SQLAuthRadio.Location = new System.Drawing.Point(205, 16);
            this.SQLAuthRadio.Name = "SQLAuthRadio";
            this.SQLAuthRadio.Size = new System.Drawing.Size(126, 15);
            this.SQLAuthRadio.TabIndex = 1;
            this.SQLAuthRadio.Text = "SQL Authentication";
            this.SQLAuthRadio.UseSelectable = true;
            // 
            // refreshServersWorker
            // 
            this.refreshServersWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.refreshServersWorker_DoWork);
            this.refreshServersWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.refreshServersWorker_RunWorkerCompleted);
            // 
            // refreshDatabasesWorker
            // 
            this.refreshDatabasesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.refreshDatabasesWorker_DoWork);
            this.refreshDatabasesWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.refreshDatabasesWorker_RunWorkerCompleted);
            // 
            // SqlSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 411);
            this.Controls.Add(this.HoldingPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SqlSelect";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "SQL Table Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SqlSelect_FormClosing);
            this.HoldingPanel.ResumeLayout(false);
            this.DatabaseSelectionPanel.ResumeLayout(false);
            this.DatabaseSelectionPanel.PerformLayout();
            this.ServerLoginPanel.ResumeLayout(false);
            this.ServerLoginPanel.PerformLayout();
            this.AuthTypePanel.ResumeLayout(false);
            this.AuthTypePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton selectionDone;
        private MetroFramework.Controls.MetroButton cancelBtn;
        private MetroFramework.Controls.MetroPanel HoldingPanel;
        private MetroFramework.Controls.MetroButton TestConnectionBtn;
        private MetroFramework.Controls.MetroPanel DatabaseSelectionPanel;
        private MetroFramework.Controls.MetroLabel databaseGrpLbl;
        private MetroFramework.Controls.MetroLabel databaseLbl;
        private MetroFramework.Controls.MetroPanel ServerLoginPanel;
        private MetroFramework.Controls.MetroLabel serverGrpLbl;
        private MetroFramework.Controls.MetroCheckBox SaveCreds;
        private MetroFramework.Controls.MetroTextBox UsernameTxt;
        private MetroFramework.Controls.MetroLabel passwordLbl;
        private MetroFramework.Controls.MetroTextBox PasswordTxt;
        private MetroFramework.Controls.MetroLabel usernameLbl;
        private MetroFramework.Controls.MetroLabel serverLbl;
        private MetroFramework.Controls.MetroPanel AuthTypePanel;
        private MetroFramework.Controls.MetroRadioButton WinAuth;
        private MetroFramework.Controls.MetroRadioButton SQLAuthRadio;
        private System.ComponentModel.BackgroundWorker refreshServersWorker;
        private System.ComponentModel.BackgroundWorker refreshDatabasesWorker;
        private System.Windows.Forms.ComboBox ServerCbo;
        private System.Windows.Forms.ComboBox DatabaseCbo;
    }
}