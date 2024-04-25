using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace New_Projekt
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string cnx = null;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            cnx = ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
            if (!IsPostBack)
            {
                fillAuthorValues();
            }
                       
            GridView1.DataBind(); 
        }

        void fillAuthorValues() 
        {

            try
            {
                using (SqlConnection con = new SqlConnection(cnx))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl ;", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DropDownList3.DataSource = dt;
                    DropDownList3.DataValueField = "author_name";
                    DropDownList3.DataBind();




                    cmd = new SqlCommand("SELECT publisher_name from publisher_master_tbl ;", con);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    DropDownList2.DataSource = dt;
                    DropDownList2.DataValueField = "publisher_name";
                    DropDownList2.DataBind();

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
              
            }


        }

        bool checkBookExists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cnx))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "';", con);
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

        void addNewBook() 
        {
            try
            {

                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                // add new comma
                genres = genres.Remove(genres.Length - 1);

                //add file 

                string filepath = "~/bookinventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("bookinventory/" + filename));
                filepath = "~/bookinventory/" + filename;


                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publisher_date,language,edition,book_cost,no_of_pages,book_descreption,actual_stock,current_stock,book_img_link) values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publisher_date,@language,@edition,@book_cost,@no_of_pages,@book_descreption,@actual_stock,@current_stock,@book_img_link)", con);
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_date", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_descreption", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book added successfully.');</script>");
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        void getBookByID()
        {
            try
            {
                
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='"+ TextBox1.Text.Trim() +"';", con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        TextBox2.Text = dt.Rows[0][1].ToString();
                        TextBox3.Text = dt.Rows[0][5].ToString();
                        TextBox5.Text = dt.Rows[0][7].ToString();
                        TextBox4.Text = dt.Rows[0][8].ToString().Trim();
                        TextBox6.Text = dt.Rows[0][9].ToString().Trim();
                        TextBox7.Text = dt.Rows[0][11].ToString().Trim();
                        TextBox8.Text = dt.Rows[0][12].ToString().Trim();
                        TextBox10.Text = dt.Rows[0][10].ToString();
                        TextBox9.Text = "" + (Convert.ToInt32(dt.Rows[0][11].ToString()) - Convert.ToInt32(dt.Rows[0][12].ToString()));

                        DropDownList1.SelectedValue = dt.Rows[0][6].ToString().Trim();
                        DropDownList2.SelectedValue = dt.Rows[0][4].ToString().Trim();
                        DropDownList3.SelectedValue = dt.Rows[0][3].ToString().Trim();

                        ListBox1.ClearSelection();

                        string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                        for (int i = 0; i < genre.Length; i++)
                        {
                            for (int j = 0; j < ListBox1.Items.Count; j++)
                            {
                                if (ListBox1.Items[j].ToString() == genre[i])
                                {
                                    ListBox1.Items[j].Selected = true;

                                }
                            }
                        }

                        global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                        global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                        global_issued_books = global_actual_stock - global_current_stock;
                        global_filepath = dt.Rows[0]["book_img_link"].ToString();

                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Book ID');</script>");
                    }
                    con.Close();


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        void updateBook()
        {
            
                try
                {

                int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                int current_stock = Convert.ToInt32(TextBox5.Text.Trim());

                if (global_actual_stock == actual_stock)
                {

                }

                else
                {
                    if (actual_stock < global_issued_books)
                    {
                        Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                        return;


                    }
                    else
                    {
                        current_stock = actual_stock - global_issued_books;
                        TextBox5.Text = "" + current_stock;
                    }
                }



                string genres = "";
                 foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);


                string filepath = "~/bookinventory/books1";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (filename == "" || filename == null)
                {
                    filepath = global_filepath;

                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("bookinventory/" + filename));
                    filepath = "~/bookinventory/" + filename;
                }





                using (SqlConnection con = new SqlConnection(cnx))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("update book_master_tbl set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publisher_date=@publisher_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_descreption=@book_descreption, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + TextBox1.Text.Trim() + "'", con);                       
                        cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@genre", genres);
                        cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@publisher_date", TextBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@edition", TextBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@no_of_pages", TextBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_descreption", TextBox10.Text.Trim());
                        cmd.Parameters.AddWithValue("@actual_stock", TextBox7.Text.Trim());
                        cmd.Parameters.AddWithValue("@current_stock", TextBox7.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_img_link", filepath);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        
                        Response.Write("<script>alert('Book has been Updated');</script>");

                        GridView1.DataBind();

                }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            


        }


        void deleteBook()
        {
            try
            {
                //string cnx = "deine_verbindungszeichenfolge";
                using (SqlConnection con = new SqlConnection(cnx))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("delete from book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    Response.Write("<script>alert('Book has been deleted');</script>");
                    
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }




        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkBookExists())
            {
                updateBook();
            }
            else
            {
                Response.Write("<script>alert('Book Not Exists, try some other Book ID');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            if (checkBookExists())
            {
                deleteBook();
            }

            else
            {
                Response.Write("<script>alert('Book with this ID doesnt Exist.');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkBookExists())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
            }
            else
            {
                addNewBook();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            getBookByID();
         
        }
    }
}