using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.View.User
{
    public partial class View_Products : System.Web.UI.Page
    {
        Products.ProductSoapClient obj = new Products.ProductSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {



            try
            {


                Products.ProductSoapClient obj = new Products.ProductSoapClient();
                DataTable productTable = obj.ViewAllProducts();


                GridViewStock.DataSource = productTable;
                GridViewStock.DataBind();
            }
            catch (Exception ex)
            {


            }
        }
    }

}