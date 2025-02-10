<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AirplaneTracking.Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link rel="stylesheet" type="text/css" href="CSS\Default.css" />
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet' />

</head>
<body>
    <div class="Wrapper">

    <!--<div class="Wrapper">-->
        
        <form runat="server">
            
            <h1 class="Logo">Login</h1>
           

            <div class="InputBox">
                <asp:TextBox ID="Username" runat="server" Placeholder="Username"></asp:TextBox>
                <i class='bx bx-user-circle'></i>

            </div>
            
            

            <div class="InputBox">
                <asp:TextBox ID="Password" runat="server" TextMode="Password" Placeholder="Password" ></asp:TextBox>
                <i class='bx bx-lock-alt'></i>
            </div>

            

            <div class="LoginButton">
                
                <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click"></asp:Button>
                <br />
                <asp:Label runat="server" ID="ErrLbl" style="color:red;"></asp:Label>
            </div>
            
            

            <%--<div class="RegisterLink">
                <p> Create a new account? <a href="#"> Register </a> </p>
            </div>--%>
            <%------%>


            <asp:TextBox ID="Button1" runat="server" Text="Hello Dr.Moath" Visible="false"></asp:TextBox>
        </form>


        
    </div>




</body>
</html>
