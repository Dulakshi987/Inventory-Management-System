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
    /// Summary description for QuotationStatus
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class QuotationStatus : System.Web.Services.WebService
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

        // Method to add a product to the database
        [WebMethod]
        public bool AddQuotationStatus(int statusId, string sName,  string pName, int total, string status)
        {
            try
            {
                GetConnection();

                // Insert product details into the database
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Status (StatusID, SName, PName, Total, Status) VALUES (@StatusID, @SName, @PName, @Total, @Status)", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@StatusID", statusId);
                    cmd.Parameters.AddWithValue("@SName", sName);
                    cmd.Parameters.AddWithValue("@PName", pName);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@Status", status);
                   

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
        public DataTable ViewAllQStatus()
        {
            DataTable statusTable = new DataTable("StatusTable");

            try
            {
                GetConnection();

                // Select all products
                using (SqlCommand cmd = new SqlCommand("SELECT StatusID, SName, PName, Total, Status FROM Status", SQLCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(statusTable);
                }

                return statusTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving Status: " + ex.Message);
                throw new Exception("Error retrieving status: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();  // Ensure connection is closed
            }
        }


        [WebMethod]
        public bool UpdateQuotationStatus(int statusId, string sName, string pName, int total, string status)
        {
            try
            {
                GetConnection();

                using (SqlCommand cmd = new SqlCommand("UPDATE Status SET SName=@SName, PName=@PName, Total=@Total, Status=@Status WHERE StatusID=@StatusID", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@StatusID",statusId);
                    cmd.Parameters.AddWithValue("@SName", sName);
                    cmd.Parameters.AddWithValue("@PName", pName);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@Status", status);
                    

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product: " + ex.Message);
            }
        }


        

    }
}


