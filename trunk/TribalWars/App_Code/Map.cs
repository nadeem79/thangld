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
using System.Diagnostics;



/// <summary>
/// Summary description for Map
/// </summary>
public class Map
{

    private static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);

    public static double MovingCalculator(int sourceX, int sourceY, int desX, int desY)
    {
        return Math.Sqrt(Math.Pow(sourceX - desX, 2) + Math.Pow(sourceY - desY, 2));
    }

    public static DateTime LandingTime(int troop, int sourceX, int sourceY, int desX, int desY, DateTime start)
    {
        return start.AddMilliseconds(MovingCalculator(sourceX, sourceY, desX, desY) * 300000);
    }

    public static Decimal CreateVillage(string username)
    {

        Decimal id = 0;
        int x;
        int y;
        int count = 0;
        Random r = new Random();
        do
        {
            count++;
            x = r.Next(20);
            y = r.Next(20);

            SqlCommand cmdCheckVillage = conn.CreateCommand();
            cmdCheckVillage.CommandText = "select count(id) from villages where x=@x and y=@y";
            cmdCheckVillage.Parameters.Add("@x", SqlDbType.Int).Value = x;
            cmdCheckVillage.Parameters.Add("@y", SqlDbType.Int).Value = y;

            SqlCommand cmdCreateVillage = conn.CreateCommand();
            cmdCreateVillage.CommandText = "insert into villages(x, y, name, userid, last_update) values (@x, @y, @name, @userid, @time);select @@identity as id";

            cmdCreateVillage.Parameters.Add("@x", SqlDbType.Int).Value = x;
            cmdCreateVillage.Parameters.Add("@y", SqlDbType.Int).Value = x;
            cmdCreateVillage.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = username + " village";
            cmdCreateVillage.Parameters.Add("@userid", SqlDbType.NVarChar, 200).Value = username;
            cmdCreateVillage.Parameters.Add("@time", SqlDbType.DateTime).Value = DateTime.Now;

            if (conn.State!=ConnectionState.Open)
                conn.Open();

            
            int hasVillage = (int)cmdCheckVillage.ExecuteScalar();
            if (hasVillage > 0)
            {
                conn.Close();
                continue;
            }

            //id = (int)cmdCreateVillage.ExecuteScalar();
            //id = 1;
            //Debugger.Log(1, "abc", cmdCreateVillage.ExecuteScalar().GetType().ToString());
            id = (Decimal)cmdCreateVillage.ExecuteScalar();
            if (id <= 0)
            {
                conn.Close();
                continue;
            }
            
            conn.Close();
        }
        while ((id == 0));

        return id;
    }


	public Map()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
