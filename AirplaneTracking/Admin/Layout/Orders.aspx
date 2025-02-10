<%@ Page Title="Orders" Language="C#" MasterPageFile="~/Admin/Layout/Shared/AD.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="AirplaneTracking.Admin.Layout.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .TableHeader {
            display: flex; /* Use Flexbox layout */
            align-items: center; /* Center items vertically */
            justify-content: space-between; /* Space items out */
            width: 450px;
            color: #6c7079;
        }

            .TableHeader h2 {
                margin-left: 20px; /* Remove default margin */
            }

        .Container {
            position: absolute;
            top: 65%;
            left: 60%;
            transform: translate(-50%, -50%);
        }

        .TableContainer {
            height: 700px; /* Set desired height */
            overflow-y: scroll; /* Enable vertical scrolling */
        }

        table {
            /* width: 100%; */
            width: 1100px;
            border-collapse: collapse;
            margin: 20px 0;
            text-align:center;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            padding: 10px;
            text-align: center;
            
        }


        td{
            color: #6c7079;
        }

        th {
            /*background: linear-gradient(to bottom right, rgba(78, 134, 181, 0.5), rgba(204, 204, 204, 0.5));*/
            color: white;
            border: none;
            backdrop-filter: blur(10px);
            /*box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);*/
            background-color: #7f1d1d;
        }

        .btn {
            display: inline-block;
            padding: 8px 12px;
            margin: 4px;
            border: none;
            border-radius: 4px;
            color: #fff;
            cursor: pointer;
        }


        .btn-edit {
            background-color: #4CAF50;
        }

        .btn-delete {
            background-color: #f44336;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Container">
        <div class="TableHeader" style="color: #6c7079;">
            <h2>Customers' Orders
            </h2>
        </div>



    

        <div class="TableContainer">
            <asp:GridView runat="server" AutoGenerateColumns="false" DataKeyNames="OrderID"
                ID="OrdersGrid"
                CssClass="table"
                OnRowCommand="OrdersGrid_RowCommand"
                OnRowDataBound="OrdersGrid_RowDataBound">
                

                <Columns>



                    <asp:TemplateField HeaderText="Order ID" >
                        <ItemTemplate>
                           #<%# Eval("OrderID") %>
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Customer's Name">
                        <ItemTemplate>
                            <%# Eval("CustomerObj.Fname") %>   <%# Eval("CustomerObj.LName") %>
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Phone Number" ItemStyle-Width="170px">
                        <ItemTemplate>
                            <%# FormatPhoneNumber(Eval("CustomerObj.PhoneNumber")) %>
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Number of Items" ItemStyle-Width="100px">
                        <ItemTemplate>
                            <%# Eval("ProdsCount") %>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Total Price">
                        <ItemTemplate>
                            <%# Eval("TotalPrice") %>$
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="was Submitted at">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("CreatedAt", "{0:MMMM dd, yyyy}") %>'></asp:Label><br />
                            <asp:Label ID="lblTime" runat="server" Text='<%# Eval("CreatedAt", "{0:hh:mm tt}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>







                    
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Button
                                ID="btnDelivered"
                                runat="server"
                                Text="Delivered"
                                CommandName="Delivered"
                                CommandArgument=<%# Eval("OrderID") %>
                                CssClass="btn btn-edit" />


                                <asp:Label ID="lblDelivered" 
                                    runat="server" 
                                    Text="Delivered" 
                                    Visible="false"
                                    style="color: green;">
                                </asp:Label>


                        </ItemTemplate>
                    </asp:TemplateField>



                    
                    <asp:TemplateField HeaderText="More Info">
                        <ItemTemplate>
                            <asp:Button
                                ID="btnViewDetails"
                                runat="server"
                                Text="View Details"
                                CommandName="ViewDetails"
                                CommandArgument =<%# Eval("OrderID") %>
                                CssClass="btn btn-delete" />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>




            </asp:GridView>
        </div>
    </div>
</asp:Content>
