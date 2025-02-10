<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Layout/Shared/AD.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="AirplaneTracking.Admin.Layout.Products" %>

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
            top: 55%;
            left: 60%;
            transform: translate(-50%, -50%);
        }

        .TableContainer {
            table-layout: fixed;
            height: 600px; /* Set desired height */
            overflow-y: scroll; /* Enable vertical scrolling */
            width: 1100px;
        }

        table {
            /* width: 100%; */

            border-collapse: collapse;
            margin: 20px 0;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            width: 100px !important;
            padding: 10px;
            text-align: center;
        }

        th {
            background-color: #7f1d1d;
            /*background: linear-gradient(to bottom right, rgba(78, 134, 181, 0.5), rgba(204, 204, 204, 0.5));*/
            border: none;
            backdrop-filter: blur(10px);
            /*box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);*/
            color: white;
        }

        td{
            color: #6c7079;
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

        .btn-add {
            background-color: #4CAF50;
        }

        .btn-edit {
            background-color: #ffa500;
        }

        .btn-disable {
            background-color: #f44336;
        }

        .btn-cancel {
            background-color: #f44336;
        }

        .btn-save {
            background-color: #4CAF50;
        }

        .btn-enable {
            background-color: #4CAF50;
        }

        .full-width-textbox {
            width: 100%; /* Make the TextBox take up the full width of the cell */
            box-sizing: border-box; /* Include padding and border in the element's total width and height */
        }
    </style>
</asp:Content>












<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- adding an clickable image
    <a href="image link" target="_blanck">
        <img src="image link" width="50" />
    </a> -->


    <div class="Container">
        <div class="TableHeader">
            <h2>Products </h2>
            <br />
        </div>


        <div class="TableContainer">
            <asp:GridView ID="GridViewProducts" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
                OnRowDataBound="GridViewProducts_RowDataBound"
                OnRowEditing="GridViewProducts_RowEditing"
                OnRowUpdating="GridViewProducts_RowUpdating"
                OnRowCancelingEdit="GridViewProducts_RowCancelingEdit"
                OnRowCommand="GridViewProducts_RowCommand"
                CssClass="table"
                ShowFooter="true">

                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="Category ID" Visible="false" />



                    <asp:TemplateField HeaderText="Product Number" ItemStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lblLineNumber" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>




                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150px">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("ProdName") %>'></asp:Label>
                        </ItemTemplate>


                        <EditItemTemplate>
                            <asp:Label ID="lblProdNameError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:TextBox ID="txtProdName" runat="server" Text='<%# Bind("ProdName") %>'></asp:TextBox>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="NewlblProdNameError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:TextBox ID="NewtxtProdName" runat="server" Text='<%# Bind("ProdName") %>'></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="Category" ItemStyle-Width="150px">
                        <ItemTemplate>

                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("CategoriesObj.CatName") %>'></asp:Label>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:Label ID="lblCatError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="NewlblCatError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:DropDownList ID="NewddlCategory" runat="server"></asp:DropDownList>
                        </FooterTemplate>


                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="Size" ItemStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lblSize" runat="server" Text='<%# Bind("SizeObj.SizeName") %>'></asp:Label>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:Label ID="lblSizeError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:DropDownList ID="ddlSize" runat="server"></asp:DropDownList>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="NewlblSizeError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:DropDownList ID="NewddlSize" runat="server"></asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="Color" ItemStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lblColor" runat="server" Text='<%# Bind("Color") %>'></asp:Label>
                        </ItemTemplate>


                        <EditItemTemplate>
                            <asp:Label ID="lblColError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:TextBox ID="txtColor" runat="server" Text='<%# Bind("Color") %>'></asp:TextBox>
                        </EditItemTemplate>



                        <FooterTemplate>
                            <asp:Label ID="NewlblColError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:TextBox ID="NewtxtColor" runat="server" Text='<%# Bind("Color") %>'></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="Material" ItemStyle-Width="150px">
                        <ItemTemplate>
                            <asp:Label ID="lblMaterial" runat="server" Text='<%# Bind("Material") %>'></asp:Label>
                        </ItemTemplate>


                        <EditItemTemplate>
                            <asp:Label ID="lblMatError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:TextBox ID="txtMaterial" runat="server" Text='<%# Bind("Material") %>'></asp:TextBox>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="NewlblMatError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:TextBox ID="NewtxtMaterial" runat="server" Text='<%# Bind("Material") %>'></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>




                    <asp:TemplateField HeaderText="Quantity" ItemStyle-Width="80px">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                        </ItemTemplate>


                        <EditItemTemplate>
                            <asp:Label ID="lblQuanError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                        </EditItemTemplate>


                        <FooterTemplate>
                            <asp:Label ID="NewlblQuanError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:TextBox ID="NewtxtQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="Original Price" ItemStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lblOldPrice" runat="server" Text='<%# Bind("OldPrice", "{0:C}") %>'></asp:Label>
                        </ItemTemplate>


                        <EditItemTemplate>
                            <asp:Label ID="lblOldPriceError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:TextBox ID="txtOldPrice" runat="server" Text='<%# Bind("OldPrice") %>'></asp:TextBox>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="NewlblOldPriceError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:TextBox ID="NewtxtOldPrice" runat="server" Text='<%# Bind("OldPrice") %>'></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="Discount" ItemStyle-Width="80px">
                        <ItemTemplate>
                            <asp:Label ID="lblDiscount" runat="server" Text='<%# Bind("Discount", "{0:P}") %>'></asp:Label>
                        </ItemTemplate>


                        <EditItemTemplate>
                            <asp:TextBox ID="txtDiscount" runat="server" Text='<%# Bind("Discount") %>'></asp:TextBox>
                        </EditItemTemplate>


                        <FooterTemplate>
                            <asp:TextBox ID="NewtxtDiscount" runat="server" Text='<%# Bind("Discount") %>' min="0"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="New Price" ItemStyle-Width="100px">
                        <ItemTemplate>
                            <asp:Label ID="lblNewPrice" runat="server" Text='<%# Bind("NewPrice", "{0:C}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="Description" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                        </ItemTemplate>


                        <EditItemTemplate>
                            <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine"></asp:TextBox>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="NewlblDescError" runat="server" Text="Required" Visible="false" Style="color: red; font-size: 15px; top: 0"></asp:Label>
                            <asp:TextBox ID="NewtxtDescription" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="Available" ItemStyle-Width="80px">
                        <ItemTemplate>
                            <asp:Label ID="lblAvailable" runat="server" Text='<%# Bind("Available") %>'></asp:Label>
                        </ItemTemplate>


                        <EditItemTemplate>
                            <asp:CheckBox ID="chkAvailable" runat="server" Checked='<%# Bind("Available") %>'></asp:CheckBox>
                        </EditItemTemplate>


                        <FooterTemplate>
                            <asp:CheckBox ID="NewchkAvailable" runat="server" Checked='<%# Bind("Available") %>'></asp:CheckBox>
                        </FooterTemplate>
                    </asp:TemplateField>












                    <asp:TemplateField HeaderText="Actions" ItemStyle-Width="150px">
                        <ItemTemplate>

                            <asp:Button
                                ID="btnEdit"
                                runat="server"
                                CommandName="Edit"
                                Text="Edit"
                                CssClass="btn btn-edit" />

                            <asp:Button
                                ID="btnDisable"
                                runat="server"
                                CommandName="Disable"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                Text="Disable"
                                CssClass="btn btn-disable" />

                            <asp:Button
                                ID="btnEnable"
                                runat="server"
                                CommandName="Enable"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                Text="Recover"
                                CssClass="btn btn-enable"
                                Visible="false" />
                        </ItemTemplate>


                        <EditItemTemplate>
                            <asp:Button
                                ID="btnSave"
                                runat="server"
                                CommandName="Update"
                                Text="Save"
                                CssClass="btn btn-save" />

                            <asp:Button
                                ID="btnCancel"
                                runat="server"
                                CommandName="Cancel"
                                Text="Cancel"
                                CssClass="btn btn-cancel" />

                        </EditItemTemplate>



                        <FooterTemplate>
                            <asp:Button
                                ID="btnAdd"
                                runat="server"
                                Text="Add New Product"
                                CommandName="Add"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                CssClass="btn btn-add" />

                        </FooterTemplate>


                    </asp:TemplateField>


                </Columns>

            </asp:GridView>
        </div>
















    </div>




</asp:Content>
