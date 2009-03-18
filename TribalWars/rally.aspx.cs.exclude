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
using NHibernate;
using beans;
using NHibernate.Criterion;

public partial class rally : System.Web.UI.Page
{
    
    beans.Village village;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        inPage p = (inPage)this.Master;
        village = p.CurrentVillage;
        
        this.lblSpear.Text = village.TotalSpear.ToString();
        this.lblSword.Text = village.TotalSword.ToString();
        this.lblAxe.Text = village.TotalAxe.ToString();
        this.lblScout.Text = village.TotalScout.ToString();
        this.lblLight.Text = village.TotalLight.ToString();
        this.lblHeavy.Text = village.TotalHeavy.ToString();
        this.lblRam.Text = village.TotalRam.ToString();
        this.lblCatapult.Text = village.TotalCatapult.ToString();
        this.lblNoble.Text = village.TotalNoble.ToString();

        ISession session = NHibernateHelper.CreateSession();

        string sOutwardsCommand = "";
        foreach (MovingCommand outgoing in this.village.Outgoings)
        {
            sOutwardsCommand += "<tr><td><a href='command.aspx?id=" + this.village.ID.ToString() + "&command=" + outgoing.ID.ToString() + "'>";
            if (outgoing.Type==MoveType.Attack)
                sOutwardsCommand += "<img src='images/attack.png'/>Tấn công làng ";
            else if (outgoing.Type==MoveType.Support)
                sOutwardsCommand += "<img src='images/support.png'/>Hỗ trợ làng ";
            sOutwardsCommand += outgoing.To.Name + " (" + outgoing.To.X.ToString() + "|" + outgoing.To.Y.ToString() + ")</td>";
            sOutwardsCommand += "<td>" + outgoing.LandingTime.ToString() + "</td>";
            sOutwardsCommand += "<td><span class='timer'>" + Functions.FormatTime(outgoing.LandingTime - DateTime.Now) + "</span></td></tr>";
        }

        string sInwardsCommand = "";
        foreach (MovingCommand incoming in this.village.Incomings)
        {
            sInwardsCommand += "<tr><td><a href='command.aspx?id=" + this.village.ID.ToString() + "&command=" + outgoing.ID.ToString() + "'>";
            if (incoming.Type == MoveType.Attack)
                sInwardsCommand += "<img src='images/attack.png'/>Tấn công từ ";
            else if (incoming.Type == MoveType.Support)
                sInwardsCommand += "<img src='images/support.png'/>Hỗ trợ từ ";
            else if (incoming.Type == MoveType.Return)
                sInwardsCommand += "<img src='images/back.png'/>Quay về từ ";
            sInwardsCommand += incoming.To.Name + " (" + incoming.From.X.ToString() + "|" + incoming.From.Y.ToString() + ")</td>";
            sInwardsCommand += "<td>" + incoming.LandingTime.ToString() + "</td>";
            sInwardsCommand += "<td><span class='timer'>" + Functions.FormatTime(incoming.LandingTime - DateTime.Now) + "</span></td></tr>";
        }

        this.lblOutwardsCommand.Text = sOutwardsCommand;
        this.lblInwardsCommand.Text = sInwardsCommand;
        this.rally_link.NavigateUrl = "rally.aspx?id=" + this.village.ID;

        if (IsPostBack)
            return;

        int target;

        if (object.Equals(Request["target"], null) || !int.TryParse(Request["target"], out target))
        {
            this.x.Text = "";
            this.y.Text = "";
        }
        else
        {
            beans.Village targetVillage = session.Load<beans.Village>(target);
            if (target != null)
            {
                this.x.Text = targetVillage.X.ToString();
                this.y.Text = targetVillage.Y.ToString();
            }
        }

