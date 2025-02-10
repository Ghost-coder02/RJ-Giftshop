using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI;

namespace AirplaneTracking.Customer.Layout.Shared
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();


            string fname = FName.Text;
            string lname = LName.Text;
            string username = Username.Text;
            string password = Password.Text;
            // gender char wwasn't added because it will be defined later
            //if ()
            //{
            //    gender = Convert.ToChar(Gender.SelectedValue.ToString());
            //}
            //= Convert.ToChar(Gender.SelectedValue.ToString());
            string DayValue= Day.Value;
            string MonthValue = Month.Value;
            string YearValue = Year.Value;
            // format the date before adding it
            string bddate = $"{YearValue}-{MonthValue.PadLeft(2, '0')}-{DayValue.PadLeft(2, '0')}";
            string country = CountryDDL.SelectedValue.ToString(); 
            string phone = CountryCode.Text + Number.Text;
            string address = txtAddress.Text;


           if (string.IsNullOrEmpty(Gender.SelectedValue) || string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(bddate) || string.IsNullOrEmpty(country) || string.IsNullOrEmpty(phone))
                {
                ErrLbl.Text = "Make sure you filled up all the fields!!";
                return;
            }

            if (string.IsNullOrEmpty(address))
            {
                txtAddress.Text = " ";
            }

            char gender = Convert.ToChar(Gender.SelectedValue.ToString());


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string Query = "insert into Customer (FName, LName, Username, Password, Gender, Date_of_birth, Country, Phone, Address, CreatedAt) Values (@fname, @lname, @username, @password, @gender, @date, @country, @phone, @address, GETDATE())";


                try
                {
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@date", bddate);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", address);

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    //ErrLbl.Text = "Registration was successful!!";
                    //ErrLbl.Visible = true;

                    // start a session
                    Session["Username"] = username;
                    Session["IsLoggedIn"] = true;
                    Session["FirstName"] = fname;

                    Response.Redirect("MainPage.aspx");
                
        }
                catch (Exception ex)
                {
                    ErrLbl.Text = ex.Message;
                    ErrLbl.Visible = true;
                    Session["IsLoggedIn"] = false;

                    return;
                    
                }
            }
        }

        protected void btnDayUp_Click(object sender, EventArgs e)
        {

        }
    }
}
