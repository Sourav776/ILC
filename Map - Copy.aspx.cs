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
        }
        if (userType == null)
        {
            user.InnerText = "";
        }
        else if (userType == "Super-Admin")
        {
            addUser.Visible = true;
            user.InnerText = "Super-Admin";
        }
        else if (userType == "Sesip-Admin")
        {
            addUser.Visible = true;
            user.InnerText = "SESIP-Admin";
        }
        else if (userType == "Programmer")
        {
            user.InnerText = "Programmer";
        }
        else if (userType == "Assistant-Programmer")
        {
            user.InnerText = "Assistant-Programmer";
        }
        else if (userType == "ILC-Admin")
        {
            user.InnerText = "ILC-Admin";
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ILCDBConnectionString"].ToString());
        SqlDataReader dr;
        SqlCommand cmd;
        int number = 10;
        con.Open();
        string output = "";
        string status = "";
        string ID = "";
        string active = "";

        string FetchData = "Select * from Location";
        cmd = new SqlCommand(FetchData, con);
        dr = cmd.ExecuteReader();

        while (dr.Read())
        {

            output = output + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + ",";
            status = status + dr[6].ToString() + ",";
            ID = ID + dr[0].ToString() + ",";
            active = active + dr[7].ToString() + ",";
        }
        active = active.Remove(active.Length - 1);
        ID = ID.Remove(ID.Length - 1);
        status = status.Remove(status.Length - 1);
        output = output.Remove(output.Length - 1);
        information.InnerText = output;
        st.InnerText = status;
        ilcid.InnerText = ID;
        activepc.InnerText = active;
    }
    protected void logoutLB_Click(object sender, EventArgs e)
    {

        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}