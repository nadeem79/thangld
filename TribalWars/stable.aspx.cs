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

public partial class stable : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmdUpdate = conn.CreateCommand();

        int id = int.Parse(Request["id"]);

        cmdUpdate.CommandText = "select v.id, v.wood, v.clay, v.iron, v.scout, v.light, v.heavy, sum(c.scout) as total_scout, sum(c.light) as total_light, sum(c.heavy) as total_heavy from villages v left join movement c on ((c.[to]=v.id and c.type=4) or ((c.type=2 or c.type=3) and c.[from]=v.id)) where v.id=@id and c.landing_time>@landing_time  group by v.id, v.wood, v.clay, v.iron, v.scout, v.light, v.heavy";
        cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = id;
        cmdUpdate.Parameters.Add("@landing_time", SqlDbType.DateTime).Value = DateTime.Now;

        SqlCommand cmdGetRecruitCommands = conn.CreateCommand();
        cmdGetRecruitCommands.CommandText = "select * from recruit where village_id=@id and troop in (5, 6, 7, 8) and end_time>getdate()";
        cmdGetRecruitCommands.Parameters.Add("@id", SqlDbType.Int).Value = id;

        conn.Open();
        SqlDataReader rdr = cmdUpdate.ExecuteReader();

        if (rdr.Read())
        {
            this.lblMaxScout.Text = Recruit.CanRecruit((int)rdr["clay"], (int)rdr["wood"], (int)rdr["iron"], 50, 50, 20).ToString();
            this.lblMaxLight.Text = Recruit.CanRecruit((int)rdr["clay"], (int)rdr["wood"], (int)rdr["iron"], 100, 125, 250).ToString();
            this.lblMaxHeavy.Text = Recruit.CanRecruit((int)rdr["clay"], (int)rdr["wood"], (int)rdr["iron"], 150, 200, 600).ToString();

            this.lblScout.Text = rdr["scout"].ToString() + "/" + ((int)rdr["scout"] + (int)rdr["total_scout"]).ToString();
            this.lblLight.Text = rdr["light"].ToString() + "/" + ((int)rdr["light"] + (int)rdr["total_light"]).ToString();
            this.lblHeavy.Text = rdr["heavy"].ToString() + "/" + ((int)rdr["heavy"] + (int)rdr["total_heavy"]).ToString();
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
                case 5:
                    sRecruitCommands += " Scouts</td>";
                    break;
                case 6:
                    sRecruitCommands += " Light Cavalries</td>";
                    break;
                case 7:
                    sRecruitCommands += " Heavy Cavalries</td>";
                    break;
                case 8:
                    sRecruitCommands += " Mounted Archers</td>";
                    break;
                default:
                    break;
            }
            sRecruitCommands += "<td>" + ((DateTime)rdrRecruitCommands["end_time"] - DateTime.Now).ToString() + "</td>";
            sRecruitCommands += "<td>" + rdrRecruitCommands["end_time"].ToString() + "</td>";
        }
        rdrRecruitCommands.Close();

        conn.Close();
        this.lblRecruiting.Text = sRecruitCommands;
    }
    protected void bttnRecruit_Click(object sender, EventArgs e)
    {
        int scout = 0, light = 0, heavy = 0, clay = 0, wood = 0, iron = 0;
        SqlCommand cmdRecruitScout = null, cmdRecruitLight = null, cmdRecruitHeavy = null;
        DataRow village_info = Village.refresh(int.Parse(Request["id"]), DateTime.Now);

        if (int.TryParse(this.txtScout.Text, out scout))
        {
            clay += scout * 50;
            wood += scout * 50;
            iron += scout * 20;
            if ((scout > 0) && (clay < (int)village_info["clay"]) && (wood < (int)village_info["wood"]) && (iron < (int)village_info["iron"]))
            {
                cmdRecruitScout = conn.CreateCommand();
                cmdRecruitScout.CommandText = "insert into recruit (village_id, troop, quantity, start_time, end_time) values (@id, 5, @quantity, @start_time, @end_time)";
                cmdRecruitScout.Parameters.Add("@id", SqlDbType.Int).Value = (int)village_info["id"];
                cmdRecruitScout.Parameters.Add("@quantity", SqlDbType.Int).Value = scout;
                cmdRecruitScout.Parameters.Add("@start_time", SqlDbType.DateTime).Value = DateTime.Now;
                cmdRecruitScout.Parameters.Add("@end_time", SqlDbType.DateTime).Value = Recruit.finish_recruit((int)village_info["stable"], 5, scout, DateTime.Now);
            }
        }

        if (int.TryParse(this.txtLight.Text, out light))
        {
            clay += light * 100;
            wood += light * 125;
            iron += light * 250;
            if ((light > 0) && (clay < (int)village_info["clay"]) && (wood < (int)village_info["wood"]) && (iron < (int)village_info["iron"]))
            {
                cmdRecruitLight = conn.CreateCommand();
                cmdRecruitLight.CommandText = "insert into recruit (village_id, troop, quantity, start_time, end_time) values (@id, 6, @quantity, @start_time, @end_time)";
                cmdRecruitLight.Parameters.Add("@id", SqlDbType.Int).Value = (int)village_info["id"];
                cmdRecruitLight.Parameters.Add("@quantity", SqlDbType.Int).Value = light;
                cmdRecruitLight.Parameters.Add("@start_time", SqlDbType.DateTime).Value = DateTime.Now;
                cmdRecruitLight.Parameters.Add("@end_time", SqlDbType.DateTime).Value = Recruit.finish_recruit((int)village_info["stable"], 6, light, DateTime.Now);
            }
        }

        if (int.TryParse(this.txtHeavy.Text, out heavy))
        {
            clay += heavy * 150;
            wood += heavy * 200;
            iron += heavy * 600;
            if ((heavy > 0) && (clay < (int)village_info["clay"]) && (wood < (int)village_info["wood"]) && (iron < (int)village_info["iron"]))
            {
                cmdRecruitHeavy = conn.CreateCommand();
                cmdRecruitHeavy.CommandText = "insert into recruit (village_id, troop, quantity, start_time, end_time) values (@id, 7, @quantity, @start_time, @end_time)";
                cmdRecruitHeavy.Parameters.Add("@id", SqlDbType.Int).Value = (int)village_info["id"];
                cmdRecruitHeavy.Parameters.Add("@quantity", SqlDbType.Int).Value = heavy;
                cmdRecruitHeavy.Parameters.Add("@start_time", SqlDbType.DateTime).Value = DateTime.Now;
                cmdRecruitHeavy.Parameters.Add("@end_time", SqlDbType.DateTime).Value = Recruit.finish_recruit((int)village_info["stable"], 7, heavy, DateTime.Now);
            }
        }
        bool recruit = false;
        conn.Open();
        if (!object.Equals(cmdRecruitScout, null))
        {
            recruit = true;
            cmdRecruitScout.ExecuteNonQuery();
        }
        if (!object.Equals(cmdRecruitLight, null))
        {
            recruit = true;
            cmdRecruitLight.ExecuteNonQuery();
        }
        if (!object.Equals(cmdRecruitHeavy, null))
        {
            recruit = true;
            cmdRecruitHeavy.ExecuteNonQuery();
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

        Response.Redirect("stable.aspx?id=" + Request["id"], true);
    }
}
