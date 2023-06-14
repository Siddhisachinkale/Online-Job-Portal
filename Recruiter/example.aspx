<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="example.aspx.cs" Inherits="WebApplicationChanges.Recruiter.recruiteredit" %>

<!DOCTYPE html>


<html class="no-js" lang="zxx">
<head runat="server">
    <meta charset="utf-8">
        <meta http-equiv="x-ua-compatible" content="ie=edge">
         <title></title>
        <meta name="description" content="">
        <meta name="viewport" content="width=device-width, initial-scale=1">
<%--        <link rel="manifest" href="site.webmanifest">--%>
		<link rel="shortcut icon" type="image/x-icon" href="../assets/img/favicon.ico">

		<!-- CSS here -->
            <link rel="stylesheet" href="../assets/css/bootstrap.min.css">
            <link rel="stylesheet" href="../assets/css/owl.carousel.min.css">
            <link rel="stylesheet" href="../assets/css/flaticon.css">
            <link rel="stylesheet" href="../assets/css/price_rangs.css">
            <link rel="stylesheet" href="../assets/css/slicknav.css">
            <link rel="stylesheet" href="../assets/css/animate.min.css">
            <link rel="stylesheet" href="../assets/css/magnific-popup.css">
            <link rel="stylesheet" href="../assets/css/fontawesome-all.min.css">
            <link rel="stylesheet" href="../assets/css/themify-icons.css">
            <link rel="stylesheet" href="../assets/css/slick.css">
            <link rel="stylesheet" href="../assets/css/nice-select.css">
            <link rel="stylesheet" href="../assets/css/style.css">

</head>

<body>
    <form id="form1" runat="server">
        <div>
            <section>
        <div class="container pt-50 pb-40">
             <div class="row">
                     <div class="col-12 pb-20">
                         <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h2 class="contact-title text-center">Edit Profile</h2>
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
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter your Address" TextMode="MultiLine" required></asp:TextBox>
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
                              <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Qualifications</label>
                                        <asp:TextBox ID="txtQualifications" runat="server" CssClass="form-control" placeholder="Enter your Qualification" required ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Current Position</label>
                                        <asp:TextBox ID="txtPost" runat="server" CssClass="form-control" placeholder="Enter your Current post" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Company Name</label>
                                        <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" placeholder="Enter your Company name" required ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Work experience</label>
                                        <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control" placeholder="Enter your Work experience" required ></asp:TextBox>
                                    </div>
                                </div>
                           
                            </div>
                             <div class="form-group mt-3">
                              
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button button-contactForm boxed-btn mr-4" OnClick="btnUpdate_Click" CausesValidation="true" ValidationGroup="UpdateValidation" />
                                
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
        </div>
    </form>
</body>
</html>
