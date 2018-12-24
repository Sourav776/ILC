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

public partial class DateWiseDetailUserReport : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    string userType = "";
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadZoneDDL();
            LoadDistrictDDL();
            LoadILC();
        }

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
            ////deployLink.Visible = true;
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
            addUser.Visible = true;
            dl.Visible = true;
            //deployLink.Visible = true;
            user.InnerText = "Programmer";
        }
        else if (userType == "Assistant-Programmer")
        {
            dl.Visible = true;
            //deployLink.Visible = true;
            user.InnerText = "Assistant-Programmer";
        }
        else if (userType == "ILC-Admin")
        {
            faqLink.Visible = false;
            user.InnerText = "ILC-Admin";
            ilcNameLBL.Visible = false;
            ilcDDL.Visible = false;
        }

        if (!IsPostBack)
        {

        }
        else
        {
            //Getting the input values from front-end

            string ILCID = ilcDDL.SelectedValue.ToString();
            string fromDate = datePickerFrom.Text;
            string toDate = datePickerTo.Text;
            Session["ILCID"] = ILCID;
            rprt.Load(Server.MapPath("~/rptDateWiseDetailUser.rpt"));
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
        string dis = districtDDL.SelectedValue;
        string div = ZoneDDL.SelectedValue;
        ilcDDL.DataSource = RetrieveILCByDistrict(dis);
        ilcDDL.DataValueField = "ILCID";
        ilcDDL.DataTextField = "ILCEng";
        ilcDDL.DataBind();
        if (dis == null)
        {
            ilcDDL.DataSource = RetrieveILCByZone(div);
            ilcDDL.DataValueField = "ILCID";
            ilcDDL.DataTextField = "ILCEng";
            ilcDDL.DataBind();
        }
    }


    public static DataSet RetrieveDisByZone(string DivCode)
    {
        string sql = "";
        //fetch the connection string from web.config
        string con = ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ConnectionString;
        if (DivCode == "ALL")
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


    public static DataSet RetrieveILCByZone(string Div)
    {
        string sql = "";
        //fetch the connection string from web.config
        string con = ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ConnectionString;
        {
            sql = @"Select ILCID,ILCEng from Location A 
  Inner Join tblDistrict B On A.DistCode=B.DistCode
  Inner Join tblDivision C On B.DivCode=C.DivCode
  Where C.DivCode='" + Div + "' order by ILCEng";
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
        LoadILC();
    }
    protected void backBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reports.aspx");
    }
    protected void rptBTN_Click(object sender, EventArgs e)
    {
        //TrackReportGeneration.Add("Details Report");
        //Getting the input values from front-end
        string ILCID = ilcDDL.SelectedValue.ToString();
        string fromDate = datePickerFrom.Text;
        string toDate = datePickerTo.Text;
        Session["ILCID"] = ILCID;
        rprt.Load(Server.MapPath("~/rptDateWiseDetailUser.rpt"));
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
    protected void Page_Unload(object sender, EventArgs e)
    {
        rprt.Close();
        rprt.Dispose();
    }
}