using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppADO.net
{
    class Program
    {
        static void Main(string[] args)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                String Query = "SELECT CustomerId, ContactName, City, Country FROM Customers";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr["CustomerId"] + " " + rdr["ContactName"] + " " + rdr["City"] + " " + rdr["Country"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hi there! this peogram arises Exception:" + ex);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
                Console.ReadKey();

            }
        }
    }
}
