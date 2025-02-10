<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Layout/Shared/AD.Master" AutoEventWireup="true" CodeBehind="jjj.aspx.cs" Inherits="AirplaneTracking.Admin.Layout.jjj" %>
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
            top: 50%;
            left: 60%;
            transform: translate(-50%, -50%);
            
            
        }

        .TableContainer{
            height: 500px; /* Set desired height */
            overflow-y: scroll; /* Enable vertical scrolling */
        }

        table {
            /* width: 100%; */
            width: 700px;
            border-collapse: collapse;
            margin: 20px 0;
            
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
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

        .btn-delete {
            background-color: #f44336;
        }

        .btn-cancel {
            background-color: #f44336;
        }

        .btn-save {
            background-color: #4CAF50;
        }

        
    </style>
</asp:Content>





<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Container">
        <div class="TableHeader">
            <h2> Categories </h2>
            <br />
        </div>


        <div class="TableContainer">
                 <!-- AutoGenerateColumns="False": you define the columns manually instead of having them automatically generated.
       DataKeyNames="ProductID": Specifies the primary key, which is typically used for operations like editing or deleting rows.
       OnRowEditing and OnRowDeleting: specify the event handlers that are triggered when a row is edited or deleted. -->

    <!-- each button knows what event it should operate depends on the commandname 
         command is used for the add function-->
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Cat_id" 
        OnRowDataBound="GridView1_RowDataBound"
        OnRowEditing="GridView1_RowEditing"  
        OnRowUpdating="GridView1_RowUpdating" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" 
        OnRowDeleting="GridView1_RowDeleting" 
        OnRowCommand="GridView1_RowCommand"
        CssClass="table" 
        ShowFooter="true">
        <Columns>


            <asp:BoundField DataField="Cat_id" HeaderText="Category ID" Visible="false" /> 



            <asp:TemplateField HeaderText="Category Number">
            <ItemTemplate>
                <asp:Label ID="lblLineNumber" runat="server"></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>



            <asp:TemplateField HeaderText="Category Name">
                <ItemTemplate>
                    <%# Eval("Name") %> <!-- syntax is used to bind data from a data source to a control on a page
                                            Eval is a method that retrieves the value of a field from the data source-->
                </ItemTemplate>


                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' /> <!-- Bind: Can also be used for two-way data binding, 
                                                                                            such as when editing values.-->
                </EditItemTemplate>


                <FooterTemplate>
                    <asp:TextBox ID="txtAddName" runat="server" Text=""/>
                </FooterTemplate>
           </asp:TemplateField>
            


          <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>

                    <asp:Button 
                        ID="btnEdit" 
                        runat="server" 
                        CommandName="Edit" 
                        Text="Edit" 
                        CssClass="btn btn-edit"/>

                    <asp:Button 
                        ID="btnDelete" 
                        runat="server" 
                        CommandName="Delete" 
                        Text="Delete" 
                        CssClass="btn btn-delete" />
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
                        CssClass="btn btn-cancel"/>
                </EditItemTemplate>

              <FooterTemplate>
                  <asp:Button
                        ID="btnAdd" 
                        runat="server" 
                        Text="Add New Product" 
                        CommandName="Add" 
                        CssClass="btn btn-add" />

              </FooterTemplate>
            
              </asp:TemplateField>
            
        </Columns>
        



    </asp:GridView>
        </div>



</div>
    
    
</asp:Content>







