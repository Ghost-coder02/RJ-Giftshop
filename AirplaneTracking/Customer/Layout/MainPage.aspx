<%@ Page Title="" EnableViewState="true" Language="C#" MasterPageFile="~/Customer/Layout/Shared/Cust.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="AirplaneTracking.Customer.Layout.MainPage" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- to load all the icons-->
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>

    <!-- Slick CSS -->
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.8.1/slick.min.css" />

    <!-- my CSS page -->
    <link href="/CSS/CustShared.css" rel="stylesheet" type="text/css" />

    <!-- Slick Theme CSS (Optional) -->
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.8.1/slick-theme.min.css" />

    <!-- to load all the icons-->
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>

    <link rel="icon" href="../../CSS/2.png" type="image/x-icon" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">



    <%-- /******************************CART PART****************************/--%>
    <div class="Cart">
        <h2>Cart </h2>


        <div class="CartList">


            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <asp:HiddenField runat="server" ID="CartData" />

                    <asp:Repeater runat="server" ID="CartProdsRepeater" OnItemCommand="CartProdsRepeater_ItemCommand">
                        <ItemTemplate>
                            <div class="CartItemWrapper">
                                <div class="CartItem">
                                    <img src="../../Images/Plushies.jpg" />


                                    <div class="Content">

                                        <%--CssClass="CartProdName"--%>
                                        <div class="Name">
                                            <%# Eval("ProdName") %>
                                        </div>


                                        <%--CssClass="CartProdPrice"--%>
                                        <div class="Price">
                                            <%# Eval("NewPrice", "{0:C}") %>
                                        </div>

                                        <div class="Quantity" cssclass="Quantity">
                                            <asp:HiddenField runat="server" ID="CartIDValue" Value='<%# Eval("CartObj.CartID") %>' />
                                            <label>Quantity :</label>
                                            <asp:Button runat="server" ID="Decrease" Text="▼" CommandArgument='<%# Eval("CartObj.CartID") %>' CommandName="Decrease" />
                                            <%--TextMode="Number" OnTextChanged="QuantBox_TextChanged" --%>
                                            <asp:TextBox AutoPostBack="True" runat="server" ID="QuantBox" CssClass="QuantBox" Text='<%# Eval("Quantity") %>' CommandArgument='<%# Eval("CartObj.CartID") %>' Enabled="false"></asp:TextBox>
                                            <asp:Button runat="server" ID="Increase" Text="▲" CommandArgument='<%# Eval("CartObj.CartID") %>' CommandName="increase" />
                                        </div>
                                    </div>

                                    <div class="DeleteItem">
                                        <asp:Button runat="server" Text="Delete" CssClass="CartProdDelete" CommandArgument='<%# Eval("CartObj.CartID") %>' CommandName="DeleteProd" />
                                    </div>


                                </div>
                                <asp:Label runat="server" ID="lblError" Text="You Can't Add More Items!!" Style="color: red; font-weight: 200; visibility: hidden;" />

                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>


        </div>




        <div class="CartFooter">
            <%--<asp:updatepanel runat="server">
                <ContentTemplate>--%>
            <asp:Button runat="server" ID="Close" Text="Close" CssClass="btnClose" ClientIDMode="Static" />
            <%--</ContentTemplate>
            </asp:updatepanel>--%>


            <asp:UpdatePanel runat="server" ID="CartFooterCheckout">
                <ContentTemplate>
                    <asp:Button runat="server" ID="Checkout" Text="Checkout" OnClick="Checkout_Click" CssClass="btnCheckout" />
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

    </div>


    <%--/*************************Checkout*************************************/--%>

    <div class="CheckoutContainer">
        <div class="CheckoutLayout">


            <div class="ReturnCart">

                <a href="MainPage.aspx" id="GoBack">Keep shopping</a>
                <h2>List of Products in the Cart</h2>


                <%--<div class="CheckoutList">--%>

                <asp:UpdatePanel runat="server" ID="CheckoutUpdatePanel" class="CheckoutList" CssClass="CheckoutList">
                    <ContentTemplate>
                        <asp:Repeater runat="server" ID="CheckoutRepeater">
                            <ItemTemplate>

                                <div class="CheckoutItem">
                                    <img src="../../Images/Plushies.jpg" />


                                    <div class="ItemInfo">
                                        <div class="Name" style="color: red; font-weight: bold;">
                                            <%--Plushies--%>

                                            <%# Eval("ProdName") %>
                                        </div>

                                        <div class="Price">
                                            <%--50$/1--%>
                                            <%--<%# Eval("NewPrice", "{0:C}/1") %>--%>
                                            <%# string.Format("{0:N2}$/1", Eval("NewPrice")) %>
                                        </div>
                                    </div>


                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="TotalQuantity">
                                                <%--5 pcs--%>
                                                <%--<asp:Label runat="server" Text="Quantity"></asp:Label>--%>
                                                <%# Eval("CartObj.CartQuant") %>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                    <div class="TotalPrice">
                                        <%--250$--%>
                                        <%--<asp:HiddenField runat="server" Value="<%# Convert.ToDecimal(Eval("newPrice")) * Convert.ToDecimal(Eval("CartObj.CartQuant"))%>" id="ItemPrice"/>--%>
                                        <%# string.Format("{0:N2}$", Convert.ToDecimal(Eval("newPrice")) * Convert.ToDecimal(Eval("CartObj.CartQuant"))) %>
                                    </div>
                                </div>




                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--</div>--%>
            </div>





            <div class="ConfirmCheckout">

                <h2>Confirm Checkout</h2>

                <%--<div class="OrderSum">--%>
                <asp:UpdatePanel runat="server" class="OrderSum">
                    <ContentTemplate>
                        <div class="row">
                            <div class="TotalsAlign">Total Quantity : </div>
                            <div class="TotalItemsQuantity">

                                <asp:Label runat="server" ID="TotalItems" CssClass="lblTotalItems"></asp:Label>

                            </div>
                        </div>



                        <div class="row">
                            <div class="TotalsAlign">
                                Total Price : 
                            </div>

                            <div class="TotalItemsPrice">
                                <asp:Label runat="server" ID="TotalItemsPrice" CssClass="lblTotalitemsPrice"></asp:Label>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--</div>--%>



                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <asp:Button runat="server" class="btnConfirmCheckout" Text="Checkout" CssClass="btnConfirmCheckout" OnClick="ConfirmCheckout_Click" ID="btnConfirmCheckout2" />


                        <div class="OrderSubmit" runat="server" visible="true">
                            <asp:Label runat="server" class="lblOrderSubmit" Text="Order submitted Successfully!!"></asp:Label>
                            <img src="../../Images/checked.png" alt="Tick Icon" />
                        </div>


                        <%--OnClientClick="Heyy();"--%>
                        <%--<asp:Button runat="server" ID="btnConfirmCheckout" Text="Checkout" CssClass="btnConfirmCheckout" OnClientClick="return handleCheckout();" />--%>
                    </ContentTemplate>
                </asp:UpdatePanel>


                <%--               
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:Button runat="server" ID="btnConfirmCheckout" Text="Checkout" 
                    CssClass="btnConfirmCheckout" 
                    OnClientClick="return handleCheckout();" />
    </ContentTemplate>
