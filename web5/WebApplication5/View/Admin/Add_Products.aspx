<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_Products.aspx.cs" Inherits="WebApplication5.View.Admin.Add_Products" %>

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

            <h3 class="text-center">ADD PRODUCTS</h3>
            <table>

                <tr>
                    <td>
                        <h5>Product Id</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="ProductID" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <h5>Product Name</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="PName" runat="server"></asp:TextBox></td>
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
                        <h5>Catagory</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="Catagory" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h5>Purchace Price</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="PPrice" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h5>Selling Price</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="SPrice" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h5>Available Stock</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="Inventory" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Savebtn" runat="server" Text="Save" class="text-danger" OnClick="Savebtn_Click" />
                        <asp:Button ID="Viewbtn" runat="server" Text="View" OnClick="Viewbtn_Click" />
                        <asp:Button ID="Updatebtn" runat="server" Text="Update" OnClick="Updatebtn_Click" />
                        <asp:Button ID="Deletebtn" runat="server" Text="Delete" OnClick="Deletebtn_Click" />

                    </td>
                </tr>
            </table>
            <div class="section">
                <asp:GridView ID="GridViewStock" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewStock_RowCommand">
                    <Columns>

                        <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                        <asp:BoundField DataField="PName" HeaderText="Product Name" />
                        <asp:BoundField DataField="PNo" HeaderText="Product Number" />
                        <asp:BoundField DataField="Catagory" HeaderText="Category" />
                        <asp:BoundField DataField="PPrice" HeaderText="Product Price" />
                        <asp:BoundField DataField="SPrice" HeaderText="Sale Price" />
                        <asp:BoundField DataField="Inventory" HeaderText="Inventory" />


                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" CommandName="EditRecord" CommandArgument='<%# Eval("ProductID") %>' Text="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>


        </div>
    </form>
</body>
</html>
