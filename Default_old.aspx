<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <%-- Responsive meta tags --%>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    
    <%-- To refresh the page after 900 seconds --%>
    <meta http-equiv="refresh" content="900"/>

    <%-- Bootstrap Core CSS and Themes References --%>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <link href="css/bootstrap-theme.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet"/>

    <title>আইএলসি নেটওয়ার্ক মনিটরিং</title>
    
    <%-- Custom CSS File --%>
    <link href="css/footerStyle.css" rel="stylesheet" />

    <%-- Animation CSS --%>
    <link href="css/animate.css" rel="stylesheet" />

</head>

<body>
    <form id="form1" runat="server">
        <header>
		    <div class="container-fluid headerlogo">
			    <div class="row">
				    <div class="col-md-2">
					    <img class="govlogo animated bounceInLeft" src="img/gov_logo.png" />
				    </div>
				    <div class="col-md-8 name fix">
					    <h4>Government of the People's Republic of Bangladesh</h4>
					    <a href="http://sesip.gov.bd">SECONDARY EDUCATION SECTOR INVESTMENT PROGRAM (SESIP)</a>
					    <h4>Directorate of Secondary and Higher Education</h4>
                        <h3>Technical Support for ICT Learning Centers(ILC) Network Operations</h3>
				    </div>
				    <div class="col-md-2">
					    <img class="sesiplogo  animated bounceInRight" src="img/sesip_logo.png" />
				    </div>
			    </div>
		    </div>
	    </header>
        <header class="headerfix">
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
                                        <li class="active"><a href="Default.aspx">Home<span class="sr-only">(current)</span></a></li>
                                        <li><a id="userHomeLink" href="UserHome.aspx" runat="server" visible="false">User Home</a></li>
                                        <li><a id="addinfoLink" href="AddInfo.aspx" runat="server" visible="false">Add Information</a></li>
                                        <li id="addUser" visible="false" runat="server"><a href="UserRegistration.aspx">Add User</a></li>
                                        <li id="dl" visible="false" runat="server"><a href="Download.aspx">Download</a></li>
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
                                <!-- /.navbar-collapse -->

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
                <div class="col-md-12">
                </div>

                <div style="padding-left: 16px">
                    <h2 align="center">Welcome to SESIP</h2>
                    <p></p>
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <center>
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <img  alt="Paris" class="center" src="img/shikkha.jpg" width="100">
                        </div>
                        <div class="col-md-12">
                            <p>Secondary Education Sector Development Plan (SE-SDP) was developed in 1998 with the Technical Assistance of ADB to develop the secondary education sector as a whole. </p>

                            <p>Secondary Education Sector Improvement Project (SESIP) implemented (1999- 2007) as the first slice of SESDP and Secondary Education Sector Development Project (2007- 2013) taken as a follow-up. Secondary Education Sector Investment Program is taken based on the inputs of the mentioned previous projects. It will be implemented through program approach (treasury model). </p> 

                            <p>The program has been taken under a multi-tranche financing arrangement with ADB amounting US$ 500 million for 10 years. The program is aimed at developing Sector Wide Approach (SWAP).</p>
                        </div>
                    </div>
			    </center>
            </div>
        </div>



      <footer  class="footerrfix">
		<div class="container-fluid">
			<div class="row">
				<center>
					<br />
					<hr>
					<div class="col-md-12 footer-copyright text-center text-black-50 py-3 footerheight">
					</div>
					<div class="col-md-12 footer-copyright text-center text-black-50 py-3">
						<p class="textcopyright">Copyright 2018 © Secondary Education Sector Investment Program (SESIP)</p>
					</div>
				</center>
			</div>
		</div>
	</footer>


        <script src="js/jquery.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
    </form>

</body>
</html>