</asp:UpdatePanel>--%>
            </div>


        </div>
    </div>

    <asp:UpdatePanel runat="server" ID="test2">
        <ContentTemplate>
            <div class="overlay" id="overlay" runat="server">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>



    <%--/*******************************Submit Order MSG************************/--%>

    <%--<div class="OrderSubmit" runat="server" visible="false">
        <asp:Label runat="server" class="lblOrderSubmit" Text="Order submitted Successfully!!"></asp:Label>
        <img src="../../Images/checked.png" alt="Tick Icon" />
    </div>--%>




    <%--/*****************************Orders History*******************************/--%>

    <div class="OrdersHistory">
        <h2>Orders Tracker </h2>


        <div class="OrdersHistoryList">


            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <asp:HiddenField runat="server" ID="OrdersData" />


                    <%--OnItemCommand="CartProdsRepeater_ItemCommand"--%>
                    <asp:Repeater runat="server" ID="OrdersHistoryRepeater" OnItemDataBound="OrdersHistoryRepeater_ItemDataBound" OnItemCommand="OrdersHistoryRepeater_ItemCommand">
                        <ItemTemplate>
                            <div class="OrdersWrapper">
                                <div class="Order">
                                    <%--<img src="../../CSS/2.png" alt="RJ logo" />--%>

                                    <div class="RJ" style="text-align: center; width: 25%; height: 100px; object-fit: cover; border-radius: 10px; position: relative; top: 0; background: linear-gradient(to Top,#7f1d1d, #dc2626); text-align: center;">
                                        <img src="/Images/RJ-logo-new.png" alt="Royal Jordanian Airlines Logo" style="width: 100px; height: 120px; position: absolute; padding: 20px; top: 50%; left: 50%; transform: translate(-50%, -50%);" />
                                        <%--<img src="\CSS\2.png" />--%>
                                    </div>


                                    <div class="Content">

                                        <%--CssClass="CartProdName"--%>
                                        <div class="OrderID">
                                            <asp:Label runat="server" Text="Order ID: #">
                                                <%# Eval("OrderID") %>
                                            </asp:Label>

                                        </div>


                                        <%--CssClass="CartProdPrice"--%>
                                        <div class="CreatedAt">
                                            <%# Eval("CreatedAt") %>
                                        </div>

                                        <div class="Status">
                                            <asp:Label runat="server" ID="lblStatus"></asp:Label>
                                        </div>


                                    </div>


                                    <asp:UpdatePanel runat="server" ID="nmnm">
                                        <ContentTemplate>
                                            <div class="ViewOrderDetails">

                                                <asp:Button runat="server" Text="View Details" ID="btnViewOrderDetails" CssClass="btnViewOrderDetails" CommandArgument='<%# Eval("OrderID") %>' CommandName="ViewOrderDetails" />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>



                                </div>


                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>


        </div>
        <div class="OrdersHistoryFooter">
            <asp:UpdatePanel runat="server" ID="btnClose" ClientIDMode="Static">
                <ContentTemplate>
                    <asp:Button runat="server" ID="CloseHistory" ClientIDMode="Static" Text="Close" CssClass="btnClose" />
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>


    </div>






    <%--/****************************Order Details**************************************/--%>
    <asp:UpdatePanel runat="server" ID="babe" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="OrderDetailsContainer" runat="server" id="OrderDetailsContainer" visible="false">
                <div class="OrderDetailsLayout">


                    <div class="ReturnOrder">

                        <a href="MainPage.aspx" id="GoBack2">Keep shopping</a>
                        <h2>List of Products in the Cart</h2>


                        <%--<div class="CheckoutList">--%>

                        <asp:UpdatePanel runat="server" ID="OrderUpdatePanel" class="OrderDetailsList" CssClass="OrderDetailsList" UpdateMode="Conditional">
                            <ContentTemplate>

                                <asp:HiddenField runat="server" ID="OrderProductsData" />

                                <asp:Repeater runat="server" ID="OrderProductsRepeater">
                                    <ItemTemplate>

                                        <div class="OrderItem">
                                            <img src="../../Images/Plushies.jpg" />


                                            <div class="ItemInfo">
                                                <div class="Name" style="color: red; font-weight: bold;">
                                                    <%--Plushies--%>

                                                    <%# Eval("ProdName") %>
                                                </div>

                                                <div class="Price">
                                                    <%--50$/1--%>
                                                    <%--<%# Eval("NewPrice", "{0:C}/1") %>--%>
                                                    <%# string.Format("{0:N2}$/1", Eval("NewPrice")) %>
                                                </div>
                                            </div>


                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <div class="TotalQuantity">
                                                        <%--5 pcs--%>
                                                        <%--<asp:Label runat="server" Text="Quantity"></asp:Label>--%>
                                                        <%# Eval("OrderProductsObj.ProdQuant") %>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>


                                            <div class="TotalPrice">
                                                <%--250$--%>
                                                <%--<asp:HiddenField runat="server" Value="<%# Convert.ToDecimal(Eval("newPrice")) * Convert.ToDecimal(Eval("CartObj.CartQuant"))%>" id="ItemPrice"/>--%>
                                                <%# string.Format("{0:N2}$", Convert.ToDecimal(Eval("OrderProductsObj.ProdQuant")) * Convert.ToDecimal(Eval("NewPrice"))) %>
                                            </div>
                                        </div>




                                    </ItemTemplate>
                                </asp:Repeater>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--</div>--%>
                    </div>





                    <div class="ConfirmOrderDtails">

                        <h2>Order Details</h2>

                        <asp:HiddenField runat="server" ID="SumData" />

                        <asp:UpdatePanel runat="server" class="OrderSum">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="TotalsAlign">Total Quantity : </div>
                                    <div class="TotalOrderQuantity">

                                        <asp:Label runat="server" ID="lblTotalOrderItems" CssClass="lblTotalOrderItems"></asp:Label>

                                    </div>
                                </div>



                                <div class="row">
                                    <div class="TotalsAlign">
                                        Total Price : 
                                    </div>

                                    <div class="TotalOrderPrice">
                                        <asp:Label runat="server" ID="lblTotalOrderPrice" CssClass="lblTotalOrderPrice"></asp:Label>
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>



                        <%--<div class="DateLabel">
                 <asp:Label runat="server" Text="<%# Eval("CreatedAt") %>" />
            </div>--%>
                    </div>


                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>



    <%--/***************************Main page**************************************/--%>

    <section class="MainHome">
        <div class="MainText">
            <h1>Exclusive Gifts
                <br />
                Perfect for Every Journey</h1>
            <p>Find the Perfect Gift for your Loved Ones</p>


            <a href="#SubWrapper" class="ScrollButton">Shop Now
                    <i class='bx bx-down-arrow-alt'></i>
            </a>
        </div>
    </section>




    <%--    font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";--%>
    <div class="SubWrapper" id="SubWrapper" style="padding: 30px; text-align: left; font-family: -apple-system, BlinkMacSystemFont, Roboto, Helvetica, Arial, sans-serif;">
        <div class="AboutUs2">
            <h2 style="padding: 10px; font-size: 48px; line-height: 60px; padding-left: 100px; margin-bottom: 20px;">
                <span style="color: #e03e3e;">About </span>
                <span style="color: #6c7079">Our Shop</span>
            </h2>
            <p class="parag2" style="color: #6c7079; background-color: #fffaf3; font-size: 20px; padding: 20px; text-align: justify;">
                At RJ Airline Gift Shop, we believe that every journey deserves a touch of joy. Founded with a passion for travel and a love for unique 
        souvenirs, our shop offers a carefully curated selection of gifts that celebrate the spirit of adventure. From trendy travel accessories
        to local artisanal products, we aim to provide travelers with memorable keepsakes that remind them of their journeys.

        Join us in celebrating the joy of travel! Explore our collection, and let us help you find the perfect memento for your next adventure.

        Thank you for choosing RJ Airline Gift Shop—where every gift tells a story. Happy travels!
            </p>
        </div>
    </div>

    <%--<section class="Services" id="Services">
        <div class="OurServices">
            <div class="Shipping">
                <div class="ServiceIcon">
                    <img src="../../GIF/gifAIR.gif" alt="Airplane" />
                </div>


                <div class="ServiceDesc" style="margin-right:0;">
                    <h3>Shipping to Every Destination </h3>
                    <p>
                        At our airline gift shop, we believe that every traveler should have access to unique souvenirs. That’s why we 
         offer shipping to every destination we serve, bringing a piece of your journey right to your doorstep. Whether 
         you’re reminiscing about a recent trip or planning your next adventure, we ensure that your favorite gifts arrive 
         quickly and safely, no matter where you are.
                    </p>
                </div>
            </div>
        </div>
    </section>--%>

    <div style="width: 100%; height: 100px;">
    </div>


    <asp:UpdatePanel ID="CatUpdate" runat="server">
        <ContentTemplate>

            <section class="Categories" id="Cats">
                <%--<div class="CenterText">
                    <h2>Shop by Category</h2>
                </div>--%>



                <div class="Slick-list">
                    <asp:Repeater ID="CatRepeater" runat="server" OnItemCommand="CatRepeater_ItemCommand">
                        <ItemTemplate>

                            <asp:UpdatePanel ID="CatUpdate" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="CatLinkButton" runat="server"
                                        CommandName="SelectedCat"
                                        CommandArgument='<%# Eval("Cat_id") %>'
                                        CssClass="CatItemLinkButton">

                                        <div class="Catnmnm">
                                                <%# Eval("Name") %>
                                        </div>


                                         <div class="CatItem">
                                            
                                             
                                             <div class="BackDiv">
                                                 <img src="../../Images/Plushies.jpg" alt="Plushies"/>
                                                 <%--<img src="../../Images/Supervisor.png" alt="nmnm" />--%>
                                             </div>
                                             
                                             <div class="txtSlick">
                                                 Take a Look Inside!
                                             </div>
                                         </div>

                                    </asp:LinkButton>

                                </ContentTemplate>

                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="CatLinkButton" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>


                        </ItemTemplate>
                    </asp:Repeater>
                </div>



            </section>





            <section class="Products" id="Prods">
                <%--<asp:Label runat="server" text='<%# Eval("Cat_id") %> ' style="color: white; height: 100px; width: 50px;"/>--%>
                <asp:Repeater ID="ProdRepeater" runat="server" OnItemCommand="ProdRepeater_ItemCommand" OnItemDataBound="ProdRepeater_ItemDataBound">
                    <ItemTemplate>

                        <div class="ProdWrapper">
                            <div class="ProdCard">
                                <div class="ProdCatTag">
                                    <%--<div class="ProdCat" style="color:#e03e3e; font-size:15px; ">--%>
                                    <%# Eval("CategoriesObj.CatName") %>
                                    <%--</div>--%>
                                </div>


                                <div class="ProdBackImage">
                                    <img src="../../Images/Stationery.jpg" alt="Stationary" />
                                </div>

                                <div runat="server" class="Discount" visible='<%# Convert.ToDecimal(Eval("Discount"))*100 > 0 %>' style="display: inline-block;">
                                    <asp:Label runat="server" CssClass="lblDiscount">Discount</asp:Label>
                                    <asp:Label runat="server" CssClass="valDiscount"><%# Convert.ToInt32(Convert.ToDecimal(Eval("Discount"))*100) %>%</asp:Label>
                                </div>
                                <%--<div runat="server" class="Discount" visible='<%# Convert.ToDecimal(Eval("Discount"))*100 > 0 %>'>
                                    <%# Convert.ToInt32(Convert.ToDecimal(Eval("Discount"))*100) %>% Discount
                                </div>--%>



                                <div class="ProdInfo">


                                    <div class="ProdName" style="font-size: 20px;">
                                        <%# Eval("ProdName") %>
                                    </div>

                                    <div class="Description" style="color: grey; font-size: 15px; margin-bottom: 15px;">
                                        <%# Eval("Description") %>
                                    </div>

                                    <div class="Size">
                                        <%# Eval("SizeObj.SizeName") %>
                                    </div>

                                    <div class="price">
                                        <div class="OldPrice" runat="server" visible='<%# Convert.ToDecimal(Eval("Discount")) > 0 %>'>
                                            $<%# Eval("OldPrice") %>
                                        </div>


                                        <div class="NewPrice">
                                            $<%# Eval("NewPrice") %>
                                        </div>
                                    </div>

                                    <div class="ProdOverlay">
                                    </div>


                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <%--OnClientClick="DisableButton();"--%>
                                            <asp:Button CssClass="AddToCartBtn" runat="server" ID="btnAddToCart2" Text="Add to Cart" CommandArgument='<%# Eval("ProductID") %>' CommandName="AddToCart" OnClientClick="return DisableButton(this);" />
                                            <asp:Button CssClass="DisabledAddToCartBtn" runat="server" ID="DisabledAddToCartBtn2" Text="In the Cart" Visible="false" />

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>



                    </ItemTemplate>
                </asp:Repeater>
            </section>
        </ContentTemplate>

        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="CatRepeater" EventName="ItemCommand" />
        </Triggers>--%>
    </asp:UpdatePanel>




    <section class="Services">
        <div class="OurServices">
            <%--<div class="Shipping">
                <div class="ServiceIcon">
                    <img src="../../GIF/gifAIR.gif" alt="Airplane" />
                </div>


                <div class="ServiceDesc">
                    <h3>Shipping to Every Destination </h3>
                    <p>
                        At our airline gift shop, we believe that every traveler should have access to unique souvenirs. That’s why we 
                 offer shipping to every destination we serve, bringing a piece of your journey right to your doorstep. Whether 
                 you’re reminiscing about a recent trip or planning your next adventure, we ensure that your favorite gifts arrive 
                 quickly and safely, no matter where you are.
                    </p>
                </div>

            </div>--%>



            <div class="ProdQuality">
                <div class="ServiceDesc" style="margin-right: 0;">
                    <h3>High Quality</h3>
                    <p>
                        Quality is at the heart of everything we do. Each product in our collection is carefully selected to ensure that it 
                 meets the highest standards. From artisan crafts to luxurious travel accessories, we strive to provide you with gifts
                 that not only represent the beauty of each destination but also stand the test of time. With our commitment to quality,
                 you can shop with confidence, knowing you’re getting the best.
                    </p>
                </div>



                <div class="ServiceIcon" style="margin-right: 0; padding-left: 100px;">
                    <img src="../../GIF/gift.gif" alt="gift" />
                </div>
            </div>



            <%--<div class="Cultures">
                <div class="ServiceIcon">
                    <img src="../../GIF/giphy.gif" />
                </div>


                <div class="ServiceDesc">
                    <h3>Cultural Souvenirs</h3>
                    <p>
                        Every destination has a story to tell, and we’re here to share those stories through our curated selection of cultural
                 souvenirs. Our gifts celebrate the unique heritage and traditions of each place we serve, allowing you to take home a
                 piece of your travels. From handcrafted items to local delicacies, our offerings invite you to explore the world’s rich 
                 diversity and connect with cultures far and wide.
                    </p>
                </div>

            </div>--%>
        </div>
    </section>




    <%--padding-left: 100px;--%>
    <h2 style="text-align: center; color: #e03e3e; margin: 20px; font-style: italic;">Trending Products</h2>

    <section class="RandProducts" id="RandProds">


        <%----%>
        <asp:Repeater runat="server" ID="RandProdsRep" OnItemCommand="RandProdsRep_ItemCommand" OnItemDataBound="RandProdsRep_ItemDataBound">
            <ItemTemplate>

                <div class="ProdWrapper">
                    <div class="ProdCard">
                        <div class="ProdCatTag">
                            <%--<div class="ProdCat" style="color:#e03e3e; font-size:15px; ">--%>
                            <%# Eval("CategoriesObj.CatName") %>
                            <%--</div>--%>
                        </div>


                        <div class="ProdBackImage">
                            <img src="../../Images/Stationery.jpg" alt="Stationary" />
                        </div>


                        <%--<div class="Discount" style="text-align: center; color: white;">
                            <h4>Discount</h4> 
                            <div style="background-color: #e03e3e; color: white; padding: 10px; display: inline-block;">
                                <%# Convert.ToInt32(Convert.ToDecimal(Eval("Discount")) * 100) %>%
                            </div>
                        </div>--%>

                        <div runat="server" class="Discount" visible='<%# Convert.ToDecimal(Eval("Discount"))*100 > 0 %>' style="display: inline-block;">
                            <asp:Label runat="server" CssClass="lblDiscount">Discount</asp:Label>
                            <asp:Label runat="server" CssClass="valDiscount"><%# Convert.ToInt32(Convert.ToDecimal(Eval("Discount"))*100) %>%</asp:Label>
                        </div>



                        <div class="ProdInfo">


                            <div class="ProdName" style="font-size: 20px;">
                                <%# Eval("ProdName") %>
                            </div>

                            <div class="Description" style="color: grey; font-size: 15px; margin-bottom: 15px;">
                                <%# Eval("Description") %>
                            </div>

                            <div class="Size">
                                <%# Eval("SizeObj.SizeName") %>
                            </div>

                            <div class="price">
                                <div class="OldPrice" runat="server" visible='<%# Convert.ToDecimal(Eval("Discount")) > 0 %>'>
                                    $<%# Eval("OldPrice") %>
                                </div>


                                <div class="NewPrice">
                                    $<%# Eval("NewPrice") %>
                                </div>
                            </div>

                            <div class="ProdOverlay">
                            </div>


                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <%--OnClientClick="DisableButton();"--%>
                                    <asp:Button CssClass="AddToCartBtn" runat="server" ID="btnAddToCart" Text="Add to Cart" CommandArgument='<%# Eval("ProductID") %>' CommandName="AddToCart" OnClientClick="return DisableButton(this);" />
                                    <asp:Button CssClass="DisabledAddToCartBtn" runat="server" ID="DisabledAddToCartBtn" Text="In the Cart" Visible="false" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>



            </ItemTemplate>
        </asp:Repeater>
    </section>






    <section class="Services">
        <div class="OurServices">
            <div class="Shipping">
                <div class="ServiceIcon">
                    <img src="../../GIF/gifAIR.gif" alt="Airplane" />
                </div>


                <div class="ServiceDesc" style="margin-right: 0;">
                    <h3>Shipping to Every Destination </h3>
                    <p>
                        At our airline gift shop, we believe that every traveler should have access to unique souvenirs. That’s why we 
