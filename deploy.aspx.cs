using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web;

public partial class deploy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
            user.InnerText = "ILC-Admin";
        }
    }
    protected void submitBTN_Click(object sender, EventArgs e)
    {
        string status = "";
        if(dashboardCB.Checked && relmCB.Checked)
        {
            status = "Both";
        }
        else if(dashboardCB.Checked && relmCB.Checked == false)
        {
            status = "Dashboard";
        }
        else if (relmCB.Checked && dashboardCB.Checked == false)
        {
            status = "ReLM";
        }

        string schoolID = schoolIDTB.Text;
        string teamViewerID = teamViewerIDTB.Text;
        string problem = problemTB.Text;
        string username = Session["userName"].ToString();
        string contact = contactTB.Text;
        string datetime = DateTime.Now.ToString();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
        SqlDataReader dr;
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO tblDeploy ([ILCID],[status],[problem],[TVID],[username],[contact],[time]) VALUES (@ILCID, @status, @problem, @TVID, @username, @contact, @time)", con);
        cmd.Parameters.AddWithValue("ILCID", schoolID);
        cmd.Parameters.AddWithValue("status", status);
        cmd.Parameters.AddWithValue("problem", problem);
        cmd.Parameters.AddWithValue("TVID", teamViewerID);
        cmd.Parameters.AddWithValue("username", username);
        cmd.Parameters.AddWithValue("contact", contact);
        cmd.Parameters.AddWithValue("time", datetime);
        cmd.ExecuteNonQuery();
        con.Close();
        clear();
    }

    protected void clear()
    {
        schoolIDTB.Text = "";
        teamViewerIDTB.Text = "";
        problemTB.Text = "";
        contactTB.Text = "";
    }
    protected void logoutLB_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}