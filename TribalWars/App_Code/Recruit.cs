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

    public static int CanRecruit(int totalClay, int totalWood, int totalIron, int priceClay, int priceWood, int priceIron)
    {
        int sumClay = totalClay / priceClay;
        int sumWood = totalWood / priceWood;
        int sumIron = totalIron / priceIron;

        int result = (sumClay < sumWood) ? sumClay : sumWood;
        return ((result < sumIron) ? result : sumIron);
            
    }

    public static int recruit_unit_time(int level, int troop)
    {
        int second = 900;

        for (int i = 0; i < level; i++)
            second -= (int)(second * 0.05);

        return second;
    }

    protected static int recruit_time(int level, int quantity, int troop)
    {
        return recruit_unit_time(level, troop) *quantity;
    }

    public static DateTime finish_recruit(int level, int troop, int quantity, DateTime start_time)
    {
        return start_time.AddSeconds(recruit_time(level, quantity, troop));
    }

    public static int troop_recruit(DateTime start, DateTime end, int level, int troop, int quantity)
    {
        TimeSpan t = end - start;
        int time = recruit_time(level, quantity, troop);
        int total_troop = t.Seconds / 900;

        return (total_troop < quantity) ? total_troop : quantity;
    }

    

   

    public Recruit()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
