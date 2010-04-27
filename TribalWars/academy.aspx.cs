using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class academy : System.Web.UI.Page
{
    protected Village Village
    {
        get;
        set;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.Village = ((inPage)(this.Master)).CurrentVillage;
        if (this.Village[BuildingType.Academy] > 0)
            this.pConstructed.Visible = true;
        else
            this.pNotConstruct.Visible = true;

        switch (Request["page"])
        {
            case "create":
                CreateHero pCreateHero = (CreateHero)Page.LoadControl(@"CreateHero.ascx");
                pCreateHero.Village = this.Village;
                this.tblMenu.Rows[1].Cells[0].Attributes.Add("class", "selected");
                this.heroPanel.Controls.Add(pCreateHero);
                break;
            case "details":
                HeroDetails pHeroDetails = (HeroDetails)Page.LoadControl(@"HeroDetails.ascx");
                pHeroDetails.Village = this.Village;
                this.tblMenu.Rows[0].Cells[0].Attributes.Add("class", "selected");
                this.heroPanel.Controls.Add(pHeroDetails);
                break;
            default:
                HeroList pHeroList = (HeroList)Page.LoadControl(@"HeroList.ascx");
                pHeroList.Village = this.Village;
                this.tblMenu.Rows[0].Cells[0].Attributes.Add("class", "selected");
                this.heroPanel.Controls.Add(pHeroList);
                break;
        }
    }
}
