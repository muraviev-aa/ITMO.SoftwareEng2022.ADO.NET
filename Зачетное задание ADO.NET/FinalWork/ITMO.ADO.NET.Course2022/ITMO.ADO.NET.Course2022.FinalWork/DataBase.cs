using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace ITMO.ADO.NET.Course2022.FinalWork
{
    internal class DataBase
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=D:\northwnd.mdf;Integrated Security=True");

        public void openConnection()
        {
            try 
            { 
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    MessageBox.Show("Соединение c БД Northwind выполнено!", "Сделайте выбор таблицы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
             }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                DialogResult res = MessageBox.Show("Хотите продолжить работу в приложении?",
                "Сделайте выбор", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(res == DialogResult.No)
                {
                    Application.Exit();
                }
            }
 
        }

        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
