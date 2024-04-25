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

    public partial class adminauthor : System.Web.UI.Page
    {
        string cnx = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            cnx = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                getAuthorByID();
            }

            else
            {
                Response.Write("<script>alert('Author with this ID doesnt Exist.');</script>");
            }
        }

        bool checkMemberExists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cnx))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='" + TextBox3.Text.Trim() + "';", con);
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


        void addNewAuthor()
        {
            try
            {
                //string cnx = "deine_verbindungszeichenfolge";
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) values(@author_id,@author_name)", con);
                    cmd.Parameters.AddWithValue("@author_id", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_name", TextBox4.Text.Trim());
                    cmd.ExecuteNonQuery();

                    con.Close();

                    Response.Write("<script>alert('Successful Add');</script>");
                    clearForm();

                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        void updateAuthor()
        {
            try
            {
                //string cnx = "deine_verbindungszeichenfolge";
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("update author_master_tbl set author_name=@author_name WHERE author_id='" + TextBox3.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@author_name", TextBox4.Text.Trim());
                    cmd.ExecuteNonQuery();

                    con.Close();

                    Response.Write("<script>alert('Author has been Updated');</script>");
                    clearForm();

                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        void deleteAuthor()
        {
            try
            {
                //string cnx = "deine_verbindungszeichenfolge";
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("delete from author_master_tbl WHERE author_id='" + TextBox3.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    Response.Write("<script>alert('Author has been deleted');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        void getAuthorByID()
        {
            try
            {
                //string cnx = "deine_verbindungszeichenfolge";
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='" + TextBox3.Text.Trim() + "'", con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        TextBox4.Text = dt.Rows[0][1].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Author ID');</script>");
                    }
                    con.Close();


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }


        void clearForm()
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                Response.Write("<script>alert('publisher with this ID already Exist.');</script>");
            }

            else
            {
                addNewAuthor();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                updateAuthor();
            }

            else
            {
                Response.Write("<script>alert('Publisher with this ID doesnt Exist.');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                deleteAuthor();
            }

            else
            {
                Response.Write("<script>alert('Author with this ID doesnt Exist.');</script>");
            }
        }
    }
}