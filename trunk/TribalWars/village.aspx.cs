using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class village : System.Web.UI.Page
{

    public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);
    

    protected void Page_Load(object sender, EventArgs e)
    {
        DataRow village;
        string sID = Request["id"];
        int id = int.Parse(sID);
        village = Village.refresh(id, DateTime.Now);
        
        this.headquarter.Text = village["headquarter"].ToString();
        this.barrack.Text = village["barracks"].ToString();
        this.stable.Text = village["stable"].ToString();
        this.workshop.Text = village["workshop"].ToString();
        this.academy.Text = village["academy"].ToString();
        this.smithy.Text = village["smithy"].ToString();
        this.rally.Text = village["rally"].ToString();
        this.market.Text = village["market"].ToString();
        this.timbercamp.Text = village["timbercamp"].ToString();
        this.claypit.Text = village["claypit"].ToString();
        this.ironmine.Text = village["ironmine"].ToString();
        this.storage.Text = village["storage"].ToString();
        this.farm.Text = village["farm"].ToString();
        this.hide.Text = village["hide"].ToString();
        this.wall.Text = village["wall"].ToString();
        this.name.Text = village["name"].ToString();
        this.clay.Text = Resource.production((int)village["claypit"]).ToString();
        this.wood.Text = Resource.production((int)village["timbercamp"]).ToString();
        this.iron.Text = Resource.production((int)village["ironmine"]).ToString();


        this.headquarter_url.NavigateUrl = "headquarter.aspx?id=" + sID;
        this.barrack_url.NavigateUrl = "barrack.aspx?id=" + sID;
        this.stable_url.NavigateUrl = "stable.aspx?id=" + sID;
        this.workshop_url.NavigateUrl = "workshop.aspx?id=" + sID;
        this.academy_url.NavigateUrl = "academy.aspx?id=" + sID;
        this.smithy_url.NavigateUrl = "smithy.aspx?id=" + sID;
        this.rally_url.NavigateUrl = "rally.aspx?id=" + sID;
        this.market_url.NavigateUrl = "market.aspx?id=" + sID;
        this.timbercamp_url.NavigateUrl = "wood.aspx?id=" + sID;
        this.claypit_url.NavigateUrl = "clay.aspx?id=" + sID;
        this.ironmine_url.NavigateUrl = "iron.aspx?id=" + sID;
        this.storage_url.NavigateUrl = "storage.aspx?id=" + sID;
        this.farm_url.NavigateUrl = "farm.aspx?id=" + sID;
        this.hide_url.NavigateUrl = "hide.aspx?id=" + sID;
        this.wall_url.NavigateUrl = "wall.aspx?id=" + sID;

        string troops = "";

        if ((int)village["spear"] > 0)
            troops += CreateTroopLabel("unit_spear.png", (int)village["spear"], "Spear fighters");
        if ((int)village["sword"] > 0)
            troops += CreateTroopLabel("unit_sword.png", (int)village["sword"], "Swordmen");
        if ((int)village["axe"] > 0)
            troops += CreateTroopLabel("unit_axe.png", (int)village["axe"], "Axemen");
        if ((int)village["scout"] > 0)
            troops += CreateTroopLabel("unit_spy.png", (int)village["scout"], "Scouts");
        if ((int)village["light"] > 0)
            troops += CreateTroopLabel("unit_light.png", (int)village["light"], "Light Cavalries");
        if ((int)village["heavy"] > 0)
            troops += CreateTroopLabel("unit_heavy.png", (int)village["heavy"], "Heavy Cavalries");
        if ((int)village["ram"] > 0)
            troops += CreateTroopLabel("unit_ram.png", (int)village["ram"], "Rams");
        if ((int)village["catapult"] > 0)
            troops += CreateTroopLabel("unit_catapult.png", (int)village["catapult"], "Catapults");
        if ((int)village["noble"] > 0)
            troops += CreateTroopLabel("unit_snob.png", (int)village["noble"], "Noblemen");

        this.lblTroops.Text = troops;

        
    }

    private string CreateTroopLabel(string image, int number, string name)
    {
        return "<tr><td><img src='images/" + image + "' /><strong> " + number.ToString() + "</strong> " + name + "</td></tr>";
    }
}
