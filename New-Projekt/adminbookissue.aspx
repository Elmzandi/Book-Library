<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="adminbookissue.aspx.cs" Inherits="New_Projekt.adminbookissue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
      <script type="text/javascript">
           $(document).ready(function () {

              // $(document).ready(function () {
             // $('.table').DataTable();
             //   });

               $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
             // $('.table1').DataTable();
           });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid">
        <div class="row">
            <div class="col-md-5" >
                <div class="card">
                    <div class="card-body">
                         <div class="row">
                     <div class="col">
                        <center>
                           <h3>Book Issuing</h3>
                        </center>
                     </div>
                  </div>


                        <div class="row">
                     <div class="col">
                        <center>
                            <img width="80px" src="imgs/books.png" />
                        </center>
                     </div>
                  </div>

                        
                 <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                        
                  <div class="row">
                     <div class="col-md-6">

                          <label>Member ID</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="Member ID" ID="TextBox3" runat="server"></asp:TextBox>
                         </div>

                     </div>

                     <div class="col-md-6">

                         <label>Book ID</label>
                         <div class="form-group">
                              <div class="input-group">
                             <asp:TextBox Cssclass="form-control" placeholder="Book ID"  ID="TextBox4" runat="server"></asp:TextBox>
                             <asp:Button class="btn btn-secondary btn-sm" ID="Button2" runat="server" Text="GO" OnClick="Button2_Click" />
                         </div>
                            </div>
                     </div>

                  </div>


                         <div class="row">
                     <div class="col-md-6">

                          <label>Member Name </label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="Member Name" ID="TextBox1" runat="server" ReadOnly="true" ></asp:TextBox>
                         </div>

                     </div>

                     <div class="col-md-6">

                         <label>Book Name</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="Book Name" ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox>

                         </div>
                     </div>

                  </div>


                    
                      <div class="row">
                     <div class="col-md-6">

                          <label>Start Date</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" ID="TextBox5" runat="server" TextMode="Date"></asp:TextBox>
                         </div>

                     </div>
                        
                           <div class="col-md-6">

                          <label>End Date</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" ID="TextBox6" runat="server" TextMode="Date"></asp:TextBox>
                         </div>

                     </div>


                          </div>

                      
                   <div class="row">
                     <div class="col-md-6">                       
                          <div class="form-group">
                              <asp:Button ID="Button1" runat="server" Text="Issue" class="btn btn-primary btn-block btn-lg" OnClick="Button1_Click" />
   
                         </div>
                     </div>

                        <div class="col-md-6">                       
                          <div class="form-group">
                              <asp:Button ID="Button3" runat="server" Text="Return" class="btn btn-success btn-block btn-lg" OnClick="Button3_Click" />
   
                         </div>
                     </div>

                  </div>
                    </div>              
                    </div>
                 
                 
            </div>



            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row" >
                     <div class="col">
                        <center>
                            <img width="80px" src="imgs/books1.png" />
                        </center>
                     </div>
                  </div>

                        <div class="row">
                     <div class="col">
                        <center>
                           <h3>Issued Books List</h3>
                        </center>
                     </div>
                  </div>

                        

                         <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                         <div class="row">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"  >
                             <Columns>
                                 <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" />
                                 <asp:BoundField DataField="member_name" HeaderText="member_name" SortExpression="member_name" />
                                 <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                 <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                 <asp:BoundField DataField="issue_date" HeaderText="issue_date" SortExpression="issue_date" />
                                 <asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />
                             </Columns>
                         </asp:GridView>
                     </div>
                  </div>
                          
                    </div>
              
                    </div>
                 

            </div>

        </div>
    </div>



</asp:Content>
