using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class wall : System.Web.UI.Page
{
    public Village Village
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        inPage p = (inPage)this.Master;
        this.Village = p.CurrentVillage;

    }
}
