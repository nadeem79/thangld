using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Village
/// </summary>
public class Village
{

    private static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);

    public static DataRow refresh(int village_id)
    {
        SqlCommand cmdGetVillageInfo = conn.CreateCommand();
        cmdGetVillageInfo.CommandText = "select * from villages where id=@id";
        cmdGetVillageInfo.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        SqlDataAdapter daGetVillageInfo = new SqlDataAdapter(cmdGetVillageInfo);
        

        SqlCommand cmdGetVillageResourceComing = conn.CreateCommand();
        cmdGetVillageResourceComing.CommandText = "select movement.* from movement m inner join villages v on (m.to=v.id and m.landing_time>v.last_update) where m.type=1 and m.to=@id and landing_time<@landing order by landing_time asc";
        cmdGetVillageResourceComing.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageResourceComing.Parameters.Add("@landing", SqlDbType.DateTime).Value = DateTime.Now;
        SqlDataAdapter daGetVillageResourceComing = new SqlDataAdapter(cmdGetVillageResourceComing);

        SqlCommand cmdGetVillageResourceSending = conn.CreateCommand();
        cmdGetVillageResourceSending.CommandText = "select movement.* from movement m inner join villages v on (m.from=v.id and m.landing_time>v.last_update) where type=1 and from=@id and landing_time<@landing order by landing_time asc";
        cmdGetVillageResourceSending.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageResourceSending.Parameters.Add("@landing", SqlDbType.DateTime).Value = DateTime.Now;
        SqlDataAdapter daGetVillageResourceSending = new SqlDataAdapter(cmdGetVillageResourceSending);

        SqlCommand cmdGetVillageIncoming = conn.CreateCommand();
        cmdGetVillageIncoming.CommandText = "select movement.* from movement m inner join villages v on (m.to=v.id and m.landing_time>v.last_update) where type=2 and to=@id and landing_time<@landing order by landing_time asc";
        cmdGetVillageIncoming.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageIncoming.Parameters.Add("@landing", SqlDbType.DateTime).Value = DateTime.Now;
        SqlDataAdapter daGetVillageIncoming = new SqlDataAdapter(cmdGetVillageIncoming);

        SqlCommand cmdGetVillageAttacking = conn.CreateCommand();
        cmdGetVillageAttacking.CommandText = "select movement.* from movement m inner join villages v on (m.from=v.id and m.landing_time>v.last_update) where type=2 and from=@id and landing_time<@landing order by landing_time asc";
        cmdGetVillageAttacking.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageAttacking.Parameters.Add("@landing", SqlDbType.DateTime).Value = DateTime.Now;
        SqlDataAdapter daGetVillageAttacking = new SqlDataAdapter(cmdGetVillageAttacking);

        SqlCommand cmdGetVillageSupportComing = conn.CreateCommand();
        cmdGetVillageSupportComing.CommandText = "select movement.* from movement m inner join villages v on (m.to=v.id and m.landing_time>v.last_update) where m.type=3 and m.to=@id and m.landing_time<@landing order by landing_time asc";
        cmdGetVillageSupportComing.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageSupportComing.Parameters.Add("@landing", SqlDbType.DateTime).Value = DateTime.Now;
        SqlDataAdapter daGetVillageSupportComing = new SqlDataAdapter(cmdGetVillageSupportComing);

        SqlCommand cmdGetVillageSupportSending = conn.CreateCommand();
        cmdGetVillageSupportSending.CommandText = "select movement.* from movement m inner join villages v on (m.from=v.id and m.landing_time>v.last_update) where m.type=3 and m.from=@id and landing_time<@landing order by landing_time asc";
        cmdGetVillageSupportSending.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageSupportSending.Parameters.Add("@landing", SqlDbType.DateTime).Value = DateTime.Now;
        SqlDataAdapter daGetVillageSupportSending = new SqlDataAdapter(cmdGetVillageSupportSending);

        SqlCommand cmdGetVillageReturning = conn.CreateCommand();
        cmdGetVillageReturning.CommandText = "select movement.* from movement m inner join villages v on (m.to=v.id and m.landing_time>v.last_update) where type=4 and to=@id and landing_time<@landing order by landing_time asc";
        cmdGetVillageReturning.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageReturning.Parameters.Add("@landing", SqlDbType.DateTime).Value = DateTime.Now;
        SqlDataAdapter daGetVillageReturning = new SqlDataAdapter(cmdGetVillageReturning);

        SqlCommand cmdGetVillageSendingHome = conn.CreateCommand();
        cmdGetVillageSendingHome.CommandText = "select movement.* from movement m inner join villages v on (m.from=v.id and m.starting_time>v.last_update) where type=4 and to=@id and starting_time<@landing order by landing_time asc";
        cmdGetVillageSendingHome.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageSendingHome.Parameters.Add("@landing", SqlDbType.DateTime).Value = DateTime.Now;
        SqlDataAdapter daGetVillageSendingHome = new SqlDataAdapter(cmdGetVillageSendingHome);

        SqlCommand cmdGetVillageRecruiting = conn.CreateCommand();
        cmdGetVillageRecruiting.CommandText = "select r.* from recruit r inner join villages v on (r.village_id=v.id and r.end_time>v.last_update) where village_id=@id";
        cmdGetVillageRecruiting.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        SqlDataAdapter daGetVillageRecruiting = new SqlDataAdapter(cmdGetVillageRecruiting);

        SqlCommand cmdGetVillageBuilding = conn.CreateCommand();
        cmdGetVillageBuilding.CommandText = "select b.* from buid b inner join villages v on (b.village_id=v.id and b.end_time>v.last_update) where village_id=@id";
        cmdGetVillageBuilding.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        SqlDataAdapter daGetVillageBuilding = new SqlDataAdapter(cmdGetVillageBuilding);

        DataSet dsCommand = new DataSet();
        conn.Open();

        daGetVillageInfo.Fill(dsCommand, "villages");
        daGetVillageAttacking.Fill(dsCommand, "attacking");
        daGetVillageBuilding.Fill(dsCommand, "build");
        daGetVillageIncoming.Fill(dsCommand, "incoming");
        daGetVillageRecruiting.Fill(dsCommand, "recruit");
        daGetVillageResourceComing.Fill(dsCommand, "resource_coming");
        daGetVillageResourceSending.Fill(dsCommand, "resource_coming");
        daGetVillageReturning.Fill(dsCommand, "return");
        daGetVillageSendingHome.Fill(dsCommand, "sending_home");
        daGetVillageSupportComing.Fill(dsCommand, "support");
        daGetVillageSupportSending.Fill(dsCommand, "support_send");

        DataRow village_info = dsCommand.Tables["villages"].Rows[0];
        for (int i = 0; i < dsCommand.Tables["attacking"].Rows.Count; i++)
        {
            DateTime last_attack = (DateTime)village_info["last_update"];
            DateTime next_update = DateTime.Now;
            if (i > 0)
                last_attack = (DateTime)dsCommand.Tables["incoming"].Rows[i - 1]["landing_time"];
            if ((dsCommand.Tables["incoming"].Rows.Count != 0) || (i != dsCommand.Tables["incoming"].Rows.Count - 1))
                next_update = (DateTime)dsCommand.Tables["incoming"].Rows[i + 1]["landing_time"];

            while ((dsCommand.Tables["support"].Rows.Count > 0)||((DateTime)dsCommand.Tables["support"].Rows["landing_time"]>DateTime.Now))
            {
                Data
            }
        }
        foreach (DataRow row in dsCommand.Tables["attacking"].Rows)
        {
            //if row.
            //village_info.
        }

        return village_info;
    }
     

	public Village()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
