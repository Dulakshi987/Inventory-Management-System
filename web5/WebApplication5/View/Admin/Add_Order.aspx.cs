using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.View.Admin
{
    public partial class Add_Order : System.Web.UI.Page
    {
        Order.OrderSoapClient obj = new Order.OrderSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId = int.Parse(OrderID.Text);
                string sName = SName.Text;
                string pName = PName.Text;
                int pNo = int.Parse(PNo.Text);
                int purchase_Price = int.Parse(Purchase_Price.Text);
                int quantity = int.Parse(Quantity.Text);
                string discount = Discount.Text;
                int total_Price = int.Parse(Total_Price.Text);
                string pMethod = PMethod.Text;

               
                bool result = obj.AddOrder(orderId, sName, pName, pNo, purchase_Price, quantity, discount, total_Price, pMethod);

                if (result)
                {
                   
                    Viewbtn_Click(sender, e);
                    Response.Write("<script>alert('Order added successfully');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Failed to add order. Please check the input.');</script>");
                }
            }
            catch (Exception ex)
            {
               
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void Viewbtn_Click(object sender, EventArgs e)
        {
            try
            {
              
                Order.OrderSoapClient obj = new Order.OrderSoapClient();
                DataTable ordersTable = obj.ViewAllOrders();

                GridVieworder.DataSource = ordersTable;
                GridVieworder.DataBind();
            }
            catch (Exception ex)
            {
               
                Response.Write("<script>alert('Error retrieving orders: " + ex.Message + "');</script>");
            }
        }


        protected void GridVieworder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
               
                if (e.CommandName == "EditRecord")
                {
                    int orderId = Convert.ToInt32(e.CommandArgument);

                  
                    Order.OrderSoapClient client = new Order.OrderSoapClient();
                    DataTable ordersTable = client.ViewAllOrders();

                   
                    DataRow[] rows = ordersTable.Select("OrderID = " + orderId);

                    if (rows.Length > 0)
                    {
                        DataRow row = rows[0];

                        
                        OrderID.Text = row["OrderID"].ToString();
                        SName.Text = row["SName"].ToString();
                        PName.Text = row["PName"].ToString();
                        PNo.Text = row["PNo"].ToString();
                        Purchase_Price.Text = row["Purchase_Price"].ToString();
                        Quantity.Text = row["Quantity"].ToString();
                        Discount.Text = row["Discount"].ToString();
                        Total_Price.Text = row["Total_Price"].ToString();
                        PMethod.Text = row["PMethod"].ToString();


                        
                        Savebtn.Visible = false;
                        Updatebtn.Visible = true;
                    }
                    else
                    {
                       
                        Response.Write("<script>alert('Order not found');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
              
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void Updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                Order.OrderSoapClient client = new Order.OrderSoapClient();

            
                int orderId = int.Parse(OrderID.Text.Trim());
                string sName = SName.Text.Trim();
                string pName = PName.Text.Trim();
                int pNo = int.Parse(PNo.Text.Trim());
                int purchase_Price = int.Parse(Purchase_Price.Text.Trim());
                int quantity = int.Parse(Quantity.Text.Trim());
                string discont = Discount.Text.Trim();
                int total_Price = int.Parse(Total_Price.Text.Trim());
                string pMethod = PMethod.Text.Trim();


                
                bool result = client.UpdateOrder(orderId, sName, pName, pNo, purchase_Price, quantity, discont, total_Price, pMethod);

                if (result)
                {
                  
                    Response.Write("<script>alert('Orders updated successfully');</script>");

                  
                    ClearTextBoxes();

                   
                    Viewbtn_Click(null, null);
                }
                else
                {
                   
                    Response.Write("<script>alert('Failed to update order');</script>");
                }
            }
            catch (Exception ex)
            {
                
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        private void ClearTextBoxes()
        {
           
            OrderID.Text = "";
            SName.Text = "";
            PName.Text = "";
            PNo.Text = "";
            Purchase_Price.Text = "";
            Quantity.Text = "";
            Discount.Text = "";
            Total_Price.Text = "";
            PMethod.Text = "";


            Savebtn.Visible = true;  // Show Save button again
            Updatebtn.Visible = false;  // Hide Update button
        }
        protected void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId = int.Parse(OrderID.Text);
                bool result = obj.DeleteOrder(orderId);

                if (result)
                {
                  
                    Viewbtn_Click(sender, e);
                    Response.Write("<script>alert('Order deleted successfully');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Failed to delete order');</script>");
                }
            }
            catch (Exception ex)
            {
               
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

    }
}

