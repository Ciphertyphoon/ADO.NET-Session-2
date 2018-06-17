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
    public partial class SQLCommand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String ConStr = ConfigurationManager.ConnectionStrings["SilverCyanide"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "SELECT * FROM tblProducts";
                //cmd.Connection = con;
                //con.Open();
                //SqlDataReader rdr = cmd.ExecuteReader();
                //GridView1.DataSource = rdr;
                //GridView1.DataBind();

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //cmd.CommandText = "SELECT COUNT(Product_Name) FROM tblProducts";
                //cmd.Connection = con;
                //con.Open();
                //int TotalRows = (int)cmd.ExecuteScalar();
                //Response.Write("Total Products:" + TotalRows.ToString());
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //Create an instance of SqlCommand class, specifying the T-SQL command 
                //that we want to execute, and the connection object.

                cmd.CommandText = "insert into tblProducts values (103, 'Apple Laptops', 100.00, 50000)";
                cmd.Connection = con;
                con.Open();

                //Since we are performing an insert operation, use ExecuteNonQuery() 
                //method of the command object. ExecuteNonQuery() method returns an 
                //integer, which specifies the number of rows inserted
                int rowsAffected = cmd.ExecuteNonQuery();
                Response.Write("Inserted Rows = " + rowsAffected.ToString() + "<br/>");

                //Set to CommandText to the update query. We are reusing the command object, 
                //instead of creating a new command object
                cmd.CommandText = "update tblProducts set QTY_Availabilty = 1010 where ID = 1";

                //use ExecuteNonQuery() method to execute the update statement on the database
                rowsAffected = cmd.ExecuteNonQuery();
                Response.Write("Updated Rows = " + rowsAffected.ToString() + "<br/>");

                //Set to CommandText to the delete query. We are reusing the command object, 
                //instead of creating a new command object
                cmd.CommandText = "Delete from tblProducts where Product_ID = 102";
                //use ExecuteNonQuery() method to delete the row from the database
                rowsAffected = cmd.ExecuteNonQuery();
                Response.Write("Deleted Rows = " + rowsAffected.ToString() + "<br/>");

            }
        }
    }
}