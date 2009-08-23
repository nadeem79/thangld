using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using System.Data;

public partial class workshop : System.Web.UI.Page
{

    protected beans.Village village;
    protected ISession NHibernateSession
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        village = ((inPage)this.Master).CurrentVillage;
        this.NHibernateSession = ((inPage)this.Master).NHibernateSession;
        IList<Recruit> recruits = village.VillageRecruitMethods.GetRecruit(this.NHibernateSession, BuildingType.Workshop);

        string sRecruitCommands = "";
        for (int i = 0; i < recruits.Count; i++)
        {
            sRecruitCommands += "<tr class='lit'>";
            sRecruitCommands += "<td>" + recruits[i].Quantity.ToString();
            switch (recruits[i].Troop)
            {
                case TroopType.Ram:
                    sRecruitCommands += " xe phá tường</td>";
                    break;
                case TroopType.Catapult:
                    sRecruitCommands += " máy ném đá</td>";
                    break;
                default:
                    break;
            }
            sRecruitCommands += "<td>";
            if (i == 0)
                sRecruitCommands += "<span class='timer'>";

            sRecruitCommands += (Functions.FormatTime(recruits[i].LastUpdate.AddSeconds(Recruit.RecruitTime(recruits[i].Troop, recruits[i].Quantity, this.village.VillageBuildingData.Barracks)) - DateTime.Now)).ToString() + "</span></td>";
            sRecruitCommands += "<td>" + recruits[i].LastUpdate.AddSeconds(Recruit.RecruitTime(recruits[i].Troop, recruits[i].Quantity, this.village.VillageBuildingData.Barracks)) + "</td>";
        }
        this.lblRecruiting.Text = sRecruitCommands;
    }


    protected void bttnRecruit_Click(object sender, EventArgs e)
    {
        int ram = 0, catapult = 0;

        int.TryParse(this.txtRam.Text, out ram);
        int.TryParse(this.txtCatapult.Text, out catapult);
        if (ram > 0)
            if (this.village.VillageRecruitMethods.BeginRecruit(TroopType.Ram, ram, this.NHibernateSession) == null)
                lblError.Text = "Không đủ tài nguyên";

        if (catapult > 0)
            if (this.village.VillageRecruitMethods.BeginRecruit(TroopType.Catapult, catapult, this.NHibernateSession) == null)
                lblError.Text = "Không đủ tài nguyên";
        if (lblError.Text.Equals(string.Empty))
            Response.Redirect("workshop.aspx?id=" + this.village.ID.ToString(), false);
    }
}
