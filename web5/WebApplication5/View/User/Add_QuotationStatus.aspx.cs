using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.View.User
{
    public partial class Add_QuotationStatus : System.Web.UI.Page
    {
        QStatus.QuotationStatusSoapClient obj = new QStatus.QuotationStatusSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int statusId = int.Parse(StatusID.Text);
                string sName = SName.Text;
                string pName = PName.Text;
                int total = int.Parse(Total.Text);
                string status = Status.Text;



                bool result = obj.AddQuotationStatus(statusId, sName, pName, total, status);

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


        protected void GridVieworder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditRecord")
                {
                    int statusId = Convert.ToInt32(e.CommandArgument);


                    QStatus.QuotationStatusSoapClient client = new QStatus.QuotationStatusSoapClient();
                    DataTable statusTable = client.ViewAllQStatus();


                    DataRow[] rows = statusTable.Select("StatusID = " + statusId);

                    if (rows.Length > 0)
                    {
                        DataRow row = rows[0];


                        StatusID.Text = row["StatusID"].ToString();
                        SName.Text = row["SName"].ToString();
                        PName.Text = row["PName"].ToString();
                        Total.Text = row["Total"].ToString();
                        Status.Text = row["status"].ToString();




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

                QStatus.QuotationStatusSoapClient client = new QStatus.QuotationStatusSoapClient();


                int statusId = int.Parse(StatusID.Text.Trim());
                string sName = SName.Text.Trim();
                string pName = PName.Text.Trim();
                int total = int.Parse(Total.Text.Trim());
                string status = Status.Text.Trim();



                bool result = client.UpdateQuotationStatus(statusId, sName, pName, total, status);

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

            StatusID.Text = "";
            SName.Text = "";
            PName.Text = "";
            Total.Text = "";
            Status.Text = "";



            Savebtn.Visible = true;  // Show Save button again
            Updatebtn.Visible = false;  // Hide Update button
        }
    }
}