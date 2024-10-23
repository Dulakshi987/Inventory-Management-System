using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.View.Admin
{
    public partial class Add_Quotation : System.Web.UI.Page
    {
        Quotations.QuotationSoapClient obj = new Quotations.QuotationSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int quotationId = int.Parse(QuotationID.Text);
                string sName = SName.Text;
                string address = Address.Text;
                string email = Email.Text;
                string pName = PName.Text;
                int stock = int.Parse(Stock.Text);
                string requested_Date = Requested_Date.Text;
                string response_Date = Response_Date.Text;



                bool result = obj.AddQuotation(quotationId, sName, address, email, pName, stock, requested_Date, response_Date);

                if (result)
                {
                    Viewbtn_Click(sender, e);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Viewbtn_Click(object sender, EventArgs e)
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


      
        protected void GridViewQuotation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
               
                if (e.CommandName == "EditRecord")
                {
                   
                    int quotationId = Convert.ToInt32(e.CommandArgument);

                    
                    Quotations.QuotationSoapClient client = new Quotations.QuotationSoapClient();
                    DataTable quotationsTable = client.ViewAllQuotations();

                    
                    DataRow[] rows = quotationsTable.Select("QuotationID = " + quotationId);

                    if (rows.Length > 0)
                    {
                        DataRow row = rows[0];

                      
                        QuotationID.Text = row["QuotationID"].ToString();
                        SName.Text = row["SName"].ToString();
                        Address.Text = row["Address"].ToString();
                        Email.Text = row["Email"].ToString();
                        PName.Text = row["PName"].ToString();
                        Stock.Text = row["Stock"].ToString();
                        Requested_Date.Text = row["Requested_Date"].ToString();
                        Response_Date.Text = row["Response_Date"].ToString();

                      
                        Savebtn.Visible = false;
                        Updatebtn.Visible = true;
                    }
                    else
                    {
                       
                        Response.Write("<script>alert('Quotation not found');</script>");
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
               
                Quotations.QuotationSoapClient client = new Quotations.QuotationSoapClient();

                
                int quotationId = int.Parse(QuotationID.Text.Trim());
                string sName = SName.Text.Trim();
                string address = Address.Text.Trim();
                string email = Email.Text.Trim();
                string pName = PName.Text.Trim();
                int stock = int.Parse(Stock.Text.Trim());
                string requested_Date = Requested_Date.Text.Trim();
                string response_Date = Response_Date.Text.Trim();


               
                bool result = client.UpdateQuotation(quotationId, sName, address, email, pName, stock, requested_Date, response_Date);

                if (result)
                {
                   
                    Response.Write("<script>alert('Quotation updated successfully');</script>");

                   
                    ClearTextBoxes();

                   
                    Viewbtn_Click(null, null);
                }
                else
                {
                 
                    Response.Write("<script>alert('Failed to update quotation');</script>");
                }
            }
            catch (Exception ex)
            {
                
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }


        private void ClearTextBoxes()
        {
          
            QuotationID.Text = "";
            SName.Text = "";
            Address.Text = "";
            Email.Text = "";
            PName.Text = "";
            Stock.Text = "";
            Requested_Date.Text = "";
            Response_Date.Text = "";

            
            Savebtn.Visible = true;  // Show Save button again
            Updatebtn.Visible = false;  // Hide Update button
        }

    }
}