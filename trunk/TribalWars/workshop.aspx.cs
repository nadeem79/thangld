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

    protected string FirstRow(int index)
    {
        return (index == 0) ? "class=\"timer\"" : "";
    }
    protected string FirstRowTime(int index, Recruit recruit)
    {
        if (index == 0)
            return Functions.FormatTime(recruit.FinishTime - DateTime.Now);
        return Functions.FormatTime(recruit.FinishTime - recruit.LastUpdate);
    }
    protected string TroopTypeString(TroopType type)
    {
        switch (type)
        {
            case TroopType.Ram:
                return "lính giáo";
            case TroopType.Catapult:
                return "lính kiếm";
            default:
                return "";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        village = ((inPage)this.Master).CurrentVillage;
        this.NHibernateSession = ((inPage)this.Master).NHibernateSession;
        IList<Recruit> recruits = village.VillageRecruitMethods.CarRecruits;
        if (recruits.Count > 0)
        {
            this.rCarRecruits.DataSource = recruits;
            this.rCarRecruits.DataBind();
        }

        
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
