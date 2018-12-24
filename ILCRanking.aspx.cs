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

public partial class ILCRankingTest : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    string userType = "";
    protected void Page_Init(object sender, EventArgs e)
    {
        datePickerFrom.Attributes.Add("autocomplete", "off");
        datePickerTo.Attributes.Add("autocomplete", "off");
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
            faqLink.Visible = false;
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
            //deployLink.Visible = true;
            user.InnerText = "Super-Admin";
        }
        else if (userType == "Sesip-Admin")
        {
            addUser.Visible = true;
            dl.Visible = true;
            adminPanel.Visible = true;
            //deployLink.Visible = true;
            user.InnerText = "Sesip-Admin";
        }
        else if (userType == "Programmer")
        {
            Response.Redirect("Default.aspx");
            addUser.Visible = true;
            dl.Visible = true;
            //deployLink.Visible = true;
            user.InnerText = "Programmer";
        }
        else if (userType == "Assistant-Programmer")
        {
            //Response.Redirect("Default.aspx");
            dl.Visible = true;
            //deployLink.Visible = true;
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
            datePickerFrom.Text = DateTime.Now.Date.ToShortDateString();
            datePickerTo.Text = DateTime.Now.Date.ToShortDateString();
        }
        else
        {
            //Getting the input values from front-end
            string fromDate = datePickerFrom.Text;
            string toDate = datePickerTo.Text;

            rprt.Load(Server.MapPath("~/rptILCRanking.rpt"));
            rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
            SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
            SqlCommand cmdRpt = new SqlCommand("SP_ILC_Ranking", conRpt);
            cmdRpt.CommandType = CommandType.StoredProcedure;
            cmdRpt.Parameters.AddWithValue("@vDateFrom", fromDate);
            cmdRpt.Parameters.AddWithValue("@vDateTo", toDate);
            SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            rprt.SetDataSource(ds);
            crv.ReportSource = rprt;

            ParameterField field2 = this.crv.ParameterFieldInfo[0];
            ParameterDiscreteValue val2 = new ParameterDiscreteValue();
            val2.Value = fromDate;
            field2.CurrentValues.Add(val2);
            ParameterField field3 = this.crv.ParameterFieldInfo[1];
            ParameterDiscreteValue val3 = new ParameterDiscreteValue();
            val3.Value = toDate;
            field3.CurrentValues.Add(val3);
            //rprt.Close();
            //rprt.Dispose();
        }
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
            //Getting the input values from front-end
            string fromDate = datePickerFrom.Text;
            string toDate = datePickerTo.Text;

            rprt.Load(Server.MapPath("~/rptILCRanking.rpt"));
            rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
            SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
            SqlCommand cmdRpt = new SqlCommand("SP_ILC_Ranking", conRpt);
            cmdRpt.CommandType = CommandType.StoredProcedure;
            cmdRpt.Parameters.AddWithValue("@vDateFrom", fromDate);
            cmdRpt.Parameters.AddWithValue("@vDateTo", toDate);
            SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            rprt.SetDataSource(ds);
            crv.ReportSource = rprt;

            ParameterField field2 = this.crv.ParameterFieldInfo[0];
            ParameterDiscreteValue val2 = new ParameterDiscreteValue();
            val2.Value = fromDate;
            field2.CurrentValues.Add(val2);
            ParameterField field3 = this.crv.ParameterFieldInfo[1];
            ParameterDiscreteValue val3 = new ParameterDiscreteValue();
            val3.Value = toDate;
            field3.CurrentValues.Add(val3);
    }
    protected void backBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reports.aspx");
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        rprt.Close();
        rprt.Dispose();
    }
}