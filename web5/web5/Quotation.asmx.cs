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
    /// Summary description for Quotation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Quotation : System.Web.Services.WebService
    {
        SqlConnection SQLCon;

        // Method to get a new connection
        public SqlConnection GetConnection()
        {
            try
            {
                SQLCon = new SqlConnection("data source=DESKTOP-HUV77V6\\SQLEXPRESS;initial catalog=techFix; Integrated Security=True");
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
        public bool AddQuotation(int quotationId, string sName, string address, string email, string pName, int stock, string requested_Date, string response_Date)
        {
            try
            {
                GetConnection();

                // Insert product details into the database
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Quotations (QuotationID, SName, Address, Email, PName, Stock, Requested_Date, Response_Date) VALUES (@QuotationID, @SName, @Address, @Email, @PName,@Stock, @Requested_Date, @Response_Date)", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@QuotationID", quotationId);
                    cmd.Parameters.AddWithValue("@SName", sName);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PName", pName);
                    cmd.Parameters.AddWithValue("@Stock", stock);
                    cmd.Parameters.AddWithValue("@Requested_Date", requested_Date);
                    cmd.Parameters.AddWithValue("@Response_Date", response_Date);



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
                Console.WriteLine("Error adding quotation: " + ex.Message);
                throw new Exception("Error adding quotation: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();  // Ensure connection is closed
            }
        }


       
        [WebMethod]
        public DataTable ViewAllQuotations()
        {
            DataTable quotationsTable = new DataTable("QuotationsTable");

            try
            {
                GetConnection();

                // Select all products
                using (SqlCommand cmd = new SqlCommand("SELECT QuotationID, SName, Address, Email, PName, Stock, Requested_Date, Response_Date FROM Quotations", SQLCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(quotationsTable);
                }

                return quotationsTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving  quotations: " + ex.Message);
                throw new Exception("Error retrieving quotations: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();  // Ensure connection is closed
            }

        }

        [WebMethod]
        public bool UpdateQuotation(int quotationId, string sName, string address, string email, string PName, int stock, string requested_Date, string response_Date)
        {
            try
            {
                GetConnection();

                using (SqlCommand cmd = new SqlCommand("UPDATE Quotations SET SName=@SName, Address=@Address, Email=@Email, PName=@PName, Stock=@Stock, Requested_Date=@Requested_Date, Response_Date=@Response_Date WHERE QuotationID=@QuotationID", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@QuotationID", quotationId);
                    cmd.Parameters.AddWithValue("@SName", sName);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PName", PName);
                    cmd.Parameters.AddWithValue("@Stock", stock);
                    cmd.Parameters.AddWithValue("@Requested_Date", requested_Date);
                    cmd.Parameters.AddWithValue("@Response_Date", response_Date);



                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating quotation: " + ex.Message);
            }
        }

    }
}