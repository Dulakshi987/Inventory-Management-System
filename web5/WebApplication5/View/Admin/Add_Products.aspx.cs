using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.View.Admin
{
    public partial class Add_Products : System.Web.UI.Page
    {
        Products.ProductSoapClient obj = new Products.ProductSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(ProductID.Text);
                string pName = PName.Text;
                int pNo = int.Parse(PNo.Text);
                string catagory = Catagory.Text;
                int pPrice = int.Parse(PPrice.Text);
                int sPrice = int.Parse(SPrice.Text);
                int inventory = int.Parse(Inventory.Text);


                bool result = obj.AddProduct(productId, pName, pNo, catagory, pPrice, sPrice, inventory);

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


                Products.ProductSoapClient obj = new Products.ProductSoapClient();
                DataTable productTable = obj.ViewAllProducts();


                GridViewStock.DataSource = productTable;
                GridViewStock.DataBind();
            }
            catch (Exception ex)
            {


            }
        }


        // Event handler for GridView row commands (only Edit is handled)
        protected void GridViewStock_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                // Check if the command name is "EditRecord"
                if (e.CommandName == "EditRecord")
                {
                    // Retrieve the ProductID from the CommandArgument
                    int productId = Convert.ToInt32(e.CommandArgument);

                    // Fetch product details from the web service
                    Products.ProductSoapClient client = new Products.ProductSoapClient();
                    DataTable productsTable = client.ViewAllProducts();

                    // Find the product with the given ProductID
                    DataRow[] rows = productsTable.Select("ProductID = " + productId);

                    if (rows.Length > 0)
                    {
                        DataRow row = rows[0];

                        // Populate the form fields with product data
                        ProductID.Text = row["ProductID"].ToString();
                        PName.Text = row["PName"].ToString();
                        PNo.Text = row["PNo"].ToString();
                        Catagory.Text = row["Catagory"].ToString();
                        PPrice.Text = row["PPrice"].ToString();
                        SPrice.Text = row["SPrice"].ToString();
                        Inventory.Text = row["Inventory"].ToString();

                        // Show the Update button and hide the Save button
                        Savebtn.Visible = false;
                        Updatebtn.Visible = true;
                    }
                    else
                    {
                        // Show error if product not found
                        Response.Write("<script>alert('Product not found');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }


        protected void Updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of the web service client
                Products.ProductSoapClient client = new Products.ProductSoapClient();

                // Retrieve data from textboxes
                int productId = int.Parse(ProductID.Text.Trim());
                string pName = PName.Text.Trim();
                int pNo = int.Parse(PNo.Text.Trim());
                string category = Catagory.Text.Trim();
                int pPrice = int.Parse(PPrice.Text.Trim());
                int sPrice = int.Parse(SPrice.Text.Trim());
                int inventory = int.Parse(Inventory.Text.Trim());

                // Call the UpdateProduct method
                bool result = client.UpdateProduct(productId, pName, pNo, category, pPrice, sPrice, inventory);

                if (result)
                {
                    // Display success message
                    Response.Write("<script>alert('Product updated successfully');</script>");

                    // Clear textboxes
                    ClearTextBoxes();

                    // Refresh the GridView
                    Viewbtn_Click(null, null);
                }
                else
                {
                    // Display failure message
                    Response.Write("<script>alert('Failed to update product');</script>");
                }
            }
            catch (Exception ex)
            {
                // Display error message
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }


        private void ClearTextBoxes()
        {
            // Clear all the input fields
            ProductID.Text = "";
            PName.Text = "";
            PNo.Text = "";
            Catagory.Text = "";
            PPrice.Text = "";
            SPrice.Text = "";
            Inventory.Text = "";

            // Reset the Save/Update button visibility
            Savebtn.Visible = true;  // Show Save button again
            Updatebtn.Visible = false;  // Hide Update button
        }

        protected void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {

                int productId = int.Parse(ProductID.Text);


                bool result = obj.DeleteProduct(productId);

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
    }
}
