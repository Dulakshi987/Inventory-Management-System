using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.View.Admin
{
    public partial class View_QuotationStatus : System.Web.UI.Page
    {
        QStatus.QuotationStatusSoapClient obj = new QStatus.QuotationStatusSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                QStatus.QuotationStatusSoapClient obj = new QStatus.QuotationStatusSoapClient();
                DataTable statusTable = obj.ViewAllQStatus();

                GridVieworder.DataSource = statusTable;
                GridVieworder.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Error retrieving orders: " + ex.Message + "');</script>");
            }
        }
    }
    }
