<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplicationChanges.User.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container pt-50 pb-40"></div>
        <div class="row">
            <div class="col-12 pb-20">
                <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="col-12">
                <h2 class="contact-title text-center">Sign In</h2>
            </div>
            <div class="col-lg-6 mx-auto">
                <div class="form-contact contact_form">
                    <div class="row">

                        <div class="col-12">
                            <div class="form-group">
                                <label>Username</label>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter Username" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password" required></asp:TextBox>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid password. Please ensure it meets the requirements." ControlToValidate="txtPassword" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!])(?!.*\s).{8,}$" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationGroup="RegistrationValidation"></asp:RegularExpressionValidator>--%>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Login Type</label>
                                <asp:DropDownList ID="ddlLoginType" runat="server" CssClass="form-control w-100">
                                    <asp:ListItem Value="0">Select Login Type</asp:ListItem>
                                    <asp:ListItem>Recruiter</asp:ListItem>
                                    <asp:ListItem>User</asp:ListItem>
                                    <asp:ListItem>Admin</asp:ListItem>


                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User is Required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlLoginType" ValidationGroup="loginValidation">

                                </asp:RequiredFieldValidator>

                            </div>

                        </div>
                    </div>

                    <div class="form-group mt-3">

                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button button-contactForm boxed-btn mr-4" OnClick="btnLogin_Click" CausesValidation="true" ValidationGroup="loginValidation" />
                        <span class="clickLink"><a href="register.aspx">New User ? Click Here</a></span>


                    </div>

                </div>
            </div>
        </div>
        <style>
            .clickLink a {
                color: Highlight;
                font-family: "Barlow",sans-serif;
                font-weight: 500;
                font-size: 15px;
            }

                .clickLink a:hover {
                    color: #fb246a;
                }
        </style>
        


    </section>
</asp:Content>
