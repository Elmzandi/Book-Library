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
    public partial class adminmemberMNG : System.Web.UI.Page
    {
        string cnx = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
            cnx = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }


        void getMemberByID()
        {
            try
            {
              
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TextBox2.Text = dr.GetValue(0).ToString();
                            TextBox7.Text = dr.GetValue(10).ToString();
                            TextBox8.Text = dr.GetValue(1).ToString();
                            TextBox3.Text = dr.GetValue(2).ToString();
                            TextBox4.Text = dr.GetValue(3).ToString();
                            TextBox9.Text = dr.GetValue(4).ToString();
                            TextBox10.Text = dr.GetValue(5).ToString();
                            TextBox11.Text = dr.GetValue(6).ToString();
                            TextBox6.Text = dr.GetValue(7).ToString();

                        }
                    }

                    else
                    {
                        Response.Write("<script>alert('Invalid Member ID');</script>");
                    }
                    con.Close();


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        void UpdateMemberStatus(string status)
        {

            try
            {

                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("update member_master_tbl set account_status='" + status + "' WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated');</script>");
                    clearForm();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }


        }

        void deleteMember()
        {
            try
            {
                //string cnx = "deine_verbindungszeichenfolge";
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("delete from member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member has been deleted');</script>");                  
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }


        bool checkMemberExists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cnx))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            UpdateMemberStatus("active");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            UpdateMemberStatus("pending");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            UpdateMemberStatus("disable");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                deleteMember();
            }

            else
            {
                Response.Write("<script>alert('Member with this ID doesnt Exist.');</script>");

            }
        }
    }
}