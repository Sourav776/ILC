using System;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("server=SSD-10; database=ILCDB; uid= sa;pwd=sqladmin");
        SqlDataReader dr;
        SqlCommand cmd;
        int number = 10;
        con.Open();
        string output = "";
        string status = "";

        string FetchData = "Select * from Location";
        cmd = new SqlCommand(FetchData, con);
        dr = cmd.ExecuteReader();

        while (dr.Read())
        {

            output = output + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + ",";
            status = status + dr[6].ToString() + ",";
        }
        status = status.Remove(status.Length - 1);
        output = output.Remove(output.Length - 1);
        information.InnerText = output;
        st.InnerText = status;


    }
}