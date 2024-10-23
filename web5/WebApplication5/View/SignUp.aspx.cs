using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.View
{
    public partial class SignUp : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            // Any initial logic can be placed here
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            string name = Name.Text.Trim();
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();
            string role = UserRadio.Checked ? "User" : "Admin";

           
            {
                try
                {
                    GetConnection();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO SignUpTbl (Name, Email, Password, Role) VALUES (@Name, @Email, @Password, @Role)", SQLCon))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password); // Consider hashing the password for security
                        cmd.Parameters.AddWithValue("@Role", role);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Redirect to SignIn.aspx after successful sign-up
                            Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            ErrorMessage.Text = "Sign up failed. Please try again.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}
