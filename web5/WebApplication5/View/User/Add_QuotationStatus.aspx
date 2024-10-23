<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_QuotationStatus.aspx.cs" Inherits="WebApplication5.View.User.Add_QuotationStatus" %>

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
        <div>
            <h2>ADD STATUS</h2>
            <table>

                <tr>
                    <td>
                        <h5>Status ID</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="StatusID" runat="server"></asp:TextBox></td>
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
                        <h5>Total</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="Total" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <h5>Status</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="Status" runat="server"></asp:TextBox></td>
                </tr>


                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Savebtn" runat="server" Text="confirm" OnClick="Savebtn_Click" />
                        <asp:Button ID="Viewbtn" runat="server" Text="View" OnClick="Viewbtn_Click" />
                        <asp:Button ID="Updatebtn" runat="server" Text="Change" OnClick="Updatebtn_Click" />
                    </td>
                </tr>
            </table>

            <br />
            <asp:GridView ID="GridVieworder" runat="server" AutoGenerateColumns="False" OnRowCommand="GridVieworder_RowCommand">
                <Columns>
                    <asp:BoundField DataField="StatusID" HeaderText="StatusID" />
                    <asp:BoundField DataField="SName" HeaderText="Supplier Name" />
                    <asp:BoundField DataField="PName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                    <asp:BoundField DataField="Status" HeaderText=" Status" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="EditBtn" runat="server" CommandName="EditRecord" CommandArgument='<%# Eval("StatusID") %>' Text="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

