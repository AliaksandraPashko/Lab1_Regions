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
        SqlConnection connection;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CountryDBConnectionString"].ConnectionString;
                connection = new SqlConnection(connectionString);

                DataTable dt = new DataTable();
                using (connection)
                {
                    connection.Open();
                    cmd = new SqlCommand("SELECT ID,Name FROM Regions", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                DDListRegions.DataSource = dt;
                DDListRegions.DataBind();
                DDListRegions.Items.Insert(0, new ListItem("-Select-", "0"));
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        protected void DDListRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDListRegions.SelectedIndex > 0)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["CountryDBConnectionString"].ConnectionString;
                connection = new SqlConnection(connectionString);

                DataTable dt = new DataTable();
                using (connection)
                {
                    connection.Open();
                    cmd = new SqlCommand("SELECT ID,Name FROM Districts where IDRegion=" + DDListRegions.SelectedValue, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                DDListDistricts.DataSource = dt;
                DDListDistricts.DataBind();
                DDListDistricts.Items.Insert(0, new ListItem("-Select-", "0"));
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        protected void DDListDistricts_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}