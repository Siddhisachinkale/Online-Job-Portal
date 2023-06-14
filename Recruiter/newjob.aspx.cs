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
    public partial class newjob : System.Web.UI.Page
    {
        MySqlConnection con;
        MySqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["LocalMysql"].ConnectionString;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["recruiter"] == null)
            {
                Response.Redirect("../User/login.aspx");
            }
            Session["title"] = "Add Job";
            if (!IsPostBack)
            {
                fillData();
            }
        }

        private void fillData()
        {
            if (Request.QueryString["id"] != null)
            {
                con = new MySqlConnection(str);
                query = "Select * from Jobs where JobId = '" + Request.QueryString["id"] + "' ";
                cmd = new MySqlCommand(query, con);
                con.Open();
                MySqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        txtJobTitle.Text = sdr["Title"].ToString();
                        txtNoOfPost.Text = sdr["NoOfPost"].ToString();
                        txtDescription.Text = sdr["Description"].ToString();
                        txtQualification.Text = sdr["Qualification"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();
                        txtSpecialization.Text = sdr["Specialization"].ToString();
                        txtLastDate.Text = Convert.ToDateTime(sdr["LastDateToApply"]).ToString("yyyy-MM-dd");
                        txtSalary.Text = sdr["Salary"].ToString();
                        ddlJobType.SelectedValue = sdr["JobType"].ToString();
                        txtCompany.Text = sdr["CompanyName"].ToString();
                        txtWebsite.Text = sdr["Website"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        btnAdd.Text = "Update";
                        //linkBack.Visible = true;
                        Session["title"] = "Edit Job";

                    }
                }
                else
                {
                    lblMsg.Text = "Job not found";
                    lblMsg.CssClass = "alert alert-danger";

                }
                sdr.Close();
                con.Close();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string type, concatQuery, imagePath = string.Empty;
                bool isValidToExecute = false;
                con = new MySqlConnection(str);
                if (Request.QueryString["id"] != null)
                {
                    if (fuCompanyLogo.HasFile)
                    {
                        if (IsValidExtension(fuCompanyLogo.FileName))
                        {
                            concatQuery = "CompanyImage=@CompanyImage";
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

                    query = @"Update Jobs set Title=@Title,NoOfPost=@NoOfPost,Description=@Description,Qualification=@Qualification,Experience=@Experience,Specialization=@Specialization,LastDateToApply=@LastDateToApply,Salary=@Salary,JobType=@JobType,CompanyName=@CompanyName,Website=@Website,Email=@Email,Address=@Address where JobId=@id";
                    type = "updated";
                    cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPost", txtNoOfPost.Text.Trim());

                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());

                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());

                    cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());

                    cmd.Parameters.AddWithValue("@LastDateToApply", txtLastDate.Text.Trim());

                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());

                    cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);

                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());

                    //cmd.Parameters.AddWithValue("@CompanyImage", txtJobTitle.Text.Trim());

                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());

                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());



                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());

                    if (fuCompanyLogo.HasFile)
                    {
                        if (IsValidExtension(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);

                            cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "Please select valid file extensiion.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        isValidToExecute = true;
                    }

                }
                else
                {
                    query = @"insert into Jobs(Title,NoOfPost,Description,Qualification,Experience,Specialization,LastDateToApply,Salary,JobType,CompanyName,CompanyImage,Website,Email,Address,CreateDate) values (@Title, @NoOfPost, @Description, @Qualification, @Experience, @Specialization, @LastDateToApply, @Salary,@JobType,@CompanyName, @CompanyImage, @Website, @Email,@Address, @CreateDate)";
                    type = "saved";
                    DateTime time = DateTime.Now;

                    cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPost", txtNoOfPost.Text.Trim());

                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());

                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());

                    cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());

                    cmd.Parameters.AddWithValue("@LastDateToApply", txtLastDate.Text.Trim());

                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());

                    cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);

                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());

                    //cmd.Parameters.AddWithValue("@CompanyImage", txtJobTitle.Text.Trim());

                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());

                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());



                    cmd.Parameters.AddWithValue("@CreateDate", time.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (fuCompanyLogo.HasFile)
                    {
                        if (IsValidExtension(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);

                            cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "Please select valid file extensiion.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        isValidToExecute = true;
                    }

                }
                if (isValidToExecute)
                {
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        lblMsg.Text = "Job " + type + " Successfully";
                        lblMsg.CssClass = "alert alert-success";
                        clear();
                        btnAdd.Text = "Add Job";

                    }
                }
                else
                {
                    lblMsg.Text = "Cannot  " + type + " the records. please try after sometime.";
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

        private void clear()
        {
            txtJobTitle.Text = string.Empty;

            txtNoOfPost.Text = string.Empty;

            txtDescription.Text = string.Empty;

            txtQualification.Text = string.Empty;

            txtExperience.Text = string.Empty;

            txtSpecialization.Text = string.Empty;

            txtLastDate.Text = string.Empty;

            txtSalary.Text = string.Empty;

            txtCompany.Text = string.Empty;

            txtWebsite.Text = string.Empty;

            txtEmail.Text = string.Empty;

            txtAddress.Text = string.Empty;

            ddlJobType.ClearSelection();

        }

        public static bool IsValidExtension(string fileName)
        {

            bool isValid = false;

            string[] fileExtension = { ".jpg", ".png", ".jpeg" };
            for (int i = 0; i <= fileExtension.Length - 1; i++)
            {

                if (fileName.Contains(fileExtension[i]))

                {

                    isValid = true;
                    break;
                }
            }
            return isValid;
        }

    }
}