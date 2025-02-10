<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="AirplaneTracking.Customer.Layout.Shared.Header" %>


<link href="/CSS/CustShared.css" rel="stylesheet" type="text/css" />
<!-- to load all the icons-->
<link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>



<header>
    <asp:ScriptManager ID="hmmm" runat="server" />
</header>

<body>

    <div class="Header">

        <div class="Logo">
            <img src="/Images/RJ-logo-new.png" alt="Royal Jordanian Airlines Logo" />
            <%--<img src="\CSS\2.png" />--%>
        </div>
       
        

        <%--<div class="SearchBox">
            <asp:TextBox ID="SearchBox" runat="server" placeholder="Search..." CssClass="SearchField" />
            <img id="SearchIcon" src="\Images\SearchIcon.png" style="width: 30px; height: 30px; color: white;" />
        </div>--%>





        <div class="ProfileCart">

            <asp:Label runat="server" ID="txtWelcome" Visible="false" Style="color: white; font-size: 20px; margin-right: 20px;" />


            <div class="OrderHistoryIcon">
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                        <%--OnClick="btnOrdersHistory_Click"--%>
                        <%--the ClientIDMode is used to make the id static and use it everywhere--%>
                        <asp:LinkButton ID="btnOrdersHistory" ClientIDMode="Static" runat="server" OnClientClick="OrdersHistoryDis();">
                History
                        </asp:LinkButton>
                    </ContentTemplate>

                </asp:UpdatePanel>

            </div>


            <div class="CartIcon">
                <asp:UpdatePanel runat="server" ID="MYUDATED">
                    <ContentTemplate>

                        <%--<asp:Button ID="btnCartIcon" runat="server" OnClick="btnCartIcon_Click" OnClientClick="CartDis();" />--%>

                        <asp:LinkButton ID="btnCartIcon" runat="server" OnClick="btnCartIcon_Click" OnClientClick="CartDis();">
                            <i class='bx bx-cart-alt'  ></i>
                        </asp:LinkButton>
                    </ContentTemplate>

                </asp:UpdatePanel>

            </div>


            <a href="~/Customer/Layout/Login.aspx" runat="server" id="Login"><i class='bx bx-user'></i>Sign in </a>
            <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click" CssClass="Logout">
                    <i class='bx bx-log-out'  ></i> Logout
            </asp:LinkButton>

        </div>



    </div>

</body>


<script>
    function CartDis() {
        let CartIcon = document.querySelector('.CartIcon');
        let Cart = document.querySelector('.Cart');
        let Container = document.querySelector('.Container');
        /*let Close = document.querySelector('.ContentPlaceHolder3_Close');*/


        CartIcon.addEventListener('click', () => {
            Cart.classList.add('active');
        })

        Close.addEventListener('click', () => {
            Cart.classList.remove('active');
            Cart.style.transition = 'right 2s ease';
        })
    }





    function OrdersHistoryDis() {
        let OrdersHistoryIcon = document.querySelector('.OrderHistoryIcon');
        let OrdersHistory = document.querySelector('.OrdersHistory');
        let Container = document.querySelector('.Container');
        let Close = document.getElementById('btnClose');


        OrdersHistoryIcon.addEventListener('click', () => {
            OrdersHistory.classList.add('active');
        })

        Close.addEventListener('click', () => {
            OrdersHistory.classList.remove('active');
            OrdersHistory.style.transition = 'right 2s ease';
        })
    }

</script>






