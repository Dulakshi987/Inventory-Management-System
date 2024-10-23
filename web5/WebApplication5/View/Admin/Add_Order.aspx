<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_Order.aspx.cs" Inherits="WebApplication5.View.Admin.Add_Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet"  href="../../Assests/Lib/css/bootstrap.min.css" />
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
            <h2>ADD ORDER</h2>
            <table>

                <tr>
                    <td>
                        <h5>Order ID</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="OrderID" runat="server"></asp:TextBox></td>
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
                        <h5>Purchase Price</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="Purchase_Price" runat="server"></asp:TextBox></td>
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
                        <h5>Payament Method</h5>
                    </td>
                    <td>
                        <asp:TextBox ID="PMethod" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Savebtn" runat="server" Text="Save" OnClick="Savebtn_Click" />
                        <asp:Button ID="Viewbtn" runat="server" Text="View" OnClick="Viewbtn_Click" />
                        <asp:Button ID="Updatebtn" runat="server" Text="Update" OnClick="Updatebtn_Click" />
                        <asp:Button ID="Deletebtn" runat="server" Text="Delete" OnClick="Deletebtn_Click" />
                    </td>
                </tr>
            </table>

            <br />
            <asp:GridView ID="GridVieworder" runat="server" AutoGenerateColumns="False" OnRowCommand="GridVieworder_RowCommand">
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="OrderID" />
                    <asp:BoundField DataField="SName" HeaderText="Supplier Name" />
                    <asp:BoundField DataField="PName" HeaderText="Product Name" />
                    <asp:BoundField DataField="PNo" HeaderText="Product No" />
                    <asp:BoundField DataField="Purchase_Price" HeaderText="Purchase Price" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Discount" HeaderText="Discount" />
                    <asp:BoundField DataField="Total_Price" HeaderText="Total Price" />
                    <asp:BoundField DataField="PMethod" HeaderText="Payment_Method" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="EditBtn" runat="server" CommandName="EditRecord" CommandArgument='<%# Eval("OrderID") %>' Text="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

