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

public partial class command : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int command;
        if (object.Equals(Request["command"], null) || !int.TryParse(Request["command"], out command))
        {
            Response.Redirect("village.aspx?id=" + Request["id"], true);
            return;
        }

       // this.
    }
}
