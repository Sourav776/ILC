using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class faq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dateTB.Text = DateTime.Now.Date.ToShortDateString();
        }
        dateTB.Attributes.Add("autocomplete", "off");
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
            Response.Redirect("Default.aspx");
            faqLink.Visible = false;
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
    protected void submitBTN_Click(object sender, EventArgs e)
    {
        string name = nameTB.Text;
        string ILCID = ILCIDTB.Text;
        string problem = problemTB.InnerText;
        string date = dateTB.Text;
        string username = Session["userName"].ToString();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
        SqlDataReader dr;
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO tblFaq ([name],[username],[problem],[ILCID],[date]) VALUES (@name, @username, @problem, @ILCID, @date)", con);
        
        cmd.Parameters.AddWithValue("ILCID", ILCID);
        cmd.Parameters.AddWithValue("name", name);
        cmd.Parameters.AddWithValue("problem", problem);
        cmd.Parameters.AddWithValue("date", date);
        cmd.Parameters.AddWithValue("username", username);
        cmd.ExecuteNonQuery();
        con.Close();
        clear();
        
    }
    protected void clear()
    {
        nameTB.Text = "";
        ILCIDTB.Text = "";
        problemTB.InnerText = "";
    }
}