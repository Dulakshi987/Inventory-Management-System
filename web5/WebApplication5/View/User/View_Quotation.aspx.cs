using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.View.User
{
    public partial class View_Quotation : System.Web.UI.Page
    {
        Quotations.QuotationSoapClient obj = new Quotations.QuotationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {


                Quotations.QuotationSoapClient obj = new Quotations.QuotationSoapClient();
                DataTable quotationsTable = obj.ViewAllQuotations();


                GridViewQuotation.DataSource = quotationsTable;
                GridViewQuotation.DataBind();
            }
            catch (Exception ex)
            {


            }
        }

    }

}
