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
    public partial class adminbookissue : System.Web.UI.Page
    {
        string cnx = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            cnx = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
            GridView1.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {          
                getNameID();
        }

        void getNameID()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("select book_name from book_master_tbl WHERE book_id='" + TextBox4.Text.Trim() + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1) 
                    {
                        TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Wrong Book ID');</script>");
                    }

                    cmd = new SqlCommand("select full_name from member_master_tbl WHERE member_id='" + TextBox3.Text.Trim() + "'", con);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Wrong User ID');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        
        bool checkIfBookExist() 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='" + TextBox4.Text.Trim() + "' AND current_stock >0", con);

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

                    con.Close();

                }
            }

            catch (Exception)
            {

                return false;
            }

        }


        bool checkIfMemberExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox3.Text.Trim() + "'", con);

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

                    con.Close();

                }
            }

            catch (Exception)
            {

                return false;
            }

        }


        void IssueBook()
        {
            try
            {
                //string cnx = "deine_verbindungszeichenfolge";
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id,member_name,book_id,book_name,issue_date,due_date) values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);
                    cmd.Parameters.AddWithValue("@member_id", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_id", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
                    cmd.ExecuteNonQuery();

                                        
                    GridView1.DataBind();


                    cmd = new SqlCommand("update book_master_tbl set current_stock= current_stock-1 WHERE book_id='" + TextBox4.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();


                    Response.Write("<script>alert('Successful Add');</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }


        void ReturnBook()
        {
            try
            {
                //string cnx = "deine_verbindungszeichenfolge";
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("delete from book_issue_tbl WHERE book_id='" + TextBox4.Text.Trim() + "' AND member_id='" + TextBox3.Text.Trim() + "'", con);

                    int Result = cmd.ExecuteNonQuery();

                   if (Result > 0)
                    {
                        cmd = new SqlCommand("update book_master_tbl set current_stock= current_stock+1 WHERE book_id='" + TextBox4.Text.Trim() + "'", con);
                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Issue has been deleted');</script>");
                        GridView1.DataBind();
                        con.Close();
                    }

                    else
                    {
                        Response.Write("<script>alert('Error - Invalid details');</script>");

                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        bool checkIfEntryExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tbl where member_id='" + TextBox3.Text.Trim() + "' AND book_id='" + TextBox4.Text.Trim() + "'", con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
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

            catch (Exception)
            {

                return false;
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfEntryExist())
                {
                    
                    Response.Write("<script>alert('You have already this Book');</script>");
                }
                else
                {
                    IssueBook();

                }

            }

            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            if (checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfEntryExist())
                {
                    ReturnBook();
                }
                else
                {
                    Response.Write("<script>alert('This Entry Not Exist');</script>");

                }

            }

            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }

        }
    }
}