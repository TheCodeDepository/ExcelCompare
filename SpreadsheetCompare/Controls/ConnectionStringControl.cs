using System.Collections.Generic;
using Microsoft.SqlServer.Management.Smo;
using System.Data;
using System.Linq;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.ComponentModel;
using System;
using System.Windows.Forms;

namespace SpreadsheetCompare.Controls
{
    public partial class ConnectionStringControl : MetroFramework.Controls.MetroUserControl
    {
        public ConnectionStringControl()
        {
            InitializeComponent();
            refreshServersWorker.RunWorkerAsync();
        }

        private string ConnectionString
        {
            get
            {
                if (WindowsAuthRadio.Checked)
                {
                    return $"Server={Server};Trusted_Connection=True;"; 
                }
                else
                {
                    return $"Server={Server};User Id={Username};Password={Password};"; 
                }
            }
        }
        private string DatabaseConnectionString
        {
            get
            {
                if (WindowsAuthRadio.Checked)
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

        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public bool Trusted { get; set; }

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
            if (Properties.Settings.Default.savedSqlCredentials != null)
            {
                foreach (string hash in Properties.Settings.Default.savedSqlCredentials)
                {
                    string[] creds = StringCipher.Decrypt(hash, GetPrivateKey()).Split(',');
                    ServersNames.Add(creds[0]);
                }
            }
            return ServersNames;
        }

        private void SaveServerCredentials(string server, string username, string password, bool trustedConnection)
        {
            string credentials = $"{server},{username},{password},{trustedConnection}";

            foreach (string hash in Properties.Settings.Default.savedSqlCredentials)
            {
                string[] creds = StringCipher.Decrypt(hash, GetPrivateKey()).Split(',');
                if (creds[0].ToUpper() == server.ToUpper())
                {
                    Properties.Settings.Default.savedSqlCredentials.Remove(hash);
                    break;
                }
            }
            Properties.Settings.Default.savedSqlCredentials.Add(StringCipher.Encrypt(credentials, GetPrivateKey()));
            Properties.Settings.Default.Save();
        }

        private void refreshServersWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var network = GetNetworkServerNames();
            var saved = GetSavedServerNames();

            foreach (string hash in saved)
            {
                string server = StringCipher.Decrypt(hash, GetPrivateKey()).Split(',')[0];
                if (!network.Contains(server))
                {
                    network.Add(server);
                }
            }
            ServerList = network;
        }

        private void refreshServersWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ServerCbo.DataSource = null;
            ServerCbo.Refresh();
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
            DatabaseCbo.DataSource = null;
            DatabaseCbo.Refresh();
            DatabaseCbo.DataSource = DatabaseList;
        }

        private void DatabaseCbo_Click(object sender, EventArgs e)
        {
            refreshDatabasesWorker.RunWorkerAsync();
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


        // Collecting Data
        private void ServerCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Server = ServerCbo.Text;
        }

        private void DatabaseCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseName = DatabaseCbo.Text;
        }

        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {
            Password = PasswordTxt.Text;
        }

        private void UsernameTxt_TextChanged(object sender, EventArgs e)
        {
            Username = UsernameTxt.Text;
        }

        private void SaveCredentialsChk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WindowsAuthRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (WindowsAuthRadio.Checked)
            {
                Trusted = true;
                UsernameTxt.Enabled = false;
                PasswordTxt.Enabled = false;
            }
            else
            {
                Trusted = false;
                UsernameTxt.Enabled = true;
                PasswordTxt.Enabled = true;
            }
        }

        private void TestConnectionBtn_Click(object sender, EventArgs e)
        {
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
            using (SqlConnection connection = new SqlConnection(DatabaseConnectionString))
            {
                connection.StatisticsEnabled = true;
                connection.Open();
                dataTable = QueryTable(query,connection);
                connection.Close();
                executionTime = connection.RetrieveStatistics()["ExecutionTime"].ToString();
            }
            
            MessageBox.Show($"{dataTable.Rows[0][0]}, Execution Time: {executionTime}");// dataTable;
        }
    }
}
