using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class farm : System.Web.UI.Page
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
        if (this.Village[BuildingType.Farm] > 0)
            this.pConstructed.Visible = true;
        else
            this.pNotConstruct.Visible = true;
    }
}
