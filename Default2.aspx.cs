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


public partial class Default2 : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    string userType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        datePickerFrom.Attributes.Add("autocomplete", "off");
        datePickerTo.Attributes.Add("autocomplete", "off");
        if (!IsPostBack)
        {

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
            rprt.Load(Server.MapPath("~/test.rpt"));
            rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
            SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
            SqlCommand cmdRpt = new SqlCommand("SP_ILC_Logged_On_User_Details", conRpt);
            cmdRpt.CommandType = CommandType.StoredProcedure;
            cmdRpt.Parameters.AddWithValue("@vDateFrom", fromDate);
            cmdRpt.Parameters.AddWithValue("@vDateTo", toDate);
            cmdRpt.Parameters.AddWithValue("@vILCID", ILCID);

            SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            rprt.SetDataSource(ds);
            crv.ReportSource = rprt;
            ParameterField field1 = this.crv.ParameterFieldInfo[0];
            ParameterDiscreteValue val1 = new ParameterDiscreteValue();
            val1.Value = fromDate;
            field1.CurrentValues.Add(val1);

            ParameterField field2 = this.crv.ParameterFieldInfo[1];
            ParameterDiscreteValue val2 = new ParameterDiscreteValue();
            val2.Value = toDate;
            field2.CurrentValues.Add(val2);
            ParameterField field3 = this.crv.ParameterFieldInfo[2];
            ParameterDiscreteValue val3 = new ParameterDiscreteValue();
            val3.Value = ILCID;
            field3.CurrentValues.Add(val3);
        }
    }
    protected void rptBTN_Click(object sender, EventArgs e)
    {
        //TrackReportGeneration.Add("Details Report");
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
        rprt.Load(Server.MapPath("~/test.rpt"));
        rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
        SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
        SqlCommand cmdRpt = new SqlCommand("SP_ILC_Logged_On_User_Details", conRpt);
        cmdRpt.CommandType = CommandType.StoredProcedure;
        
        cmdRpt.Parameters.AddWithValue("@vDateFrom", fromDate);
        cmdRpt.Parameters.AddWithValue("@vDateTo", toDate);
        cmdRpt.Parameters.AddWithValue("@vILCID", ILCID);
        
        SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        rprt.SetDataSource(ds);
        crv.ReportSource = rprt;
        ParameterField field1 = this.crv.ParameterFieldInfo[0];
        ParameterDiscreteValue val1 = new ParameterDiscreteValue();
        val1.Value = fromDate;
        field1.CurrentValues.Add(val1);

        ParameterField field2 = this.crv.ParameterFieldInfo[1];
        ParameterDiscreteValue val2 = new ParameterDiscreteValue();
        val2.Value = toDate;
        field2.CurrentValues.Add(val2);
        ParameterField field3 = this.crv.ParameterFieldInfo[2];
        ParameterDiscreteValue val3 = new ParameterDiscreteValue();
        val3.Value = ILCID;
        field3.CurrentValues.Add(val3);
    }
    protected void logoutLB_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}