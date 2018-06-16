using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample_ADO.netWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SARIMANOK\\HYDRASERVER;Initial Catalog=Northwind;Persist Security Info=True;User ID=SA;Password=system123");
            SqlCommand cmd = new SqlCommand("SELECT CustomerId, ContactName, City, Country FROM Customers", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
           
            source.DataSource = rdr;
            dataGridView1.DataSource = source;
            con.Close();

        }
    }
}
