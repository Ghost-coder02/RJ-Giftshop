<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AirplaneTracking.Customer.Layout.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <!-- to load all the icons-->
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet' />


    <link href="/CSS/CustShared.css" rel="stylesheet" type="text/css" />

</head>
<body>

    <section class="whole">
        <div class="Logo" style="position: absolute;">
            <a href="MainPage.aspx">
                <img src="/Images/RJ-logo-new.png" alt="Royal Jordanian Airlines Logo" />
            </a>
            <%--<img src="\CSS\2.png" />--%>
        </div>


        <div class="Login2">
            <form runat="server">

                <h1>Login</h1>


                <div class="InputBox">
                    <asp:TextBox ID="Username" runat="server" Placeholder="Username"></asp:TextBox>
                    <i class='bx bx-user-circle'></i>

                </div>



                <div class="InputBox">
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
                    <i class='bx bx-lock-alt'></i>
                </div>



                <div class="LoginButton">

                    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click"></asp:Button>
                    <br />
                    <asp:Label runat="server" ID="ErrLbl" Style="color: red;"></asp:Label>
                </div>



                <div class="RegisterLink">
                    <p>Create a new account? <a href="Register.aspx">Register </a></p>
                </div>
                __
        
            </form>
        </div>
    </section>




</body>
</html>