        session.Close();
        
    }
    

    protected void bttnAttack_Click(object sender, EventArgs e)
    {
        int spear, sword, axe, scout, light, heavy, ram, catapult, noble, x, y, i;
        try
        {
            spear = (int.TryParse(this.spear.Text, out i)) ? int.Parse(this.spear.Text) : 0;
            sword = (int.TryParse(this.sword.Text, out i)) ? int.Parse(this.sword.Text) : 0;
            axe = (int.TryParse(this.axe.Text, out i)) ? int.Parse(this.axe.Text) : 0;
            scout = (int.TryParse(this.scout.Text, out i)) ? int.Parse(this.scout.Text) : 0;
            light = (int.TryParse(this.light.Text, out i)) ? int.Parse(this.light.Text) : 0;
            heavy = (int.TryParse(this.heavy.Text, out i)) ? int.Parse(this.heavy.Text) : 0;
            ram = (int.TryParse(this.ram.Text, out i)) ? int.Parse(this.ram.Text) : 0;
            catapult = (int.TryParse(this.catapult.Text, out i)) ? int.Parse(this.catapult.Text) : 0;
            noble = (int.TryParse(this.noble.Text, out i)) ? int.Parse(this.noble.Text) : 0;

            this.lblAxe.Text = this.x.Text + "|" + this.y.Text;

            x = int.Parse(this.x.Text);
            y = int.Parse(this.y.Text);
        }
        catch (FormatException exc)
        {
            this.lblError.Text = "Nhập số";
            return;
        }

        if ((spear+sword+axe+scout+light+heavy+ram+catapult+noble)==0)
        {
            this.lblError.Text = "Nhập một loại quân";
            return;
        }

        this.Page_Load(sender, e);
        if (spear > (int)village["spear"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (sword > (int)village["sword"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (axe > (int)village["axe"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (scout > (int)village["scout"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (light > (int)village["light"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (heavy > (int)village["heavy"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (ram > (int)village["ram"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (catapult > (int)village["catapult"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (noble > (int)village["noble"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }

        SqlCommand cmdCheckVillage = conn.CreateCommand();
        cmdCheckVillage.CommandText = "select id from villages where x=@x and y=@y";
        cmdCheckVillage.Parameters.Add("@x", SqlDbType.Int).Value = x;
        cmdCheckVillage.Parameters.Add("@y", SqlDbType.Int).Value = y;

        

        this.conn.Open();
        object o = cmdCheckVillage.ExecuteScalar();
        if (object.Equals(o, null))
        {
            this.lblError.Text = "Toạ độ không tồn tại";
            this.conn.Close();
            return;
        }

        SqlCommand cmdCreateCommand = conn.CreateCommand();
        cmdCreateCommand.CommandText = "insert into movement ([from], [to], type, starting_time, landing_time, spear, sword, axe, scout, light, heavy, ram, catapult, noble) values (@from, @to, 2, @starting, @landing, @spear, @sword, @axe, @scout, @light, @heavy, @ram, @catapult, @noble)";
        cmdCreateCommand.Parameters.Add("@from", SqlDbType.Int).Value = this.village["id"];
        cmdCreateCommand.Parameters.Add("@to", SqlDbType.Int).Value = o;
        cmdCreateCommand.Parameters.Add("@starting", SqlDbType.DateTime).Value = DateTime.Now;
        cmdCreateCommand.Parameters.Add("@landing", SqlDbType.DateTime).Value = Map.LandingTime(1, (int)village["x"], (int)village["y"], x, y, DateTime.Now);
        cmdCreateCommand.Parameters.Add("@spear", SqlDbType.Int).Value = spear;
        cmdCreateCommand.Parameters.Add("@sword", SqlDbType.Int).Value = sword;
        cmdCreateCommand.Parameters.Add("@axe", SqlDbType.Int).Value = axe;
        cmdCreateCommand.Parameters.Add("@scout", SqlDbType.Int).Value = scout;
        cmdCreateCommand.Parameters.Add("@light", SqlDbType.Int).Value = light;
        cmdCreateCommand.Parameters.Add("@heavy", SqlDbType.Int).Value = heavy;
        cmdCreateCommand.Parameters.Add("@ram", SqlDbType.Int).Value = ram;
        cmdCreateCommand.Parameters.Add("@catapult", SqlDbType.Int).Value = catapult;
        cmdCreateCommand.Parameters.Add("@noble", SqlDbType.Int).Value = noble;
        cmdCreateCommand.ExecuteNonQuery();

        SqlCommand cmdUpdateVillage = conn.CreateCommand();
        cmdUpdateVillage.CommandText = "update villages set spear=@spear, sword=@sword, axe=@axe, scout=@scout, light=@light, heavy=@heavy, ram=@ram, catapult=@catapult, noble=@noble, last_update=@last_update where id=@id";

        cmdUpdateVillage.Parameters.Add("@id", SqlDbType.Int).Value = this.village["id"];
        cmdUpdateVillage.Parameters.Add("@spear", SqlDbType.Int).Value = (int)village["spear"] - spear;
        cmdUpdateVillage.Parameters.Add("@sword", SqlDbType.Int).Value = (int)village["sword"] - sword;
        cmdUpdateVillage.Parameters.Add("@axe", SqlDbType.Int).Value = (int)village["axe"] - axe;
        cmdUpdateVillage.Parameters.Add("@scout", SqlDbType.Int).Value = (int)village["scout"] - scout;
        cmdUpdateVillage.Parameters.Add("@light", SqlDbType.Int).Value = (int)village["light"] - light;
        cmdUpdateVillage.Parameters.Add("@heavy", SqlDbType.Int).Value = (int)village["heavy"] - heavy;
        cmdUpdateVillage.Parameters.Add("@ram", SqlDbType.Int).Value = (int)village["ram"] - ram;
        cmdUpdateVillage.Parameters.Add("@catapult", SqlDbType.Int).Value = (int)village["catapult"] - catapult;
        cmdUpdateVillage.Parameters.Add("@noble", SqlDbType.Int).Value = (int)village["noble"] - noble;
        cmdUpdateVillage.Parameters.Add("@last_update", SqlDbType.DateTime).Value = DateTime.Now;
        cmdUpdateVillage.ExecuteNonQuery();

        this.conn.Close();

        Response.Redirect("rally.aspx?id=" + Request["id"], true);
    }
    protected void bttnSupport_Click(object sender, EventArgs e)
    {
        int spear, sword, axe, scout, light, heavy, ram, catapult, noble, x, y, i;
        try
        {
            spear = (int.TryParse(this.spear.Text, out i)) ? int.Parse(this.spear.Text) : 0;
            sword = (int.TryParse(this.sword.Text, out i)) ? int.Parse(this.sword.Text) : 0;
            axe = (int.TryParse(this.axe.Text, out i)) ? int.Parse(this.axe.Text) : 0;
            scout = (int.TryParse(this.scout.Text, out i)) ? int.Parse(this.scout.Text) : 0;
            light = (int.TryParse(this.light.Text, out i)) ? int.Parse(this.light.Text) : 0;
            heavy = (int.TryParse(this.heavy.Text, out i)) ? int.Parse(this.heavy.Text) : 0;
            ram = (int.TryParse(this.ram.Text, out i)) ? int.Parse(this.ram.Text) : 0;
            catapult = (int.TryParse(this.catapult.Text, out i)) ? int.Parse(this.catapult.Text) : 0;
            noble = (int.TryParse(this.noble.Text, out i)) ? int.Parse(this.noble.Text) : 0;

            x = int.Parse(this.x.Text);
            y = int.Parse(this.y.Text);
        }
        catch (FormatException exc)
        {
            this.lblError.Text = "Nhập số";
            return;
        }

        if ((spear + sword + axe + scout + light + heavy + ram + catapult + noble) == 0)
        {
            this.lblError.Text = "Nhập một loại quân";
            return;
        }

        this.Page_Load(sender, e);
        if (spear > (int)village["spear"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (sword > (int)village["sword"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (axe > (int)village["axe"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (scout > (int)village["scout"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (light > (int)village["light"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (heavy > (int)village["heavy"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (ram > (int)village["ram"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (catapult > (int)village["catapult"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }
        if (noble > (int)village["noble"])
        {
            this.lblError.Text = "Không đủ quân";
            return;
        }

        SqlCommand cmdCheckVillage = conn.CreateCommand();
        cmdCheckVillage.CommandText = "select id from villages where x=@x and y=@y";
        cmdCheckVillage.Parameters.Add("@x", SqlDbType.Int).Value = x;
        cmdCheckVillage.Parameters.Add("@y", SqlDbType.Int).Value = y;



        this.conn.Open();
        object o = cmdCheckVillage.ExecuteScalar();
        if (object.Equals(o, null))
        {
            this.lblError.Text = "Toạ độ không tồn tại";
            this.conn.Close();
            return;
        }

        SqlCommand cmdCreateCommand = conn.CreateCommand();
        cmdCreateCommand.CommandText = "insert into movement ([from], [to], type, starting_time, landing_time, spear, sword, axe, scout, light, heavy, ram, catapult, noble) values (@from, @to, 3, @starting, @landing, @spear, @sword, @axe, @scout, @light, @heavy, @ram, @catapult, @noble)";
        cmdCreateCommand.Parameters.Add("@from", SqlDbType.Int).Value = this.village["id"];
        cmdCreateCommand.Parameters.Add("@to", SqlDbType.Int).Value = o;
        cmdCreateCommand.Parameters.Add("@starting", SqlDbType.DateTime).Value = DateTime.Now;
        cmdCreateCommand.Parameters.Add("@landing", SqlDbType.DateTime).Value = Map.LandingTime(1, (int)village["x"], (int)village["y"], x, y, DateTime.Now);
        cmdCreateCommand.Parameters.Add("@spear", SqlDbType.Int).Value = spear;
        cmdCreateCommand.Parameters.Add("@sword", SqlDbType.Int).Value = sword;
        cmdCreateCommand.Parameters.Add("@axe", SqlDbType.Int).Value = axe;
        cmdCreateCommand.Parameters.Add("@scout", SqlDbType.Int).Value = scout;
        cmdCreateCommand.Parameters.Add("@light", SqlDbType.Int).Value = light;
        cmdCreateCommand.Parameters.Add("@heavy", SqlDbType.Int).Value = heavy;
        cmdCreateCommand.Parameters.Add("@ram", SqlDbType.Int).Value = ram;
        cmdCreateCommand.Parameters.Add("@catapult", SqlDbType.Int).Value = catapult;
        cmdCreateCommand.Parameters.Add("@noble", SqlDbType.Int).Value = noble;
        cmdCreateCommand.ExecuteNonQuery();
        this.conn.Close();

        Response.Redirect("rally.aspx?id=" + Request["id"], true);
    }
}
