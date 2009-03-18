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

public partial class barrack : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmdUpdate = conn.CreateCommand();

        int id = int.Parse(Request["id"]);

        cmdUpdate.CommandText = "select v.id, v.wood, v.clay, v.iron, v.spear, v.sword, v.axe, 0 as total_spear, 0 as total_sword, 0 as total_axe from villages v LEFT join movement c on ((c.[to]=v.id and c.type=4) or ((c.type=2 or c.type=3) and c.[from]=v.id) and c.landing_time>getdate()) where v.id=@id group by v.id, v.wood, v.clay, v.iron, v.spear, v.sword, v.axe";
        cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = id;
        cmdUpdate.Parameters.Add("@landing_time", SqlDbType.DateTime).Value = DateTime.Now;

        SqlCommand cmdGetRecruitCommands = conn.CreateCommand();
        cmdGetRecruitCommands.CommandText = "select * from recruit where village_id=@id and troop in (1, 2, 3, 4) and end_time>getdate()";
        cmdGetRecruitCommands.Parameters.Add("@id", SqlDbType.Int).Value = id;

        conn.Open();
        SqlDataReader rdr = cmdUpdate.ExecuteReader();
        if (rdr.Read())
        {
            this.lblMaxSpear.Text = Recruit.CanRecruit((int)rdr["clay"], (int)rdr["wood"], (int)rdr["iron"], 30, 50, 10).ToString();
            this.lblMaxSword.Text = Recruit.CanRecruit((int)rdr["clay"], (int)rdr["wood"], (int)rdr["iron"], 30, 30, 70).ToString();
            this.lblMaxAxe.Text = Recruit.CanRecruit((int)rdr["clay"], (int)rdr["wood"], (int)rdr["iron"], 30, 60, 40).ToString();

            this.lblSpear.Text = rdr["spear"].ToString() + "/" + ((int)rdr["spear"] + (int)rdr["total_spear"]).ToString();
            this.lblSword.Text = rdr["sword"].ToString() + "/" + ((int)rdr["sword"] + (int)rdr["total_sword"]).ToString();
            this.lblAxe.Text = rdr["axe"].ToString() + "/" + ((int)rdr["axe"] + (int)rdr["total_axe"]).ToString();
        }

        rdr.Close();

        SqlDataReader rdrRecruitCommands = cmdGetRecruitCommands.ExecuteReader();
        string sRecruitCommands = "";
        while (rdrRecruitCommands.Read())
        {
            sRecruitCommands += "<tr class='lit'>";
            sRecruitCommands += "<td>" + rdrRecruitCommands["quantity"].ToString();
            switch ((int)rdrRecruitCommands["troop"])
            {
                case 1:
                    sRecruitCommands += " Spear fighters</td>";
                    break;
                case 2:
                    sRecruitCommands += " Swordmen</td>";
                    break;
                case 3:
                    sRecruitCommands += " Axemen</td>";
                    break;
                case 4:
                    sRecruitCommands += " Bowmen</td>";
                    break;
                default:
                    break;
            }
            sRecruitCommands += "<td><span class='timer'>" + ((DateTime)rdrRecruitCommands["end_time"] - DateTime.Now).ToString() + "</span></td>";
            sRecruitCommands += "<td>" + rdrRecruitCommands["end_time"].ToString() + "</td>";
        }
        rdrRecruitCommands.Close();
        conn.Close();
        this.lblRecruiting.Text = sRecruitCommands;

    }
    protected void bttnRecruit_Click(object sender, EventArgs e)
    {
        int spear = 0, sword = 0, axe = 0, iron = 0, clay = 0, wood = 0;
        SqlCommand cmdRecruitSpear = null, cmdRecruitSword = null, cmdRecruitAxe = null;
        
        DataRow village_info = Village.refresh(int.Parse(Request["id"]), DateTime.Now);

        if (int.TryParse(this.txtSpear.Text, out spear))
        {
            clay += spear * 30;
            wood += spear * 50;
            iron += spear * 10;
            if ((spear > 0) && (clay < (int)village_info["clay"]) && (wood < (int)village_info["wood"]) && (iron < (int)village_info["iron"]))
            {
                cmdRecruitSpear = conn.CreateCommand();
                cmdRecruitSpear.CommandText = "insert into recruit (village_id, troop, quantity, start_time, end_time) values (@id, 1, @quantity, @start_time, @end_time)";
                cmdRecruitSpear.Parameters.Add("@id", SqlDbType.Int).Value = (int)village_info["id"];
                cmdRecruitSpear.Parameters.Add("@quantity", SqlDbType.Int).Value = spear;
                cmdRecruitSpear.Parameters.Add("@start_time", SqlDbType.DateTime).Value = DateTime.Now;
                cmdRecruitSpear.Parameters.Add("@end_time", SqlDbType.DateTime).Value = Recruit.finish_recruit((int)village_info["barracks"], 1, spear, DateTime.Now);
            }
            else
            {
                lblError.Text = "Không đủ tài nguyên";
                return;
            }
        }

        if (int.TryParse(this.txtSword.Text, out sword))
        {
            clay += sword * 30;
            wood += sword * 30;
            iron += sword * 70;
            if ((sword > 0) && (clay < (int)village_info["clay"]) && (wood < (int)village_info["wood"]) && (iron < (int)village_info["iron"]))
            {
                cmdRecruitSword = conn.CreateCommand();
                cmdRecruitSword.CommandText = "insert into recruit (village_id, troop, quantity, start_time, end_time) values (@id, 2, @quantity, @start_time, @end_time)";
                cmdRecruitSword.Parameters.Add("@id", SqlDbType.Int).Value = (int)village_info["id"];
                cmdRecruitSword.Parameters.Add("@quantity", SqlDbType.Int).Value = spear;
                cmdRecruitSword.Parameters.Add("@start_time", SqlDbType.DateTime).Value = DateTime.Now;
                cmdRecruitSword.Parameters.Add("@end_time", SqlDbType.DateTime).Value = Recruit.finish_recruit((int)village_info["barracks"], 2, spear, DateTime.Now);
            }
        }

        if (int.TryParse(this.txtAxe.Text, out axe))
        {
            clay += sword * 30;
            wood += sword * 60;
            iron += sword * 40;
            if ((axe > 0) && (clay < (int)village_info["clay"]) && (wood < (int)village_info["wood"]) && (iron < (int)village_info["iron"]))
            {
                cmdRecruitAxe = conn.CreateCommand();
                cmdRecruitAxe.CommandText = "insert into recruit (village_id, troop, quantity, start_time, end_time) values (@id, 3, @quantity, @start_time, @end_time)";
                cmdRecruitAxe.Parameters.Add("@id", SqlDbType.Int).Value = (int)village_info["id"];
                cmdRecruitAxe.Parameters.Add("@quantity", SqlDbType.Int).Value = spear;
                cmdRecruitAxe.Parameters.Add("@start_time", SqlDbType.DateTime).Value = DateTime.Now;
                cmdRecruitAxe.Parameters.Add("@end_time", SqlDbType.DateTime).Value = Recruit.finish_recruit((int)village_info["barracks"], 3, spear, DateTime.Now);
            }
        }
        conn.Open();
        
        bool recruit = false;

        if (!object.Equals(cmdRecruitAxe, null))
        {
            recruit = true;
            cmdRecruitAxe.ExecuteNonQuery();
        }
        if (!object.Equals(cmdRecruitSword, null))
        {
            recruit = true;
            cmdRecruitSword.ExecuteNonQuery();
        }
        if (!object.Equals(cmdRecruitSpear, null))
        {
            recruit = true;
            cmdRecruitSpear.ExecuteNonQuery();
        }

        if (recruit)
        {
            SqlCommand cmdUpdateVillage = conn.CreateCommand();
            cmdUpdateVillage.CommandText = "update villages set clay=clay-@clay, wood=wood-@wood, iron=iron-@iron where id=@id";
            cmdUpdateVillage.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(Request["id"]);
            cmdUpdateVillage.Parameters.Add("@clay", SqlDbType.Int).Value = clay;
            cmdUpdateVillage.Parameters.Add("@wood", SqlDbType.Int).Value = wood;
            cmdUpdateVillage.Parameters.Add("@iron", SqlDbType.Int).Value = iron;
            cmdUpdateVillage.ExecuteNonQuery();
        }

        conn.Close();

        Response.Redirect("barrack.aspx?id=" + Request["id"], true);

    }
}
