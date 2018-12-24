using System;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userType = "";
        string userName = "";
        if (Session["userName"] != null)
        {
            userName = Session["userName"].ToString();
            userType = Session["userType"].ToString();
            loginLink.Visible = false;
            logoutLink.Visible = true;
            reportsLink.Visible = true;
            faqLink.Visible = true;
        }
        if (userType == null)
        {
            user.InnerText = "";
        }
        else if (userType == "Super-Admin")
        {
            addinfoLink.Visible = true;
            dl.Visible = true;
            addUser.Visible = true;
            mapLink.Visible = true;
            adminPanel.Visible = true;
            //deployLink.Visible = true;
            user.InnerText = "Super-Admin";
        }
        else if (userType == "Sesip-Admin")
        {
            addinfoLink.Visible = true;
            dl.Visible = true;
            addUser.Visible = true;
            mapLink.Visible = true;
            adminPanel.Visible = true;
            //deployLink.Visible = true;
            user.InnerText = "Sesip-Admin";
        }
        else if (userType == "Programmer")
        {
            addinfoLink.Visible = true;
            dl.Visible = true;
            addUser.Visible = true;
            mapLink.Visible = true;
            //deployLink.Visible = true;
            user.InnerText = "Programmer";
        }
        else if (userType == "Assistant-Programmer")
        {
            addinfoLink.Visible = true;
            dl.Visible = true;
            mapLink.Visible = true;
            //deployLink.Visible = true;
            user.InnerText = "Assistant-Programmer";
        }
        else if (userType == "ILC-Admin")
        {
            faqLink.Visible = false;
            addinfoLink.Visible = true;
            mapLink.Visible = true;
            user.InnerText = "ILC-Admin";
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