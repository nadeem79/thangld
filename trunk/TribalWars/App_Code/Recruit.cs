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
/// Summary description for Recruit
/// </summary>
public class Recruit
{
    private static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);

    protected static int recruit_time(int level, int quantity, int troop)
    {
        int second = 900;

        for (int i = 0; i < level; i++)
            second -= (int)(second * 0.05);

        return second * quantity;
    }

    public static DateTime finish_recruit(int level, int troop, int quantity, DateTime start_time)
    {
        return start_time.AddSeconds(recruit_time(level, quantity, troop));
    }

    public static int troop_recruit(DateTime start, DateTime end, int level, int troop, int quantity)
    {
        TimeSpan t = end - start;
        int time = recruit_time(level, quantity, troop);
        //int total_troop = t.Seconds % 
        //Math.Round(

        return 0;
    }

    public Recruit()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
