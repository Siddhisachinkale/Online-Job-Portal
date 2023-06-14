<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplicationChanges.User.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <section>
        <div class="container pt-50 pb-40">
             <div class="row">
                     <div class="col-12 pb-20">
                         <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h2 class="contact-title text-center">Sign Up</h2>
                    </div>
                    <div class="col-lg-6 mx-auto">
                        <div class="form-contact contact_form" >
                            <div class="row">
                                  <div class="col-12">
                                      <h6>Login Information</h6>
                                      </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Username</label>
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter Unique Username" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                           <label>Password</label>
                                        
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password" required></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid password. Please ensure it meets the requirements." ControlToValidate="txtPassword" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!])(?!.*\s).{8,}$" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationGroup="RegistrationValidation"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                         <label>Confirm Password</label>
                                      
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Confirm Password" TextMode="Password" required></asp:TextBox>
<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and Confirm password should be same!" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationGroup="RegistrationValidation"></asp:CompareValidator>
                                    </div>
                                </div>
                                 <div class="col-12">
                                      <h6>Personal Information</h6>
                                      </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Full Name</label>
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter your Full Name" required></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name must be in characters!"  ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtFullName">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                 <div class="col-12">
                                    <div class="form-group">
                                        <label>Address</label>
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter your Address" TextMode="MultiLine" required></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="col-12">
                                    <div class="form-group">
                                        <label>Mobile Number</label>
                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter your Mobile Number" required></asp:TextBox>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Number must have 10 digits!"  ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtMobile" ValidationGroup="RegistrationValidation">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                 <div class="col-12">
                                    <div class="form-group">
                                        <label>Email</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter your Email" required TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                               <%-- <div class="col-12">
                                    <div class="form-group">
                                        <label>Country</label>
                                        
                                        <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-contact w-100"
                                            AppendDateBoundItems="true" DataTextField="CountryName" DataValueField="CountryName">
                                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Country Required"  ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlCountry">

                                        </asp:RequiredFieldValidator>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalMysql %>" SelectCommand="Select [CountryName] from [Country]"></asp:SqlDataSource>
                                    </div>
                                </div>--%>
                           
                            <div class="col-12">
                                    <div class="form-group">
                                         <label>Register Type</label>
                                <asp:DropDownList ID="ddlRegisterType" runat="server" CssClass="form-control w-100">
                                    <asp:ListItem Value="0">Select Register Type</asp:ListItem>
                                    <asp:ListItem>Recruiter</asp:ListItem>
                                    <asp:ListItem>User</asp:ListItem>


                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User is Required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlRegisterType" ValidationGroup="loginValidation">

                                </asp:RequiredFieldValidator>
                                       </div>
                                </div>
                                 </div>
                            <div class="form-group mt-3">
                              
                                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button button-contactForm boxed-btn mr-4" OnClick="btnRegister_Click" CausesValidation="true" ValidationGroup="RegistrationValidation" />
                                <span class="clickLink"><a href="login.aspx">Already Registered?Click Here</a></span>
                            </div>
                            </div>
                      </div>
                    </div>
                 </div>
                 <style>
                     .clickLink a {
                        color: Highlight;
                           font-family:"Barlow",sans-serif;
                           font-weight:500;
                           font-size:15px;
                     }
 .clickLink a:hover{
     color:#fb246a;
 }</style>


</asp:Content>
