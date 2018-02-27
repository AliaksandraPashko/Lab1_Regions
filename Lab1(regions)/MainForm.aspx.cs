using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Lab1_regions_
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CountryDBConnectionString"].ConnectionString;
        
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT ID, Name FROM Regions", connection);
            connection.Open();
            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataBind();
            connection.Close();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}