using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

public partial class outPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.lblToogleShoutbox.Text = "<a href=\"javascript:void(0);\" onclick=\"ShowHideShoutbox('" + this.RadDock1.ClientID + "')\">Ẩn / hiện shoutbox</a>";
    }
    
    
    protected void Timer1_Tick(object sender, EventArgs e)
    {

    }
}
