﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationChanges.User
{
    public partial class resumebuilder : System.Web.UI.Page
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader sdr;
        string query;
        string str = ConfigurationManager.ConnectionStrings["LocalMysql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
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
                string query = "Select * from User where UserId=@userId";
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

                        txtTenth.Text = sdr["TenthGrade"].ToString();

                        txtTwelfth.Text = sdr["TwelfthGrade"].ToString();

                        txtGraduation.Text = sdr["GraduationGrade"].ToString();

                        txtPostGraduation.Text = sdr["PostGraduationGrade"].ToString();

                        txtPhd.Text = sdr["Phd"].ToString();

                        txtWork.Text = sdr["Workson"].ToString();

                        txtExperience.Text = sdr["Experience"].ToString();

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
                    bool isValid = false;
                    con = new MySqlConnection(str);
                    if (fuResume.HasFile)
                    {
                        if (Utils.IsValidExtension4Resume(fuResume.FileName))
                        {

                            concatQuery = "Resume=@resume,";
                            isValid = true;
                        }

                        else
                        {
                            concatQuery = string.Empty;

                        }
                    }
                    else
                    {
                        concatQuery = string.Empty;
                    }

                    query = @"Update User set Username=@Username, Name=@Name, Email=@Email, Mobile=@Mobile, TenthGrade=@TenthGrade, TwelfthGrade=@TwelfthGrade, GraduationGrade=@GraduationGrade, PostGraduationGrade=@PostGraduationGrade, Phd=@Phd, WorksOn=@Workson, Experience=@Experience," + concatQuery + "Address=@Address where UserId=@UserId";

                    cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());

                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());

                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());

                    cmd.Parameters.AddWithValue("@TenthGrade", txtTenth.Text.Trim());

                    cmd.Parameters.AddWithValue("@TwelfthGrade", txtTwelfth.Text.Trim());

                    cmd.Parameters.AddWithValue("@GraduationGrade", txtGraduation.Text.Trim());

                    cmd.Parameters.AddWithValue("@PostGraduationGrade", txtPostGraduation.Text.Trim());

                    cmd.Parameters.AddWithValue("@Phd", txtPhd.Text.Trim());

                    cmd.Parameters.AddWithValue("@Workson", txtWork.Text.Trim());

                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());

                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);

                    if (fuResume.HasFile)
                    {
                        if (Utils.IsValidExtension4Resume(fuResume.FileName))
                        {
                            Guid obj = Guid.NewGuid();


                            filePath = "Resumes/" + obj.ToString() + fuResume.FileName;
                            fuResume.PostedFile.SaveAs(Server.MapPath("~/Resumes/") + obj.ToString() + fuResume.FileName);

                            cmd.Parameters.AddWithValue("@resume", filePath);
                            isValid = true;
                        }
                        else
                        {
                            concatQuery = string.Empty;
                            lblMsg.Visible = true;
                            lblMsg.Text = "Select .doc, .docx or .pdf file only.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        isValid = true;

                    }
                    if (isValid)
                    {
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Resume details updated successfully";
                            lblMsg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Cannot update the records,please try after sometime";
                            lblMsg.CssClass = "alert alert-danger";
                        }
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