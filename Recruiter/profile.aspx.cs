using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationChanges.Recruiter
{
    public partial class profile : System.Web.UI.Page
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter sda;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["LocalMysql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["recruiter"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                showUserProfile();
            }
        }

        private void showUserProfile()
        {
            con = new MySqlConnection(str);
            string query = "Select UserId,Username,Name,Address,Mobile,Email from Recruiter where Username=@username";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", Session["recruiter"]);
            sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dlProfile.DataSource = dt;
                dlProfile.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Please do login again with your latest username');</script>");
            }


        }

        protected void dlProfile_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "EditUserProfile")
            {
                Response.Redirect("recruiteredit.aspx?id=" + e.CommandArgument.ToString());
            }

        }
    }
}