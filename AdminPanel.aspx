<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPanel.aspx.cs" Inherits="AdminPanel" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%-- Responsive meta tags --%>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />

    <%-- Bootstrap Core CSS and Themes References --%>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <link href="css/bootstrap-theme.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" />

    <title>আইএলসি নেটওয়ার্ক মনিটরিং</title>

    <%-- Custom CSS File --%>
    <link href="~/css/style.css" rel="stylesheet" />
    <link href="~/css/footerStyle.css" rel="stylesheet" />

    <%-- Animation CSS --%>
    <link href="css/animate.css" rel="stylesheet" />

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datePickerFrom").datepicker();
            $("#datePickerTo").datepicker();
        });
    </script>

</head>

<body>
    <form id="form1" runat="server">
        <header>
		    <div class="container-fluid headerlogo">
			    <div class="row">
				    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
					    <img class="govlogo animated bounceInLeft" src="img/gov_logo.png" />
				    </div>
				    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 name fix">
					    <h4>Government of the People's Republic of Bangladesh</h4>
					    <a href="http://sesip.gov.bd"><b>SECONDARY EDUCATION SECTOR INVESTMENT PROGRAM (SESIP)</b></a>
					    <h4>Directorate of Secondary and Higher Education</h4>
                        <h3>ILC Dashboard</h3>
				    </div>
				    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
					    <img class="sesiplogo  animated bounceInRight" src="~/../img/sesip_logo.png" />
				    </div>
			    </div>
		    </div>
	    </header>
        <header>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12 headernav">

                        <nav class="navbar navbar-default">

                            <!-- Brand and toggle get grouped for better mobile display -->
                            <div class="navbar-header">
                                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                                    <span class="sr-only">Toggle navigation</span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                </button>
                            </div>

                            <!-- Collect the nav links, forms, and other content for toggling -->
                            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                                <ul class="nav navbar-nav">
                                    <li><a href="Default.aspx">Home</a></li>
                                    <li><a id="reportsLink" href="Reports.aspx" runat="server" visible="false">Reports</a></li>
                                    <li><a id="mapLink" href="Map.aspx" runat="server" visible="false">Map</a></li>
                                    <li><a id="addinfoLink" href="AddInfo.aspx" runat="server" visible="false">Add Information</a></li>
                                    <li visible="false" id="addUser" runat="server"><a href="UserRegistration.aspx">Add User</a></li>
                                    <li id="dl" visible="false" runat="server"><a href="Download.aspx">Download</a></li>
                                    <li id="faqLink" visible="false" runat="server"><a href="faq.aspx">FAQ</a></li>
                                    <li class="active" id="adminPanel" runat="server"><a href="AdminPanel.aspx">Admin Panel</a></li>
                                    <li><a href="About.aspx">About</a></li>
                                </ul>
                                <ul class="nav navbar-nav navbar-right">
                                    <li id="loginLink" runat="server" visible="true">
                                        <a href="Login.aspx">Login</a>
                                    </li>
                                    <li id="logoutLink" runat="server" visible="false">
                                        <asp:LinkButton ID="logoutLB" OnClick="logoutLB_Click" runat="server">Logout</asp:LinkButton>
                                    </li>
                                    <li>
                                        <a id="user" href="#" runat="server"></a>
                                    </li>
                                </ul>
                            </div>
                        </nav>

                        <p id="demo" align="right"></p>
                        <script>
                            var d = new Date();
                            document.getElementById("demo").innerHTML = d;
                        </script>

                    </div>
                </div>
            </div>

        </header>
        <div class="container">
            <div class="row">
            </div>
        </div>

        <center>
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div style="padding-left: 16px">
                            <br />
                            <br />
                            <table border="2" class="table">
                                <tr>
                                    <td>
                                        Admin Panel
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href="ap.aspx">Manage Assistant Programmers</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href="Programmers.aspx">Manage Programmers</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href="ilcadmins.aspx">Manage ILC-Admins</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                   </div>
                </div>
            </div>
        </center>

        <footer class="footerrfix">
            <div class="container-fluid">
                <div class="row">
                    <center>
					<br />
					<hr>
					<div class="col-md-12 footer-copyright text-center text-black-50 py-3">
						<p class="textcopyright">Copyright 2018 © Secondary Education Sector Investment Program (SESIP), Designed and developed by <a href="http://www.ddclbd.com" target="_blank" style="text-decoration: none; color: white;">DDCL</a></p>
					</div>
				</center>
                </div>
            </div>
        </footer>

    </form>

</body>
</html>