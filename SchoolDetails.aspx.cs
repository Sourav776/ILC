using System;
using System.Data.SqlClient;
using System.Configuration;

public partial class SchoolDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userType = "";
        string userName = "";
        string distCode = "";
        string divCode = "";
        if (Session["userName"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        if (Session["userName"] != null)
        {
            userName = Session["userName"].ToString();
            userType = Session["userType"].ToString();
            distCode = Session["distCode"].ToString();
            divCode = Session["divCode"].ToString();

            mapLink.Visible = true;
            logoutLink.Visible = true;
            reportsLink.Visible = true;
            addinfoLink.Visible = true;
            faqLink.Visible = true;
        }
        if (userType == null)
        {
            user.InnerText = "";
        }
        else if (userType == "Super-Admin")
        {
            adminPanel.Visible = true;
            downloadLink.Visible = true;
            addUser.Visible = true;
            user.InnerText = "Super-Admin";
        }
        else if (userType == "Sesip-Admin")
        {
            adminPanel.Visible = true;
            downloadLink.Visible = true;
            addUser.Visible = true;
            user.InnerText = "Sesip-Admin";
        }
        else if (userType == "Programmer")
        {
            downloadLink.Visible = true;
            addUser.Visible = true;
            user.InnerText = "Programmer";
        }
        else if (userType == "Assistant-Programmer")
        {
            downloadLink.Visible = true;
            user.InnerText = "Assistant-Programmer";
        }
        else if (userType == "ILC-Admin")
        {
            faqLink.Visible = false;
            user.InnerText = "ILC-Admin";
        }
        string id = "";
        if(Request.QueryString["ID"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            id = Request.QueryString["ID"];
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
        SqlDataReader dr;
        SqlCommand cmd;
        con.Open();
        string ILCID = "";
        string schoolName = "";
        string schoolAddress = "";
        string headName = "";
        string headPhone = "";
        string headEmail = "";
        string trainerName = "";
        string trainerPhone = "";
        string trainerEmail = "";
        string query = "SELECT * FROM ILCInfo WHERE ILCID ='"+ id + "'";

        cmd = new SqlCommand(query, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ILCID = dr[0].ToString();
            schoolName = dr[1].ToString();
            schoolAddress = dr[2].ToString();
            headName = dr[3].ToString();
            headPhone = dr[4].ToString();
            headEmail = dr[5].ToString();
            trainerName = dr[6].ToString();
            trainerPhone = dr[7].ToString();
            trainerEmail = dr[8].ToString();
        }
        con.Close();
        schoolnameH.InnerText = schoolName;
        schoolnameH2.InnerText = schoolName;
        ilcidH.InnerText = ILCID;
        addressTD.InnerHtml = schoolAddress;
        headNameTD.InnerHtml = headName;
        headPhoneTD.InnerHtml = headPhone;
        headEmailTD.InnerHtml = headEmail;
        trainerNameTD.InnerHtml = trainerName;
        trainerEmailTD.InnerHtml = trainerEmail;
        trainerPhoneTD.InnerHtml = trainerPhone;
    }
    protected void logoutLB_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }

    protected void backBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("Map.aspx");
    }
    protected void editBTN_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["ID"];
        Response.Redirect("UpdateInfo.aspx?ILCID=" + id);
    }
}