using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirplaneTracking.Customer.Layout.Shared
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    //txtWelcome.Text = "Welcome, " + Session["Username"];
                    txtWelcome.Text = "Welcome, "+ Session["FirstName"];
                    txtWelcome.Visible = true;
                    btnOrdersHistory.Visible = true;

                    //Login.InnerText = "Logout";
                    //Login.Attributes["class"] = "bx bx-log-out ";
                    //Login.Attributes["href"] = "#";
                    Login.Visible = false;
                    btnLogout.Visible = true;
                    

                }
                else
                {
                    btnOrdersHistory.Visible = false;
                    Login.Visible = true;
                    btnLogout.Visible = false;

                }
            }
           
        }




        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }



        protected void btnCartIcon_Click(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
                Response.Redirect("Login.aspx");
            
        }

        protected void btnOrdersHistory_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
                Session.Clear();
                Session.Abandon();

                // Optional: Clear authentication cookie if using Forms Authentication
                if (Request.Cookies[".ASPXAUTH"] != null)
                {
                    var cookie = new HttpCookie(".ASPXAUTH")
                    {
                        Expires = DateTime.Now.AddDays(-1) // Set to an expired date
                    };
                    Response.Cookies.Add(cookie);
                }


                txtWelcome.Visible= false;
                btnOrdersHistory.Visible= false;
                btnLogout.Visible= false;
                Login.Visible = true;
            }

        
    }
}