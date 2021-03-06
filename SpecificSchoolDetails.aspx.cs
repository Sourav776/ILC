﻿using System;
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


public partial class SpecificSchoolDetails : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadZoneDDL();
            LoadDistrictDDL();
            LoadILC();    
            
        }
        string ilcid = "";
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
            Response.Redirect("Default.aspx");
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
            user.InnerText = "ILC-Admin";
            ilcid = Session["ein"].ToString();
        }

        if(!IsPostBack)
        {
            
        }
        else
        {
            string ILCID = ilcDDL.SelectedValue.ToString();
            if(ILCID.Length != 0)
            {
                Session["ILCID"] = ILCID;
                rprt.Load(Server.MapPath("~/rptILCInfo.rpt"));
                rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
                SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
                SqlCommand cmdRpt = new SqlCommand("SP_ILC_Details_Information_Specific", conRpt);
                cmdRpt.CommandType = CommandType.StoredProcedure;
                cmdRpt.Parameters.AddWithValue("@vILCID", ILCID);
                SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                rprt.SetDataSource(ds);
                crv.ReportSource = rprt;
                ParameterField field1 = this.crv.ParameterFieldInfo[0];
                ParameterDiscreteValue val1 = new ParameterDiscreteValue();
                val1.Value = ILCID;
                field1.CurrentValues.Add(val1);
            }
        }
    }


    private void LoadZoneDDL()
    {

        ZoneDDL.DataSource = RetrieveZones();
        ZoneDDL.DataValueField = "DivCode";
        ZoneDDL.DataTextField = "Division";
        ZoneDDL.DataBind();
      
    }

    private void LoadDistrictDDL()
    {
        districtDDL.DataSource = RetrieveDistricts();
        districtDDL.DataValueField = "DistCode";
        districtDDL.DataTextField = "DistName";
        districtDDL.DataBind();
        
    }


    public static DataSet RetrieveZones()
    {
        //fetch the connection string from web.config
        string con = ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ConnectionString;

        //SQL statement to fetch countries
        string sql = @"SELECT Division, DivCode FROM tblDivision order by Division";

        DataSet dsZones = new DataSet();
        //Open SQL Connection
        using (SqlConnection conn = new SqlConnection(con))
        {
            conn.Open();
            //Initialize command object
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Fill the result set
                adapter.Fill(dsZones);
            }
        }

        return dsZones;
    }

    public static DataSet RetrieveDistricts()
    {
        //fetch the connection string from web.config
        string con = ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ConnectionString;

        //SQL statement to fetch countries
        string sql = @"SELECT DistCode, DistName FROM tblDistrict order by DistName";

        DataSet dsDistricts = new DataSet();
        //Open SQL Connection
        using (SqlConnection conn = new SqlConnection(con))
        {
            conn.Open();
            //Initialize command object
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Fill the result set
                adapter.Fill(dsDistricts);
            }
        }
        return dsDistricts;
    }
    private void LoadDis()
    {
        districtDDL.DataSource = RetrieveDisByZone(ZoneDDL.SelectedValue);
        districtDDL.DataValueField = "DistCode";
        districtDDL.DataTextField = "DistName";
        districtDDL.DataBind();
    }

    private void LoadILC()
    {
        ilcDDL.DataSource = RetrieveILCByDistrict(districtDDL.SelectedValue);
        ilcDDL.DataValueField = "ILCID";
        ilcDDL.DataTextField = "ILCEng";
        ilcDDL.DataBind();
    }


    public static DataSet RetrieveDisByZone(string DivCode)
    {
        string sql = "";
        //fetch the connection string from web.config
        string con = ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ConnectionString;
        if (DivCode=="ALL")
        {
            sql = @"SELECT DistName, DistCode FROM tblDistrict ORDER BY DistName";
        }
        else
        {
            sql = @"SELECT DistName, DistCode FROM tblDistrict  WHERE DivCode = '" + DivCode + "' ORDER BY DistName";
        }

        DataSet dsDis = new DataSet();
        //Open SQL Connection
        using (SqlConnection conn = new SqlConnection(con))
        {
            conn.Open();
            //Initialize command object
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Fill the result set
                adapter.Fill(dsDis);
            }
        }
        return dsDis;
    }
    public static DataSet RetrieveILCByDistrict(string distCode)
    {
        string sql = "";
        //fetch the connection string from web.config
        string con = ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ConnectionString;
        if (distCode == "100")
        {
            sql = @"SELECT ILCID, ILCEng FROM Location ORDER BY ILCEng";
        }
        else
        {
            sql = @"SELECT ILCID, ILCEng FROM Location WHERE distCode = '" + distCode + "' ORDER BY ILCEng";
        }

        DataSet dsILC = new DataSet();
        //Open SQL Connection
        using (SqlConnection conn = new SqlConnection(con))
        {
            conn.Open();
            //Initialize command object
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Fill the result set
                adapter.Fill(dsILC);
            }
        }
        return dsILC;
    }


    protected void districtDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadILC();
    }
    protected void ZoneDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDis();
    }
    protected void logoutLB_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
    protected void rptBTN_Click(object sender, EventArgs e)
    {
        TrackReportGeneration.Add("Specific School Details Report");
        string ILCID = ilcDDL.SelectedValue.ToString();
        Session["ILCID"] = ILCID;
        rprt.Load(Server.MapPath("~/rptILCInfo.rpt"));
        rprt.SetDatabaseLogon("sa", "sqladmin@123", "103.234.26.37", "SESIP", true);
        SqlConnection conRpt = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
        SqlCommand cmdRpt = new SqlCommand("SP_ILC_Details_Information_Specific", conRpt);
        cmdRpt.CommandType = CommandType.StoredProcedure;
        cmdRpt.Parameters.AddWithValue("@vILCID", ILCID);
        SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        rprt.SetDataSource(ds);
        crv.ReportSource = rprt;
        ParameterField field1 = this.crv.ParameterFieldInfo[0];
        ParameterDiscreteValue val1 = new ParameterDiscreteValue();
        val1.Value = ILCID;
        field1.CurrentValues.Add(val1);
    }
    protected void backBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reports.aspx");
    }
}