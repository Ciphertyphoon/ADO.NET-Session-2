﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Properties
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using (SqlConnection sourceCon = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Products_Source", sourceCon);
                sourceCon.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    using (SqlConnection destinationCon = new SqlConnection(cs))
                    {
                        using (SqlBulkCopy bc = new SqlBulkCopy(destinationCon))
                        {
                            bc.BatchSize = 10000;
                            bc.NotifyAfter = 5000;
                            bc.SqlRowsCopied += new SqlRowsCopiedEventHandler(bc_SqlRowsCopied);
                            bc.DestinationTableName = "Products_Destination";
                            destinationCon.Open();
                            bc.WriteToServer(rdr);
                        }
                    }
                }
            }
        }


        static void bc_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            Console.WriteLine(e.RowsCopied + " loaded....");

        }

    }
}
