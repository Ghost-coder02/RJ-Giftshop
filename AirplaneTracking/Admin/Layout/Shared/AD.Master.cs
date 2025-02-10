using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirplaneTracking.Admin.Layout.Shared
{
   
    public partial class AD : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool IsLogin = Convert.ToBoolean(Session["is_Login"]);
            if (IsLogin.Equals(false))
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}