using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.ADO.NET.Course2022.Lab4.Exercise2
{
    public partial class Form1 : Form
    {
        private DataTable customersTable = new DataTable("Customers");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TableGrid.DataSource = customersTable;

            customersTable.Columns.Add("CustomerID", Type.GetType("System.String"));
            customersTable.Columns.Add("CompanyName", Type.GetType("System.String"));
            customersTable.Columns.Add("ContactName", Type.GetType("System.String"));
            customersTable.Columns.Add("ContactTitle", Type.GetType("System.String"));
            customersTable.Columns.Add("Address", Type.GetType("System.String"));
            customersTable.Columns.Add("City", Type.GetType("System.String"));
            customersTable.Columns.Add("Country", Type.GetType("System.String"));
            customersTable.Columns.Add("Phone", Type.GetType("System.String"));

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = customersTable.Columns["CustomerID"];
            customersTable.PrimaryKey = keyColumns;

            customersTable.Columns["CustomerID"].AllowDBNull = false;
            customersTable.Columns["CompanyName"].AllowDBNull = false;
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow custRow = customersTable.NewRow();
                Object[] custRecord = {"ALFKI", "Alfreds Futterkiste", "Maria Anders",
                                 "Sales Representative", "Obere Str. 57", "Berlin",
                                  "Germany", "030-0074321"};
                custRow.ItemArray = custRecord;
                customersTable.Rows.Add(custRow);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
