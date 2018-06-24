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
    public partial class DataReaderObjs : System.Web.UI.Page
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
                    // Create the DataTable and columns. This will 
                    // be used as the datasource for the GridView
                    DataTable sourceTable = new DataTable();
                    sourceTable.Columns.Add("ID");
                    sourceTable.Columns.Add("Name");
                    sourceTable.Columns.Add("Price");
                    sourceTable.Columns.Add("DiscountedPrice");

                    while (reader.Read())
                    {
                        //Calculate the 10% discounted price
                        int OriginalPrice = Convert.ToInt32(reader["UnitPrice"]);
                        double DiscountedPrice = OriginalPrice * 0.9;

                        // Populate datatable column values from the SqlDataReader
                        DataRow datarow = sourceTable.NewRow();
                        datarow["ID"] = reader["Id"];
                        datarow["Name"] = reader["ProductName"];
                        datarow["Price"] = OriginalPrice;
                        datarow["DiscountedPrice"] = DiscountedPrice;

                        //Add the DataRow to the DataTable
                        sourceTable.Rows.Add(datarow);
                    }

                    // Set sourceTable as the DataSource for the GridView
                    GridView1.DataSource = sourceTable;
                    GridView1.DataBind();
                }
            }
        }
    }
}