<%@ Page Title="" Language="C#" MasterPageFile="~/Recruiter/Recruiter.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WebApplicationChanges.Recruiter.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <meta charset="utf-8">
        <meta http-equiv="x-ua-compatible" content="ie=edge">
         
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
    <div class="container pt-5 pb-5">
        <div class="main-body">
            <asp:DataList ID="dlProfile" runat="server" Width="100%" OnItemCommand="dlProfile_ItemCommand">
                <ItemTemplate>
                    <div class="row gutters-sm">
                        <div class="col-md-4 mb-3">
                            <div class="card">
                                <div class="card-body">
                                    <div class="d-flex flex-column align-items-center text-center">
                                        <img src="https://cdn-icons-png.flaticon.com/512/666/666201.png" alt="UserPic" class="rounded-circle" width="150"/>
                                        <div class="mt-3">
                                            <h4 class="text-capitalize"><%#Eval("Name") %></h4>
                                            <p class="text-secondary mb-1">@<%#Eval("Username") %></p>
                                            <p class="text-muted font-size-sm text-capitalize">
                                                
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">Full Name</h6>
                                    </div>
                                    <div class="col-sm-9 text-secondary text-capitalize">
                                        <%#Eval("Name") %>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">Email</h6>
                                    </div>
                                    <div class="col-sm-9 text-secondary text-capitalize">
                                        <%#Eval("Email") %>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">Mobile</h6>
                                    </div>
                                    <div class="col-sm-9 text-secondary text-capitalize">
                                        <%#Eval("Mobile") %>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">Address</h6>
                                    </div>
                                    <div class="col-sm-9 text-secondary text-capitalize">
                                        <%#Eval("Address") %>
                                    </div>
                                </div>
                                <hr />
                               <%-- <div class="row">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">Resume Upload</h6>
                                    </div>
                                    <div class="col-sm-9 text-secondary text-capitalize">
                                        <%#Eval("Resume") == DBNull.Value ? "Not Uploaded" : "Uploaded"  %>
                                    </div>
                                </div>--%>
                             
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit"  CssClass="button button-contactForm boxed-btn" CommandName="EditUserProfile" CommandArgument='<%#Eval("UserId") %>'/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>