using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.View.User
{
    public partial class Add_Inventory : System.Web.UI.Page
    {
        Inventory.InventorySoapClient obj = new Inventory.InventorySoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int inventoryId = int.Parse(InventoryID.Text);
                string sName = SName.Text;
                string pName = PName.Text;
                int pNo = int.Parse(PNo.Text);
                int sale_Price = int.Parse(Sale_Price.Text);
                int quantity = int.Parse(Quantity.Text);
                string discount = Discount.Text;
                int total_Price = int.Parse(Total_Price.Text);
                string expire_Date = Expire_Date.Text;


                bool result = obj.AddInventory(inventoryId, sName, pName, pNo, sale_Price, quantity, discount, total_Price, expire_Date);

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

                Inventory.InventorySoapClient obj = new Inventory.InventorySoapClient();
                DataTable stockTable = obj.ViewAllInventories();

                GridViewinventory.DataSource = stockTable;
                GridViewinventory.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Error retrieving inventories: " + ex.Message + "');</script>");
            }
        }


        protected void GridViewinventory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditRecord")
                {
                    int inventoryId = Convert.ToInt32(e.CommandArgument);


                    Inventory.InventorySoapClient client = new Inventory.InventorySoapClient();
                    DataTable stocksTable = client.ViewAllInventories();


                    DataRow[] rows = stocksTable.Select("InventoryID = " + inventoryId);

                    if (rows.Length > 0)
                    {
                        DataRow row = rows[0];


                        InventoryID.Text = row["InventoryID"].ToString();
                        SName.Text = row["SName"].ToString();
                        PName.Text = row["PName"].ToString();
                        PNo.Text = row["PNo"].ToString();
                        Sale_Price.Text = row["Sale_Price"].ToString();
                        Quantity.Text = row["Quantity"].ToString();
                        Discount.Text = row["Discount"].ToString();
                        Total_Price.Text = row["Total_Price"].ToString();
                        Expire_Date.Text = row["Expire_Date"].ToString();



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

                Inventory.InventorySoapClient client = new Inventory.InventorySoapClient();


                int inventoryId = int.Parse(InventoryID.Text.Trim());
                string sName = SName.Text.Trim();
                string pName = PName.Text.Trim();
                int pNo = int.Parse(PNo.Text.Trim());
                int sale_Price = int.Parse(Sale_Price.Text.Trim());
                int quantity = int.Parse(Quantity.Text.Trim());
                string discont = Discount.Text.Trim();
                int total_Price = int.Parse(Total_Price.Text.Trim());
                string expire_Date = Expire_Date.Text.Trim();



                bool result = client.UpdateInventory(inventoryId, sName, pName, pNo, sale_Price, quantity, discont, total_Price, expire_Date);

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

            InventoryID.Text = "";
            SName.Text = "";
            PName.Text = "";
            PNo.Text = "";
            Sale_Price.Text = "";
            Quantity.Text = "";
            Discount.Text = "";
            Total_Price.Text = "";
            Expire_Date.Text = "";


            Savebtn.Visible = true;  // Show Save button again
            Updatebtn.Visible = false;  // Hide Update button
        }


    }
}