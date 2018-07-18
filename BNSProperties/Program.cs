using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNSProperties
{
    class Program
    {
        static void Main(string[] args)
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
                            //bc.SqlRowsCopied += (sender, eventArgs) =>
                            //{
                            //    Console.WriteLine(eventArgs.RowsCopied + " loaded....");
                            //};
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

