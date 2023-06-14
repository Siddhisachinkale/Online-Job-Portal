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
    public partial class contact : System.Web.UI.Page
    {
        MySqlConnection con;
        MySqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["LocalMysql"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection(str);
                string query = "insert into contact (name,email,subject,msg) values (@name, @email, @subject, @msg)";
                cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", name.Value.Trim());
                cmd.Parameters.AddWithValue("@email", email.Value.Trim());
                cmd.Parameters.AddWithValue("@subject", subject.Value.Trim());
                cmd.Parameters.AddWithValue("@msg", message.Value.Trim());

                con.Open();

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Thanks for reaching out, will look into your problem.";
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

            name.Value = string.Empty;
            email.Value = string.Empty;
            subject.Value = string.Empty;
            message.Value = string.Empty;

        }
    }
    
}