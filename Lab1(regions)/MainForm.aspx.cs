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
        string connectionString = ConfigurationManager.ConnectionStrings["CountryDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                cmd = new SqlCommand("SELECT ID,Name FROM Regions", connection);

                DDListRegions.DataSource = cmd.ExecuteReader();
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
                connection = new SqlConnection(connectionString);
                
                connection.Open();
                cmd = new SqlCommand("SELECT ID,Name FROM Districts where IDRegion=" + DDListRegions.SelectedValue, connection);
       
                DDListDistricts.DataSource = cmd.ExecuteReader();
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
            if (DDListDistricts.SelectedIndex > 0)
            {
                connection = new SqlConnection(connectionString);
                cmd = new SqlCommand("SELECT ID,Name,Type,Population from Settlements where IDDistrict=" + DDListDistricts.SelectedValue, connection);
                connection.Open();
                
                GridView.DataSource = cmd.ExecuteReader();
                GridView.DataBind();
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

       protected void ShowData()
        {
            connection= new SqlConnection(connectionString);
            DataTable dataTable = new DataTable();
            cmd = new SqlCommand("SELECT ID,Name,Type,Population from Settlements where IDDistrict=" + DDListDistricts.SelectedValue, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            GridView.DataSource = dataTable;
            GridView.DataBind();
        }

        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            connection = new SqlConnection(connectionString);
            string id = GridView.DataKeys[e.RowIndex].Value.ToString();
            TextBox name = (TextBox)GridView.Rows[e.RowIndex].FindControl("textbox1");
            TextBox type = (TextBox)GridView.Rows[e.RowIndex].FindControl("textbox2");
            TextBox population = (TextBox)GridView.Rows[e.RowIndex].FindControl("textbox3");

            cmd = new SqlCommand("UPDATE Settlements SET Name='" + name.Text + "',Type = '"+type.Text+"',Population = '"+population.Text+"' where ID = "+id, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            GridView.EditIndex = -1;
            GridView.DataBind();
            ShowData();
        }

        protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView.EditIndex = -1;
            GridView.DataBind();
            ShowData();
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView.Rows[e.RowIndex];
            Label deleteName = (Label)row.FindControl("Name");
            connection = new SqlConnection(connectionString);
            
            cmd = new SqlCommand("DELETE FROM Settlements where Name='"+ GridView.DataKeys[e.RowIndex].Values[0].ToString()+"'", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            ShowData();
            connection.Close();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);

            string name = txtName.Text;
            string type = txtType.Text;
            int population = Int32.Parse(txtPopulation.Text);
            cmd = new SqlCommand("INSERT INTO Settlements (IDDistrict,Name,Type,Population) VALUES (" + DDListDistricts.SelectedValue+",'" + name+"','"+type+"',"+population+")",connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            ShowData();
            connection.Close();
        }
    }
}