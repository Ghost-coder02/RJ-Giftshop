using AirplaneTracking.Admin.Models;
using AirplaneTracking.Admin.Repository;
using System;
using System.Data;


namespace AirplaneTracking.Admin.Layout
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatRepo repo = new CatRepo();
            DataTable ctgs = repo.GetCategories();
            CatRepeater.DataSource = ctgs;
            CatRepeater.DataBind();

        }
    }
}