offer shipping to every destination we serve, bringing a piece of your journey right to your doorstep. Whether 
you’re reminiscing about a recent trip or planning your next adventure, we ensure that your favorite gifts arrive 
quickly and safely, no matter where you are.
                    </p>
                </div>
            </div>
        </div>
    </section>


    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <!-- Slick JS -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.8.1/slick.min.js"></script>





    <script>



        var checkoutContainers = document.getElementsByClassName('CheckoutContainer');
        var overlays = document.getElementsByClassName('overlay');
        var OrderSubmit = document.getElementsByClassName('OrderSubmit');
        var OrderDetailsContainer = document.getElementsByClassName('OrderDetailsContainer');



        document.addEventListener('DOMContentLoaded', function () {
            var button = document.getElementById('ContentPlaceHolder3_CartFooterCheckout');
            if (button) {
                button.addEventListener('click', function () {


                    if (checkoutContainers.length > 0) {
                        checkoutContainers[0].style.display = 'block';
                    }
                    if (overlays.length > 0) {
                        overlays[0].style.display = 'block';
                    }
                });
            } else {
                console.log('Button not found');
            }
        });







        //document.addEventListener('DOMContentLoaded', function () {
        //    var button = document.getElementById('btnViewOrderDetails');
        //    if (button) {
        //        button.addEventListener('click', function () {


        //            if (OrderDetailsContainer.length > 0) {
        //                OrderDetailsContainer[0].style.display = 'block';
        //            }
        //            if (overlays.length > 0) {
        //                overlays[0].style.display = 'block';
        //            }
        //        });
        //    } else {
        //        console.log('Button not found');
        //    }
        //});


        //document.addEventListener('DOMContentLoaded', function () {
        //    // Use the correct client ID for the button
        //    var button = document.getElementById('');

        //    if (button) {
        //        button.addEventListener('click', function () {
        //            var OrderSubmit = document.getElementsByClassName('OrderSubmit');
        //            var overlays = document.getElementsByClassName('overlay');
        //            var checkoutContainers = document.getElementsByClassName('checkoutContainer');

        //            if (OrderSubmit.length > 0) {
        //                OrderSubmit[0].style.display = 'block';
        //            }
        //            if (overlays.length > 0) {
        //                overlays[0].style.display = 'block';
        //            }
        //            if (checkoutContainers.length > 0) {
        //                checkoutContainers[0].style.display = 'none'; // Change to 'none' to hide
        //            }
        //        });
        //    }
        //});

        <%--// Optional: Returning false to prevent postback in JavaScript
        function handleCheckout() {
            // Your JavaScript logic if needed before postback
            return true; // or return false if you want to prevent the postback
        }--%>



       <%-- document.addEventListener('DOMContentLoaded', function () {
            var button = document.getElementById('<%= btnConfirmCheckout.ClientID %>');

            if (button) {
                button.addEventListener('click', function () {
                    if (OrderSubmit.length > 0) {
                        OrderSubmit[0].style.display = 'block';
                    }
                    if (overlays.length > 0) {
                        overlays[0].style.display = 'block';
                    }
                    if (checkoutContainers.length > 0) {
                        checkoutContainers[0].style.display = 'hidden';
                    }
                });
            }
        });--%>


        //function handleCheckout() {
        //    return true;
        //}
        //function Heyy() {
        //    /*document.addEventListener('DOMContentLoaded', function () {*/
        //        var button = document.getElementById('ContentPlaceHolder3_btnConfirmCheckout');

        //        if (button) {
        //            button.addEventListener('click', function () {
        //                if (OrderSubmit.length > 0) {
        //                    OrderSubmit[0].style.visibility = "visible";
        //                    OrderSubmit[0].style.display = 'block'; // Show the OrderSubmit

        //                }
        //                if (overlays.length > 0) {
        //                    overlays[0].style.display = 'block';  // Show the overlay
        //                }
        //                if (checkoutContainers.length > 0) {
        //                    checkoutContainers[0].style.display = 'none';  // Hide the checkoutContainer
        //                }
        //            });
        //        }
        //   /* });*/
        //}








        //create a method with the javascript function for the slick, so i can recall it anywhere i want to run it
        $(document).ready(function () {
            CatsSlickMove();

        });

        function CatsSlickMove() {
            $('.Slick-list').slick({
                slidesToShow: 4,
                slidesToScroll: 3,
                autoplay: true,
                dots: true,
                arrows: true,
                responsive: [{
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                }]

            });




        }







    </script>


    <script>
        document.addEventListener("DOMContentLoaded", function () {
            const options = {
                root: null, // Use the viewport as the root
                rootMargin: '0px',
                threshold: 0.1 // Trigger when 10% of the target is visible
            };

            const observer = new IntersectionObserver((entries) => {
                entries.forEach(entry => {
                    if (entry.isIntersecting) {
                        // Add the 'visible' class when the element comes into view
                        entry.target.querySelector('.ServiceIcon').classList.add('visible');
                        entry.target.querySelector('.ServiceDesc').classList.add('visible');
                        observer.unobserve(entry.target); // Stop observing after it becomes visible
                    }
                });
            }, options);


            document.querySelectorAll('.Shipping, .ProdQuality, .Cultures').forEach(section => {
                observer.observe(section);
            });
        });
    </script>


</asp:Content>



