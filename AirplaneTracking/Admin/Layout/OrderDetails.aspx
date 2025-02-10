<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Layout/Shared/AD.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="AirplaneTracking.Admin.Layout.OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        * {
            font-family: 'Lucida Handwriting';
        }

        .Container {
            display: flex;
            flex-direction: column;
        }

        #MainContent_lblCustInfo {
            text-align: left;
            font-family: 'Lucida Handwriting';
            color: rgba(78, 134, 181, 0.5);
            padding-bottom: 20px;
            font-weight: 600;
            font-size:x-large;
        }


        .InvoiceTitle {
        }


        .InvoiceInfo {
            display: flex;
            justify-content: space-evenly;
            margin-bottom: 20px;
                transform: translate(-55px, 10px);
                color: #6c7079;
          
        }

        .CustomerInfo, .OrderInfo {
            width: 48%;
        }

        .InvoiceTable {
            width: 100%;
            overflow-x: auto; /* Makes table responsive */
        }

        table {
            width: 90%;
            border-collapse: collapse;
            text-align: center;
        }

        th, td {

            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        td{
            color: #6c7079;
        }

        th {
            text-align: center;
            /*font-family: 'Lucida Handwriting';*/
            color: white;
            padding-bottom: 20px;
            /*background-color: rgba(78, 134, 181, 0.5);*/
            background-color: #7f1d1d;
        }

        h2 {
            text-align: center;
            padding-right: 10%;

            /*font-family: 'Lucida Handwriting';*/
            color: black;
            padding-bottom: 20px;
            font-size: xx-large;
            
        }

        .CustomerOrderContainer {
            display: flex;
            padding: 20px;
            background-color: #f9f9f9; /* Light background for the whole container */
        }

        .CustomerInfo, .OrderInfo {
            background-color: rgba(255, 255, 255, 0.8); /* White background for info boxes */
            border: 1px solid rgba(78, 134, 181, 0.5); /* Subtle border color */
            border-radius: 10px; /* Rounded corners */
            padding: 20px;
            width: 40%; /* Adjust width as necessary */
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1); /* Subtle shadow */
        }

            .CustomerInfo h2, .OrderInfo h2 {
                text-align: left;
                font-family: 'Lucida Handwriting';
                color: rgba(78, 134, 181, 0.5);
                padding-bottom: 20px;
            }

        div {
            margin-bottom: 10px; /* Space between entries */
        }


        .TotalPrice{
            font-weight:600;
            text-align:end;
            padding-right: 150px;
            padding-top: 30px;
        }
        

        asp\:Label {
            text-align: left;
            font-family: 'Lucida Handwriting';
            color: rgba(78, 134, 181, 0.5);
            padding-bottom: 20px;
        }

            /* Adding a style for the labels to be bold */
            asp\:Label:first-child {
                font-weight: bold; /* Make the label text bold */
            }
    </style>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="InvoiceTitle">
        <h2>Invoice</h2>
    </div>


    <div class="Container">

        <%--<asp:Label runat="server" ID="lblCustInfo" Text=" To "></asp:Label>--%>

        <div class="InvoiceInfo">

            <div class="CustomerInfo">
                <div class="Name">
                    <asp:Label runat="server" Text="Customer's Name: " style="font-weight:600; color:black;"></asp:Label>
                    <asp:Label ID="lblCustName" runat="server" ></asp:Label>
                </div>


                <div class="Address">
                    <asp:Label runat="server" Text="Address: " style="font-weight:600; color:black;"></asp:Label>
                    <asp:Label ID="lblCustAdd" runat="server"></asp:Label>
                </div>


                <div class="ContactInfo">
                    <asp:Label runat="server" Text="Contact Information: " style="font-weight:600; color:black;"></asp:Label>
                    <asp:Label ID="lblCustContact" runat="server"></asp:Label>
                </div>

            </div>



            <div class="OrderInfo">
                <div class="OrderID">
                    <asp:Label runat="server" Text="Order ID: " style="font-weight:600; color:black;"></asp:Label>
                    <asp:Label ID="lblOrderID" runat="server"></asp:Label>
                </div>


                <div class="OrderDate">
                    <asp:Label runat="server" Text="Date: " style="font-weight:600; color:black;"></asp:Label>
                    <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                </div>


                <div class="OrderTime">
                    <asp:Label runat="server" Text="Time: " style="font-weight:600; color:black;" ></asp:Label>
                    <asp:Label ID="lblOrderTime" runat="server"></asp:Label>
                </div>
            </div>
        </div>






        <div class="InvoiceTable">
            <table>
                <thead>
                    <tr>
                        <th style="width: 100px;">Product ID</th>
                        <th>Product Name</th>
                        <th>Size</th>
                        <th>Color</th>
                        <th>Material</th>
                        <th>Original Price</th>
                        <th>Discount</th>
                        <th style="width: 150px;">Price after Discount</th>
                        <th style="width: 100px;">Number of Items</th>
                        <th style="width: 100px;">Total Item Price</th>
                    </tr>
                </thead>


                <tbody>
                    <asp:Repeater runat="server" ID="InvoiceRepeater">
                        <ItemTemplate>
                            <tr>
                                <td>#<%# Eval("ProductID") %></td>
                                <td><%# Eval("ProdName") %></td>
                                <td><%# Eval("SizeObj.SizeName") %></td>
                                <td><%# Eval("Color") %></td>
                                <td><%# Eval("Material") %></td>
                                <td><%# Eval("OrderProdObj.OldPrice") %>$</td>
                                <td><%# Convert.ToInt32(Convert.ToDecimal(Eval("OrderProdObj.Discount"))*100) %>%</td>
                                <td><%# Eval("OrderProdObj.NewPrice") %>$</td>
                                <td><%# Eval("OrderProdObj.ProdQuant") %></td>
                                <td><%# Eval("OrderProdObj.ProdPrice") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>


        </div>


        <div class="TotalPrice">
            <asp:Label runat="server" Text="Total Price : " style="font-weight:600;"></asp:Label>
            <asp:Label runat="server" ID="lblTotalPrice" style="font-weight:200;" ></asp:Label>
        </div>
    </div>




</asp:Content>
