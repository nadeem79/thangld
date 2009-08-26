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
using System.Collections.Generic;
using beans;
using NHibernate;

public partial class stable : System.Web.UI.Page
{

    protected beans.Village village;
    protected ISession NHibernateSession
    {
        get;
        set;
    }

    protected string TroopTypeString(TroopType type)
    {
        switch (type)
        {
            case TroopType.Scout:
                return "siêu điệp viên";
            case TroopType.Light:
                return "kỵ binh";
            case TroopType.Heavy:
                return "hiệp sỹ";
        }
        return "";
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

    protected Price scoutPrice, lightCavalryPrice, heavyCavalryPrice;

    protected void Page_Load(object sender, EventArgs e)
    {
        village = ((inPage)this.Master).CurrentVillage;

        this.scoutPrice = Recruit.GetPrice(TroopType.Scout, this.village[BuildingType.Stable]);
        this.lightCavalryPrice = Recruit.GetPrice(TroopType.Light, this.village[BuildingType.Stable]);
        this.heavyCavalryPrice = Recruit.GetPrice(TroopType.Heavy, this.village[BuildingType.Stable]);

        this.NHibernateSession = ((inPage)this.Master).NHibernateSession;
        if (Request["mode"] != null && Request["mode"] == "cancel_recruit")
        {
            int id = 0;
            int.TryParse(Request["recruit_id"], out id);
            if (id != 0)
            {
                this.village.VillageRecruitMethods.CancelRecruit(id, this.NHibernateSession);
                ((inPage)this.Master).WoodLabel.Text = this.village.VillageResourceData.Wood.ToString();
                ((inPage)this.Master).ClayLabel.Text = this.village.VillageResourceData.Clay.ToString();
                ((inPage)this.Master).IronLabel.Text = this.village.VillageResourceData.Iron.ToString();
            }
        }

        IList<Recruit> recruits = this.village.VillageRecruitMethods.CavalryRecruits;
        if (recruits.Count > 0)
        {
            this.rCavalryRecruits.DataSource = recruits;
            this.rCavalryRecruits.DataBind();
        }
        
        
    }

    protected void bttnRecruit_Click(object sender, EventArgs e)
    {
        int scout = 0, light = 0, heavy = 0;

        int.TryParse(this.txtScout.Text, out scout);
        int.TryParse(this.txtLight.Text, out light);
        int.TryParse(this.txtHeavy.Text, out heavy);

        if (scout > 0)
            if (this.village.VillageRecruitMethods.BeginRecruit(TroopType.Scout, scout, this.NHibernateSession) == null)
                lblError.Text = "Không đủ tài nguyên";

        if (light > 0)
            if (this.village.VillageRecruitMethods.BeginRecruit(TroopType.Light, light, this.NHibernateSession) == null)
                lblError.Text = "Không đủ tài nguyên";
        if (heavy > 0)
            if (this.village.VillageRecruitMethods.BeginRecruit(TroopType.Heavy, heavy, this.NHibernateSession) == null)
                lblError.Text = "Không đủ tài nguyên";
        if (lblError.Text.Equals(string.Empty))
            Response.Redirect("stable.aspx?id=" + this.village.ID.ToString(), false);
    }
}
