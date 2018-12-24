﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reporting" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

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
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet"/>

    <title>আইএলসি নেটওয়ার্ক মনিটরিং</title>

    <%-- Custom CSS File --%>
    <link href="~/css/style.css" rel="stylesheet" />
    <link href="~/css/footerStyle.css" rel="stylesheet" />

    <%-- Animation CSS --%>
    <link href="css/animate.css" rel="stylesheet" />

    <style>
        .test{
            text-decoration: none;
            font-style:normal;
        }
    </style>

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
                                        <li><a href="Default.aspx">Home<span class="sr-only">(current)</span></a></li>
                                        <li class="active"><a href="Reports.aspx">Reports<span class="sr-only">(current)</span></a></li>
                                        <li id="mapLink" visible="false" runat="server"><a href="Map.aspx">Map</a></li>
                                        <li id="addInfoLink"><a href="AddInfo.aspx">Add Information</a></li>
                                        <li  id="addUser" visible="false" runat="server"><a href="UserRegistration.aspx">Add User</a></li>
                                        <li id="downloadLink" runat="server" visible="false"><a href="Download.aspx">Download</a></li>
                                        <li id="faqLink" visible="false" runat="server"><a href="faq.aspx">FAQ</a></li>
                                        <li id="adminPanel" visible="false" runat="server"><a href="AdminPanel.aspx">Admin Panel</a></li>
                                        <li><a href="About.aspx">About</a></li>
                                        <%--<li id="deployLink" visible="false" runat="server"><a href="deploy.aspx">Deploy Status</a></li>--%>
                                    </ul>
                                    <ul class="nav navbar-nav navbar-right">
                                        <li>
                                            <a id="user" href="#" runat="server"></a>
                                        </li>
                                        <li id="logoutLink" runat="server" visible="true">
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
            <div class="row">
                <div class="col-md-12">
                </div>

                <div style="padding-left: 16px">
                    <h2 align="center">Welcome
                        <asp:Label ID="userName" runat="server" Text=""></asp:Label></h2>
                    <p></p>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div style="padding-left: 16px">
                    <CR:CrystalReportViewer ID="crvAllSchool" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" ToolPanelView="None" />
                </div>
            </div>
        </div>

       <center>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                </div>

                <div style="padding-left: 16px">
                    <h2>প্রতিবেদনসমূহ</h2>
                    <p></p>
                </div>
            </div>
        </div>
        </center>

        <div class="container fullbody">
            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-6 table-responsive">
                    <table border="2" class="table">
                        <tr id="allSchoolTR" class="success table-tr" visible="false" runat="server">
                            <td>
                                <asp:LinkButton ID="rptAllSchoolBTN" OnClick="rptAllSchoolBTN_Click" CssClass="test" runat="server" >আইসিটি লার্নিং সেন্টারের তালিকা</asp:LinkButton>
                            </td>
                        </tr>
                        <tr id="specificSchoolTR" class="success table-tr" visible="false" runat="server">
                            <td>
                                <asp:LinkButton ID="rptSpecificSchoolBTN" OnClick="rptSpecificSchoolBTN_Click" runat="server">নির্দিষ্ট আইসিটি লার্নিং সেন্টারের তথ্য</asp:LinkButton>
                            </td>
                        </tr>
                        <tr id="currentILCStatusTR" class="success table-tr" visible="false" runat="server">
                            <td>
                                <asp:LinkButton ID="rptCurrentILCStatusBTN" OnClick="rptCurrentILCStatusBTN_Click" runat="server">আইসিটি লার্নিং সেন্টারের এই মুহূর্তের স্ট্যাটাস</asp:LinkButton>
                            </td>
                        </tr>
                       <tr id="CurrentSpecificILCStatusTR" class="success table-tr" visible="false" runat="server">
                            <td>
                                <asp:LinkButton ID="rptCurrentSpecificILCStatus" OnClick="rptCurrentSpecificILCStatus_Click" runat="server">বর্তমানে নির্দিষ্ট আইসিটি লার্নিং সেন্টারের স্ট্যাটাস</asp:LinkButton>
                            </td>
                        </tr>
                        <tr id="CurrentAllILCStatusTR" class="success table-tr" visible="false" runat="server">
                            <td>
                                <asp:LinkButton ID="CurrentAllILCStatus" OnClick="CurrentAllILCStatus_Click" runat="server">বর্তমানে সকল আইসিটি লার্নিং সেন্টারের স্ট্যাটাস</asp:LinkButton>
                            </td>
                        </tr>
<%--                        <tr id="dateWiseILCStatusTR" class="success table-tr" visible="false" runat="server">
                            <td>
                                <asp:LinkButton ID="rptDateWiseILCStatusBTN" OnClick="rptDateWiseILCStatusBTN_Click" runat="server">তারিখ অনুযায়ী আইসিটি লার্নিং সেন্টারের স্ট্যাটাস</asp:LinkButton>
                            </td>
                        </tr>--%>
                        <tr id="dateWiseILCStatusDetailsTR" class="success table-tr" visible="false" runat="server">
                            <td>
                                <asp:LinkButton ID="dateWiseILCStatusDetailsBTN" OnClick="dateWiseILCStatusDetailsBTN_Click" runat="server">তারিখ অনুযায়ী আইসিটি লার্নিং সেন্টারের বিস্তারিত স্ট্যাটাস</asp:LinkButton></td>
                        </tr>
                        <tr id="dateWiseAllILCStatusTR" class="success table-tr" visible="false" runat="server">
                            <td>
                                <asp:LinkButton ID="dateWiseAllILCStatus" OnClick="dateWiseAllILCStatus_Click" runat="server">তারিখ অনুযায়ী সকল আইসিটি লার্নিং সেন্টারের সার্ভারের স্ট্যাটাস</asp:LinkButton>
                            </td>
                        </tr>
<%--                        <tr id="distWiseTodaysILCStatusTR" class="success table-tr" visible="false" runat="server">
                            <td>
                                <asp:LinkButton ID="rptDistWiseTodaysILCStatus" runat="server">জেলা অনুযায়ী আজকের আইএলসি স্ট্যাটাস</asp:LinkButton>
                            </td>
                        </tr>
                        <tr id="divWiseTodaysILCStatusTR" class="success table-tr" visible="false" runat="server">
                            <td>
                                <asp:LinkButton ID="rptDivWiseTodaysILCStatus" runat="server">বিভাগ অনুযায়ী আজকের আইএলসি স্ট্যাটাস</asp:LinkButton>
                            </td>
                        </tr>--%>
                        <tr id="ilcRankingTR" class="success table-tr" visible="false" runat="server">
                            <td>
                                <asp:LinkButton ID="rptILCRanking" OnClick="rptILCRanking_Click" runat="server">আইসিটি লার্নিং সেন্টারের র‍্যাঙ্কিং</asp:LinkButton>
                            </td>
                        </tr>
                    </table>

                </div>
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
