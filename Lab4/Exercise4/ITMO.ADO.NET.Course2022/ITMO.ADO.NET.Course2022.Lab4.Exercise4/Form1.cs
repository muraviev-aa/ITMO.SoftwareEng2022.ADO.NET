using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ITMO.ADO.NET.Course2022.Lab4.Exercise4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SqlConnection northwindConnection = new SqlConnection(@"Integrated Security=SSPI;
        Persist Security Info=False;User ID=Admin;Initial Catalog=Northwind;
        Data Source=DESKTOP-F5Q5EST\SQLEXPRESS");
        private SqlDataAdapter sqlDataAdapter1;
        private DataSet northwindDataset = new DataSet("Northwind");
        private DataTable customersTable = new DataTable("Customers");

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlDataAdapter1 = new SqlDataAdapter("SELECT * FROM Customers", northwindConnection);
            northwindDataset.Tables.Add(customersTable);
            sqlDataAdapter1.Fill(northwindDataset.Tables["Customers"]);
            dataGridView1.DataSource = northwindDataset.Tables["Customers"];
            SqlCommandBuilder commands = new SqlCommandBuilder(sqlDataAdapter1);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                northwindDataset.EndInit();
                sqlDataAdapter1.Update(northwindDataset.Tables["Customers"]);
            }
            catch (SystemException ex)
            { 
                MessageBox.Show(ex.Message); 
            }
        }
    }


}
