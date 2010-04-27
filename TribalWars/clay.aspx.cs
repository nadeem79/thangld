using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using beans;

public partial class clay : System.Web.UI.Page
{

    protected Village current;

    protected void Page_Load(object sender, EventArgs e)
    {
        current = ((inPage)(this.Master)).CurrentVillage;
        if (this.current[BuildingType.ClayPit] > 0)
            this.pConstructed.Visible = true;
        else
            this.pNotConstruct.Visible = true;

    }
}
