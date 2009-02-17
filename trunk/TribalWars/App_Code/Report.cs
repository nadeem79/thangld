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
/// Summary description for Report
/// </summary>
public class Report
{

    public static void WriteAttackReport(
        int aVillage, int dVillage, string owner, DateTime create_time,
        int aSpear,  int aSword,  int aAxe,  int aBowman,  int aLight,  int aScout,  int aHeavy,  int aMounted,  int aRam,  int aCatapult,  int aNoble,
        int dSpear,  int dSword,  int dAxe,  int dBowman,  int dLight,  int dScout,  int dHeavy,  int dMounted,  int dRam,  int dCatapult,  int dNoble,
        bool winningSide, // true nếu là bên thắng, false nếu là bên thua
        int sSpear,  int sSword,  int sAxe,  int sBowman,  int sLight,  int sScout,  int sHeavy,  int sMounted,  int sRam,  int sCatapult,  int sNoble,
        int wood, int clay, int iron)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);
        SqlCommand cmdReport = conn.CreateCommand();

        cmdReport.CommandText = "insert into reports (owner, village_1, village_2, create_time, winningside," +
            "aspear, asword, aaxe, abow, ascout, alight, aheavy, amounted, aram, acatapult, anoble, " +
            "dspear, dsword, daxe, dbow, dscout, dlight, dheavy, dmounted, dram, dcatapult, dnoble, " +
            "sspear, ssword, saxe, sbow, sscout, slight, sheavy, smounted, sram, scatapult, snoble, " +
            "clay, wood, iron) " +
            " values (@owner, @village_1, @village_2, @create_time, @winningside," +
            "@aspear, @asword, @aaxe, @abow, @ascout, @alight, @aheavy, @amounted, @aram, @acatapult, @anoble, " +
            "@dspear, @dsword, @daxe, @dbow, @dscout, @dlight, @dheavy, @dmounted, @dram, @dcatapult, @dnoble, " +
            "@sspear, @ssword, @saxe, @sbow, @sscout, @slight, @sheavy, @smounted, @sram, @scatapult, @snoble, " +
            "@clay, @wood, @iron)";

        cmdReport.Parameters.Add("@owner", SqlDbType.NVarChar, 200).Value = owner;
        cmdReport.Parameters.Add("@village_1", SqlDbType.Int).Value = aVillage;
        cmdReport.Parameters.Add("@village_2", SqlDbType.Int).Value = dVillage;
        cmdReport.Parameters.Add("@create_time", SqlDbType.DateTime).Value = create_time;
        cmdReport.Parameters.Add("@winningside", SqlDbType.Bit).Value = winningSide;

        cmdReport.Parameters.Add("@aspear", SqlDbType.Int).Value = aSpear;
        cmdReport.Parameters.Add("@asword", SqlDbType.Int).Value = aSword;
        cmdReport.Parameters.Add("@aaxe", SqlDbType.Int).Value = aAxe;
        cmdReport.Parameters.Add("@abow", SqlDbType.Int).Value = aBowman;
        cmdReport.Parameters.Add("@ascout", SqlDbType.Int).Value = aScout;
        cmdReport.Parameters.Add("@alight", SqlDbType.Int).Value = aLight;
        cmdReport.Parameters.Add("@aheavy", SqlDbType.Int).Value = aHeavy;
        cmdReport.Parameters.Add("@amounted", SqlDbType.Int).Value = aMounted;
        cmdReport.Parameters.Add("@aram", SqlDbType.Int).Value = aRam;
        cmdReport.Parameters.Add("@acatapult", SqlDbType.Int).Value = aCatapult;
        cmdReport.Parameters.Add("@anoble", SqlDbType.Int).Value = aNoble;

        cmdReport.Parameters.Add("@dspear", SqlDbType.Int).Value = dSpear;
        cmdReport.Parameters.Add("@dsword", SqlDbType.Int).Value = dSword;
        cmdReport.Parameters.Add("@daxe", SqlDbType.Int).Value = dAxe;
        cmdReport.Parameters.Add("@dbow", SqlDbType.Int).Value = dBowman;
        cmdReport.Parameters.Add("@dscout", SqlDbType.Int).Value = dScout;
        cmdReport.Parameters.Add("@dlight", SqlDbType.Int).Value = dLight;
        cmdReport.Parameters.Add("@dheavy", SqlDbType.Int).Value = dHeavy;
        cmdReport.Parameters.Add("@dmounted", SqlDbType.Int).Value = dMounted;
        cmdReport.Parameters.Add("@dram", SqlDbType.Int).Value = dRam;
        cmdReport.Parameters.Add("@dcatapult", SqlDbType.Int).Value = dCatapult;
        cmdReport.Parameters.Add("@dnoble", SqlDbType.Int).Value = dNoble;

        cmdReport.Parameters.Add("@sspear", SqlDbType.Int).Value = sSpear;
        cmdReport.Parameters.Add("@ssword", SqlDbType.Int).Value = sSword;
        cmdReport.Parameters.Add("@saxe", SqlDbType.Int).Value = sAxe;
        cmdReport.Parameters.Add("@sbow", SqlDbType.Int).Value = sBowman;
        cmdReport.Parameters.Add("@sscout", SqlDbType.Int).Value = sScout;
        cmdReport.Parameters.Add("@slight", SqlDbType.Int).Value = sLight;
        cmdReport.Parameters.Add("@sheavy", SqlDbType.Int).Value = sHeavy;
        cmdReport.Parameters.Add("@smounted", SqlDbType.Int).Value = sMounted;
        cmdReport.Parameters.Add("@sram", SqlDbType.Int).Value = sRam;
        cmdReport.Parameters.Add("@scatapult", SqlDbType.Int).Value = sCatapult;
        cmdReport.Parameters.Add("@snoble", SqlDbType.Int).Value = sNoble;

        conn.Open();
        cmdReport.ExecuteNonQuery();
        conn.Close();
    }

    public Report()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
