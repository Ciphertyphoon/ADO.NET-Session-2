////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DataReaderObjNext.aspx.cs
//
// summary:	Implements the data reader object next.aspx class
////////////////////////////////////////////////////////////////////////////////////////////////////

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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A data reader object next. </summary>
    ///
    /// <remarks>   Jonna, 03-Jul-18. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class DataReaderObjNext : System.Web.UI.Page
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by Page for load events. </summary>
        ///
        /// <remarks>   Jonna, 03-Jul-18. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by Button1 for click events. </summary>
        ///
        /// <remarks>   Jonna, 03-Jul-18. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Button1_Click(object sender, EventArgs e)
        {
            String ConStr = ConfigurationManager.ConnectionStrings["SilverCyanide"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select * from tblProductInventory; Select * from tblProductCategories", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    GridView1.DataSource = reader;
                    GridView1.DataBind();

                    while (reader.NextResult())
                    {
                        GridView2.DataSource = reader;
                        GridView2.DataBind();
                    }

                }
            }
        }
    }
}