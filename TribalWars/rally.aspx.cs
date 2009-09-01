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
using System.Data.SqlClient;
using NHibernate;
using beans;
using NHibernate.Criterion;
using System.Collections.Generic;
using Telerik.Web.UI;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public partial class rally : System.Web.UI.Page
{
    
    protected beans.Village village;
    protected Attack attack;
    protected Support support;

    

    protected void Page_Load(object sender, EventArgs e)
    {

        inPage p = (inPage)this.Master;
        village = p.CurrentVillage;

        if (this.village[BuildingType.Rally] > 0)
            this.pConstructed.Visible = true;
        else
        {
            this.pNotConstruct.Visible = true;
            return;
        }

        switch (Request["page"])
        {
            case "unit":
                TroopStat pTroopStat = (TroopStat)Page.LoadControl(@"TroopStat.ascx");
                pTroopStat.Village = this.village;
                this.tblMenu.Rows[1].Cells[0].Attributes.Add("class", "selected");
                this.troopPanel.Controls.Add(pTroopStat);
                break;
            default:
                TroopCommand pTroopCommand = (TroopCommand)Page.LoadControl(@"TroopCommand.ascx");
                pTroopCommand.Village = this.village;
                this.tblMenu.Rows[0].Cells[0].Attributes.Add("class", "selected");
                this.troopPanel.Controls.Add(pTroopCommand);
                break;
        }
        
    }

    
}
