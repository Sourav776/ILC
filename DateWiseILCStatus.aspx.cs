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


public partial class DateWiseILCStatus : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    string userType = "";
    protected void Page_Load(object sender, EventArgs e)
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
            dl.Visible = true;
            user.InnerText = "Assistant-Programmer";
        }
        else if (userType == "ILC-Admin")
        {
            faqLink.Visible = false;
            Response.Redirect("Reports.aspx");
            user.InnerText = "ILC-Admin";
            ilcNameLBL.Visible = false;
            ilcNameDDL.Visible = false;
        }
        if (!IsPostBack)
        {

        }
        else
        {
            if (userType == "ILC-Admin")
            {
                string fromDate = datePickerFrom.Text;
                string toDate = datePickerTo.Text;
                string ILCID = Session["ein"].ToString();
                rprt.Load(Server.MapPath("~/rptDateWiseILCStatus.rpt"));
                rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
                SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
                SqlCommand cmdRpt = new SqlCommand("SP_Date_Wise_ILC_Status", conRpt);
                cmdRpt.CommandType = CommandType.StoredProcedure;
                cmdRpt.Parameters.AddWithValue("@vILCID", ILCID);
                cmdRpt.Parameters.AddWithValue("@vDateFrom", fromDate);
                cmdRpt.Parameters.AddWithValue("@vDateTo", toDate);
                SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                rprt.SetDataSource(ds);
                crv.ReportSource = rprt;
                ParameterField field1 = this.crv.ParameterFieldInfo[0];
                ParameterDiscreteValue val1 = new ParameterDiscreteValue();
                val1.Value = ILCID;
                field1.CurrentValues.Add(val1);

                ParameterField field2 = this.crv.ParameterFieldInfo[1];
                ParameterDiscreteValue val2 = new ParameterDiscreteValue();
                val2.Value = fromDate;
                field2.CurrentValues.Add(val2);
                ParameterField field3 = this.crv.ParameterFieldInfo[2];
                ParameterDiscreteValue val3 = new ParameterDiscreteValue();
                val3.Value = toDate;
                field3.CurrentValues.Add(val3);
            }
            else
            {
                //Getting the input values from front-end
                string schoolName = ilcNameDDL.SelectedValue.ToString();
                string fromDate = datePickerFrom.Text;
                string toDate = datePickerTo.Text;
                string ILCID = "";
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
                SqlDataReader dr;
                SqlCommand cmd;
                con.Open();
                string query = "SELECT * FROM Location WHERE ILCEng = '" + schoolName + "'";
                cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ILCID = dr[6].ToString();
                }
                Session["ILCID"] = ILCID;
                con.Close();
                rprt.Load(Server.MapPath("~/rptDateWiseILCStatus.rpt"));
                rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
                SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
                SqlCommand cmdRpt = new SqlCommand("SP_Date_Wise_ILC_Status", conRpt);
                cmdRpt.CommandType = CommandType.StoredProcedure;
                cmdRpt.Parameters.AddWithValue("@vILCID", ILCID);
                cmdRpt.Parameters.AddWithValue("@vDateFrom", fromDate);
                cmdRpt.Parameters.AddWithValue("@vDateTo", toDate);
                SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                rprt.SetDataSource(ds);
                crv.ReportSource = rprt;
                ParameterField field1 = this.crv.ParameterFieldInfo[0];
                ParameterDiscreteValue val1 = new ParameterDiscreteValue();
                val1.Value = ILCID;
                field1.CurrentValues.Add(val1);

                ParameterField field2 = this.crv.ParameterFieldInfo[1];
                ParameterDiscreteValue val2 = new ParameterDiscreteValue();
                val2.Value = fromDate;
                field2.CurrentValues.Add(val2);
                ParameterField field3 = this.crv.ParameterFieldInfo[2];
                ParameterDiscreteValue val3 = new ParameterDiscreteValue();
                val3.Value = toDate;
                field3.CurrentValues.Add(val3);
            }
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
        TrackReportGeneration.Add("Date Wise ILC Status");
        if (userType == "ILC-Admin")
        {
            string fromDate = datePickerFrom.Text;
            string toDate = datePickerTo.Text;
            string ILCID = Session["ein"].ToString();
            rprt.Load(Server.MapPath("~/rptDateWiseILCStatus.rpt"));
            rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
            SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
            SqlCommand cmdRpt = new SqlCommand("SP_Date_Wise_ILC_Status", conRpt);
            cmdRpt.CommandType = CommandType.StoredProcedure;
            cmdRpt.Parameters.AddWithValue("@vILCID", ILCID);
            cmdRpt.Parameters.AddWithValue("@vDateFrom", fromDate);
            cmdRpt.Parameters.AddWithValue("@vDateTo", toDate);
            SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            rprt.SetDataSource(ds);
            crv.ReportSource = rprt;
            ParameterField field1 = this.crv.ParameterFieldInfo[0];
            ParameterDiscreteValue val1 = new ParameterDiscreteValue();
            val1.Value = ILCID;
            field1.CurrentValues.Add(val1);

            ParameterField field2 = this.crv.ParameterFieldInfo[1];
            ParameterDiscreteValue val2 = new ParameterDiscreteValue();
            val2.Value = fromDate;
            field2.CurrentValues.Add(val2);
            ParameterField field3 = this.crv.ParameterFieldInfo[2];
            ParameterDiscreteValue val3 = new ParameterDiscreteValue();
            val3.Value = toDate;
            field3.CurrentValues.Add(val3);

        }
        else
        {
            //Getting the input values from front-end
            string schoolName = ilcNameDDL.SelectedValue.ToString();
            string fromDate = datePickerFrom.Text;
            string toDate = datePickerTo.Text;
            string ILCID = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
            SqlDataReader dr;
            SqlCommand cmd;
            con.Open();
            string query = "SELECT * FROM Location WHERE ILCEng = '" + schoolName + "'";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ILCID = dr[6].ToString();
            }
            Session["ILCID"] = ILCID;
            con.Close();
            rprt.Load(Server.MapPath("~/rptDateWiseILCStatus.rpt"));
            rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
            SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
            SqlCommand cmdRpt = new SqlCommand("SP_Date_Wise_ILC_Status", conRpt);
            cmdRpt.CommandType = CommandType.StoredProcedure;
            cmdRpt.Parameters.AddWithValue("@vILCID", ILCID);
            cmdRpt.Parameters.AddWithValue("@vDateFrom", fromDate);
            cmdRpt.Parameters.AddWithValue("@vDateTo", toDate);
            SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            rprt.SetDataSource(ds);
            crv.ReportSource = rprt;
            ParameterField field1 = this.crv.ParameterFieldInfo[0];
            ParameterDiscreteValue val1 = new ParameterDiscreteValue();
            val1.Value = ILCID;
            field1.CurrentValues.Add(val1);

            ParameterField field2 = this.crv.ParameterFieldInfo[1];
            ParameterDiscreteValue val2 = new ParameterDiscreteValue();
            val2.Value = fromDate;
            field2.CurrentValues.Add(val2);
            ParameterField field3 = this.crv.ParameterFieldInfo[2];
            ParameterDiscreteValue val3 = new ParameterDiscreteValue();
            val3.Value = toDate;
            field3.CurrentValues.Add(val3);
        }
    }
}