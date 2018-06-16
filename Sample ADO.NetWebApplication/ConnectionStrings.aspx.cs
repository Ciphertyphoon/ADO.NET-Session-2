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
    public partial class ConnectionStrings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                String Query = "SELECT CustomerId, ContactName, City, Country FROM Customers";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex);
            }
            finally
            {
                con.Close();
            }

        }
    }
}