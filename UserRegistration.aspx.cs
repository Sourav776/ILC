using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userType = "";
        string userName = "";
        if (Session["userName"] == null)
        {
            Response.Redirect("Default.aspx");
        }
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
            Response.Redirect("Default.aspx");
        }
        else if (userType == "Super-Admin")
        {
            adminPanel.Visible = true;
            addinfoLink.Visible = true;
            dl.Visible = true;
            addUser.Visible = true;
            mapLink.Visible = true;
            adminPanel.Visible = true;
            user.InnerText = "Super-Admin";
        }
        else if (userType == "Sesip-Admin")
        {
            adminPanel.Visible = true;
            addinfoLink.Visible = true;
            dl.Visible = true;
            addUser.Visible = true;
            mapLink.Visible = true;
            adminPanel.Visible = true;
            user.InnerText = "Sesip-Admin";
        }
        else if (userType == "Programmer")
        {
            addinfoLink.Visible = true;
            dl.Visible = true;
            addUser.Visible = true;
            mapLink.Visible = true;
            user.InnerText = "Programmer";
        }
        else if (userType == "Assistant-Programmer")
        {
            Response.Redirect("Default.aspx");
            addinfoLink.Visible = true;
            dl.Visible = true;
            addUser.Visible = true;
            mapLink.Visible = true;
            user.InnerText = "Assistant-Programmer";
        }
        else if (userType == "ILC-Admin")
        {
            faqLink.Visible = false;
            Response.Redirect("Default.aspx");
            mapLink.Visible = true;
            user.InnerText = "ILC-Admin";
        }
    }
    protected void registerBTN_Click(object sender, EventArgs e)
    {
        string ein = einTB.Text;
        string username = usernameTB.Text;
        string phone = phoneTB.Text;
        string email = emailTB.Text;
        string password = passwordTB.Text;
        string usertype = "2";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
        con.Open();

        SqlCommand cmd = new SqlCommand("INSERT INTO [tblUser] ([username],[password],[phone],[email],[ILCID],[userType]) VALUES (@username, @password, @phone, @email, @ILCID, @userType)", con);
        cmd.Parameters.AddWithValue("username", username);
        cmd.Parameters.AddWithValue("password", password);
        cmd.Parameters.AddWithValue("phone", phone);
        cmd.Parameters.AddWithValue("email", email);
        cmd.Parameters.AddWithValue("ILCID", ein);
        cmd.Parameters.AddWithValue("userType", usertype);
        cmd.ExecuteNonQuery();
        con.Close();
        clear();
    }

    protected void clear()
    {
        einTB.Text = "";
        usernameTB.Text = "";
        phoneTB.Text = "";
        emailTB.Text = "";
        passwordTB.Text = "";
        reTypePasswordTB.Text = "";

    }
    protected void logoutLB_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}