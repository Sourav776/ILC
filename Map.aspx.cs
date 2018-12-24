using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Map : System.Web.UI.Page
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
            
            loginLink.Visible = false;
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
            addUser.Visible = true;
            dl.Visible = true;
            adminPanel.Visible = true;
            //deployLink.Visible = true;
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
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
        SqlDataReader dr;
        SqlCommand cmd;
        con.Open();
        string output = "";
        string status = "";
        string ID = "";
        string active = "";

        string FetchData = "Select * from Location Order by RecNo";
        cmd = new SqlCommand(FetchData, con);
        dr = cmd.ExecuteReader();

        while (dr.Read())
        {

            output = output + dr[4].ToString() + "," + dr[7].ToString() + "," + dr[8].ToString() + ",";
            status = status + dr[10].ToString() + ",";
            ID = ID + dr[6].ToString() + ",";
            active = active + dr[11].ToString() + ",";
        }
        active = active.Remove(active.Length - 1);
        ID = ID.Remove(ID.Length - 1);
        status = status.Remove(status.Length - 1);
        output = output.Remove(output.Length - 1);
        information.InnerText = output;
        st.InnerText = status;
        ilcid.InnerText = ID;
        activepc.InnerText = active;

        using (SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString()))
        {
            SqlDataReader dr2;
            SqlCommand cmd2;
            con2.Open();
            int off = 0;
            string onStatus = "SELECT COUNT(*) FROM Location WHERE CStatus = 1";
            cmd2 = new SqlCommand(onStatus, con2);
            dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                onStatusH4.InnerHtml = "Currently Active ILC   " + dr2[0].ToString();
                off = 640 - int.Parse(dr2[0].ToString());
                offStatusH4.InnerHtml = "Currently Inactive ILC " + off;
            }
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