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
    public partial class DataAdapterwithDataset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SilverCyanide"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Create an instance of SqlDataAdapter. Spcify the command and the connection
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from tblProductInventory", connection);
                // Create an instance of DataSet, which is an in-memory datastore for storing tables
                DataSet dataset = new DataSet();
                // Call the Fill() methods, which automatically opens the connection, executes the command 
                // and fills the dataset with data, and finally closes the connection.
                dataAdapter.Fill(dataset);

                GridView1.DataSource = dataset;
                GridView1.DataBind();
            }
        }
    }
}