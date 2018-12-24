<%@ Page Language="C#" AutoEventWireup="true" CodeFile="faq.aspx.cs" Inherits="faq" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <%-- Responsive meta tags --%>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />

    <%-- Bootstrap Core CSS and Themes References --%>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <link href="css/bootstrap-theme.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet"/>

    <title>আইএলসি নেটওয়ার্ক মনিটরিং</title>
   

    <%-- Custom CSS File --%>
    <link href="~/css/footerStyle.css" rel="stylesheet" />
    <link href="~/css/style.css" rel="stylesheet" />

    <%-- Animation CSS --%>
    <link href="css/animate.css" rel="stylesheet" />

    <%-- Date picker Jquery --%>
        <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#dateTB").datepicker();
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
                                        <li><a id="addinfoLink" href="AddInfo.aspx" runat="server" visible="false"><span class="sr-only">(current)</span>Add Information</a></li>
                                        <li visible="false" id="addUser" runat="server"><a href="UserRegistration.aspx">Add User</a></li>
                                        <li id="dl" visible="false" runat="server"><a href="Download.aspx">Download</a></li>
                                        <li class="active" id="faqLink" visible="false" runat="server"><a href="faq.aspx">FAQ</a></li>
                                        <li id="adminPanel" visible="false" runat="server"><a href="AdminPanel.aspx">Admin Panel</a></li>
                                        <li><a href="About.aspx">About</a></li>
                                        <%--<li id="deployLink" visible="false" runat="server"><a href="deploy.aspx">Deploy Status</a></li>--%>
                                    </ul>
                                    <ul class="nav navbar-nav navbar-right">
                                        <li>
                                            <a id="user" href="#" runat="server"></a>
                                        </li>
                                        <li id="loginLink" runat="server" visible="true">
                                            <a href="Login.aspx">Login</a>
                                        </li>
                                        <li id="logoutLink" runat="server" visible="false">
                                            <asp:LinkButton ID="logoutLB" OnClick="logoutLB_Click" runat="server">Logout</asp:LinkButton>
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
            <div class="panel-group" id="faqAccordion">
                <div class="panel panel-default ">
                    <div class="panel-heading accordion-toggle question-toggle collapsed" data-toggle="collapse" data-parent="#faqAccordion" data-target="#question0">
                         <h4 class="panel-title">
                            <a href="#" class="ing">Q: I did everything but the google map pointer isn’t turning green.</a>
                      </h4>

                    </div>
                    <div id="question0" class="panel-collapse collapse" style="height: 0px;">
                        <div class="panel-body">
                             <h5><span class="label label-primary">Answer</span></h5>

                            <p>
                                Once the file is generated, you have to wait for roughly 15 minutes. The process here is the file is generated then automatically get transferred into the central server. A process automatically picks up the file with '15 minutes' interval and updates the map.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default ">
                    <div class="panel-heading accordion-toggle collapsed question-toggle" data-toggle="collapse" data-parent="#faqAccordion" data-target="#question1">
                         <h4 class="panel-title">
                            <a href="#" class="ing">Q: I turned on all the laptops but some laptops are not showing up on the output text file.</a>
                      </h4>

                    </div>
                    <div id="question1" class="panel-collapse collapse" style="height: 0px;">
                        <div class="panel-body">
                             <h5><span class="label label-primary">Answer</span></h5>
                            <p>
                                At first find out which laptops are not showing up on the output text file. Then ping the server from those laptops. If ping failed check the internet connectivity. If ping is okay go to This PC and find 'Network' on the left panel. Click on it, a pop up will come, accept it.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default ">
                    <div class="panel-heading accordion-toggle collapsed question-toggle" data-toggle="collapse" data-parent="#faqAccordion" data-target="#question2">
                         <h4 class="panel-title">
                            <a href="#" class="ing">Q: Cannot access the Dashboard.</a>
                      </h4>

                    </div>
                    <div id="question2" class="panel-collapse collapse" style="height: 0px;">
                        <div class="panel-body">
                             <h5><span class="label label-primary">Answer</span></h5>

                            <p>
                                Please check your internet connection.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default ">
                    <div class="panel-heading accordion-toggle collapsed question-toggle" data-toggle="collapse" data-parent="#faqAccordion" data-target="#question3">
                         <h4 class="panel-title">
                            <a href="#" class="ing">Q: Cannot login into the Dashboard</a>
                      </h4>

                    </div>
                    <div id="question3" class="panel-collapse collapse" style="height: 0px;">
                        <div class="panel-body">
                             <h5><span class="label label-primary">Answer</span></h5>
                            <p>
                                Please recheck your login id and password. If you still can't login contact with the personnel from SESIP.
                            </p>
                        </div>
                    </div>
                </div>
                                <div class="panel panel-default ">
                    <div class="panel-heading accordion-toggle collapsed question-toggle" data-toggle="collapse" data-parent="#faqAccordion" data-target="#question4">
                         <h4 class="panel-title">
                            <a href="#" class="ing">Q: ILC UPS/IPS is out of order.</a>
                      </h4>

                    </div>
                    <div id="question4" class="panel-collapse collapse" style="height: 0px;">
                        <div class="panel-body">
                             <h5><span class="label label-primary">Answer</span></h5>
                            <p>
                                At every ILC there is a printed helpline number. For claiming warranty school authority or Assistant Programmers have to inform the Bidder first and inform SESIP simultaneously.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default ">
                    <div class="panel-heading accordion-toggle collapsed question-toggle" data-toggle="collapse" data-parent="#faqAccordion" data-target="#question5">
                         <h4 class="panel-title">
                            <a href="#" class="ing" style="color: red;">I want to report.</a>
                      </h4>

                    </div>
                    <div id="question5" class="panel-collapse collapse" style="height: 0px;">
                        <div class="panel-body">
                    <table border="2" class="table">
			    <tr class="success table-tr">
			    	<td>Name</td>
			    	<td>
                        <asp:TextBox ID="nameTB" runat="server" Width="450px"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="schoolNameRFV" runat="server"  ForeColor="Red" ErrorMessage="Please enter your name" ControlToValidate="nameTB"></asp:RequiredFieldValidator>
			    	</td>
			    </tr>
                 <tr class="table-tr">
			    	<td>ILCID</td>
                    <td>
                        <asp:TextBox ID="ILCIDTB" runat="server" Width="450px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="schoolIDRFV" runat="server"  ForeColor="Red" ErrorMessage="Please enter the EIN Number" ControlToValidate="ILCIDTB"></asp:RequiredFieldValidator>
                    </td>
			    </tr>
                <tr class="table-tr">
			    	<td>Date</td>
                    <td>
                        <asp:TextBox ID="dateTB" runat="server" Width="450px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="dateRFV" runat="server"  ForeColor="Red" ErrorMessage="Please enter the Date" ControlToValidate="dateTB"></asp:RequiredFieldValidator>
                    </td>
			    </tr>
                <tr class="table-tr">
			    	<td>Problem</td>
                    <td>
                        <textarea class="" cols="120" rows="5" id="problemTB" runat="server"></textarea>

                    </td>
			    </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="submitBTN" CssClass="btn btn-success" runat="server" Text="SEND" OnClick="submitBTN_Click" />
                    </td>
                </tr>
			  </table>
                        </div>
                    </div>
                </div>
                </div>
        
            </div>
        <!--/panel-group-->
       <div class="row">

			<div class="col-xs-12 table-responsive" >
