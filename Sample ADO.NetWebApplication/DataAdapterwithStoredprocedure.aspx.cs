using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample_ADO.NetWebApplication
{
    public partial class DataAdapterwithStoredprocedure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SilverCyanide"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Create an instance of SqlDataAdapter, specifying the stored procedure 
                // and the connection object to use
                SqlDataAdapter dataAdapter = new SqlDataAdapter("spGetProductInventoryById", connection);
                // Specify the command type is an SP
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                // Associate the parameter with the stored procedure
               dataAdapter.SelectCommand.Parameters.AddWithValue("@ProductId", TextBox1.Text);
                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset);

                GridView1.DataSource = dataset;
                GridView1.DataBind();
            }
        }
    }
}