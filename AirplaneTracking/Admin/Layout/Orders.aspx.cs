using AirplaneTracking.Customer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirplaneTracking.Admin.Layout
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrdersGrid();
            }
        }



        private void BindOrdersGrid()
        {

            OrdersRepo repo = new OrdersRepo();
            OrdersGrid.DataSource = repo.GetOrders();
            OrdersGrid.DataBind();
        }



        protected string FormatPhoneNumber(object phoneNumber)
        {
            if (phoneNumber == null)
                return string.Empty;


            string phoneStr = phoneNumber.ToString();

            //phoneStr.Length == 10
            if (true)
            {
                return string.Format("({0}) {1}-{2}",
                    phoneStr.Substring(0, 4),
                    phoneStr.Substring(4, 3),
                    phoneStr.Substring(7, 4));
            }
            //return phoneStr; 
        }




        protected void OrdersGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if(e.CommandName == "Delivered")
            {
                OrdersRepo repo = new OrdersRepo();
                int OrderID = Convert.ToInt32(((string)e.CommandArgument).ToString());
                repo.UpdateStatus(OrderID);
                BindOrdersGrid();
            }

            if(e.CommandName == "ViewDetails")
            {
                int OrderID = Convert.ToInt32(((string)e.CommandArgument).ToString());
                Response.Redirect($"OrderDetails.aspx?OrderID={ OrderID}");
            }
        }





        protected void OrdersGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int Status = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrderStatus"));

                Button btnDelivered = (Button)e.Row.FindControl("btnDelivered");
                Label lblDelivered = (Label)e.Row.FindControl("lblDelivered");

                if (Status == 1)
                {
                    btnDelivered.Visible = false;
                    lblDelivered.Visible = true;
                }

                else
                {
                    btnDelivered.Visible = true;
                    lblDelivered.Visible = false;
                }
            }
        }
    }
}