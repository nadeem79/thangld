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
/// Summary description for Functions
/// </summary>
public class Functions
{
    public static string FormatTime(TimeSpan time)
    {
        return (time.Days * 24 + time.Hours).ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public Functions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
