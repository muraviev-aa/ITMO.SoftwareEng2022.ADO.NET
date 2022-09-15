using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ITMO.ADO.NET.Course2022.Lab4.Exercise3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sqlDataAdapter1.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            sqlDataAdapter1.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
            sqlDataAdapter1.FillError += new FillErrorEventHandler(OnFillError);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = northwindDataSet1.Customers;
            sqlDataAdapter1.Fill(northwindDataSet1.Customers);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                sqlDataAdapter1.Update(northwindDataSet1);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }
        private void OnRowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            NorthwindDataSet.CustomersRow custRow = (NorthwindDataSet.CustomersRow)e.Row;
            DialogResult response = MessageBox.Show("Continue updating " + custRow.CustomerID.ToString() +
            "?", "Continue Update?", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                e.Status = UpdateStatus.SkipCurrentRow;
            }
        }
        private void OnRowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            NorthwindDataSet.CustomersRow custRow = (NorthwindDataSet.CustomersRow)e.Row;
            MessageBox.Show(custRow.CustomerID.ToString() + " has been updated");
            northwindDataSet1.Customers.Clear();
            sqlDataAdapter1.Fill(northwindDataSet1.Customers);

        }
        protected static void OnFillError(object sender, FillErrorEventArgs e)
        {
            DialogResult response = MessageBox.Show("The following error occurred while Filling the DataSet: " + e.Errors.Message.ToString() +
            " Continue attempting to fill?", "FillError Encountered", MessageBoxButtons.YesNo);

            if (response == DialogResult.Yes)
            {
                e.Continue = true;
            }
            else
            {
                e.Continue = false;
            }

        }



    }
}
