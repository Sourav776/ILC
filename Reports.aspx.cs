using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Configuration;


public partial class Reporting : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = "";
        string userType = "";
        if (Session["userName"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            username = Session["userName"].ToString();
            userName.Text = Session["userName"].ToString();
            userType = Session["userType"].ToString();
            mapLink.Visible = true;
            faqLink.Visible = true;
        }
        if (userType == null)
        {
            Response.Redirect("Default.aspx");
        }
        else if(userType == "Super-Admin")
        {
            user.InnerText = "Super-Admin";
            adminPanel.Visible = true;
            addUser.Visible = true;
            downloadLink.Visible = true;
            allSchoolTR.Visible = true;
            specificSchoolTR.Visible = true;
            currentILCStatusTR.Visible = true;
            CurrentSpecificILCStatusTR.Visible = true;
            //dateWiseILCStatusTR.Visible = true;
            //distWiseTodaysILCStatusTR.Visible = true;
            //divWiseTodaysILCStatusTR.Visible = true;
            ilcRankingTR.Visible = true;
            dateWiseILCStatusDetailsTR.Visible = true;
            dateWiseAllILCStatusTR.Visible = true;
        }
        else if (userType == "Sesip-Admin")
        {
            user.InnerText = "Sesip-Admin";
            adminPanel.Visible = true;
            addUser.Visible = true;
            downloadLink.Visible = true;
            allSchoolTR.Visible = true;
            specificSchoolTR.Visible = true;
            currentILCStatusTR.Visible = true;
            CurrentSpecificILCStatusTR.Visible = true;
            //dateWiseILCStatusTR.Visible = true;
            //distWiseTodaysILCStatusTR.Visible = true;
            //divWiseTodaysILCStatusTR.Visible = true;
            ilcRankingTR.Visible = true;
            dateWiseILCStatusDetailsTR.Visible = true;
            dateWiseAllILCStatusTR.Visible = true;
        }
        else if(userType == "Programmer")
        {
            user.InnerText = "Programmer";
            addUser.Visible = true;
            downloadLink.Visible = true;
            allSchoolTR.Visible = true;
            specificSchoolTR.Visible = true;
            CurrentSpecificILCStatusTR.Visible = true;
            //dateWiseILCStatusTR.Visible = true;
            //distWiseTodaysILCStatusTR.Visible = true;
            //divWiseTodaysILCStatusTR.Visible = true;
            dateWiseILCStatusDetailsTR.Visible = true;
        }
        else if (userType == "Assistant-Programmer")
        {
            user.InnerText = "Assistant-Programmer";
            downloadLink.Visible = true;
            allSchoolTR.Visible = true;
            specificSchoolTR.Visible = true;
            CurrentSpecificILCStatusTR.Visible = true;
            //dateWiseILCStatusTR.Visible = true;
            //distWiseTodaysILCStatusTR.Visible = true;
            dateWiseILCStatusDetailsTR.Visible = true;
        }
        else if (userType == "ILC-Admin")
        {
            faqLink.Visible = false;
            user.InnerText = "ILC-Admin";
            specificSchoolTR.Visible = true;
            CurrentSpecificILCStatusTR.Visible = true;
            dateWiseILCStatusDetailsTR.Visible = true;
        }
    }
    protected void logoutLB_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }

    protected void rptAllSchoolBTN_Click(object sender, EventArgs e)
    {
        string filename = "All ILC Information Details Report";
        TrackReportGeneration.Add(filename);
        Response.Redirect("AllSchoolDetails.aspx");
    }

    protected void rptSpecificSchoolBTN_Click(object sender, EventArgs e)
    {
        string filename = "Specific ILC Information Report";
        TrackReportGeneration.Add(filename);
        Response.Redirect("SpecificSchoolDetails.aspx");
    }
    protected void rptDateWiseILCStatusBTN_Click(object sender, EventArgs e)
    {
        string filename = "Specific ILC Information Report";
        TrackReportGeneration.Add(filename);
        Response.Redirect("DateWiseILCStatus.aspx");
    }
    protected void rptDistWiseTodaysILCStatus_Click(object sender, EventArgs e)
    {
        string filename = "District Wise ILC Status Report";
        TrackReportGeneration.Add(filename);
        Response.Redirect("DistWiseILCStatusForToday.aspx");
    }
    protected void rptDivWiseTodaysILCStatus_Click(object sender, EventArgs e)
    {
        string filename = "Division Wise ILC Status Report";
        TrackReportGeneration.Add(filename);
        Response.Redirect("DivWiseILCStatusForToday.aspx");
    }
    protected void rptCurrentILCStatusBTN_Click(object sender, EventArgs e)
    {
        TrackReportGeneration.Add("Current ILC Status of All School");
        Response.Redirect("CurrentILCStatus.aspx");
    }
    protected void rptCurrentSpecificILCStatus_Click(object sender, EventArgs e)
    {
        Response.Redirect("CurrentSpecificILCStatus.aspx");
    }
    protected void rptILCRanking_Click(object sender, EventArgs e)
    {
        TrackReportGeneration.Add("ILC Ranking");
        Response.Redirect("ILCRanking.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void dateWiseILCStatusDetailsBTN_Click(object sender, EventArgs e)
    {
        TrackReportGeneration.Add("Date Wise Detailed ILC Status");
        Response.Redirect("DateWiseDetailUserReport.aspx");
    }
    protected void dateWiseAllILCStatus_Click(object sender, EventArgs e)
    {
        TrackReportGeneration.Add("Date Wise All ILC Status");
        Response.Redirect("DateWiseAllILCStatus.aspx");
    }
}