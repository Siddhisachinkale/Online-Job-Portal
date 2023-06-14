using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationChanges.Admin
{
    public partial class JobList : System.Web.UI.Page
    {
        MySqlConnection con;
        MySqlCommand cmd;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["LocalMysql"].ConnectionString;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/login.aspx");
            }
            if (!IsPostBack)
            {
                ShowJob();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowJob();
        }

        private void ShowJob()
        {
            string query = string.Empty;
            con = new MySqlConnection(str);
            //query = @"select Row_Number() over(Order by (Select 1)) as Sr_No, JobId, Title, NoOfPost, Qualification, Experience, LastDateToApply, CompanyName, CreateDate from Jobs";
            query = @"SELECT ROW_NUMBER() OVER (ORDER BY j.JobId) AS Sr_No,
       j.JobId,
       j.Title,
       j.NoOfPost,
       j.Qualification,
       j.Experience,
       j.LastDateToApply,
       r.Name AS RecruiterName,
       j.CreateDate,
       j.CompanyName
FROM jobs j
INNER JOIN recruiter r ON j.CompanyName = r.CompanyName;
";
            cmd = new MySqlCommand(query, con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            //if (Request.QueryString["id"] != null)
            //{
            //    linkBack.Visible = true;
            //}

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowJob();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int jobId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                con = new MySqlConnection(str);
                cmd = new MySqlCommand("delete from Jobs where JobId=@id", con);
                cmd.Parameters.AddWithValue("@id", jobId);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblMsg.Text = "Job details deleted successfully";
                    lblMsg.CssClass = "alert alert-success";


                }
                else
                {
                    lblMsg.Text = ("Cannot delete the record");
                    lblMsg.CssClass = "alert alert-danger";

                }

                GridView1.EditIndex = -1;
                ShowJob();

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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditJob")
            {
                Response.Redirect("newjob.aspx?id=" + e.CommandArgument.ToString());
            }
        }



        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ID = e.Row.RowIndex.ToString();
                if (Request.QueryString["id"] != null)
                {
                    int jobId = Convert.ToInt32(GridView1.DataKeys[e.Row.RowIndex].Values[0]);
                    if (jobId == Convert.ToInt32(Request.QueryString["id"]))
                    {
                        e.Row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    }
                }
            }
        }
    }
}