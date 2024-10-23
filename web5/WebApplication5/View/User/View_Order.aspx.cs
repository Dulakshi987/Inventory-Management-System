using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.View.User
{
    public partial class View_Order : System.Web.UI.Page
    {
        Order.OrderSoapClient obj = new Order.OrderSoapClient();

        protected void Page_Load(object sender, EventArgs e)
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

    }
    }
