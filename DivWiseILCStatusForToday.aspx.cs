using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data;

public partial class DivWiseILCStatusForToday : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        string userType = "";
        string userName = "";
        if (Session["userName"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            userName = Session["userName"].ToString();
            userType = Session["userType"].ToString();
            loginLink.Visible = false;
            logoutLink.Visible = true;
            reportsLink.Visible = true;
            addinfoLink.Visible = true;
            mapLink.Visible = true;
            faqLink.Visible = true;
        }
        if (userType == null)
        {
            Response.Redirect("Default.aspx");
        }
        else if (userType == "Super-Admin")
        {
            addUser.Visible = true;
            dl.Visible = true;
            adminPanel.Visible = true;
            user.InnerText = "Super-Admin";
        }
        else if (userType == "Sesip-Admin")
        {
            addUser.Visible = true;
            dl.Visible = true;
            adminPanel.Visible = true;
            user.InnerText = "Sesip-Admin";
        }
        else if (userType == "Programmer")
        {
            addUser.Visible = true;
            dl.Visible = true;
            user.InnerText = "Programmer";
        }
        else if (userType == "Assistant-Programmer")
        {
            Response.Redirect("Default.aspx");
            dl.Visible = true;
            user.InnerText = "Assistant-Programmer";
        }
        else if (userType == "ILC-Admin")
        {
            faqLink.Visible = false;
            Response.Redirect("Default.aspx");
            user.InnerText = "ILC-Admin";
        }
        if(!IsPostBack)
        {

        }
                else
        {
            string divisionName = ilcDivisionDDL.SelectedValue.ToString();

            rprt.Load(Server.MapPath("~/rptDivisionWiseTodaysILCReport.rpt"));
            rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
            SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
            SqlCommand cmdRpt = new SqlCommand("SP_ILC_Server_Active_Status_Division", conRpt);
            cmdRpt.CommandType = CommandType.StoredProcedure;
            cmdRpt.Parameters.AddWithValue("@vDivCode", divisionName);
            SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            rprt.SetDataSource(ds);
            crv.ReportSource = rprt;
            ParameterField field1 = this.crv.ParameterFieldInfo[0];
            ParameterDiscreteValue val1 = new ParameterDiscreteValue();
            val1.Value = divisionName;
            field1.CurrentValues.Add(val1);
        }
    }
    protected void backBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reports.aspx");
    }
    protected void logoutLB_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
    protected void rptBTN_Click(object sender, EventArgs e)
    {
        TrackReportGeneration.Add("Division wise wise ILC Status");
        string divisionName = ilcDivisionDDL.SelectedValue.ToString();

        rprt.Load(Server.MapPath("~/rptDivisionWiseTodaysILCReport.rpt"));
        rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
        SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
        SqlCommand cmdRpt = new SqlCommand("SP_ILC_Server_Active_Status_Division", conRpt);
        cmdRpt.CommandType = CommandType.StoredProcedure;
        cmdRpt.Parameters.AddWithValue("@vDivCode", divisionName);
        SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        rprt.SetDataSource(ds);
        crv.ReportSource = rprt;
        ParameterField field1 = this.crv.ParameterFieldInfo[0];
        ParameterDiscreteValue val1 = new ParameterDiscreteValue();
        val1.Value = divisionName;
        field1.CurrentValues.Add(val1);
    }
}