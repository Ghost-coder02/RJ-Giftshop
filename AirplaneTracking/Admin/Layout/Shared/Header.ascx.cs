using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirplaneTracking.Admin.Layout.Shared
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
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


            //"~/AirplaneTracking/"
                
            Response.Redirect("~/Default.aspx");

        }
    }
}