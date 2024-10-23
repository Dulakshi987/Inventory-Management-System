<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebApplication5.View.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Assests/Lib/css/bootstrap.min.css" />
</head>
<body>
       <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row" style="height:150%"></div>
            <div class="row">
                <div class="col-md-2"> </div>
                <div class="col-md-4">
                    <h1>TECHFIX COMPUTER SHOP</h1>
                    <img src="../Assests/Images/shop.jpeg" class="img-fluid" />
                </div>
                <div class="col-md-4">
                    <h2 class="text-danger">Sign up</h2>

                    <!-- Name Field -->
                    <div class="mb-3">
                        <label for="Name" class="form-label">Name</label>
                        <asp:TextBox ID="Name" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- Email Field -->
                    <div class="mb-3">
                        <label for="Email" class="form-label">Email</label>
                        <asp:TextBox ID="Email" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- Password Field -->
                    <div class="mb-3">
                        <label for="Password" class="form-label">Password</label>
                        <asp:TextBox ID="Password" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <!-- User Role Radio Buttons -->
                    <div class="mb-3 form-check">
                        <asp:RadioButton ID="UserRadio" GroupName="RoleGroup"  runat="server" CssClass="form-check-input" />
                        <label for="UserRadio" class="form-check-label">User</label>
                    </div>

                    <div class="mb-3 form-check">
                        <asp:RadioButton ID="AdminRadio" GroupName="RoleGroup"  runat="server" CssClass="form-check-input" />
                        <label for="AdminRadio" class="form-check-label">Admin</label>
                    </div>

                    <!-- Error Message Label -->
                    <div class="mb-3">
                        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                    </div>

                    <!-- Submit Button -->
                    <div class="mb-3 d-grid">
                        <asp:Button ID="SignUpButton" Text="Sign Up" CssClass="btn btn-danger btn-block" OnClick="SignUpButton_Click" runat="server" />
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
