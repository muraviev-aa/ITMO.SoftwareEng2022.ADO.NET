using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.ADO.NET.Course2022.Lab4.Exercise1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetCustomersButton_Click(object sender, EventArgs e)
        {
            NorthwindDataSet northwindDataSet1 = new NorthwindDataSet();
            NorthwindDataSetTableAdapters.CustomersTableAdapter
            customersTableAdapter1 = new NorthwindDataSetTableAdapters.CustomersTableAdapter();
            customersTableAdapter1.Fill(northwindDataSet1.Customers);

            foreach (NorthwindDataSet.CustomersRow nWCustomer in northwindDataSet1.Customers.Rows)
            {
                CustomerListBox.Items.Add(nWCustomer.CompanyName);
            }
        }
    }
}
