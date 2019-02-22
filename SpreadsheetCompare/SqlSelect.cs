using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadsheetCompare
{
    public partial class SqlSelect : MetroFramework.Forms.MetroForm
    {
        public SqlSelect()
        {
            InitializeComponent();
            refreshServersWorker.RunWorkerAsync();
        }


        private string ConnectionString { get; set; }
        public string DatabaseConnectionString
        {
            get
            {
                if (WinAuth.Checked)
                {
                    return $"Database={DatabaseName};Server={Server};Trusted_Connection=True;";
                }
                else
                {
                    return $"Database={DatabaseName};Server={Server};User Id={Username};Password={Password};";
                }
            }
        }

        public List<string> ServerList { get; set; }
        public List<string> DatabaseList { get; set; }

        public string Server { get { return ServerCbo.Text; } set { ServerCbo.Text = value; } }
        public string Username { get { return UsernameTxt.Text; } set { UsernameTxt.Text = value; } }
        public string Password { get { return PasswordTxt.Text; } set { PasswordTxt.Text = value; } }
        public string DatabaseName { get { return DatabaseCbo.Text; } set { DatabaseCbo.Text = value; } }
        public bool Trusted { get { return WinAuth.Checked; } set { if (value) { WinAuth.Checked = true; } else { SQLAuthRadio.Checked = true; } } }

        public StringCollection ServerCredentails
        {
            get { return Properties.Settings.Default.savedSqlCredentials; }
            set { Properties.Settings.Default.savedSqlCredentials = value; }
        }
        public bool ShouldSave { get { return SaveCreds.Checked; } set { SaveCreds.Checked = value; } }

        // Servers
        public void GetServers()
        {
            refreshServersWorker.RunWorkerAsync();
        }
        private List<string> GetNetworkServerNames()
        {
            List<string> ServersNames = new List<string>();
            foreach (DataRow datarow in SmoApplication.EnumAvailableSqlServers(false).Rows)
            {
                ServersNames.Add(datarow[0].ToString());
            }
            return ServersNames;
        }
        private List<string> GetSavedServerNames()
        {
            List<string> ServersNames = new List<string>();
            if (ServerCredentails != null)
            {
                foreach (string hash in ServerCredentails)
                {
                    string[] creds = StringCipher.Decrypt(hash, GetPrivateKey()).Split(',');
                    ServersNames.Add(creds[0]);
                }
            }
            return ServersNames;
        }

        // Credentials
        private void SaveServerCredentials()
        {
            string credentials = $"{Server},{Username},{Password},{Trusted}";
            if (ServerCredentails != null)
            {
                foreach (string hash in ServerCredentails)
                {
                    string[] creds = StringCipher.Decrypt(hash, GetPrivateKey()).Split(',');
                    if (creds[0].ToUpper() == Server.ToUpper())
                    {
                        ServerCredentails.Remove(hash);
                        break;
                    }
                }
            }
            else
            {
                ServerCredentails = new StringCollection();
            }
            ServerCredentails.Add(StringCipher.Encrypt(credentials, GetPrivateKey()));
            Properties.Settings.Default.Save();
        }
        private void LoadServerCredentials()
        {
            if (ServerCredentails != null)
            {
                foreach (string hash in ServerCredentails)
                {
                    string[] creds = StringCipher.Decrypt(hash, GetPrivateKey()).Split(',');
                    if (creds[0].ToUpper() == Server.ToUpper())
                    {
                        Server = creds[0];
                        Username = creds[1];
                        Password = creds[2];
                        Trusted = bool.Parse(creds[3]);
                        break;
                    }
                }
            }
        }

        private void refreshServersWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var network = GetNetworkServerNames();
            var saved = GetSavedServerNames();
            var serverList = new List<string>();
            foreach (string name in saved)
            {                
                if (!network.Contains(name))
                {
                    network.Add(name);
                }
            }
            ServerList = network;
            ServerList.Sort();
        }

        private void refreshServersWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ServerCbo.DataSource = null;
            ServerCbo.DataSource = ServerList;
        }

        private void refreshDatabasesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DatabaseList = new List<string>();
            try
            {
                DataTable dbnames = QueryTable("SELECT name FROM master.dbo.sysdatabases");
                foreach (DataRow dr in dbnames.Rows)
                {
                    DatabaseList.Add(dr[0].ToString());
                }
            }
            catch (Exception)
            {

                DatabaseList.Add("Refresh Failed, Check your connection.");
            }
        }

        private void refreshDatabasesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DatabaseCbo.DataSource = DatabaseList;
        }

        private void DatabaseCbo_Click(object sender, EventArgs e)
        {
            if (!refreshDatabasesWorker.IsBusy)
            {
                if (WinAuth.Checked)
                {
                    ConnectionString = $"Server={Server};Trusted_Connection=True;";
                }
                else
                {
                    ConnectionString = $"Server={Server};User Id={Username};Password={Password};";
                }
                refreshDatabasesWorker.RunWorkerAsync();
            }

        }

        private DataTable QueryTable(string query, SqlConnection sqlConnection = null)
        {
            DataTable table = new DataTable();
            if (sqlConnection == null)
            {
                using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
                {
                    sqlConn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                    {
                        SqlDataAdapter ds = new SqlDataAdapter(cmd);
                        ds.Fill(table);
                    }
                    sqlConn.Close();
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    SqlDataAdapter ds = new SqlDataAdapter(cmd);
                    ds.Fill(table);
                }
            }
            return table;
        }

        private string GetPrivateKey()
        {
            RegistryKey localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey windowsNTKey = localMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion");
            return (string)windowsNTKey.GetValue("ProductId");
        }

        private void TestConnectionBtn_Click(object sender, EventArgs e)
        {
            TestConnection(out string result);
            MetroFramework.MetroMessageBox.Show(this, result, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool TestConnection(out string result)
        {
            if (DatabaseName == "" || DatabaseName == null)
            {
                result = "Please Select a database.";
                return false;
            }
            string query = $@"Declare @Table Table
                              (
                                  attribute_id int,
                                  attribute_name nvarchar(50),
                                  attribute_value nvarchar(50)
                              );
                              INSERT @Table Exec master.dbo.sp_server_info 2;
                              SELECT TOP 1[attribute_value] FROM @TABLE                              
                           ";
            DataTable dataTable = new DataTable();
            string executionTime = "";
            bool success = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConnectionString))
                {
                    connection.StatisticsEnabled = true;
                    connection.Open();
                    dataTable = QueryTable(query, connection);
                    connection.Close();
                    executionTime = connection.RetrieveStatistics()["ExecutionTime"].ToString();
                    result = $"Version: {dataTable.Rows[0][0]}\nExecution Time: {executionTime}";

                }
            }
            catch (Exception)
            {
                success = false;
                result = "Test Connection Failed, Consider using a different authentication option";
            }
            return success;
        }

        // Collecting Data
        private void selectionDone_Click(object sender, EventArgs e)
        {
            if (TestConnection(out string result))
            {
                if (ShouldSave)
                {
                    SaveServerCredentials();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, result, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SqlSelect_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ServerCbo_Click(object sender, EventArgs e)
        {
            ServerCbo.DataSource = null;
            ServerCbo.DataSource = ServerList;
        }

        private void WinAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (Trusted)
            {
                PasswordTxt.Enabled = false;
                UsernameTxt.Enabled = false;

            }
            else
            {
                PasswordTxt.Enabled = true;
                UsernameTxt.Enabled = true;
            }
        }


        // Try Loading Server Credentials
        private void ServerCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadServerCredentials();
        }
    }
}
