using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationChanges.Recruiter
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader sdr;
        string query;
        string str = ConfigurationManager.ConnectionStrings["LocalMysql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["recruiter"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    showUserInfo();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }

            }
        }

        private void showUserInfo()
        {

            try
            {
                con = new MySqlConnection(str);
                string query = "Select * from Recruiter where UserId=@userId";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", Request.QueryString["id"]);
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtUserName.Text = sdr["Username"].ToString();

                        txtFullName.Text = sdr["Name"].ToString();

                        txtEmail.Text = sdr["Email"].ToString();

                        txtMobile.Text = sdr["Mobile"].ToString();

                        txtQualifications.Text = sdr["Qualifications"].ToString();

                        txtExperience.Text = sdr["Experience"].ToString();

                        txtCompanyName.Text = sdr["CompanyName"].ToString();

                        txtPost.Text = sdr["Post"].ToString();



                        txtAddress.Text = sdr["Address"].ToString();


                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "User not found";
                    lblMsg.CssClass = "alert alert-danger";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string concatQuery = string.Empty;
                    string filePath = string.Empty;
                    //bool isValidToExecute = false;
                    //bool isValid = false;
                    con = new MySqlConnection(str);

                    query = @"Update Recruiter set Username=@Username, Name=@Name, Email=@Email, Mobile=@Mobile, Qualifications=@Qualifications, CompanyName=@CompanyName, Post=@Post, Experience=@Experience,Address=@Address where UserId=@UserId";

                    cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());

                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());

                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());

                    cmd.Parameters.AddWithValue("@Qualifications", txtQualifications.Text.Trim());

                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());

                    cmd.Parameters.AddWithValue("@Post", txtPost.Text.Trim());

                    cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text.Trim());



                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);


                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = " Details updated successfully";
                        lblMsg.CssClass = "alert alert-success";
                    }



                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Cannot update the records,please try <b>Relogin</b>";
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
    }
}



