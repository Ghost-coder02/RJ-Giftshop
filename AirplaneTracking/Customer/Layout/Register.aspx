<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AirplaneTracking.Customer.Layout.Shared.Register" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>

    <!-- to load all the icons-->
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet' />


    <!-- link to te CSS file -->
    <link href="../../CSS/CustShared.css" rel="stylesheet" type="text/css" />


    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>

</head>



<body>
    <section class="whole">
         <div class="Logo" style="position: absolute;">
     <a href="MainPage.aspx">
         <img src="/Images/RJ-logo-new.png" alt="Royal Jordanian Airlines Logo" />
     </a>
     <%--<img src="\CSS\2.png" />--%>
 </div>

        <div class="RegisterContainer">

            <form id="form1" runat="server">
                <div class="RegInfo">
                    <h2>Register </h2>


                    <div class="Name">
                        <asp:TextBox runat="server" ID="FName" placeholder="First Name" />

                        <asp:TextBox runat="server" ID="LName" placeholder="Last Name" />
                    </div>


                    <div class="InputBox">
                        <asp:TextBox runat="server" ID="Username" placeholder="Username" />
                        <i class='bx bx-user-circle'></i>

                    </div>


                    <div class="InputBox">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" placeholder="Password" />
                        <i class='bx bx-lock-alt'></i>
                    </div>



                    <div class="GenNBD">
                        <asp:Label runat="server" ID="DateTitle">
                                    Date of Birth
                        </asp:Label>


                        <asp:DropDownList runat="server" ID="Gender">
                            <asp:ListItem Text="Select a Gender" Value="" style="color: black" />
                            <asp:ListItem Text="Female" Value="F" style="color: black" />
                            <asp:ListItem Text="Male" Value="M" style="color: black" />
                        </asp:DropDownList>
                    </div>


                    <div class="DatePicker">
                        <div class="DateField">
                            <asp:Label runat="server" ID="lblDay">Day</asp:Label>
                            <div class="InputGroup">

                                <%--&#9650; represents the arrow up icon for the box--%>
                                <%--<asp:Button runat="server" class="btnDayUp" Text="&#9650;▲" onclick="ChangeValue('Day', 1)" />--%>
                                <%-- <button type="button" class="ArrowUp" onclick="ChangeValue('Day', 1)"> &#9650;</button>--%>
                                <input runat="server" type="number" id="Day" name="Day" min="1" max="31" value="1" />
                                <%--&#9660; is used to show the arrow down--%>
                                <%--<asp:Button runat="server" ID="btnDayDown" Text="▼" onclick="ChangeValue('Day', -1)"/>--%>
                                <%-- <button type="button" class="ArrowDown" onclick="ChangeValue('Day', -1)" > &#9660;</button>--%>
                            </div>
                        </div>


                        <div class="DateField">
                            <asp:Label runat="server" ID="lblMonth">Month</asp:Label>

                            <div class="InputGroup">
                                <input runat="server" type="number" id="Month" name="Month" min="1" max="12" value="1" />
                            </div>
                        </div>



                        <div class="DateField">
                            <asp:Label runat="server" ID="lblYear">Year</asp:Label>

                            <div class="InputGroup">
                                <%--<button type="button" class="ArrowUp" onclick="ChangeValue('Year', 1)" >&#9650;</button>--%>
                                <input runat="server" type="number" id="Year" name="Year" min="1950" max="2100" value="2024" />
                                <%-- <button type="button" class="ArrowDown" onclick="ChangeValue('Year', -1)" > &#9660;</button>--%>
                            </div>
                        </div>





                        <%--<script>
                            /* this function takes two parameters field (the id for the HTML element) and increament (a number that will be added or sub from the value) */
                            function ChangeValue(field, increament) {

                                /* const is used to declare a variable, once a value is assigned to this variable it can't be re-assigned to any other value*/
                                /* it's just defined on the block scope */
                                /* getElementById is a built-in func to access the element */
                                const input = document.getElementById(field);

                                /* in let u can re-assign the variable to different values */
                                /* it's also just defined on the block scope */
                                /* this line reatrievs the value inside the field and convert it to a number, the 10 is the base which means it's a decimal*/
                                let Value = parseInt(input.Value, 10);


                                /* show the allowable emin and max values */
                                const minValue = parseInt(input.min, 10);
                                const maxValue = parseInt(input.max, 10);

                                Value += increament;
                                if (value >= minValue && Value <= maxValue) {
                                    input.value = Value;

                                }
                            }
                        </script>--%>


                        <%-- To add the date by using the calendar
                        <asp:TextBox runat="server" ID="BDDate" placeholder=" DD/MM/YY "></asp:TextBox>

                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $('#<%= BDDate.ClientID %>').datepicker({
                                    dateFormat: 'yy-mm-dd',
                                    changeMonth: true,
                                    changeYear: true,
                                    showAnim: 'slideDown',
                                    yearRange: "1950:2025"

                                });
                            }); 

                            </script>--%>
                    </div>





                    <div class="Phone">
                        <div class="Country">
                            <asp:DropDownList runat="server" ID="CountryDDL">
                                <asp:ListItem Text="country" Value="" style="color: black" />
                                <asp:ListItem Text="Jordan" Value="Jordan" style="color: black" />
                                <asp:ListItem Text="Japan" Value="Japan" style="color: black" />
                            </asp:DropDownList>

                        </div>


                        <div class="PhoneNumber">
                            <asp:DropDownList runat="server" ID="CountryCode">
                                <asp:ListItem Text="+962" Value="+962" />
                            </asp:DropDownList>
                            <asp:TextBox runat="server" ID="Number" placeholder="Phone Number" />
                        </div>
                    </div>





                    <div class="Address">
                        <asp:TextBox runat="server" ID="txtAddress" placeholder="where do u live weirdo 3>>>>>>" />

                    </div>

                </div>
                <div class="RegisterButton">
                    <asp:Button ID="Submit" runat="server" Text="Register" OnClick="Submit_Click"></asp:Button>
                    <br />
                    <asp:Label runat="server" ID="ErrLbl" Style="color: red;"></asp:Label>
                </div>



                <div class="LoginLink">
                    <p>Go back to the Login Page <a href="Login.aspx">Login </a></p>
                </div>


            </form>
        </div>
    </section>


</body>
</html>
