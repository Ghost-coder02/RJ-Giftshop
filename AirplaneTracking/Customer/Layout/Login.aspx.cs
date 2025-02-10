using AirplaneTracking.Customer.Repository;
using AirplaneTracking.Customer.Models; 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;



namespace AirplaneTracking.Customer.Layout
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();

            string username = Username.Text;
            string password = Password.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Customer WHERE [Username]=@username AND [Password]=@password";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);


                    int count = (int)cmd.ExecuteScalar();

                    conn.Close();



                    if (count > 0)
                    {
                        CustRepo repo = new CustRepo();

                        // retrieves a list of objects and assign it to the vars in the model
                        List<Models.Customer> varRepo = repo.GetCustInfo(username);
                        //Customer.Models.Customer varRepo = new Customer.Models.Customer();
                        
                        Session["is_login"] = true;


                        Session["Info"] = varRepo;
                    
                        // this will retrieve a list that contains all the user info
                        List<Models.Customer> CustInfo = (List<Models.Customer>)Session["Info"];


                        // since it's always gonna return only one customer then we refer to the index zero which contains all of the information about this customer
                        
                        Session["CustID"] = CustInfo[0].CustId;
                        Session["Username"] = CustInfo[0].Username;
                        Session["FirstName"] = CustInfo[0].FirstName;
                        List<Customer.Models.Products> CartItems = new List<Products>();
                        //List<Products> CartInfo = (List<Products>)Session["CartInfo"];
                        Session["CartItems"] = CartItems;




                        Response.Redirect("/Customer/Layout/MainPage.aspx");

                    }
                    else
                    {
                        ErrLbl.Text = "Wrong username or password";
                    }
                }
            }

            else
            {
                ErrLbl.Text = "Username or Password can't be empty!!";
                ErrLbl.Visible = true;
                return;
            }
        }

    }
}