<%--			  <table border="2" class="table">
			    <tr class="success table-tr">
			    	<td>Name</td>
			    	<td>
                        <asp:TextBox ID="nameTB" runat="server" Width="450px"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="schoolNameRFV" runat="server"  ForeColor="Red" ErrorMessage="Please enter your name" ControlToValidate="nameTB"></asp:RequiredFieldValidator>
			    	</td>
			    </tr>
                 <tr class="table-tr">
			    	<td>ILCID</td>
                    <td>
                        <asp:TextBox ID="ILCIDTB" runat="server" Width="450px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="schoolIDRFV" runat="server"  ForeColor="Red" ErrorMessage="Please enter the EIN Number" ControlToValidate="ILCIDTB"></asp:RequiredFieldValidator>
                    </td>
			    </tr>
                <tr class="table-tr">
			    	<td>Date</td>
                    <td>
                        <asp:TextBox ID="dateTB" runat="server" Width="450px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="dateRFV" runat="server"  ForeColor="Red" ErrorMessage="Please enter the Date" ControlToValidate="dateTB"></asp:RequiredFieldValidator>
                    </td>
			    </tr>
                <tr class="table-tr">
			    	<td>Problem</td>
                    <td>
                        <textarea class="" cols="120" rows="5" id="problemTB" runat="server"></textarea>

                    </td>
			    </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="submitBTN" CssClass="btn btn-success" runat="server" Text="SEND" OnClick="submitBTN_Click" />
                    </td>
                </tr>
			  </table>--%>

			</div>
		</div>

     <footer  class="footerrfix">
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

        <script src="js/jquery.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
    </form>
</body>
</html>