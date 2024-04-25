<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="New_Projekt.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
      <script type="text/javascript">
          $(document).ready(function () {
              $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
          });

          function readURL(input) {
              if (input.files && input.files[0]) {
                  var reader = new FileReader();

                  reader.onload = function (e) {
                      $('#imgview').attr('src', e.target.result);
                  };

                  reader.readAsDataURL(input.files[0]);
              }
          }

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
                            <img width="80px" src="imgs/generaluser.png" />
                        </center>
                     </div>
                  </div>

                        <div class="row">
                     <div class="col">
                        <center>
                           <h3>Profile</h3>
                        </center>
                     </div>
                  </div>


                         <div class="row">
                     <div class="col">
                        <center>
                          <span>Accounnt Status</span>
                            <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Your status"></asp:Label>
                           

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

                          <label>Full Name</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="Full Name" ID="TextBox3" runat="server"></asp:TextBox>
                         </div>

                     </div>

                     <div class="col-md-6">

                         <label>Date of Birth</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control"  ID="TextBox4" runat="server" TextMode="Date"></asp:TextBox>

                         </div>
                     </div>

                  </div>

                         <div class="row">
                     <div class="col-md-6">

                          <label>Contact Number</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="+44" ID="TextBox1" runat="server" TextMode="Phone"></asp:TextBox>
                         </div>

                     </div>

                     <div class="col-md-6">

                         <label>Email</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control"  placeholder="Email" ID="TextBox2" runat="server" TextMode="Email"></asp:TextBox>

                         </div>
                     </div>

                  </div>


                     <div class="row">
                     <div class="col-md-4">

                          <label>State</label>
                         <div class="form-group">
                             <asp:DropDownList ID="DropDownList1" Cssclass="form-control"   runat="server">
                                                               <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Berlin" Value="Berlin" />
                              <asp:ListItem Text="Bayern (Bavaria)" Value="Bayern" />
                              <asp:ListItem Text="Niedersachsen (Lower Saxony)" Value="Niedersachsen" />
                              <asp:ListItem Text="Baden-Württemberg" Value="Baden-Württemberg" />
                              <asp:ListItem Text="Rheinland-Pfalz (Rhineland-Palatinate)" Value="Rheinland-Pfalz" />
                              <asp:ListItem Text="Sachsen (Saxony)" Value="Sachsen" />
                              <asp:ListItem Text="Thüringen (Thuringia)" Value="Thüringen" />
                              <asp:ListItem Text="Hessen" Value="Hessen" />
                              <asp:ListItem Text="Nordrhein-Westfalen (North Rhine-Westphalia)" Value="Nordrhein-Westfalen" />
                              <asp:ListItem Text="Sachsen-Anhalt (Saxony-Anhalt)" Value="Sachsen-Anhalt " />
                              <asp:ListItem Text="Brandenburg" Value="Brandenburg" />
                              <asp:ListItem Text="Mecklenburg-Vorpommern" Value="Mecklenburg-Vorpommern" />
                              <asp:ListItem Text="Hamburg" Value="Hamburg" />
                              <asp:ListItem Text="Schleswig-Holstein" Value="Saarland" />
                              <asp:ListItem Text="Saarland" Value="Madhya Pradesh" />
                              <asp:ListItem Text="Bremen" Value="Bremen" />                              
                             </asp:DropDownList>
                         </div>

                     </div>

                     <div class="col-md-4">

                         <label>City</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="City"  ID="TextBox6" runat="server"></asp:TextBox>

                         </div>
                     </div>

                         <div class="col-md-4">

                         <label>Pin Code</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="Pin Code" ID="TextBox7" runat="server" TextMode="Number"></asp:TextBox>

                         </div>
                     </div>

                  </div>
                   
                      <div class="row">
                     <div class="col">

                          <label>Full Adresse</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="Full Adresse" ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox>
                         </div>

                     </div>
                          </div>

                        <div class="row">
                     <div class="col">
                        <center>
                            <h4> <span class="badge badge-pill badge-info">Login Credentials</span> </h4>
                          
                        </center>
                     </div>
                  </div>



                        <div class="row">
                     <div class="col-md-4">

                          <label>User ID</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="User ID" ID="TextBox8" runat="server" ReadOnly="True"></asp:TextBox>
                         </div>

                     </div>

                     <div class="col-md-4">

                         <label>Old Password</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="Password" ID="TextBox9" runat="server" ReadOnly="True"></asp:TextBox>

                         </div>
                     </div>


                             <div class="col-md-4">

                          <label>New Password</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="New Password" ID="TextBox19" runat="server" ReadOnly="False"></asp:TextBox>
                         </div>

                     </div>

                  </div>

                    





                   <div class="row">
                     <div class="col">                       
                          <div class="form-group">
                              <asp:Button ID="Button1" runat="server" Text="Update" class="btn btn-primary btn-block btn-lg" OnClick="Button1_Click" />
   
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
                           <h3>Your Issued Books</h3>
                        </center>
                     </div>
                  </div>
                     
                          <div class="row">
                            <div class="col">
                        <center>                  
                           <span class="badge badge-pill badge-info">Your Book Info</span>
                        </center>
                     </div>
                            </div>
                  </div>

                         <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                         <div class="row">
                     <div class="col">
                         <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered"  OnRowDataBound="GridView1_RowDataBound"  >
                         </asp:GridView>
                     </div>
                  </div>
                          
                    </div>
              
                    </div>
                 

            </div>

        </div>



</asp:Content>
