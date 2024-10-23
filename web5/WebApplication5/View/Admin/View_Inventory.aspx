<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_Inventory.aspx.cs" Inherits="WebApplication5.View.Admin.View_Inventory" %>

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
                    <a class="nav-link" href="Add_Products.aspx">Products</a>
                </li>


                <li class="nav-item">
                    <a class="nav-link" href="View_Inventory.aspx">Inventory</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="Add_Order.aspx">Order</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="Add_Quotation.aspx">Quatation</a>
                </li>


                <li class="nav-item">
                    <a class="nav-link" href="View_Quotationstatus.aspx">Quotation status</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="../Login.aspx">logout</a>
                </li>
            </ul>

        </div>
    </nav>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewinventory" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="InventoryID" HeaderText="InventoryID" />
                    <asp:BoundField DataField="SName" HeaderText="Supplier Name" />
                    <asp:BoundField DataField="PName" HeaderText="Product Name" />
                    <asp:BoundField DataField="PNo" HeaderText="Product No" />
                    <asp:BoundField DataField="Sale_Price" HeaderText="Sale Price" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Discount" HeaderText="Discount" />
                    <asp:BoundField DataField="Total_Price" HeaderText="Total Price" />
                    <asp:BoundField DataField="Expire_Date" HeaderText="Expire_Date" />

                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
