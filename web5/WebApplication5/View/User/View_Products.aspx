<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_Products.aspx.cs" Inherits="WebApplication5.View.User.View_Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../Assests/Lib/css/bootstrap.min.css" />
</head>
<body>

    <nav class="navbar navbar-expand-lg navbar-danger bg-danger text-light">
        <a class="navbar-brand" href="#">TECHFIX COMPUTER SHOP</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">



                <li class="nav-item">
                    <a class="nav-link" href="View_Products.aspx">Stock</a>
                </li>


                <li class="nav-item">
                    <a class="nav-link" href="View_Order.aspx">Order</a>
                </li>



                <li class="nav-item">
                    <a class="nav-link" href="View_Quotation.aspx">Quatation</a>
                </li>


                <li class="nav-item">
                    <a class="nav-link" href="Add_Quotationstatus.aspx">Quotation status</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="../Login.aspx">logout</a>
                </li>
            </ul>

        </div>
    </nav>
    <form id="form1" runat="server">
        <div class="section">
            <br />
            <h2>VIEW PRODUCTS</h2>
            <asp:GridView ID="GridViewStock" runat="server" AutoGenerateColumns="False">

                <Columns>

                    <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                    <asp:BoundField DataField="PName" HeaderText="Product Name" />
                    <asp:BoundField DataField="PNo" HeaderText="Product No" />
                    <asp:BoundField DataField="Catagory" HeaderText="Catagory" />
                    <asp:BoundField DataField="PPrice" HeaderText="Purchase Price" />
                    <asp:BoundField DataField="SPrice" HeaderText="Selling Price" />
                    <asp:BoundField DataField="Inventory" HeaderText="Stock" />



                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
