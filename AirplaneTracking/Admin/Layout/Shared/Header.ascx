<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="AirplaneTracking.Admin.Layout.Shared.Header" %>

<link href="CSS/Shared.css" rel="stylesheet" type="text/css" />
<!-- to load all the icons-->
<link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>


<div class="Header">

    <h4> Hello Layan</h4>
        
    <div class="SearchBox">
        <asp:TextBox ID="SearchInput" runat="server" Placeholder="Search..." CssClass="SearchField"></asp:TextBox>
        <img id="nmnm" src="\Images\SearchIcon.png" style="width:30px; height:30px; color:white;" />
        <i class='bx bx-bell' style='color:#fffefe; font-size: 30px; transform: translateY(+40%);'  ></i>
        <%--<img id="Bell" src="https://cdn-icons-png.flaticon.com/128/15450/15450266.png"  />--%>
    </div>
    


    <%--<div class="Logout">
        <img src="/Images/Logout.png" class="LogoutLogo">
        <a href="/logout">Logout</a>
    </div>--%>


    <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click" CssClass="Logout">
        <i class='bx bx-log-out'  ></i> Logout
</asp:LinkButton>
    

</div>