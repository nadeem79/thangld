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
/// Summary description for Build
/// </summary>
public class Build
{
    private static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["tw"].ConnectionString);

    protected static int build_time(int level, int headquarter, int building)
    {
        int second = 1200;

        for (int i = 0; i < level; i++)
            second += (int)(second * 0.2);
        for (int i = 0; i < headquarter; i++)
            second -= (int)(second * 0.05);

        return second;
    }

    public static DateTime finish_build(int level, int headquarter, DateTime start_time, int building)
    {
        return start_time.AddSeconds(build_time(level, headquarter, building));
    }

    public Build()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}