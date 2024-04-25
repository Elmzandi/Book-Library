using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_Projekt
{
    public partial class userlogin : System.Web.UI.Page
    {
        string cnx = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            cnx = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cnx))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Response.Write("<script>alert('Login Sucess');</script>");
                            Session["username"] = dr.GetValue(8).ToString();
                            Session["fullname"] = dr.GetValue(0).ToString();
                            Session["role"] = "user";
                            Session["status"] = dr.GetValue(10).ToString();

                        }
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid credentials');</script>");
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}