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
    /// Summary description for Order
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Order : System.Web.Services.WebService
    {
        SqlConnection SQLCon;

        // Method to get a new connection
        public SqlConnection GetConnection()
        {
            try
            {
                SQLCon = new SqlConnection("data source=DESKTOP-HUV77V6\\SQLEXPRESS;initial catalog=techFix;Integrated Security=True");
                SQLCon.Open();
            }
            catch (Exception ex)
            {
                // Log error for debugging (this will show in the console output of the server)
                Console.WriteLine("Error Connecting to DB: " + ex.Message);
                throw new Exception("Could not connect to the database.");
            }
            return SQLCon;

        }
        [WebMethod]
        public bool AddOrder(int orderId, string sName, string pName, int pNo, int purchase_Price, int quantity, string discount, int total_Price, string pMethod)
        {
            try
            {
                GetConnection();

                // Insert product details into the database
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Orders (OrderID,SName, PName, PNo, Purchase_Price, Quantity, Discount, Total_Price,PMethod) VALUES (@OrderID,@SName, @PName, @PNo, @Purchase_Price, @Quantity, @Discount, @Total_Price, @PMethod)", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@SName", sName);
                    cmd.Parameters.AddWithValue("@PName", pName);
                    cmd.Parameters.AddWithValue("@PNo", pNo);
                    cmd.Parameters.AddWithValue("@Purchase_Price", purchase_Price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@Total_Price", total_Price);
                    cmd.Parameters.AddWithValue("@PMethod", pMethod);


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
                Console.WriteLine("Error adding order: " + ex.Message);
                throw new Exception("Error adding order: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();  // Ensure connection is closed
            }
        }
        [WebMethod]
        public DataTable ViewAllOrders()
        {
            DataTable ordersTable = new DataTable("OrdersTable");

            try
            {
                GetConnection();

                // Select all products
                using (SqlCommand cmd = new SqlCommand("SELECT OrderID,SName, PName, PNo, Purchase_Price, Quantity, Discount, Total_Price, PMethod FROM Orders", SQLCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ordersTable);
                }

                return ordersTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving orders: " + ex.Message);
                throw new Exception("Error retrieving orders: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();  // Ensure connection is closed
            }
        }


        [WebMethod]
        public bool UpdateOrder(int orderId, string sName, string pName, int pNo, int purchase_Price, int quantity, string discount, int total_Price, string pMethod)
        {
            try
            {
                GetConnection();

                using (SqlCommand cmd = new SqlCommand("UPDATE Orders SET SName= @SName, PName=@PName, PNo=@PNo, Purchase_Price=@Purchase_Price, Quantity=@Quantity, Discount=@Discount, Total_Price=@Total_Price, PMethod=@PMethod WHERE OrderID=@OrderID", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@SName", sName);
                    cmd.Parameters.AddWithValue("@PName", pName);
                    cmd.Parameters.AddWithValue("@PNo", pNo);
                    cmd.Parameters.AddWithValue("@Purchase_Price", purchase_Price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@Total_Price", total_Price);
                    cmd.Parameters.AddWithValue("@PMethod", pMethod);


                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating orders: " + ex.Message);
            }
        }

        [WebMethod]
        public bool DeleteOrder(int orderId)
        {
            try
            {
                GetConnection();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE OrderID=@OrderID", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting order: " + ex.Message);
            }
        }


    }
}
