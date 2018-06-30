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
    public partial class DataSetASP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SilverCyanide"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("spGetProductAndCategoriesData", connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset);


                //GridView1.DataSource = dataset;
                //GridView1.DataBind();

                //GridView2.DataSource = dataset;
                //GridView2.DataBind();

                //GridView1.DataSource = dataset.Tables[0];
                //GridView1.DataBind();

                //GridView2.DataSource = dataset.Tables[1];
                //GridView2.DataBind();

                //By default the tables in the DataSet will have table names as Table, Table1, Table2 etc. So if you want to give the tables in the DataSet a meaningful name, use the TableName property as shown below.
                dataset.Tables[0].TableName = "Products";
                dataset.Tables[1].TableName = "Categories";

                //These table names can then be used when binding to a GridView control, instead of using the integral indexer, which makes your code more readable, and maintainable.
                GridView1.DataSource = dataset.Tables["Products"];
                GridView1.DataBind();

                GridView2.DataSource = dataset.Tables["Categories"];
                GridView2.DataBind();

            }

        }
    }
}