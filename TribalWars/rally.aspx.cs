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

public partial class rally : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);
    DataRow village;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        inPage p = (inPage)this.Master;
        string sID = Request["id"];
        int id = int.Parse(sID);
        village = p.village;
        this.lblSpear.Text = village["spear"].ToString();
        this.lblSword.Text = village["sword"].ToString();
        this.lblAxe.Text = village["axe"].ToString();
        this.lblScout.Text = village["scout"].ToString();
        this.lblLight.Text = village["light"].ToString();
        this.lblHeavy.Text = village["heavy"].ToString();
        this.lblRam.Text = village["ram"].ToString();
        this.lblCatapult.Text = village["catapult"].ToString();
        this.lblNoble.Text = village["noble"].ToString();

        DataSet ds = new DataSet();

        SqlCommand cmdGetOutwardCommand = conn.CreateCommand();
        cmdGetOutwardCommand.CommandText = "select m.id as mid, m.type, m.landing_time, m.[to], v.name, v.x, v.y, v.id as vid from movement m inner join villages v on (m.[to]=v.id) where m.landing_time>getdate() and m.[from]=@id order by landing_time asc";
        cmdGetOutwardCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
        SqlDataAdapter daOutward = new SqlDataAdapter(cmdGetOutwardCommand);
        
        SqlCommand cmdGetInwardCommand = conn.CreateCommand();
        cmdGetInwardCommand.CommandText = "select m.id as mid, m.type, m.landing_time, m.[from], v.name, v.x, v.y, v.id as vid from movement m inner join villages v on (m.[from]=v.id) where m.landing_time>getdate() and m.[to]=@id order by landing_time asc";
        cmdGetInwardCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
        SqlDataAdapter daInward = new SqlDataAdapter(cmdGetInwardCommand);

        daInward.Fill(ds, "inwards");
        daOutward.Fill(ds, "outwards");

        string sOutwardsCommand = "";
        string sInwardsCommand = "";

        foreach (DataRow row in ds.Tables["outwards"].Rows)
        {
            int command_type = (int)row["type"];
            if (command_type == 2)
            {
                sOutwardsCommand += "<tr><td><a href='command.aspx?id=" + sID + "&command=" + row["mid"].ToString() + "'>";
                sOutwardsCommand += "<img src='images/attack.png'/>Tấn công làng ";
                sOutwardsCommand += row["name"].ToString() + " (" + row["x"].ToString() + "|" + row["y"].ToString() + ")</td>";
                sOutwardsCommand += "<td>" + row["landing_time"] + "</td>";
                sOutwardsCommand += "<td><span class='timer'>" + Functions.FormatTime((DateTime)row["landing_time"] - DateTime.Now) + "</span></td></tr>";
            }
            else if (command_type == 3)
            {
                sOutwardsCommand += "<tr><td><a href='command.aspx?id=" + sID + "&command=" + row["mid"].ToString() + "'>";
                sOutwardsCommand += "<img src='images/support.png'/>Hỗ trợ làng ";
                sOutwardsCommand += row["name"].ToString() + " (" + row["x"].ToString() + "|" + row["y"].ToString() + ")</td>";
                sOutwardsCommand += "<td>" + row["landing_time"] + "</td>";
                sOutwardsCommand += "<td><span class='timer'>" + Functions.FormatTime((DateTime)row["landing_time"] - DateTime.Now) + "</span></td></tr>";
            }
        }
        foreach (DataRow row in ds.Tables["inwards"].Rows)
        {
            int command_type = (int)row["type"];
            if (command_type == 2)
            {
                sInwardsCommand += "<tr><td><a href='command.aspx?id=" + sID + "&command=" + row["mid"].ToString() + "'>";
                sInwardsCommand += "<img src='images/attack.png'/>Tấn công từ ";
                sInwardsCommand += row["name"].ToString() + " (" + row["x"].ToString() + "|" + row["y"].ToString() + ")</td>";
                sInwardsCommand += "<td>" + row["landing_time"] + "</td>";
                sInwardsCommand += "<td><span class='timer'>" + Functions.FormatTime((DateTime)row["landing_time"] - DateTime.Now) + "</span></td></tr>";
            }
            else if (command_type == 3)
            {
                sInwardsCommand += "<tr><td><a href='command.aspx?id=" + sID + "&command=" + row["mid"].ToString() + "'>";
                sInwardsCommand += "<img src='images/support.png'/>Hỗ trợ từ ";
                sInwardsCommand += row["name"].ToString() + " (" + row["x"].ToString() + "|" + row["y"].ToString() + ")</td>";
                sInwardsCommand += "<td>" + row["landing_time"] + "</td>";
                sInwardsCommand += "<td><span class='timer'>" + Functions.FormatTime((DateTime)row["landing_time"] - DateTime.Now) + "</span></td></tr>";
            }
            else if (command_type == 4)
            {
                sInwardsCommand += "<tr><td><a href='command.aspx?id=" + sID + "&command=" + row["mid"].ToString() + "'>";
                sInwardsCommand += "<img src='images/back.png'/>Quay về từ ";
                sInwardsCommand += row["name"].ToString() + " (" + row["x"].ToString() + "|" + row["y"].ToString() + ")</td>";
                sInwardsCommand += "<td>" + row["landing_time"] + "</td>";
                sInwardsCommand += "<td><span class='timer'>" + Functions.FormatTime((DateTime)row["landing_time"] - DateTime.Now) + "</span></td></tr>";
            }
        }

        this.lblOutwardsCommand.Text = sOutwardsCommand;
        this.lblInwardsCommand.Text = sInwardsCommand;
        this.rally_link.NavigateUrl = "rally.aspx?id=" + sID;

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
            SqlCommand cmdGetVillageCoord = conn.CreateCommand();
            cmdGetVillageCoord.CommandText = "select x, y from villages where id=@id";
            cmdGetVillageCoord.Parameters.Add("@id", SqlDbType.Int).Value = target;
            this.conn.Open();
            SqlDataReader rdr = cmdGetVillageCoord.ExecuteReader();
            if (rdr.Read())
            {
                this.x.Text = rdr["x"].ToString();
                this.y.Text = rdr["y"].ToString();
            }
            else
            {
                this.x.Text = "";
                this.y.Text = "";
            }
            rdr.Close();
            this.conn.Close();
        }
        

        
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
