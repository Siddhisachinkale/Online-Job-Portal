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
    public partial class viewresume : System.Web.UI.Page
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
                ShowAppliedJob();
            }
        }
        private void ShowAppliedJob()
        {
            string query = string.Empty;
            con = new MySqlConnection(str);
            query = @"SELECT 
  ROW_NUMBER() OVER (ORDER BY aj.AppliedJobId) AS Sr_No,
  aj.AppliedJobId,
  j.CompanyName,
  aj.JobId,
  j.Title,
  u.Mobile,
  u.Name,
  u.Email,
  u.Resume
FROM AppliesJobs aj
INNER JOIN Jobs j ON aj.JobId=j.JobId
INNER JOIN User u ON aj.UserId=u.UserId;";
            cmd = new MySqlCommand(query, con);

            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

       
        
        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowAppliedJob();
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int appliedJobId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

                con = new MySqlConnection(str);
                cmd = new MySqlCommand("delete from AppliesJobs where AppliedJobId=@id", con);
                cmd.Parameters.AddWithValue("@id", appliedJobId);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblMsg.Text = "Resume details deleted successfully";
                    lblMsg.CssClass = "alert alert-success";


                }
                else
                {
                    lblMsg.Text = ("Cannot delete the record");
                    lblMsg.CssClass = "alert alert-danger";

                }
                GridView1.EditIndex = -1;
                ShowAppliedJob();

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

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

            e.Row.Attributes["onCLick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Click to view job details";
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    HiddenField jobId = (HiddenField)row.FindControl("hdnJobId");
                    Response.Redirect("JobList.aspx?id" + jobId.Value);
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#ffffff");
                    row.ToolTip = "Click to select this row";
                }
            }
        }
    }
}