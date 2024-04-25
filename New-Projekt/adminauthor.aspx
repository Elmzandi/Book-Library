<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="adminauthor.aspx.cs" Inherits="New_Projekt.adminauthor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="row">
            <div class="col-md-5" >
                <div class="card">
                    <div class="card-body">
                         <div class="row">
                     <div class="col">
                        <center>
                           <h3>Author Details</h3>
                        </center>
                     </div>
                  </div>

                        <div class="row">
                     <div class="col">
                        <center>
                            <img  width="80px" src="imgs/writer.png" />                           
                        </center>
                     </div>
                  </div>

                    
                 <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>


                        
                  <div class="row">
                     <div class="col-md-4">

                          <label>Author ID</label>
                         <div class="form-group">
                             <div class="input-group">

                             <asp:TextBox Cssclass="form-control" placeholder="ID" ID="TextBox3" runat="server"></asp:TextBox>
                             <asp:Button ID="Button2" class="btn btn-secondary btn-sm" runat="server" Text="GO" OnClick="Button2_Click" />
                         </div>
                         </div>
                     </div>

                     <div class="col-md-8">

                         <label>Author Name</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="Author Name" ID="TextBox4" runat="server"></asp:TextBox>
                         </div>
                     </div>

                  </div>
                       
                   <div class="row">
                     <div class="col-md-4">                       
                          <div class="form-group">
                              <asp:Button ID="Button1" runat="server" Text="Add" class="btn btn-success btn-block btn-sm" OnClick="Button1_Click" />
   
                         </div>
                     </div>

                        <div class="col-md-4">                       
                          <div class="form-group">
                              <asp:Button ID="Button3" runat="server" Text="Update" class="btn btn-primary btn-block btn-sm" OnClick="Button3_Click" />
   
                         </div>
                     </div>



                        <div class="col-md-4">                       
                          <div class="form-group">
                              <asp:Button ID="Button4" runat="server" Text="Delete" class="btn btn-danger btn-block btn-sm" OnClick="Button4_Click"  />
                         </div>
                             
                     </div>


                  </div>

                    </div>   
                    
                    </div>
                      <a href="Home.aspx"><< Back to Home</a> <br><br>

                 
            </div>



            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                     <div class="col">
                        <center>
                           <h3>Author List</h3>
                        </center>
                     </div>
                  </div>                        

                         <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                         <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1" 
                             >
                             <Columns>
                                 <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                 <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
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
