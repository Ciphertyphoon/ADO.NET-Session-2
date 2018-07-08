// ***********************************************************************
// Assembly         : Sample ADO.NetWebApplication
// Author           : jonna
// Created          : 06-30-2018
//
// Last Modified By : jonna
// Last Modified On : 06-30-2018
// ***********************************************************************
// <copyright file="SimpleSqlCommandBuilder.aspx.cs" company="">
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
    /// Class SimpleSqlCommandBuilder.
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class SimpleSqlCommandBuilder : System.Web.UI.Page
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
        /// Handles the Click event of the btnGetStudent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SilverCyanide"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string selectQuery = "Select * from tblStudents where ID = " + txtStudentID.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Students");

            // Store DataSet and the select query in ViewState, so they can be used
            // later to generate the T-SQL commands using SqlCommandBuilder class
            ViewState["DATASET"] = dataSet;
            ViewState["SELECT_QUERY"] = selectQuery;

            if (dataSet.Tables["Students"].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables["Students"].Rows[0];
                txtStudentName.Text = dataRow["Name"].ToString();
                txtTotalMarks.Text = dataRow["TotalMarks"].ToString();
                ddlGender.SelectedValue = dataRow["Gender"].ToString();
                lblStatus.ForeColor = System.Drawing.Color.DarkMagenta;
                lblStatus.Text = "Here's your Student Info";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No record with ID = " + txtStudentID.Text;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SilverCyanide"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            // Retrieve the Select query from ViewState and use it to build
            // SqlCommand command object, which will then be set as the 
            // SelectCommand of the SqlDataAdapter object
            dataAdapter.SelectCommand = new SqlCommand((string)ViewState["SELECT_QUERY"], con);

            // Associate SqlDataAdapter object with SqlCommandBuilder. At this point
            // SqlCommandBuilder should generate T-SQL statements automatically
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

            DataSet ds = (DataSet)ViewState["DATASET"];
            DataRow dr = ds.Tables["Students"].Rows[0];
            dr["Name"] = txtStudentName.Text;
            dr["Gender"] = ddlGender.SelectedValue;
            dr["TotalMarks"] = txtTotalMarks.Text;
            dr["Id"] = txtStudentID.Text;

            int rowsUpdated = dataAdapter.Update(ds, "Students");
            if (rowsUpdated == 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No rows updated";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = rowsUpdated.ToString() + " row(s) updated";
            }
            //For troubleshooting purposes, if you want to see the autogenerated INSERT, UPDATE, and DELETE T-SQL statements, use GetInsertCommand(), GetUpdateCommand() and GetDeleteCommand().
            lblInsert.Text = builder.GetInsertCommand().CommandText;
            lblUpdate.Text = builder.GetUpdateCommand().CommandText;
            lblDelete.Text = builder.GetDeleteCommand().CommandText;
        }
    }
}
