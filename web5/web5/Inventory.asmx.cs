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
    /// Summary description for Inventory
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Inventory : System.Web.Services.WebService
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
               
                Console.WriteLine("Error Connecting to DB: " + ex.Message);
                throw new Exception("Could not connect to the database.");
            }
            return SQLCon;
        }

       
        [WebMethod]
        public bool AddInventory(int inventoryId, string sName, string pName, int pNo, int sale_Price, int quantity,string discount, int total_Price,string expire_Date)
        {
            try
            {
                GetConnection();

               
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Stocks (InventoryID, SName,PName, PNo, Sale_Price, Quantity, Discount,Total_Price, Expire_Date) VALUES (@InventoryID, @SName,@PName, @PNo, @Sale_Price, @Quantity, @Discount, @Tota_Price,@Expire_Date)", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                    cmd.Parameters.AddWithValue("@PName", pName);
                    cmd.Parameters.AddWithValue("@SName", sName);
                    cmd.Parameters.AddWithValue("@PNo", pNo);
                    cmd.Parameters.AddWithValue("@Sale_Price", sale_Price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@Total_Price", total_Price);
                    cmd.Parameters.AddWithValue("@Expire_Date", expire_Date);


                    int rowsAffected = cmd.ExecuteNonQuery();  // Returns the number of affected rows
                    if (rowsAffected > 0)
                    {
                        return true;  
                    }
                    else
                    {
                        return false; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding inventory: " + ex.Message);
                throw new Exception("Error adding inventory: " + ex.Message);
            }
            finally
            {
                SQLCon.Close(); 
            }
        }

       
        [WebMethod]
        public DataTable ViewAllInventories()
        {
            DataTable stocksTable = new DataTable("StocksTable");

            try
            {
                GetConnection();

               
                using (SqlCommand cmd = new SqlCommand("SELECT InventoryID, SName,PName, PNo, Sale_Price, Quantity, Discount, Total_Price,Expire_Date FROM Stocks", SQLCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(stocksTable);
                }

                return stocksTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving inventory: " + ex.Message);
                throw new Exception("Error retrieving inventory: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();  // Ensure connection is closed
            }
        }


        [WebMethod]
        public bool UpdateInventory(int inventoryId, string sName, string pName, int pNo, int sale_Price, int quantity, string discount, int total_price,string expire_Date)
        {
            try
            {
                GetConnection();

                using (SqlCommand cmd = new SqlCommand("UPDATE Stocks SET SName=@SName,PName=@PName, PNo=@PNo, Sale_Price=@Sale_Price, Quantity=@Quantity, Discount=@Discount, Total_Price=@Total_Price,Expire_Date=@Expire_Date WHERE InventoryID=@InventoryID", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                    cmd.Parameters.AddWithValue("@SName", sName);
                    cmd.Parameters.AddWithValue("@PName", pName);
                    cmd.Parameters.AddWithValue("@PNo", pNo);
                    cmd.Parameters.AddWithValue("@Sale_Price", sale_Price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@Total_Price", total_price);
                    cmd.Parameters.AddWithValue("@Expire_Date", expire_Date);


                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating inventory: " + ex.Message);
            }
        }


       

    }
}


