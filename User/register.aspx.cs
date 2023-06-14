using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationChanges.User
{
    public partial class register : System.Web.UI.Page
    {

        MySqlConnection con;
        MySqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["LocalMysql"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) // Check if all validations pass
            {
                try
                {
                    con = new MySqlConnection(str);
                    if (ddlRegisterType.SelectedValue =="User")
                    {
                        string query = "insert into User (Username,Password,Name,Address,Mobile,Email) values (@Username,@Password,@Name,@Address,@Mobile,@Email)";

                        cmd = new MySqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtConfirmPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    }
                    else
                    {
                        string query = "insert into Recruiter (Username,Password,Name,Address,Mobile,Email) values (@Username,@Password,@Name,@Address,@Mobile,@Email)";

                        cmd = new MySqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtConfirmPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    }

                    con.Open();

                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Registered Successfully.";
                        lblMsg.CssClass = "alert alert-success";
                        clear();
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Cannot save record right now, Please try after sometime";
                        lblMsg.CssClass = "alert alert-danger";

                    }
                }


                catch (MySqlException ex)
                {
                    if (ex.Number == 1062) // MySQL error number for duplicate entry
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "The username '" + txtUserName.Text.Trim() + "' already exists. Please choose a different username.";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                    else
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");


                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Check the entries...";
                lblMsg.CssClass = "alert alert-danger";
            }
        }
        private void clear()
        {
            txtUserName.Text = String.Empty;
            txtConfirmPassword.Text = String.Empty;
            txtFullName.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtMobile.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtPassword.Text = String.Empty;


        }
    }
}