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
using beans;
using System.Collections.Generic;
using NHibernate;

public partial class barrack : System.Web.UI.Page
{

    protected beans.Village village;

    protected void Page_Load(object sender, EventArgs e)
    {
        village = ((inPage)this.Master).CurrentVillage;
        ISession session = NHibernateHelper.CreateSession();
        IList<Recruit> recruits = village.GetRecruit(session, BuildingType.Barracks);

        string sRecruitCommands = "";
        for (int i=0; i<recruits.Count; i++)
        {
            sRecruitCommands += "<tr class='lit'>";
            sRecruitCommands += "<td>" + recruits[i].Quantity.ToString();
            switch (recruits[i].Troop)
            {
                case TroopType.Spear:
                    sRecruitCommands += " lính giáo</td>";
                    break;
                case TroopType.Sword:
                    sRecruitCommands += " lính kiếm</td>";
                    break;
                case TroopType.Axe:
                    sRecruitCommands += " lính rìu</td>";
                    break;
                default:
                    break;
            }
            sRecruitCommands += "<td>";
            if (i == 0)
                sRecruitCommands += "<span class='timer'>";
            
            sRecruitCommands += (Functions.FormatTime(recruits[i].LastUpdate.AddSeconds(Recruit.RecruitTime(recruits[i].Troop, recruits[i].Quantity, this.village.Barracks)) - DateTime.Now)).ToString() + "</span></td>";
            sRecruitCommands += "<td>" + recruits[i].LastUpdate.AddSeconds(Recruit.RecruitTime(recruits[i].Troop, recruits[i].Quantity, this.village.Barracks)) + "</td>";
        }
        this.lblRecruiting.Text = sRecruitCommands;
        session.Close();
    }
    protected void bttnRecruit_Click(object sender, EventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();
        
        int spear = 0, sword = 0, axe = 0;

        int.TryParse(this.txtSpear.Text, out spear);
        int.TryParse(this.txtSword.Text, out sword);
        int.TryParse(this.txtAxe.Text, out axe);

        if (spear > 0)
            if (this.village.BeginRecruit(TroopType.Spear, spear, session)==null)
                lblError.Text = "Không đủ tài nguyên";
        
        if (sword > 0)
            if (this.village.BeginRecruit(TroopType.Sword, sword, session) == null)
                lblError.Text = "Không đủ tài nguyên";
        if (axe > 0)
            if (this.village.BeginRecruit(TroopType.Axe, axe, session) == null)
                lblError.Text = "Không đủ tài nguyên";
        session.Close();

        if (lblError.Text.Equals(string.Empty))
            Response.Redirect("barrack.aspx?id=" + this.village.ID.ToString(), true);
    }
}
