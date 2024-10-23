<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_Quotation.aspx.cs" Inherits="WebApplication5.View.Admin.Add_Quotation" %>

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

            <h3 class="text-center">REQUESTED QUOTATIONS</h3>
            <table>

                <tr>
                    <td>
                        <h4>Quotation ID</h4>
                    </td>
                    <td>
                        <asp:TextBox ID="QuotationID" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h4>Supplier Name</h4>
                    </td>
                    <td>
                        <asp:TextBox ID="SName" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h4>Address</h4>
                    </td>
                    <td>
                        <asp:TextBox ID="Address" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h4>Email</h4>
                    </td>
                    <td>
                        <asp:TextBox ID="Email" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h4>Product Name</h4>
                    </td>
                    <td>
                        <asp:TextBox ID="PName" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h4>Stock</h4>
                    </td>
                    <td>
                        <asp:TextBox ID="Stock" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h4>Requested Date
                        </h4>
                    </td>
                    <td>
                        <asp:TextBox ID="Requested_Date" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>
                        <h4>Response Date </h4>
                    </td>
                    <td>
                        <asp:TextBox ID="Response_Date" runat="server"></asp:TextBox></td>
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

                <asp:GridView ID="GridViewQuotation" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewQuotation_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="QuotationID" HeaderText="QuotationID" />
                        <asp:BoundField DataField="SName" HeaderText="Supplier Name" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="PName" HeaderText="Product Name" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                        <asp:BoundField DataField="Requested_Date" HeaderText="Requested_Date" />
                        <asp:BoundField DataField="Response_Date" HeaderText="Response_Date" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="EditBtn" runat="server" CommandName="EditRecord" CommandArgument='<%# Eval("QuotationID") %>' Text="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

