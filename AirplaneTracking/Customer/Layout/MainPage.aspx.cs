using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using AirplaneTracking.Customer.Models;
using AirplaneTracking.Customer.Repository;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.Media;
using System.Web.UI.HtmlControls;
using AirplaneTracking.Admin.Models;
using AirplaneTracking.Admin.Layout;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace AirplaneTracking.Customer.Layout
{
    public partial class MainPage : System.Web.UI.Page
    {
        CatRepo repo = new CatRepo();
        ProdRepo repo2 = new ProdRepo();

        int CustID;


        protected void Page_Load(object sender, EventArgs e)
        {
            CustID = Convert.ToInt32(Session["CustID"]);
            
            if (!IsPostBack)
            {
                if (Session["CustID"] != null)
                {
                    BindCat();
                    BindRandProds();
                    BindCart();
                    BindCartItems();
                    BindOrdersHistory();

                    //babe.Visible = false;
                    //overlay.Visible = false;
                    

                }
                else
                {
                    BindCat();
                    BindRandProds();
                    //Response.Redirect("Login.aspx");
                }



            }

        }


        public void BindCat()
        {
            DataTable Cats = repo.GetCategories();
            CatRepeater.DataSource = Cats;
            CatRepeater.DataBind();


            /*if (repo.GetImage() != null)
            {
                Response.ContentType = "image/jpg"; // Set appropriate MIME type
                Response.BinaryWrite(repo.GetImage());
                Response.End();
            }*/


        }



        public void CatRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SelectedCat")
            {
                // to retrieve the selected cat id from commandArgument
                int CatId = Convert.ToInt32(e.CommandArgument.ToString());

                // Bind the products based on a selected cat
                BindProd(CatId);


                //this line is to ensure that the javaScript code is being run at every partial postback
                string script = "CatsSlickMove()";
                ScriptManager.RegisterStartupScript(this, GetType(), "CatsSlickMove", script, true);

            }
        }


        public void BindProd(int CatId)
        {

            ProdRepeater.DataSource = repo2.GetProducts(CatId);
            ProdRepeater.DataBind();
        }


        public void BindRandProds()
        {
            RandProdsRep.DataSource = repo2.GetRandProds();
            RandProdsRep.DataBind();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

        }

        protected void CatLinkButton_Click(object sender, EventArgs e)
        {


        }



        protected void RandProdsRep_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                if (Session["Username"] != null)
                {
                    string ProductId = e.CommandArgument.ToString();
                    if (Session["CustID"] != null)
                    {
                        int CustID = Convert.ToInt32(Session["CustID"]);

                        ProdRepo repo = new ProdRepo();
                        repo.AddToCart(ProductId, CustID);
                        BindCart();
                        System.Web.UI.WebControls.Button button = (System.Web.UI.WebControls.Button)e.CommandSource;

                        //button.Enabled = false;
                        //button.Text = "In the Cart"; 
                        //button.CssClass += "disabled";

                        button.Enabled = false;
                        button.Visible = false;


                        System.Web.UI.WebControls.Button DisButton = (System.Web.UI.WebControls.Button)e.Item.FindControl("DisabledAddToCartBtn");
                        DisButton.Enabled = true;
                        DisButton.Visible = true;


                    }


                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }



        public void BindCart()
        {
            ProdRepo repo = new ProdRepo();
            int CustID = Convert.ToInt32(Session["CustID"]);
            //if(cartProducts.Count > 0)
            //    cartProducts.Clear();

            List<Customer.Models.Products> cartProducts = repo.DisplayCart(CustID);
            //Session["cart-products"] = cartProducts;
            //assigning a serialized value to the hidden var (it can be only used within the same page) and it will be deserialized later in the function

            // this refers to the hidden field
            CartData.Value = null;
            CartData.Value = JsonConvert.SerializeObject(cartProducts);
            CartProdsRepeater.DataSource = cartProducts;
            CartProdsRepeater.DataBind();

            if(CartProdsRepeater.Items.Count <= 0)
            {
                Checkout.Enabled = false;
            }
            else
            {
                Checkout.Enabled = true;
            }

        }






        public void BindCartItems()
        {

        }


        protected void CartProdsRepeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {


            if (e.CommandName == "DeleteProd")
            {
                ProdRepo repo = new ProdRepo();
                int CartID = Convert.ToInt32(e.CommandArgument.ToString());

                repo.DeleteProd(CartID);
                BindCart();
            }




            if (e.CommandName == "increase")
            {

                RepeaterItem item = (RepeaterItem)e.Item;
                System.Web.UI.WebControls.TextBox quantBox = (System.Web.UI.WebControls.TextBox)item.FindControl("QuantBox");



                int currentQuantity = int.Parse(quantBox.Text);


                ProdRepo repo = new ProdRepo();
                int CartID = Convert.ToInt32(e.CommandArgument.ToString());
                int maxQuantity = repo.GetProdQuant(CartID);



                if (currentQuantity < maxQuantity)
                {
                    quantBox.Text = (currentQuantity + 1).ToString();
                    List<Customer.Models.Products> cartProduct = repo.UpdateCartQuant(CartID, currentQuantity + 1, CustID);
                    CartData.Value = JsonConvert.SerializeObject(cartProduct);
                }
                else
                {
                    //lblError.
                }
            }




            if (e.CommandName == "Decrease")
            {
                RepeaterItem item = (RepeaterItem)e.Item;
                System.Web.UI.WebControls.TextBox quantBox = (System.Web.UI.WebControls.TextBox)item.FindControl("QuantBox");


                int currentQuantity = int.Parse(quantBox.Text);

                ProdRepo repo = new ProdRepo();
                int CartID = Convert.ToInt32(e.CommandArgument.ToString());
                int maxQuantity = repo.GetProdQuant(CartID);

                if (currentQuantity > 1)
                {
                    quantBox.Text = (currentQuantity - 1).ToString();
                    List<Customer.Models.Products> cartProduct = repo.UpdateCartQuant(CartID, currentQuantity - 1, CustID);
                    CartData.Value = JsonConvert.SerializeObject(cartProduct);
                }
                else
                {
                    //System.Web.UI.WebControls.Label Error = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblError");
                    //Error.Visible = true;
                    //Error.Text = "This Amount isn't Available in Our Store";

                }
            }

        }

        protected void btnAddToCart_Click1(object sender, EventArgs e)
        {

        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            // to copy the cart items in the repeater into other repeater without hitting the database
            //CheckoutRepeater.DataSource = CartProdsRepeater.Items;
            //CheckoutRepeater.DataBind();

            if (CartProdsRepeater.Items.Count <= 0)
                return;



            if (CartProdsRepeater.Items.Count > 0)
            {
                List<Customer.Models.Products> products = JsonConvert.DeserializeObject<List<Customer.Models.Products>>(CartData.Value);
                CheckoutRepeater.DataSource = products;
                CheckoutRepeater.DataBind();

                //this will assign values to every var in the model


                //to show the total number of items
                int counter = CheckoutRepeater.Items.Count;
                TotalItems.Text = counter.ToString();



                double totalPrice = 0;

                foreach (Customer.Models.Products item in products)
                {

                    var lblItemPrice = item.Quantity * item.NewPrice;
                    //if (lblItemPrice != null )
                    //{
                    double price = Convert.ToDouble(lblItemPrice);

                    totalPrice += price;
                    //}
                }

                TotalItemsPrice.Text = totalPrice.ToString("C");
            }

            else
            {

                Checkout.Enabled = false;
            }



        }

        protected void QuantBox_TextChanged(object sender, EventArgs e)
        {

            RepeaterItem item = (RepeaterItem)((System.Web.UI.WebControls.TextBox)sender).NamingContainer;
            System.Web.UI.WebControls.TextBox quantBox = (System.Web.UI.WebControls.TextBox)item.FindControl("QuantBox");


            int currentQuantity = int.Parse(quantBox.Text);


            var info = (HiddenField)item.FindControl("CartIDValue");
            int CartID = Convert.ToInt32(info.Value);
            int CustID = Convert.ToInt32(Session["CustID"]);
            /*var product = item.DataItem as Products;*/
            //products is the data type of the item
            //if (product == null || product.CartObj == null)
            //{

            //    return;
            //}

            //int CartID = product.CartObj.CartID;



            ProdRepo repo = new ProdRepo();
            int maxQuantity = repo.GetProdQuant(CartID);


            if (currentQuantity < maxQuantity)
            {
                quantBox.Text = currentQuantity.ToString();
                List<Customer.Models.Products> cartProdut = repo.UpdateCartQuant(CartID, currentQuantity, CustID);

                //List<Products> products = JsonConvert.DeserializeObject<List<Products>>(CartData.Value);

                //foreach(Products product in products)
                //{
                //    if(product?.CartObj?.CartID == CartID)
                //    {
                //        product.CartObj.CartQuant = currentQuantity;
                //    }
                //}

                CartData.Value = JsonConvert.SerializeObject(cartProdut);

            }
            else
            {
                //Error
            }



        }

        protected void ConfirmCheckout_Click(object sender, EventArgs e)
        {
            repo2.PlaceOrder(CustID);
            btnConfirmCheckout2.Enabled = false;
            btnConfirmCheckout2.Text = "Order Submitted Successfully";
            btnConfirmCheckout2.BackColor =System.Drawing.Color.Green;

        }



        public void BindOrdersHistory()
        {
            ProdRepo repo = new ProdRepo();
            int CustID = Convert.ToInt32(Session["CustID"]);

            List<Customer.Models.Orders> OrdersList = repo.DisplayOrdersHistory(CustID);

            //this is the name of the hidden value
            OrdersData.Value = null;
            OrdersData.Value = JsonConvert.SerializeObject(OrdersList);
            OrdersHistoryRepeater.DataSource = OrdersList;
            OrdersHistoryRepeater.DataBind();



        }



        protected void OrdersHistoryRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Retrieve the status value from the data item
            bool orderStatus = Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "OrderStatus"));


            System.Web.UI.WebControls.Label lblStatus = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblStatus");


            if (orderStatus)
            {
                lblStatus.Text = "Delivered";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "On the Way";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }

        }





        public void BindOrderDetails(int OrderID)
        {
            //if (OrderProductsRepeater.Items.Count > 0)
            //{
                ProdRepo repo = new ProdRepo();
                List<Customer.Models.Products> OrderProducts = repo.DisplayOrderProducts(OrderID);


                //OrderProductsRepeater.DataSource=OrderProducts;
                //this refers to the hidden field
                OrderProductsData.Value = null;
                OrderProductsData.Value = JsonConvert.SerializeObject(OrderProducts);
                OrderProductsRepeater.DataSource = OrderProducts;
                OrderProductsRepeater.DataBind();



                


                List<Customer.Models.Orders> info = repo.GetPriceNQuant(OrderID);

                SumData.Value = null;
                SumData.Value = JsonConvert.SerializeObject(info);


                List<Customer.Models.Orders> deserializedOrders = JsonConvert.DeserializeObject<List<Customer.Models.Orders>>(SumData.Value);



                if (deserializedOrders != null && deserializedOrders.Count > 0)
                {
                    Customer.Models.Orders order2 = deserializedOrders[0]; // Get the first order from the list

                    // Assign values to the labels
                    lblTotalOrderItems.Text = order2.ProdsCount.ToString();
                    lblTotalOrderPrice.Text = order2.TotalPrice.ToString(); 
                }
                else
                {
                    // Handle the case where no orders are found or the list is empty
                    lblTotalOrderItems.Text = "0";
                    lblTotalOrderPrice.Text = "0";
                }



            //}


        }



        protected void OrdersHistoryRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewOrderDetails")
            {
                int OrderID = Convert.ToInt32(((string)e.CommandArgument).ToString());
                BindOrderDetails(OrderID);

                babe.Update();
                babe.Visible = true;
                OrderDetailsContainer.Visible = true;


                test2.Visible = true;
                overlay.Visible = true; 

            }

        }

        protected void RandProdsRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
                if (Session["CustID"] != null)
                {
                    int CustID = Convert.ToInt32(Session["CustID"]);

                    ProdRepo repo = new ProdRepo();
                    List<Models.Products> productsInCart = repo.DisplayCart(CustID);


                    int ProdID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ProductID"));
                    System.Web.UI.WebControls.Button button = (System.Web.UI.WebControls.Button)e.Item.FindControl("btnAddToCart");


                    bool isProductInCart = productsInCart.Any(product => product.ProductID == ProdID);


                    if (isProductInCart)
                    {
                    button.Enabled = false;
                    button.Visible = false;


                    System.Web.UI.WebControls.Button DisButton = (System.Web.UI.WebControls.Button)e.Item.FindControl("DisabledAddToCartBtn");
                    DisButton.Enabled = true;
                    DisButton.Visible = true;
                }
                }
            else
            {

            }

        }

        protected void ProdRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Session["CustID"] != null)
            {
                int CustID = Convert.ToInt32(Session["CustID"]);

                ProdRepo repo = new ProdRepo();
                List<Models.Products> productsInCart = repo.DisplayCart(CustID);


                int ProdID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ProductID"));
                System.Web.UI.WebControls.Button button = (System.Web.UI.WebControls.Button)e.Item.FindControl("btnAddToCart2");


                bool isProductInCart = productsInCart.Any(product => product.ProductID == ProdID);


                if (isProductInCart)
                {
                    button.Enabled = false;
                    button.Visible = false;


                    System.Web.UI.WebControls.Button DisButton = (System.Web.UI.WebControls.Button)e.Item.FindControl("DisabledAddToCartBtn2");
                    DisButton.Enabled = true;
                    DisButton.Visible = true;
                }
            }
            else
            {

            }
        }

        protected void ProdRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                if (Session["Username"] != null)
                {
                    string ProductId = e.CommandArgument.ToString();
                    if (Session["CustID"] != null)
                    {
                        int CustID = Convert.ToInt32(Session["CustID"]);

                        ProdRepo repo = new ProdRepo();
                        repo.AddToCart(ProductId, CustID);
                        BindCart();
                        System.Web.UI.WebControls.Button button = (System.Web.UI.WebControls.Button)e.CommandSource;

                        button.Enabled = false;
                        button.Visible = false;


                        System.Web.UI.WebControls.Button DisButton = (System.Web.UI.WebControls.Button)e.Item.FindControl("DisabledAddToCartBtn2");
                        DisButton.Enabled = true;
                        DisButton.Visible = true;


                    }


                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}