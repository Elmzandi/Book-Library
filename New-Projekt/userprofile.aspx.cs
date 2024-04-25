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
    public partial class userprofile : System.Web.UI.Page
    {
        string cnx = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            cnx = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
            

            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        void getUserPersonalDetails()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id= '"+ Session["username"].ToString() + "';", con);            
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                    TextBox4.Text = dt.Rows[0]["dob"].ToString();
                    TextBox1.Text = dt.Rows[0]["contact_no"].ToString();
                    TextBox2.Text = dt.Rows[0]["email"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["city"].ToString();
                    TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                    TextBox5.Text = dt.Rows[0]["full_adresse"].ToString();
                    TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                    TextBox9.Text = dt.Rows[0]["password"].ToString();

                    Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                    if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-success");
                    }
                    else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                    }
                    else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                    }
                    else
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-info");
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }


        void getUserBookData()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    string sqlQuery = "SELECT * FROM book_issue_tbl WHERE member_id = @MemberID";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@MemberID", Session["username"].ToString());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        void updateBook()
        {

            string password = "";
            if (TextBox19.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox19.Text.Trim();
            }

            try
            {

                using (SqlConnection con = new SqlConnection(cnx))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("update member_master_tbl set full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_adresse=@full_adresse, password=@password, account_status=@account_status WHERE member_id='" + Session["username"].ToString().Trim() + "'", con);
                    cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact_no", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@full_adresse", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@account_status", "pending");

                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                    {

                        Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                        getUserPersonalDetails();
                        getUserBookData();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invaid entry');</script>");
                    }

                }
            }
                
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }



        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            updateBook();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
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



    

