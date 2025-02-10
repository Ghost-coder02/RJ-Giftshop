<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sidebar.ascx.cs" Inherits="AirplaneTracking.Admin.Layout.Shared.Sidebar" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Data.SqlClient" %>


<!-- to  add google fonts -->
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Dancing+Script:wght@400..700&family=Edu+AU+VIC+WA+NT+Hand:wght@400..700&family=Lora:ital,wght@0,400..700;1,400..700&family=Petit+Formal+Script&family=Playwrite+AT:ital,wght@0,100..400;1,100..400&family=Playwrite+CL:wght@100..400&display=swap" rel="stylesheet">


<link rel="stylesheet" type="text/css" href="/CSS/Shared.css" />

<!-- No need for <html>, <head>, and <body> tags in user controls -->

<aside class="Wrapper" >
    <div class="SidebarHeader">

        <img id="Logo" src="/Images/RJ-logo-new.png" alt="Royal Jordanian Airlines Logo" width="50" height="50" />

        <h6>
            RJ Shop Management Board
        </h6>

   </div>


    <ul class="Sidebar">

        <li>
            <a href="#">
                <img src="../../../Images/Icons/dashboard.png" alt="Dashboard " style="width:30px; height:30px;"/>
                <span class="nav-item">Dashboard</span>
            </a>
        </li>



        <li>
            <a href="jjj.aspx">
                <img src="../../../Images/Icons/categorization.png" alt="items" style="width:30px; height:30px;" />
                <span class="nav-item">Categories</span>
            </a>
        </li>


        <li>
            <a href="Products.aspx">
                <img src="../../../Images/Icons/skin-care.png" alt="items" style="width:30px; height:30px;" />
                <span class="nav-item">Products</span>
            </a>
        </li>


        <li>
            <a href="Orders.aspx">
                <%--../../../Images/order-delivery.png--%>
                <img src="../../../Images/Icons/order-delivery (1).png" alt="Orders" style="width:30px; height:30px;" />
                <span class="nav-item"> Orders </span>
            </a>
        </li>

    
    </ul>


    <div class="user-account">
            <div class="user-profile">
                <img src="/Images/layan2.jpg" alt="Profile Picture">

                <div class="user-detail">
                    <h3>Layan Alhassoon</h3>
                    <span>Administrator</span>
                </div>
            </div>
        </div>
            
</aside>



<script>
    function confirmLogout() {
        if (confirm("هل أنت متأكد انك تريد الخروج؟")) {
            window.location.href = "logout.aspx";
        }
    }
</script>

