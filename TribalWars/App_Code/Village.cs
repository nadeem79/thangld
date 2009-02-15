﻿using System;
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

    public static DataRow refresh(int village_id, DateTime refreshingTime)
    {
        SqlCommand cmdGetVillageInfo = conn.CreateCommand();
        cmdGetVillageInfo.CommandText = "select * from villages where id=@id";
        cmdGetVillageInfo.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        SqlDataAdapter daGetVillageInfo = new SqlDataAdapter(cmdGetVillageInfo);

        SqlCommand cmdGetTroopStation = conn.CreateCommand();
        cmdGetTroopStation.CommandText = "select * from station where at_village=@id";
        cmdGetTroopStation.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        SqlDataAdapter daGetTroopStation = new SqlDataAdapter(cmdGetTroopStation);

        SqlCommand cmdGetVillageResourceComing = conn.CreateCommand();
        cmdGetVillageResourceComing.CommandText = "select movement.* from movement m inner join villages v on (m.to=v.id and m.landing_time>=v.last_update) where m.type=1 and m.to=@id and landing_time<=@landing order by landing_time asc";
        cmdGetVillageResourceComing.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageResourceComing.Parameters.Add("@landing", SqlDbType.DateTime).Value = refreshingTime;
        SqlDataAdapter daGetVillageResourceComing = new SqlDataAdapter(cmdGetVillageResourceComing);

        SqlCommand cmdGetVillageResourceSending = conn.CreateCommand();
        cmdGetVillageResourceSending.CommandText = "select movement.* from movement m inner join villages v on (m.from=v.id and m.landing_time>=v.last_update) where type=1 and from=@id and landing_time<=@landing order by landing_time asc";
        cmdGetVillageResourceSending.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageResourceSending.Parameters.Add("@landing", SqlDbType.DateTime).Value = refreshingTime;
        SqlDataAdapter daGetVillageResourceSending = new SqlDataAdapter(cmdGetVillageResourceSending);

        SqlCommand cmdGetVillageIncoming = conn.CreateCommand();
        cmdGetVillageIncoming.CommandText = "select movement.* from movement m inner join villages v on (m.to=v.id and m.landing_time>=v.last_update) where type=2 and to=@id and landing_time<=@landing order by landing_time asc";
        cmdGetVillageIncoming.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageIncoming.Parameters.Add("@landing", SqlDbType.DateTime).Value = refreshingTime;
        SqlDataAdapter daGetVillageIncoming = new SqlDataAdapter(cmdGetVillageIncoming);

        SqlCommand cmdGetVillageAttacking = conn.CreateCommand();
        cmdGetVillageAttacking.CommandText = "select movement.* from movement m inner join villages v on (m.from=v.id and m.landing_time>=v.last_update) where type=2 and from=@id and landing_time<=@landing order by landing_time asc";
        cmdGetVillageAttacking.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageAttacking.Parameters.Add("@landing", SqlDbType.DateTime).Value = DateTime.Now;
        SqlDataAdapter daGetVillageAttacking = new SqlDataAdapter(cmdGetVillageAttacking);

        SqlCommand cmdGetVillageSupportComing = conn.CreateCommand();
        cmdGetVillageSupportComing.CommandText = "select movement.* from movement m inner join villages v on (m.to=v.id and m.landing_time>=v.last_update) where m.type=3 and m.to=@id and m.landing_time<=@landing order by landing_time asc";
        cmdGetVillageSupportComing.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageSupportComing.Parameters.Add("@landing", SqlDbType.DateTime).Value = refreshingTime;
        SqlDataAdapter daGetVillageSupportComing = new SqlDataAdapter(cmdGetVillageSupportComing);

        SqlCommand cmdGetVillageSupportSending = conn.CreateCommand();
        cmdGetVillageSupportSending.CommandText = "select movement.* from movement m inner join villages v on (m.from=v.id and m.landing_time>=v.last_update) where m.type=3 and m.from=@id and landing_time<=@landing order by landing_time asc";
        cmdGetVillageSupportSending.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageSupportSending.Parameters.Add("@landing", SqlDbType.DateTime).Value = refreshingTime;
        SqlDataAdapter daGetVillageSupportSending = new SqlDataAdapter(cmdGetVillageSupportSending);

        SqlCommand cmdGetVillageReturning = conn.CreateCommand();
        cmdGetVillageReturning.CommandText = "select movement.* from movement m inner join villages v on (m.to=v.id and m.landing_time>=v.last_update) where type=4 and to=@id and landing_time<=@landing order by landing_time asc";
        cmdGetVillageReturning.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageReturning.Parameters.Add("@landing", SqlDbType.DateTime).Value = refreshingTime;
        SqlDataAdapter daGetVillageReturning = new SqlDataAdapter(cmdGetVillageReturning);

        SqlCommand cmdGetVillageSendingHome = conn.CreateCommand();
        cmdGetVillageSendingHome.CommandText = "select movement.* from movement m inner join villages v on (m.from=v.id and m.starting_time>=v.last_update) where type=4 and to=@id and starting_time<=@landing order by landing_time asc";
        cmdGetVillageSendingHome.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageSendingHome.Parameters.Add("@landing", SqlDbType.DateTime).Value = refreshingTime;
        SqlDataAdapter daGetVillageSendingHome = new SqlDataAdapter(cmdGetVillageSendingHome);

        SqlCommand cmdGetVillageInfantryRecruiting = conn.CreateCommand();
        cmdGetVillageInfantryRecruiting.CommandText = "select r.* from recruit r inner join villages v on (r.village_id=v.id and r.end_time>=v.last_update) where troop in (1, 2, 3, 4) and village_id=@id ";
        cmdGetVillageInfantryRecruiting.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        SqlDataAdapter daGetVillageInfantryRecruiting = new SqlDataAdapter(cmdGetVillageInfantryRecruiting);

        SqlCommand cmdGetVillageCavalryRecruiting = conn.CreateCommand();
        cmdGetVillageCavalryRecruiting.CommandText = "select r.* from recruit r inner join villages v on (r.village_id=v.id and r.end_time>=v.last_update) where troop in (5, 6, 7, 8) and village_id=@id";
        cmdGetVillageCavalryRecruiting.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        SqlDataAdapter daGetVillageCavalryRecruiting = new SqlDataAdapter(cmdGetVillageCavalryRecruiting);

        SqlCommand cmdGetVillageEngineRecruiting = conn.CreateCommand();
        cmdGetVillageEngineRecruiting.CommandText = "select r.* from recruit r inner join villages v on (r.village_id=v.id and r.end_time>=v.last_update) where troop in (9, 10) and village_id=@id";
        cmdGetVillageEngineRecruiting.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        SqlDataAdapter daGetVillageEngineRecruiting = new SqlDataAdapter(cmdGetVillageEngineRecruiting);

        SqlCommand cmdGetVillageNobleRecruiting = conn.CreateCommand();
        cmdGetVillageNobleRecruiting.CommandText = "select r.* from recruit r inner join villages v on (r.village_id=v.id and r.end_time>=v.last_update) where troop = 11 and village_id=@id";
        cmdGetVillageNobleRecruiting.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        SqlDataAdapter daGetVillageNobleRecruiting = new SqlDataAdapter(cmdGetVillageNobleRecruiting);

        SqlCommand cmdGetVillageBuilding = conn.CreateCommand();
        cmdGetVillageBuilding.CommandText = "select b.* from buid b inner join villages v on (b.village_id=v.id and b.end_time>=v.last_update) where village_id=@id and stop_time<@stop_time";
        cmdGetVillageBuilding.Parameters.Add("@id", SqlDbType.Int).Value = village_id;
        cmdGetVillageBuilding.Parameters.Add("@stop_time", SqlDbType.DateTime).Value = DateTime.Now;
        SqlDataAdapter daGetVillageBuilding = new SqlDataAdapter(cmdGetVillageBuilding);

        DataSet dsCommand = new DataSet();
        if (conn.State!=ConnectionState.Open)
            conn.Open();

        daGetVillageInfo.Fill(dsCommand, "villages");
        daGetVillageAttacking.Fill(dsCommand, "attacking");
        daGetVillageBuilding.Fill(dsCommand, "build");
        daGetVillageIncoming.Fill(dsCommand, "incoming");
        daGetVillageCavalryRecruiting.Fill(dsCommand, "cavalry");
        daGetVillageInfantryRecruiting.Fill(dsCommand, "infantry");
        daGetVillageEngineRecruiting.Fill(dsCommand, "engine");
        daGetVillageNobleRecruiting.Fill(dsCommand, "noble");
        daGetVillageResourceComing.Fill(dsCommand, "resource_coming");
        daGetVillageResourceSending.Fill(dsCommand, "resource_sending");
        daGetVillageReturning.Fill(dsCommand, "return");
        daGetVillageSendingHome.Fill(dsCommand, "sending_home");
        daGetVillageSupportComing.Fill(dsCommand, "support");
        daGetVillageSupportSending.Fill(dsCommand, "support_send");
        daGetTroopStation.Fill(dsCommand, "station");

        DataRow village_info = dsCommand.Tables["villages"].Rows[0];
        dsCommand.Tables["villages"].ImportRow(village_info);
        DataRow origin_info = dsCommand.Tables["villages"].Rows[1];
        for (int i = 0; i < dsCommand.Tables["incoming"].Rows.Count; i++)
        {
            DateTime last_attack = (DateTime)village_info["last_update"];
            DateTime next_update = DateTime.Now;
            if (i > 0)
                last_attack = (DateTime)dsCommand.Tables["incoming"].Rows[i - 1]["landing_time"];
            if ((dsCommand.Tables["incoming"].Rows.Count != 0) || (i != dsCommand.Tables["incoming"].Rows.Count - 1))
                next_update = (DateTime)dsCommand.Tables["incoming"].Rows[i + 1]["landing_time"];

            //quan di danh lang khac
            while ((dsCommand.Tables["attacking"].Rows.Count > 0) || ((DateTime)dsCommand.Tables["attacking"].Rows[0]["landing_time"] < next_update))
            {
                DataRow row = dsCommand.Tables["attacking"].Rows[0];
                DataRow targetInfo = Village.refresh((int)row["to"], (DateTime)row["landing_time"]);

                int spear, sword, axe, bowman, light, scout, heavy, mounted, ram, catapult, noble, iron = 0, clay = 0, wood = 0;
                
                bool attackWin = AttackCalculator.attack(
                    (int)row["spear"], (int)row["sword"], (int)row["axe"], (int)row["bowman"], (int)row["light"], (int)row["scout"], (int)row["heavy"], (int)row["mounted"], (int)row["ram"], (int)row["catapult"], (int)row["noble"],
                    (int)targetInfo["spear"], (int)targetInfo["sword"], (int)targetInfo["axe"], (int)targetInfo["bowman"], (int)targetInfo["light"], (int)targetInfo["scout"], (int)targetInfo["heavy"], (int)targetInfo["mounted"], (int)targetInfo["ram"], (int)targetInfo["catapult"], (int)targetInfo["noble"],
                    out spear, out sword, out axe, out bowman, out light, out scout, out heavy, out mounted, out ram, out catapult, out noble);

                if (attackWin)
                {
                    int intCanHaul = spear * 25 + sword * 15 + axe * 10 + bowman * 10 + light * 80 + heavy * 50 + mounted * 50;
                    int intTotalResource = (int)targetInfo["iron"] + (int)targetInfo["clay"] + (int)targetInfo["wood"];

                    if (intTotalResource <= intCanHaul)
                    {
                        clay = (int)targetInfo["clay"];
                        wood = (int)targetInfo["wood"];
                        iron = (int)targetInfo["iron"];
                    }
                    else
                    {
                        clay = (int)(((double)targetInfo["clay"] / (double)intTotalResource) * intCanHaul);
                        wood = (int)(((double)targetInfo["wood"] / (double)intTotalResource) * intCanHaul);
                        iron = (int)(((double)targetInfo["iron"] / (double)intTotalResource) * intCanHaul);
                    }

                    DateTime landing_time = Map.LandingTime(1, (int)targetInfo["x"], (int)targetInfo["y"], (int)village_info["x"], (int)village_info["y"]);

                    SqlCommand cmdReturn = conn.CreateCommand();
                    cmdReturn.CommandText = "insert into movement " +
                        "(from, to, type, starting_time, landing_time, spear, sword, axe, bowman, scout, light, heavy, mounted, ram, catapult, noble, clay, wood, iron) values " +
                        "(@from, @to, 4, @starting_time, @landing_time, @spear, @sword, @axe, @bowman, @scout, @light, @heavy, @mounted, @ram, @catapult, @noble, @clay, @wood, @iron)";

                    cmdReturn.Parameters.Add("@from", SqlDbType.Int).Value = (int)targetInfo["id"];
                    cmdReturn.Parameters.Add("@to", SqlDbType.Int).Value = village_id;
                    cmdReturn.Parameters.Add("@starting_time", SqlDbType.DateTime).Value = (DateTime)row["landing_time"];
                    cmdReturn.Parameters.Add("@landing_time", SqlDbType.DateTime).Value = landing_time;
                    cmdReturn.Parameters.Add("@spear", SqlDbType.Int).Value = spear;
                    cmdReturn.Parameters.Add("@sword", SqlDbType.Int).Value = sword;
                    cmdReturn.Parameters.Add("@axe", SqlDbType.Int).Value = axe;
                    cmdReturn.Parameters.Add("@bowman", SqlDbType.Int).Value = bowman;
                    cmdReturn.Parameters.Add("@scout", SqlDbType.Int).Value = scout;
                    cmdReturn.Parameters.Add("@light", SqlDbType.Int).Value = light;
                    cmdReturn.Parameters.Add("@heavy", SqlDbType.Int).Value = heavy;
                    cmdReturn.Parameters.Add("@ram", SqlDbType.Int).Value = ram;
                    cmdReturn.Parameters.Add("@catapult", SqlDbType.Int).Value = catapult;
                    cmdReturn.Parameters.Add("@noble", SqlDbType.Int).Value = noble;
                    cmdReturn.Parameters.Add("@clay", SqlDbType.Int).Value = clay;
                    cmdReturn.Parameters.Add("@wood", SqlDbType.Int).Value = wood;
                    cmdReturn.Parameters.Add("@iron", SqlDbType.Int).Value = iron;

                    cmdReturn.ExecuteNonQuery();

                    if (landing_time < DateTime.Now)
                    {
                        if (dsCommand.Tables["return"].Rows.Count==0)
                            dsCommand.Tables["return"].Rows.Add(0, (int)targetInfo["id"], village_info, 4, (DateTime)row["landing_time"], landing_time, 0, scout, bowman, spear, sword, axe, mounted, light, heavy, ram, catapult, noble, 0, 0, 0, 0, 0, 0, iron, clay, wood);
                        else
                        {
                            DataRow returningRow = dsCommand.Tables["return"].NewRow();
                            returningRow["spear"] = (int)village_info["spear"] + (int)row["spear"];
                            returningRow["sword"] = (int)village_info["sword"] + (int)row["sword"];
                            returningRow["axe"] = (int)village_info["axe"] + (int)row["axe"];
                            returningRow["bowman"] = (int)village_info["bowman"] + (int)row["bowman"];
                            returningRow["scout"] = (int)village_info["scout"] + (int)row["scout"];
                            returningRow["light"] = (int)village_info["light"] + (int)row["light"];
                            returningRow["mounted"] = (int)village_info["mounted"] + (int)row["mounted"];
                            returningRow["heavy"] = (int)village_info["heavy"] + (int)row["heavy"];
                            returningRow["noble"] = (int)village_info["noble"] + (int)row["noble"];

                            int j = 0;
                            while (landing_time > (DateTime)dsCommand.Tables["return"].Rows[j]["landing_time"])
                                j++;
                            dsCommand.Tables["return"].Rows.InsertAt(returningRow, j);
                            
                        }
                        
                        
                    }
                }

                Report.WriteAttackReport(
                    (int)row["spear"], (int)row["sword"], (int)row["axe"], (int)row["bowman"], (int)row["light"], (int)row["scout"], (int)row["heavy"], (int)row["mounted"], (int)row["ram"], (int)row["catapult"], (int)row["noble"],
                    (int)targetInfo["spear"], (int)targetInfo["sword"], (int)targetInfo["axe"], (int)targetInfo["bowman"], (int)targetInfo["light"], (int)targetInfo["scout"], (int)targetInfo["heavy"], (int)targetInfo["mounted"], (int)targetInfo["ram"], (int)targetInfo["catapult"], (int)targetInfo["noble"],
                    attackWin,
                    spear, sword, axe, bowman, light, scout, heavy, mounted, ram, catapult, noble,
                    wood, clay, iron);
            }
            
            //Quân đóng ở làng
            foreach (DataRow row in dsCommand.Tables["station"].Rows)
            {
                village_info["spear"] = (int)village_info["spear"] + (int)row["spear"];
                village_info["sword"] = (int)village_info["sword"] + (int)row["sword"];
                village_info["axe"] = (int)village_info["axe"] + (int)row["axe"];
                village_info["bowman"] = (int)village_info["bowman"] + (int)row["bowman"];
                village_info["scout"] = (int)village_info["scout"] + (int)row["scout"];
                village_info["light"] = (int)village_info["light"] + (int)row["light"];
                village_info["mounted"] = (int)village_info["mounted"] + (int)row["mounted"];
                village_info["heavy"] = (int)village_info["heavy"] + (int)row["heavy"];
                village_info["noble"] = (int)village_info["noble"] + (int)row["noble"];
                village_info["wood"] = (int)village_info["wood"] + (int)row["wood"];
                village_info["clay"] = (int)village_info["clay"] + (int)row["clay"];
                village_info["iron"] = (int)village_info["iron"] + (int)row["iron"];
            }

            //quan ve tu noi khac
            while ((dsCommand.Tables["return"].Rows.Count > 0) || ((DateTime)dsCommand.Tables["return"].Rows[0]["landing_time"] < next_update))
            {
                DataRow row = dsCommand.Tables["return"].Rows[0];
                village_info["spear"] = (int)village_info["spear"] + (int)row["spear"];
                village_info["sword"] = (int)village_info["sword"] + (int)row["sword"];
                village_info["axe"] = (int)village_info["axe"] + (int)row["axe"];
                village_info["bowman"] = (int)village_info["bowman"] + (int)row["bowman"];
                village_info["scout"] = (int)village_info["scout"] + (int)row["scout"];
                village_info["light"] = (int)village_info["light"] + (int)row["light"];
                village_info["mounted"] = (int)village_info["mounted"] + (int)row["mounted"];
                village_info["heavy"] = (int)village_info["heavy"] + (int)row["heavy"];
                village_info["noble"] = (int)village_info["noble"] + (int)row["noble"];
                village_info["wood"] = (int)village_info["wood"] + (int)row["wood"];
                village_info["clay"] = (int)village_info["clay"] + (int)row["clay"];
                village_info["iron"] = (int)village_info["iron"] + (int)row["iron"];

                origin_info["spear"] = (int)origin_info["spear"] + (int)row["spear"];
                origin_info["sword"] = (int)origin_info["sword"] + (int)row["sword"];
                origin_info["axe"] = (int)origin_info["axe"] + (int)row["axe"];
                origin_info["bowman"] = (int)origin_info["bowman"] + (int)row["bowman"];
                origin_info["scout"] = (int)origin_info["scout"] + (int)row["scout"];
                origin_info["light"] = (int)origin_info["light"] + (int)row["light"];
                origin_info["mounted"] = (int)origin_info["mounted"] + (int)row["mounted"];
                origin_info["heavy"] = (int)origin_info["heavy"] + (int)row["heavy"];
                origin_info["noble"] = (int)origin_info["noble"] + (int)row["noble"];
                origin_info["wood"] = (int)origin_info["wood"] + (int)row["wood"];
                origin_info["clay"] = (int)origin_info["clay"] + (int)row["clay"];
                origin_info["iron"] = (int)origin_info["iron"] + (int)row["iron"];

                dsCommand.Tables["return"].Rows.Remove(row);
            }

            //quan support tu noi khac
            while ((dsCommand.Tables["support"].Rows.Count > 0) || ((DateTime)dsCommand.Tables["support"].Rows[0]["landing_time"] < next_update))
            {
                DataRow row = dsCommand.Tables["support"].Rows[0];
                village_info["spear"] = (int)village_info["spear"] + (int)row["spear"];
                village_info["sword"] = (int)village_info["sword"] + (int)row["sword"];
                village_info["axe"] = (int)village_info["axe"] + (int)row["axe"];
                village_info["bowman"] = (int)village_info["bowman"] + (int)row["bowman"];
                village_info["scout"] = (int)village_info["scout"] + (int)row["scout"];
                village_info["light"] = (int)village_info["light"] + (int)row["light"];
                village_info["mounted"] = (int)village_info["mounted"] + (int)row["mounted"];
                village_info["heavy"] = (int)village_info["heavy"] + (int)row["heavy"];
                village_info["noble"] = (int)village_info["noble"] + (int)row["noble"];


                bool stationed = false;
                foreach (DataRow row2 in dsCommand.Tables["station"].Rows)
                    if ((int)row2["from_village"] == (int)row["to"])
                    {
                        stationed = true;
                        break;
                    }

                SqlCommand cmdStation = conn.CreateCommand();

                //if 

                cmdStation.CommandText = "insert into station (from_village, at_village, spear, sword, axe, bowman, light, scout, heavy, mounted, ram, catapult, noble)" + 
                                                    "values   (@from_village, @at_village, @spear, @sword, @axe, @bowman, @light, @scout, @heavy, @ram, @catapult, @noble)";


                dsCommand.Tables["support"].Rows.Remove(row);
            }

            //quan tu xay
            int recruit;
            while (dsCommand.Tables["infantry"].Rows.Count > 0)
            {
                DataRow row = dsCommand.Tables["infantry"].Rows[0];

                recruit = Recruit.troop_recruit((DateTime)row["start_time"], next_update, (int)village_info["barracks"], (int)row["troop"], (int)row["quantity"]);
                string sTroop = "spear";
                switch ((int)row["troop"])
                {
                    case 1:
                        sTroop = "spear";
                        break;
                    case 2:
                        sTroop = "sword";
                        break;
                    case 3:
                        sTroop = "axe";
                        break;
                    case 4:
                        sTroop = "bowman";
                        break;
                    default:
                        break;
                }

                village_info[sTroop] = (int)village_info[sTroop] + recruit;
                origin_info[sTroop] = (int)origin_info[sTroop] + recruit;

                if (recruit == (int)row["quantity"])
                    dsCommand.Tables["infantry"].Rows.Remove(row);
                else
                    break;
            }

            if (dsCommand.Tables["infantry"].Rows.Count > 0)
            {
                DataRow row = dsCommand.Tables["infantry"].Rows[0];
                SqlCommand cmdUpdateRecruit = conn.CreateCommand();
                cmdUpdateRecruit.CommandText = "update recruit set start_time=@start_time, quantity=@quantity where id=@id";
                cmdUpdateRecruit.Parameters.Add("@start_time", SqlDbType.DateTime).Value = ((DateTime)row["start_time"]).AddSeconds(recruit * Recruit.recruit_unit_time((int)origin_info["barracks"], (int)row["troop"]));
                cmdUpdateRecruit.Parameters.Add("@quantity", SqlDbType.Int).Value = (int)row["quantity"] - recruit;
                cmdUpdateRecruit.Parameters.Add("@id", SqlDbType.Int).Value = (int)row["id"];
                cmdUpdateRecruit.ExecuteNonQuery();
            }


            while (dsCommand.Tables["cavalry"].Rows.Count > 0)
            {
                DataRow row = dsCommand.Tables["cavalry"].Rows[0];

                recruit = Recruit.troop_recruit((DateTime)row["start_time"], next_update, (int)village_info["barracks"], (int)row["troop"], (int)row["quantity"]);
                string sTroop = "scout";
                switch ((int)row["troop"])
                {
                    case 5:
                        sTroop = "scout";
                        break;
                    case 6:
                        sTroop = "light";
                        break;
                    case 7:
                        sTroop = "heavy";
                        break;
                    case 8:
                        sTroop = "mounted";
                        break;
                    default:
                        break;
                }

                village_info[sTroop] = (int)village_info[sTroop] + recruit;
                origin_info[sTroop] = (int)origin_info[sTroop] + recruit;

                if (recruit == (int)row["quantity"])
                    dsCommand.Tables["cavalry"].Rows.Remove(row);
                else
                    break;
            }

            if (dsCommand.Tables["cavalry"].Rows.Count > 0)
            {
                DataRow row = dsCommand.Tables["cavalry"].Rows[0];
                SqlCommand cmdUpdateRecruit = conn.CreateCommand();
                cmdUpdateRecruit.CommandText = "update recruit set start_time=@start_time, quantity=@quantity where id=@id";
                cmdUpdateRecruit.Parameters.Add("@start_time", SqlDbType.DateTime).Value = ((DateTime)row["start_time"]).AddSeconds(recruit * Recruit.recruit_unit_time((int)origin_info["barracks"], (int)row["troop"]));
                cmdUpdateRecruit.Parameters.Add("@quantity", SqlDbType.DateTime).Value = (int)row["quantity"] - recruit;
                cmdUpdateRecruit.Parameters.Add("@id", SqlDbType.Int).Value = (int)row["id"];
                cmdUpdateRecruit.ExecuteNonQuery();
            }

            //
            while (dsCommand.Tables["engine"].Rows.Count > 0)
            {
                DataRow row = dsCommand.Tables["engine"].Rows[0];

                recruit = Recruit.troop_recruit((DateTime)row["start_time"], next_update, (int)village_info["barracks"], (int)row["troop"], (int)row["quantity"]);
                string sTroop = "ram";
                switch ((int)row["troop"])
                {
                    case 9:
                        sTroop = "ram";
                        break;
                    case 10:
                        sTroop = "catapult";
                        break;
                    default:
                        break;
                }

                village_info[sTroop] = (int)village_info[sTroop] + recruit;
                origin_info[sTroop] = (int)origin_info[sTroop] + recruit;

                if (recruit == (int)row["quantity"])
                    dsCommand.Tables["engine"].Rows.Remove(row);
                else
                    break;
            }

            if (dsCommand.Tables["engine"].Rows.Count > 0)
            {
                DataRow row = dsCommand.Tables["engine"].Rows[0];
                SqlCommand cmdUpdateRecruit = conn.CreateCommand();
                cmdUpdateRecruit.CommandText = "update recruit set start_time=@start_time, quantity=@quantity where id=@id";
                cmdUpdateRecruit.Parameters.Add("@start_time", SqlDbType.DateTime).Value = ((DateTime)row["start_time"]).AddSeconds(recruit * Recruit.recruit_unit_time((int)origin_info["barracks"], (int)row["troop"]));
                cmdUpdateRecruit.Parameters.Add("@quantity", SqlDbType.DateTime).Value = (int)row["quantity"] - recruit;
                cmdUpdateRecruit.Parameters.Add("@id", SqlDbType.Int).Value = (int)row["id"];
                cmdUpdateRecruit.ExecuteNonQuery();
            }

            // Xây noble
            while (dsCommand.Tables["noble"].Rows.Count > 0)
            {
                DataRow row = dsCommand.Tables["noble"].Rows[0];

                recruit = Recruit.troop_recruit((DateTime)row["start_time"], next_update, (int)village_info["barracks"], (int)row["troop"], (int)row["quantity"]);
                village_info["noble"] = (int)village_info["noble"] + recruit;
                origin_info["noble"] = (int)origin_info["noble"] + recruit;

                if (recruit == (int)row["quantity"])
                    dsCommand.Tables["noble"].Rows.Remove(row);
                else
                    break;
            }

            if (dsCommand.Tables["noble"].Rows.Count > 0)
            {
                DataRow row = dsCommand.Tables["noble"].Rows[0];
                SqlCommand cmdUpdateRecruit = conn.CreateCommand();
                cmdUpdateRecruit.CommandText = "update recruit set start_time=@start_time, quantity=@quantity where id=@id";
                cmdUpdateRecruit.Parameters.Add("@start_time", SqlDbType.DateTime).Value = ((DateTime)row["start_time"]).AddSeconds(recruit * Recruit.recruit_unit_time((int)origin_info["barracks"], (int)row["troop"]));
                cmdUpdateRecruit.Parameters.Add("@quantity", SqlDbType.DateTime).Value = (int)row["quantity"] - recruit;
                cmdUpdateRecruit.Parameters.Add("@id", SqlDbType.Int).Value = (int)row["id"];
                cmdUpdateRecruit.ExecuteNonQuery();
            }


            //resource
            village_info["wood"] = Resource.update((int)village_info["timbercamp"], (int)village_info["wood"], last_attack, next_update);
            origin_info["wood"] = village_info["wood"];
            village_info["clay"] = Resource.update((int)village_info["claypit"], (int)village_info["clay"], last_attack, next_update);
            origin_info["clay"] = village_info["clay"];
            village_info["iron"] = Resource.update((int)village_info["ironmine"], (int)village_info["iron"], last_attack, next_update);
            origin_info["iron"] = village_info["iron"];

            //resource_coming
            while ((dsCommand.Tables["resource_coming"].Rows.Count > 0) || ((DateTime)dsCommand.Tables["resource_coming"].Rows[0]["landing_time"] < next_update))
            {
                DataRow row = dsCommand.Tables["resource_coming"].Rows[0];
                village_info["wood"] = (int)village_info["wood"] + (int)row["wood"];
                origin_info["wood"] = village_info["wood"];
                village_info["clay"] = (int)village_info["clay"] + (int)row["clay"];
                origin_info["clay"] = village_info["clay"];
                village_info["iron"] = (int)village_info["iron"] + (int)row["iron"];
                origin_info["iron"] = village_info["iron"];
            }

            //xây nhà
            while (dsCommand.Tables["build"].Rows.Count > 0)
            {
                DataRow row = dsCommand.Tables["build"].Rows[0];
                string sBuilding = "headquarter";
                switch ((int)row["building"])
                {
                    case 1:
                        sBuilding = "headquarter";
                        break;
                    case 2:
                        sBuilding = "barracks";
                        break;
                    case 3:
                        sBuilding = "stable";
                        break;
                    case 4:
                        sBuilding = "workshop";
                        break;
                    case 5:
                        sBuilding = "academy";
                        break;
                    case 6:
                        sBuilding = "smithy";
                        break;
                    case 7:
                        sBuilding = "rally";
                        break;
                    case 8:
                        sBuilding = "market";
                        break;
                    case 9:
                        sBuilding = "timbercamp";
                        break;
                    case 10:
                        sBuilding = "claypit";
                        break;
                    case 11:
                        sBuilding = "ironmine";
                        break;
                    case 12:
                        sBuilding = "farm";
                        break;
                    case 13:
                        sBuilding = "storage";
                        break;
                    case 14:
                        sBuilding = "hide";
                        break;
                    case 15:
                        sBuilding = "wall";
                        break;
                    default:
                        break;
                }
                village_info[sBuilding] = (int)village_info[sBuilding] + 1;
                origin_info[sBuilding] = (int)origin_info[sBuilding] + 1;
            }
            
            
            //Mãi mới đến đánh nhau :(
            int spear1, sword1, axe1, bowman1, light1, scout1, heavy1, mounted1, ram1, catapult1, noble1, iron1 = 0, clay1 = 0, wood1 = 0;

            DataRow row1 = dsCommand.Tables["incoming"].Rows[0];

            bool attackWin1 = AttackCalculator.attack(
                (int)row1["spear"], (int)row1["sword"], (int)row1["axe"], (int)row1["bowman"], (int)row1["light"], (int)row1["scout"], (int)row1["heavy"], (int)row1["mounted"], (int)row1["ram"], (int)row1["catapult"], (int)row1["noble"],
                (int)village_info["spear"], (int)village_info["sword"], (int)village_info["axe"], (int)village_info["bowman"], (int)village_info["light"], (int)village_info["scout"], (int)village_info["heavy"], (int)village_info["mounted"], (int)village_info["ram"], (int)village_info["catapult"], (int)village_info["noble"],
                out spear1, out sword1, out axe1, out bowman1, out light1, out scout1, out heavy1, out mounted1, out ram1, out catapult1, out noble1);

            if (attackWin1)
            {
                int intCanHaul = spear1 * 25 + sword1 * 15 + axe1 * 10 + bowman1 * 10 + light1 * 80 + heavy1 * 50 + mounted1 * 50;
                int intTotalResource = (int)village_info["iron"] + (int)village_info["clay"] + (int)village_info["wood"];

                if (intTotalResource <= intCanHaul)
                {
                    clay1 = (int)village_info["clay"];
                    wood1 = (int)village_info["wood"];
                    iron1 = (int)village_info["iron"];
                }
                else
                {
                    clay1 = (int)(((double)village_info["clay"] / (double)intTotalResource) * intCanHaul);
                    wood1 = (int)(((double)village_info["wood"] / (double)intTotalResource) * intCanHaul);
                    iron1 = (int)(((double)village_info["iron"] / (double)intTotalResource) * intCanHaul);
                }

                DateTime landing_time = Map.LandingTime(1, (int)village_info["x"], (int)village_info["y"], (int)village_info["x"], (int)village_info["y"]);

                SqlCommand cmdReturn = conn.CreateCommand();
                cmdReturn.CommandText = "insert into movement " +
                    "(from, to, type, starting_time, landing_time, spear, sword, axe, bowman, scout, light, heavy, mounted, ram, catapult, noble, clay, wood, iron) values " +
                    "(@from, @to, 4, @starting_time, @landing_time, @spear, @sword, @axe, @bowman, @scout, @light, @heavy, @mounted, @ram, @catapult, @noble, @clay, @wood, @iron)";

                cmdReturn.Parameters.Add("@from", SqlDbType.Int).Value = village_id;
                cmdReturn.Parameters.Add("@to", SqlDbType.Int).Value = row1["from"];
                cmdReturn.Parameters.Add("@starting_time", SqlDbType.DateTime).Value = (DateTime)row1["landing_time"];
                cmdReturn.Parameters.Add("@landing_time", SqlDbType.DateTime).Value = landing_time;
                cmdReturn.Parameters.Add("@spear", SqlDbType.Int).Value = spear1;
                cmdReturn.Parameters.Add("@sword", SqlDbType.Int).Value = sword1;
                cmdReturn.Parameters.Add("@axe", SqlDbType.Int).Value = axe1;
                cmdReturn.Parameters.Add("@bowman", SqlDbType.Int).Value = bowman1;
                cmdReturn.Parameters.Add("@scout", SqlDbType.Int).Value = scout1;
                cmdReturn.Parameters.Add("@light", SqlDbType.Int).Value = light1;
                cmdReturn.Parameters.Add("@heavy", SqlDbType.Int).Value = heavy1;
                cmdReturn.Parameters.Add("@ram", SqlDbType.Int).Value = ram1;
                cmdReturn.Parameters.Add("@catapult", SqlDbType.Int).Value = catapult1;
                cmdReturn.Parameters.Add("@noble", SqlDbType.Int).Value = noble1;
                cmdReturn.Parameters.Add("@clay", SqlDbType.Int).Value = clay1;
                cmdReturn.Parameters.Add("@wood", SqlDbType.Int).Value = wood1;
                cmdReturn.Parameters.Add("@iron", SqlDbType.Int).Value = iron1;

                cmdReturn.ExecuteNonQuery();
            }
            dsCommand.Tables["incoming"].Rows.Remove(row1);
        }

        //cập nhật lại


        if (conn.State != ConnectionState.Closed)
            conn.Close();
        return village_info;
    }
     

	public Village()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
