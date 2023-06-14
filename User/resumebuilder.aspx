<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="resumebuilder.aspx.cs" Inherits="WebApplicationChanges.User.resumebuilder" %>
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
                        <h2 class="contact-title text-center">Build Resume</h2>
                    </div>
                    <div class="col-lg-12 ">
                        <div class="form-contact contact_form" >
                            <div class="row">
                                  <div class="col-12">
                                      <h6>Personal Information</h6>
                                      </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Full Name</label>
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter your Full Name" required></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name must be in characters!"  ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtFullName">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Username</label>
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter Unique Username" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Address</label>
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter your Address" TextMode="MultiLine" required ></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Mobile Number</label>
                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter your Mobile Number" required></asp:TextBox>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Number must have 10 digits!"  ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtMobile" ValidationGroup="RegistrationValidation">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Email</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter your Email" required TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                               <div class="col-12 pt-4">
                                      <h6>Academic Information</h6>
                                      </div>
                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>10th Percentage/Grade</label>
                                        <asp:TextBox ID="txtTenth" runat="server" CssClass="form-control" placeholder="Ex: 90%"  ></asp:TextBox>
                                    </div>
                                </div>

                                
                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>12th Percentage/Grade</label>
                                        <asp:TextBox ID="txtTwelfth" runat="server" CssClass="form-control" placeholder="Ex: 90%" ></asp:TextBox>
                                    </div>
                                </div>

                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Graduation Pointer/Grade</label>
                                        <asp:TextBox ID="txtGraduation" runat="server" CssClass="form-control" placeholder="Ex: Bsc Comp Science with 9.3 pointer"  ></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Post Graduation Pointer/Grade</label>
                                        <asp:TextBox ID="txtPostGraduation" runat="server" CssClass="form-control" placeholder="Ex: Msc Comp Science with 9.3 pointer"  ></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Phd Grade</label>
                                        <asp:TextBox ID="txtPhd" runat="server" CssClass="form-control" placeholder="Phd grade"  ></asp:TextBox>
                                    </div>
                                </div>
                                  <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Job Profile/Work On</label>
                                        <asp:TextBox ID="txtWork" runat="server" CssClass="form-control" placeholder="Current Job Profile" ></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Work Experience</label>
                                        <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control" placeholder="Previous Work Experience"  ></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Resume</label>
                                        <asp:FileUpload ID="fuResume" runat="server" CssClass="form-control pt-2" ToolTip=".doc,.docx,.pdf ectension only"/>
                                    </div>
                                </div>
                                
                            <div class="form-group mt-3">
                              
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button button-contactForm boxed-btn mr-4" OnClick="btnUpdate_Click" CausesValidation="true" ValidationGroup="UpdateValidation" />
                                
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

        </div>
    </section>
</asp:Content>
