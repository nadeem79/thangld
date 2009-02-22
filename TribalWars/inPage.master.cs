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
    public DataRow village;

    public inPage()
    {
        this.Init += new EventHandler(inPage_Init);
    }

    void inPage_Init(object sender, EventArgs e)
    {

        DateTime start = DateTime.Now;
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
        if (object.Equals(Request["id"], null) || (!int.TryParse(Request["id"], out id)))
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
        cmdCheckOwner.CommandText = "select count(*) from villages where userid=@userid and id=@id";
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

        this.village = Village.refresh(id, start);

        SqlCommand cmdGetAttackCount = conn.CreateCommand();
        cmdGetAttackCount.CommandText = "select count(*) from movement where landing_time>=@landing_time and [to]=@id and type=2";
        cmdGetAttackCount.Parameters.Add("@id", SqlDbType.Int).Value = id;
        cmdGetAttackCount.Parameters.Add("@landing_time", SqlDbType.DateTime).Value = start;

        int attack_count = (int)cmdGetAttackCount.ExecuteScalar();

        conn.Close();

        this.lblCoord.Text = this.village["x"].ToString() + "|" + this.village["y"].ToString();
        this.currentVillage.Text = (string)this.village["name"];
        this.currentVillage.NavigateUrl = "village.aspx?id=" + id.ToString();

        this.wood.Text = this.village["wood"].ToString();
        this.clay.Text = this.village["clay"].ToString();
        this.iron.Text = this.village["iron"].ToString();
        this.iron_url.NavigateUrl = "iron.aspx?id=" + id.ToString();
        this.clay_url.NavigateUrl = "clay.aspx?id=" + id.ToString();
        this.wood_url.NavigateUrl = "wood.aspx?id=" + id.ToString();
        this.lblReport.NavigateUrl = "list_report.aspx?id=" + id.ToString();
        this.map.NavigateUrl = "map.aspx?id=" + id.ToString();

        this.resource.Text = Village.getMaxResource((int)this.village["storage"]).ToString();
        this.pop.Text = Village.getMaxPopulation((int)this.village["farm"]).ToString();
        this.res_url.NavigateUrl = "resource.aspx?id=" + id.ToString();
        this.pop_url.NavigateUrl = "population.aspx?id=" + id.ToString();

        if (attack_count > 0)
        {
            this.incoming.Text = "<td><table class='navi-border' style='margin: auto; border-collapse: collapse;'><tbody><tr><td><table class='box' cellspacing='0'><tbody><tr><td align='center' height='20' width='60'><img src='images/att.png' alt=''/> (" + attack_count.ToString() + ")</td></tr></tbody></table></td></tr></tbody></table></td>";
        }

        DateTime stop = DateTime.Now;
        this.delay.Text = (stop - start).Milliseconds.ToString();
        this.time.Text = start.ToString("dd/MM/yyyy hh:mm:ss");
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}