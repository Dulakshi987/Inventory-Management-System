<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_QuotationStatus.aspx.cs" Inherits="WebApplication5.View.Admin.View_QuotationStatus" %>

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
            <h2>QUOTATION STATUS</h2>
            <br />
            <asp:GridView ID="GridVieworder" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="StatusID" HeaderText="StatusID" />
                    <asp:BoundField DataField="SName" HeaderText="Supplier Name" />
                    <asp:BoundField DataField="PName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                    <asp:BoundField DataField="Status" HeaderText=" Status" />


                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
