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

/// <summary>
/// Summary description for Resource
/// </summary>
public class Resource
{

    protected static int production(int level)
    {
        if (level == 1)
            return 30;
        return production(level - 1);
    }

    public static int update(int level, int current, DateTime start, DateTime stop)
    {
        TimeSpan span = stop - start;
        double time = span.TotalHours;
        return (int)time*production(level) + current;
    }

    public Resource()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
