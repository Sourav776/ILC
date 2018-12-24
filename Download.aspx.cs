using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = "";
        string userType = "";
        string userName = "";
        if (Session["userName"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            username = Session["userName"].ToString();
            userType = Session["userType"].ToString();
        }
        if (Session["userName"] != null)
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
            adminPanel.Visible = true;
            addUser.Visible = true;
            adminPanel.Visible = true;
            //deployLink.Visible = true;
            user.InnerText = "Super-Admin";
            ilcAdmin.Visible = true;
            sesipAdmin.Visible = true;
            ap.Visible = true;
            p.Visible = true;
        }
        else if (userType == "Sesip-Admin")
        {
            adminPanel.Visible = true;
            addUser.Visible = true;
            adminPanel.Visible = true;
            //deployLink.Visible = true;s
            user.InnerText = "Sesip-Admin";
            ilcAdmin.Visible = true;
            sesipAdmin.Visible = true;
            ap.Visible = true;
            p.Visible = true;
        }
        else if (userType == "Programmer")
        {
            addUser.Visible = true;
            //deployLink.Visible = true;
            user.InnerText = "Programmer";
            ilcAdmin.Visible = true;
            ap.Visible = true;
            p.Visible = true;
        }
        else if (userType == "Assistant-Programmer")
        {
            //deployLink.Visible = true;
            user.InnerText = "Assistant-Programmer";
            ilcAdmin.Visible = true;
            ap.Visible = true;
        }
        else if (userType == "ILC-Admin")
        {
            faqLink.Visible = false;
            Response.Redirect("Default.aspx");
            ilcAdmin.Visible = true;
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