// ***********************************************************************
// Assembly         : Sample ADO.NetWebApplication
// Author           : jonna
// Created          : 06-30-2018
//
// Last Modified By : jonna
// Last Modified On : 06-30-2018
// ***********************************************************************
// <copyright file="CachingDataset.aspx.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class CachingDataset.
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class CachingDataset : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnLoadData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            // Check if the DataSet is present in the cache
            if (Cache["Data"] == null)
            {
                // If the dataset is not in the cache load data from the database into the DataSet
                string CS = ConfigurationManager.ConnectionStrings["SilverCyanide"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(CS))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from tblProductInventory", connection);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset);

                    gvProducts.DataSource = dataset;
                    gvProducts.DataBind();

                    // Store the DataSet in the Cache
                    Cache["Data"] = dataset;
                    lblMessage.Text = "Data loaded from the Database";
                }
            }
            // If the DataSet is in the Cache
            else
            {
                // Retrieve the DataSet from the Cache and type cast to DataSet
                gvProducts.DataSource = (DataSet)Cache["Data"];
                gvProducts.DataBind();
                lblMessage.Text = "Data loaded from the Cache";
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClearnCache control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnClearnCache_Click(object sender, EventArgs e)
        {
            // Check if the DataSet is present in the cache
            if (Cache["Data"] != null)
            {
                // Remove the DataSet from the Cache
                Cache.Remove("Data");
                lblMessage.Text = "DataSet removed from the cache";
            }
            // If the DataSet is not in the Cache
            else
            {
                lblMessage.Text = "There is nothing in the cache to remove";
            }
        }
    }
}
