using AirplaneTracking.Customer.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AirplaneTracking.Admin.Layout
{
    public partial class OrderDetails : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    string orderIdString = Request.QueryString["OrderID"];

                    if (int.TryParse(orderIdString, out int OrderID))
                    {
                    BindInvoiceRep(OrderID);
                    DisplayCustOrderInfo(OrderID);
                    }


                
            }
            
        }


        public void BindInvoiceRep(int OrderID)
        {
            OrdersRepo repo = new OrdersRepo();
            InvoiceRepeater.DataSource = repo.GetOrderProducts(OrderID);
            InvoiceRepeater.DataBind();
        }


        
        private void DisplayCustOrderInfo(int orderId)
        {


            OrdersRepo repo = new OrdersRepo();
            List<Models.Orders> orders = repo.GetCustOrderInfo(orderId); 


            if (orders.Count > 0)
            {
                //orderId
                lblOrderID.Text = orders[1].OrderID.ToString();
                lblOrderDate.Text = orders[1].CreatedAt.ToString("MMMM dd, yyyy"); 
                lblOrderTime.Text = orders[1].CreatedAt.ToString("hh:mm tt"); 



                lblCustName.Text = $"{orders[1].CustomerObj.FName} {orders[0].CustomerObj.LName}";
                lblCustContact.Text = orders[1].CustomerObj.PhoneNumber;
                lblCustAdd.Text = orders[1].CustomerObj.Address;

                lblTotalPrice.Text = orders[1].TotalPrice.ToString()+"$";
            }
            else
            {
                // Handle case where no orders are found
                MessageBox.Show("No orders found for the given Order ID.");
            }
        }

    }
}