<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_Inventory.aspx.cs" Inherits="WebApplication5.View.User.Add_Inventory" %>

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
        <div>
            <h2>ADD INVENTORY</h2>
            <table>

                <tr>
                    <td>
                        <h5>Inventory ID</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="InventoryID" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h5>Supplier Name</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="SName" runat="server"></asp:TextBox></td>
                </tr>



                <tr>
                    <td>
                        <h5>Product Name</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="PName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>

                    <td>
                        <h5>Product No</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="PNo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <h5>Sale Price</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="Sale_Price" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h5>Quantity</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="Quantity" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h5>Discount</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="Discount" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h5>Total Price</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="Total_Price" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h5>Expire_Date</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="Expire_Date" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Savebtn" runat="server" Text="Save" class="text-danger" OnClick="Savebtn_Click" />
                        <asp:Button ID="Viewbtn" runat="server" Text="View" OnClick="Viewbtn_Click" />
                        <asp:Button ID="Updatebtn" runat="server" Text="Update" OnClick="Updatebtn_Click" />
                    </td>
                </tr>
            </table>

            <div class="section">
                <asp:GridView ID="GridViewinventory" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewinventory_RowCommand">
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
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="EditBtn" runat="server" CommandName="EditRecord" CommandArgument='<%# Eval("InventoryID") %>' Text="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>







