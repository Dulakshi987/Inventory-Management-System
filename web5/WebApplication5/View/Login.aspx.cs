using System;
using System.Data.SqlClient;

namespace WebApplication5.View
{
    public partial class Login : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            // You may add any page load logic here if needed
        }

        protected void SignInButton_Click(object sender, EventArgs e)
        {
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();
            string role = UserRadio.Checked ? "User" : "Admin";  // Determine the role selected

            try
            {
                // Establish the connection
                GetConnection();

                // Prepare the SQL query to check the user credentials
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SignUpTbl WHERE Email = @Email AND Password = @Password AND Role = @Role", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);  // Ensure you are using hashed passwords in real-world scenarios
                    cmd.Parameters.AddWithValue("@Role", role);

                    int count = (int)cmd.ExecuteScalar();  // Execute the query and return a single value

                    if (count > 0)
                    {
                        // Successful login, redirect based on the role
                        if (role == "Admin")
                        {
                            Response.Redirect("../View/Admin/Add_Products.aspx");  // Redirect Admin to Add Products page
                        }
                        else if (role == "User")
                        {
                            Response.Redirect("../View/User/View_Products.aspx");  // Redirect User to View Products page
                        }
                    }
                    else
                    {
                        // Display error message if login fails
                        ErrorMessage.Text = "Invalid email, password, or role. Please try again.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message in case of exceptions
                ErrorMessage.Text = "Error: " + ex.Message;
            }
            finally
            {
                // Ensure the connection is closed
                if (SQLCon != null && SQLCon.State == System.Data.ConnectionState.Open)
                {
                    SQLCon.Close();
                }
            }
        }
    }
}
