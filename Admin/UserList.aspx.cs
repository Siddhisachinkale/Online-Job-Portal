using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationChanges.Admin
{
    public partial class UserList : System.Web.UI.Page
    {

        MySqlConnection con;
        MySqlCommand cmd;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["LocalMysql"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/login.aspx");
            }
            if (!IsPostBack)
            {
                ShowUsers();
            }
        }

        private void ShowUsers()
        {
            string query = string.Empty;
            con = new MySqlConnection(str);
            query = @"select Row_Number() over(Order by (Select 1)) as Sr_No,UserId, Name, Email, Mobile from User;";
            cmd = new MySqlCommand(query, con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowUsers();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int userId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                con = new MySqlConnection(str);
                cmd = new MySqlCommand("delete from User where UserId=@id", con);
                cmd.Parameters.AddWithValue("@id", userId);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblMsg.Text = "User deleted successfully";
                    lblMsg.CssClass = "alert alert-success";


                }
                else
                {
                    lblMsg.Text = ("Cannot delete the record");
                    lblMsg.CssClass = "alert alert-danger";

                }

                GridView1.EditIndex = -1;
                ShowUsers();

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}