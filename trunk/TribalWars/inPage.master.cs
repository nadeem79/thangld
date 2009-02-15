using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class inPage : System.Web.UI.MasterPage
{

    public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        int count = 0;

        if (object.Equals(Session["username"], null))
        {
            Response.Redirect("index.aspx", true);
            return;
        }

        conn.Open();

        SqlCommand cmdCheckVillage = conn.CreateCommand();
        cmdCheckVillage.CommandText = "select count(id) from villages where userid=@userid";
        cmdCheckVillage.Parameters.Add("@userid", SqlDbType.NVarChar, 200).Value = (string)Session["username"];
        
        count = (int)cmdCheckVillage.ExecuteScalar();
        
        if (count == 0)
        {
            Decimal dVillageID = Map.CreateVillage((string)Session["username"]);
            conn.Close();
            Response.Redirect("village.aspx?id=" + dVillageID.ToString(), true);
            return;
        }

        int id;
        if (object.Equals(Request["id"], null)||int.TryParse(Request["id"], out id))
        {
            SqlCommand cmdGetFirstVillage = conn.CreateCommand();
            cmdGetFirstVillage.CommandText = "select top 1 id from villages where userid=@userid";
            cmdGetFirstVillage.Parameters.Add("@userid", SqlDbType.NVarChar, 200).Value = (string)Session["username"];
            id = (int)cmdGetFirstVillage.ExecuteScalar();
            conn.Close();
            Response.Redirect("village.aspx?id=" + id, true);
            return;
        }

        SqlCommand cmdCheckOwner = conn.CreateCommand();
        cmdCheckOwner.CommandText = "select * from villages where userid=@userid and id=@id";
        cmdCheckOwner.Parameters.Add("@userid", SqlDbType.NVarChar, 200).Value = (string)Session["username"];
        cmdCheckOwner.Parameters.Add("@id", SqlDbType.Int).Value = id;

        count = (int)cmdCheckOwner.ExecuteScalar();
        if (count == 0)
        {
            SqlCommand cmdGetFirstVillage = conn.CreateCommand();
            cmdGetFirstVillage.CommandText = "select top 1 id from villages where userid=@userid";
            cmdGetFirstVillage.Parameters.Add("@userid", SqlDbType.NVarChar, 200).Value = (string)Session["username"];
            id = (int)cmdGetFirstVillage.ExecuteScalar();
            conn.Close();
            Response.Redirect("village.aspx?id=" + id, true);
            return;
        }



        conn.Close();
    }
}
