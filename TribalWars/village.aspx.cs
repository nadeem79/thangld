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
using beans;

public partial class village : System.Web.UI.Page
{

    protected Village current;

    protected void Page_Load(object sender, EventArgs e)
    {
        current = ((inPage)(this.Master)).CurrentVillage;
    }

    private string CreateTroopLabel(string image, int number, string name)
    {
        return "";
    }
}
