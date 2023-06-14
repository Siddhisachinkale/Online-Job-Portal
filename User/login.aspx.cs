using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationChanges.User
{
    public partial class login : System.Web.UI.Page
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader sdr;
        string str = ConfigurationManager.ConnectionStrings["LocalMysql"].ConnectionString;
        string username, password = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (ddlLoginType.SelectedValue == "Admin")
                    {
                        username = ConfigurationManager.AppSettings["username"];
                        password = ConfigurationManager.AppSettings["password"];
                        if (username == txtUserName.Text.Trim() && password == txtPassword.Text.Trim())
                        {
                            Session["admin"] = username;
                            Response.Redirect("../Admin/admindashboard.aspx", false);
                        }
                        else
                        {
                            showErrorMsg("Admin");
                        }

                    }
                    else if(ddlLoginType.SelectedValue == "User")
                    {
                        con = new MySqlConnection(str);
                        string query = "Select * from User where Username=@Username and Password=@Password";
                        cmd = new MySqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());


                        con.Open();

                        sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            Session["user"] = sdr["Username"].ToString();
                            Session["userId"] = sdr["UserId"].ToString();
                            Response.Redirect("default.aspx", false);


                        }
                        else
                        {
                            showErrorMsg("User");
                        }
                        con.Close();
                    }
                    else
                    {
                        con = new MySqlConnection(str);
                        string query = "Select * from Recruiter where Username=@Username and Password=@Password";
                        cmd = new MySqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());


                        con.Open();

                        sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            Session["recruiter"] = sdr["Username"].ToString();
                            Session["recruiterId"] = sdr["UserId"].ToString();
                            Response.Redirect("../Recruiter/recruiterdashboard.aspx", false);


                        }
                        else
                        {
                            showErrorMsg("Recruiter");
                        }
                        con.Close();

                    }

                }

                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                    con.Close();


                }

            }

        }

        private void showErrorMsg(string userType)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "<b>" + userType + "</b> Credentials are incorrect...";
            lblMsg.CssClass = "alert alert-danger";
        }
    }
}


        

