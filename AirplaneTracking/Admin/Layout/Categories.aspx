<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Layout/Shared/AD.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="AirplaneTracking.Admin.Layout.Categories" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>









<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">



    <!-- Minimal CSS -->
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .meow {
            display: flex; /* Use Flexbox layout */
            align-items: center; /* Center items vertically */
            justify-content: space-between; /* Space items out */
            width: 500px;
        }

            .meow h2 {
                margin: 0; /* Remove default margin */
            }



        .container{
            position: absolute;
            top: 50%;
            left: 60%;
            transform: translate(-50%, -50%);
        }

        table {
            /*width: 100%;*/
            width: 500px;
            border-collapse: collapse;
            margin: 20px 0;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            padding: 10px;
            text-align: left;
        }

        th {
            background-color: lightskyblue;
            color: white;
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
    </style>








    <div class="container">
        <div class="meow">
            <h2>Categories</h2>
            <a href="#" class="btn btn-add">Add New Category</a>
        </div>


        <table>
            <thead>
                <tr>
                    <th>Number</th>
                    <th>Name</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <!-- Sample Row -->
                <asp:Repeater runat="server" ID="CatRepeater">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Cat_id") %></td>
                            <td><%# Eval("Name") %></td>
                            <td>
                                <a href="#" class="btn btn-edit">Edit</a>
                                <a href="#" class="btn btn-delete">Delete</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

                <!-- Additional rows will go here -->
            </tbody>
        </table>
    </div>










</asp:Content>


