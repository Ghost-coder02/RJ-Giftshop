using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace AirplaneTracking
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Username_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Password_TextChange(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //string x = ConfigurationManager.AppSettings["AppSecret"].ToString().Trim();

            // connectionString --> Defines the details required to establish a connection to the database server
            //string connectionString = "Data Source=DESKTOP-K0SBBOA\\SQLEXPRESS;Initial Catalog=LayanStore;Integrated Security=True;TrustServerCertificate=True";
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString.ToString();

            // Retrieve username and password from TextBoxes
            string username = Username.Text;
            string password = Password.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ErrLbl.Text = "Username or Password is incorrect...!";
                return;
            }

            // Create a SqlConnection object to connect to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open the connection
                conn.Open();

                // SQL query to check if username and password exist in the database
                // @username and @password are the ones that i supplied 
                string loginQuery = "SELECT COUNT(*) FROM dbo.Admins WHERE username=@username AND password=@password";

                // cmd object --> Defines and executes SQL commands and queries against the database.
                // we should pass 2 values, the query that i'm willing to execute and the connectionString
                SqlCommand cmd = new SqlCommand(loginQuery, conn);

                // Add parameters and their values
                // the purpose of using parameters to pass the values is a good practice to avoid sql injection 
                // i initiated 2 parameters @username and @password and then assigned the values that i inserted to them so i can compare them with the values in the database
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                // Execute the query to get the count of matching records
                // ExecuteScalar() is a function that's used to return a single value and is associated with cmd objects and is also used for upcasting
                int count = (int)cmd.ExecuteScalar();

                // Close the connection
                conn.Close();

                // Check if any matching record was found
                if (count > 0)
                {
                    Session["is_login"] = true;
                    // Login successful: Redirect to another page or show a success message
                    Response.Redirect("/Admin/Layout/jjj.aspx");
                    // Example: Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    // Login failed: Display an error message
                    Response.Write("<script>alert('Oh dumb dummy you've entered the wrong info! ');</script>");
                }
            }



        }
    }
}