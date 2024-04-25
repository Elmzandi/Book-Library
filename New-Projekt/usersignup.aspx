<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="New_Projekt.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto" >
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
                           <h3>Sign Up</h3>
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

                     </div>l

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
                     <div class="col-md-6">

                          <label>User ID</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="User ID" ID="TextBox8" runat="server"></asp:TextBox>
                         </div>

                     </div>

                     <div class="col-md-6">

                         <label>Password</label>
                         <div class="form-group">
                             <asp:TextBox Cssclass="form-control" placeholder="Password" ID="TextBox9" runat="server" TextMode="Password"></asp:TextBox>

                         </div>
                     </div>

                  </div>



                   <div class="row">
                     <div class="col">                       
                          <div class="form-group">                             
                              <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click"  />
                         </div>

                     </div>
                                  

                  </div>


                    </div>
              
                    </div>
                 
                 <a href="Home.aspx"><< Back to Home</a> <br><br>
            </div>


        </div>
    </div>


</asp:Content>
