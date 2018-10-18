<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateInfo.aspx.cs" Inherits="UpdateInfo" %>
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
   
    <%-- Custom css for centering table --%>
<%--    <style>
        tr, th {
            text-align: center;
        }
    </style>--%>

    <%-- Custom CSS File --%>
    <link href="~/css/footerStyle.css" rel="stylesheet" />
    <link href="~/css/style.css" rel="stylesheet" />

    <%-- Animation CSS --%>
    <link href="css/animate.css" rel="stylesheet" />

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
                                        <li class="active"><a id="addinfoLink" href="AddInfo.aspx" runat="server" visible="false"><span class="sr-only">(current)</span>Add Information</a></li>
                                        <li visible="false" id="addUser" runat="server"><a href="UserRegistration.aspx">Add User</a></li>
                                        <li id="dl" visible="false" runat="server"><a href="Download.aspx">Download</a></li>
                                        <li id="faqLink" visible="false" runat="server"><a href="faq.aspx">FAQ</a></li>
                                        <li id="adminPanel" visible="false" runat="server"><a href="AdminPanel.aspx">Admin Panel</a></li>
                                        <li><a href="About.aspx">About</a></li>
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
            <div class="row">
            </div>
        </div>
             <div class="container fullbody">
		<div class="row">

            <div class="col-xs-12">
                <asp:GridView ID="updateInfoGV" runat="server" DataSourceID="updateInfoSDS" AutoGenerateColumns="False" DataKeyNames="ILCID">
                    <Columns>
                        <asp:CommandField ShowEditButton="True"></asp:CommandField>
                        <asp:BoundField DataField="ILCID" HeaderText="ILCID" SortExpression="ILCID" ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="SchoolName" HeaderText="SchoolName" SortExpression="SchoolName"></asp:BoundField>
                        <asp:BoundField DataField="SchoolAddress" HeaderText="SchoolAddress" SortExpression="SchoolAddress"></asp:BoundField>
                        <asp:BoundField DataField="HeadmasterName" HeaderText="HeadmasterName" SortExpression="HeadmasterName"></asp:BoundField>
                        <asp:BoundField DataField="HeadPhone" HeaderText="HeadPhone" SortExpression="HeadPhone"></asp:BoundField>
                        <asp:BoundField DataField="HeadMail" HeaderText="HeadMail" SortExpression="HeadMail"></asp:BoundField>
                        <asp:BoundField DataField="TrainerName" HeaderText="TrainerName" SortExpression="TrainerName"></asp:BoundField>
                        <asp:BoundField DataField="TrainerPhone" HeaderText="TrainerPhone" SortExpression="TrainerPhone"></asp:BoundField>
                        <asp:BoundField DataField="TrainerEmail" HeaderText="TrainerEmail" SortExpression="TrainerEmail"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="updateInfoSDS" ConnectionString='<%$ ConnectionStrings:ILCDBConnectionString %>' DeleteCommand="DELETE FROM [ILCInfo] WHERE [ILCID] = @original_ILCID AND (([SchoolName] = @original_SchoolName) OR ([SchoolName] IS NULL AND @original_SchoolName IS NULL)) AND (([SchoolAddress] = @original_SchoolAddress) OR ([SchoolAddress] IS NULL AND @original_SchoolAddress IS NULL)) AND (([HeadmasterName] = @original_HeadmasterName) OR ([HeadmasterName] IS NULL AND @original_HeadmasterName IS NULL)) AND (([HeadPhone] = @original_HeadPhone) OR ([HeadPhone] IS NULL AND @original_HeadPhone IS NULL)) AND (([HeadMail] = @original_HeadMail) OR ([HeadMail] IS NULL AND @original_HeadMail IS NULL)) AND (([TrainerName] = @original_TrainerName) OR ([TrainerName] IS NULL AND @original_TrainerName IS NULL)) AND (([TrainerPhone] = @original_TrainerPhone) OR ([TrainerPhone] IS NULL AND @original_TrainerPhone IS NULL)) AND (([TrainerEmail] = @original_TrainerEmail) OR ([TrainerEmail] IS NULL AND @original_TrainerEmail IS NULL))" InsertCommand="INSERT INTO [ILCInfo] ([ILCID], [SchoolName], [SchoolAddress], [HeadmasterName], [HeadPhone], [HeadMail], [TrainerName], [TrainerPhone], [TrainerEmail]) VALUES (@ILCID, @SchoolName, @SchoolAddress, @HeadmasterName, @HeadPhone, @HeadMail, @TrainerName, @TrainerPhone, @TrainerEmail)" SelectCommand="SELECT [ILCID], [SchoolName], [SchoolAddress], [HeadmasterName], [HeadPhone], [HeadMail], [TrainerName], [TrainerPhone], [TrainerEmail] FROM [ILCInfo] WHERE ([ILCID] = @ILCID)" UpdateCommand="UPDATE [ILCInfo] SET [SchoolName] = @SchoolName, [SchoolAddress] = @SchoolAddress, [HeadmasterName] = @HeadmasterName, [HeadPhone] = @HeadPhone, [HeadMail] = @HeadMail, [TrainerName] = @TrainerName, [TrainerPhone] = @TrainerPhone, [TrainerEmail] = @TrainerEmail WHERE [ILCID] = @original_ILCID AND (([SchoolName] = @original_SchoolName) OR ([SchoolName] IS NULL AND @original_SchoolName IS NULL)) AND (([SchoolAddress] = @original_SchoolAddress) OR ([SchoolAddress] IS NULL AND @original_SchoolAddress IS NULL)) AND (([HeadmasterName] = @original_HeadmasterName) OR ([HeadmasterName] IS NULL AND @original_HeadmasterName IS NULL)) AND (([HeadPhone] = @original_HeadPhone) OR ([HeadPhone] IS NULL AND @original_HeadPhone IS NULL)) AND (([HeadMail] = @original_HeadMail) OR ([HeadMail] IS NULL AND @original_HeadMail IS NULL)) AND (([TrainerName] = @original_TrainerName) OR ([TrainerName] IS NULL AND @original_TrainerName IS NULL)) AND (([TrainerPhone] = @original_TrainerPhone) OR ([TrainerPhone] IS NULL AND @original_TrainerPhone IS NULL)) AND (([TrainerEmail] = @original_TrainerEmail) OR ([TrainerEmail] IS NULL AND @original_TrainerEmail IS NULL))" ConflictDetection="CompareAllValues" OldValuesParameterFormatString="original_{0}">
                    <DeleteParameters>
                        <asp:Parameter Name="original_ILCID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_SchoolName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_SchoolAddress" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_HeadmasterName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_HeadPhone" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_HeadMail" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_TrainerName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_TrainerPhone" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_TrainerEmail" Type="String"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ILCID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="SchoolName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="SchoolAddress" Type="String"></asp:Parameter>
                        <asp:Parameter Name="HeadmasterName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="HeadPhone" Type="String"></asp:Parameter>
                        <asp:Parameter Name="HeadMail" Type="String"></asp:Parameter>
                        <asp:Parameter Name="TrainerName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="TrainerPhone" Type="String"></asp:Parameter>
                        <asp:Parameter Name="TrainerEmail" Type="String"></asp:Parameter>
                    </InsertParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="ILCID" Name="ILCID" Type="String"></asp:QueryStringParameter>
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SchoolName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="SchoolAddress" Type="String"></asp:Parameter>
                        <asp:Parameter Name="HeadmasterName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="HeadPhone" Type="String"></asp:Parameter>
                        <asp:Parameter Name="HeadMail" Type="String"></asp:Parameter>
                        <asp:Parameter Name="TrainerName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="TrainerPhone" Type="String"></asp:Parameter>
                        <asp:Parameter Name="TrainerEmail" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_ILCID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_SchoolName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_SchoolAddress" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_HeadmasterName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_HeadPhone" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_HeadMail" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_TrainerName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_TrainerPhone" Type="String"></asp:Parameter>
                        <asp:Parameter Name="original_TrainerEmail" Type="String"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>
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

