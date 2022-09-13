using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Configuration;
using System.Windows.Forms;

namespace ITMO.ADO.NET.Course2022.Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.connection.StateChange += new StateChangeEventHandler(this.connection_StateChange);
        }
        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;

        }

        string testConnect = GetConnectionStringByName("DBConnect.NorthwindConnectionString");

        OleDbConnection connection = new OleDbConnection();
        //string testConnect = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;
        //Persist Security Info=False;User ID=Admin;Initial Catalog=Northwind;
        //Data Source=DESKTOP-F5Q5EST\SQLEXPRESS";

        private void connection_StateChange(object sender, StateChangeEventArgs e)
        {
            connectToDBToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Closed);
            disconnectFromDBToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Open);
        }
        private void connectToDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = testConnect;
                    connection.Open();
                    MessageBox.Show("Соединение с базой данных выполнено успешно");
                }
                else
                {
                    MessageBox.Show("Соединение с базой данных уже установлено");
                }
            }
            catch (OleDbException XcpSQL)
            {
                foreach (OleDbError se in XcpSQL.Errors)
                {
                    MessageBox.Show(se.Message,
                    "SQL Error code" + se.NativeError,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disconnectFromDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Соединение с базой данных закрыто");
            }
            else
            {
                MessageBox.Show("Соединение с базой уже закрыто");
            }
        }

        private void connectionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;

            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    MessageBox.Show("name = " + cs.Name);
                    MessageBox.Show("providerName = " + cs.ProviderName);
                    MessageBox.Show("connectionString = " + cs.ConnectionString);
                }
            }
        }
    }
}
