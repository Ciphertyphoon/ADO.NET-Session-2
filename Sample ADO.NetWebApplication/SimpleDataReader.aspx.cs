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
    public partial class SimpleDataReader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["SilverCyanide"].ConnectionString;
            
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select * from tblProductInventory", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
            }
        }
    }
}