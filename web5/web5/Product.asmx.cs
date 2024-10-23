using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace web5
{
    /// <summary>
    /// Summary description for Product
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Product : System.Web.Services.WebService
    {
        SqlConnection SQLCon;

     
        public SqlConnection GetConnection()
        {
            try
            {
                SQLCon = new SqlConnection("data source=DESKTOP-HUV77V6\\SQLEXPRESS;initial catalog=techFix;Integrated Security=True");
                SQLCon.Open();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error Connecting to DB: " + ex.Message);
                throw new Exception("Could not connect to the database.");
            }
            return SQLCon;
        }

       
        [WebMethod]
        public bool AddProduct(int productId, string pName, int pNo, string catagory, int pPrice, int sPrice, int inventory)
        {
            try
            {
                GetConnection();

                // Insert product details into the database
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Products (ProductID, PName, PNo, Catagory, PPrice, SPrice, Inventory) VALUES (@ProductID, @PName, @PNo, @Catagory, @PPrice, @SPrice, @Inventory)", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@PName", pName);
                    cmd.Parameters.AddWithValue("@PNo", pNo);
                    cmd.Parameters.AddWithValue("@Catagory", catagory);
                    cmd.Parameters.AddWithValue("@PPrice", pPrice);
                    cmd.Parameters.AddWithValue("@SPrice", sPrice);
                    cmd.Parameters.AddWithValue("@Inventory", inventory);

                    int rowsAffected = cmd.ExecuteNonQuery();  // Returns the number of affected rows
                    if (rowsAffected > 0)
                    {
                        return true;  // Insert succeeded
                    }
                    else
                    {
                        return false; // Insert failed
                    }
                }
            }
            catch (Exception ex)
            {
                // Provide detailed error message
                Console.WriteLine("Error adding product: " + ex.Message);
                throw new Exception("Error adding product: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();  // Ensure connection is closed
            }
        }

        // Method to retrieve all products from the database
        [WebMethod]
        public DataTable ViewAllProducts()
        {
            DataTable productsTable = new DataTable("ProductsTable");

            try
            {
                GetConnection();

                // Select all products
                using (SqlCommand cmd = new SqlCommand("SELECT ProductID, PName, PNo, Catagory, PPrice, SPrice, Inventory FROM Products", SQLCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(productsTable);
                }

                return productsTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving products: " + ex.Message);
                throw new Exception("Error retrieving products: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();  // Ensure connection is closed
            }
        }


        [WebMethod]
        public bool UpdateProduct(int productId, string pName, int pNo, string category, int pPrice, int sPrice, int inventory)
        {
            try
            {
                GetConnection();

                using (SqlCommand cmd = new SqlCommand("UPDATE Products SET PName=@PName, PNo=@PNo, Catagory=@Category, PPrice=@PPrice, SPrice=@SPrice, Inventory=@Inventory WHERE ProductID=@ProductID", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@PName", pName);
                    cmd.Parameters.AddWithValue("@PNo", pNo);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@PPrice", pPrice);
                    cmd.Parameters.AddWithValue("@SPrice", sPrice);
                    cmd.Parameters.AddWithValue("@Inventory", inventory);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product: " + ex.Message);
            }
        }


        // WebMethod to delete a product
        [WebMethod]
        public bool DeleteProduct(int productId)
        {
            try
            {
                GetConnection();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductID=@ProductID", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting product: " + ex.Message);
            }
        }

    }
}

