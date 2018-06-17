using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample_ADO.NetWebApplication
{
    public partial class SQLInjectionPrevention : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GetProductsButton_Click(object sender, EventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SilverCyanide"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //Build the query dynamically, by concatenating the text, that the user has 
                //typed into the ProductNameTextBox. This is a bad way of constructing
                //queries. This line of code will open doors for sql injection attack

                //SqlCommand cmd = new SqlCommand("Select * from tblProductInventory where ProductName like '" + ProductNameTextBox.Text + "%'", connection);
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                // Parameterized query. @ProductName is the parameter
                string Command = "spGetProductsByName";
                SqlCommand cmd = new SqlCommand(Command, connection);
                // Specify that the T-SQL command is a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // Provide the value for the parameter
                cmd.Parameters.AddWithValue("@ProductName", ProductNameTextBox.Text + "%");

                connection.Open();
                ProductsGridView.DataSource = cmd.ExecuteReader();
                ProductsGridView.DataBind();

                //i'; Delete from tblProductInventory --
                //Sql profiler
                //exec sp_executesql N'Select * from tblProductInventory where ProductName like @ProductName',N'@ProductName nvarchar(39)',@ProductName = N'i''; Delete from tblProductInventory --%'
            }
            //Execute spGetProductsByName 'ip'
        }
    }
}