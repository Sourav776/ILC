using System;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userType = "";
        string userName = "";
        if (Session["userName"] == null)
        {
            user.InnerText = "";
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
            user.InnerText = "";
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
            user.InnerText = "ILC-Admin";
        }
    }
    protected void submitBTN_Click(object sender, EventArgs e)
    {
        //Get input value
        string userName = usernameTB.Value;
        string password = passwordTB.Value;

        //Establish Database Connection
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
        SqlDataReader dr;
        SqlCommand cmd;
        con.Open();
        string query = "SELECT username, password, role, tblUser.divCode, tblUser.ILCID, tblUser.distCode, tblDistrict.DistName, tblDivision.Latitude, tblDivision.Longitude FROM tblUser LEFT JOIN tblDistrict ON tblUser.distCode = tblDistrict.DistCode LEFT JOIN tblDivision ON tblDistrict.DivCode = tblDivision.DivCode WHERE username = '" + userName + "' and password = '" + password + "'";
        cmd = new SqlCommand(query, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
                    HttpContext.Current.Session.Add("userName", userName);
                    HttpContext.Current.Session.Add("userType", dr[2].ToString());
                    HttpContext.Current.Session.Add("divCode", dr[3].ToString());
                    HttpContext.Current.Session.Add("ein", dr[4].ToString());
                    HttpContext.Current.Session.Add("distCode", dr[5].ToString());
                    HttpContext.Current.Session.Add("distName", dr[6].ToString());
                    HttpContext.Current.Session.Add("latitude", dr[7].ToString());
                    HttpContext.Current.Session.Add("longitude", dr[8].ToString());
                    Response.Redirect("Map.aspx");
        }
    }
    protected void logoutLB_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}