using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample_ADO.netWindowsFormsApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Form2_Load();

        }
        private void Form2_Load()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Sample_ADO.netWindowsFormsApp.Properties.Settings.NorthwindConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", connection);
                connection.Open();
                BindingSource source = new BindingSource();
                source.DataSource = cmd.ExecuteReader();
                dataGridView1.DataSource = source;
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
                Console.WriteLine(" Check Connection");

            }
            finally
            {
                connection.Close();
 

            }
        }
    }
}
