using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample_ADO.NetWebApplication
{
    public partial class SimpleRead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SARIMANOK\\HYDRASERVER;Initial Catalog=Northwind;Persist Security Info=True;User ID=SA;Password=system123");
            SqlCommand cmd = new SqlCommand("SELECT CustomerId, ContactName, City, Country FROM Customers", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            con.Close();
        }
    }
}