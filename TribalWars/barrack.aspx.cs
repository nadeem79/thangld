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
    private ISession NHibernateSession
    {
        get;
        set;
    }

    protected string GetTroopText(TroopType type)
    {
        switch (type)
        {
            case TroopType.Spear:
                return "lính giáo";
            case TroopType.Sword:
                return "lính kiếm";
            case TroopType.Axe:
                return "lính rìu";
        }
        return "";
    }
    protected string GetFirstRecruit(int index)
    {
        if (index == 0)
            return "class='timer'";
        return "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        this.NHibernateSession = (ISession)Context.Items[Constant.NHibernateSessionSign];

        village = ((inPage)this.Master).CurrentVillage;
        Price p = Recruit.GetPrice(TroopType.Axe, this.village[BuildingType.Barracks]);
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

        IList<Recruit> recruits = village.VillageRecruitMethods.InfantryRecruits;
        if (recruits.Count > 0)
        {
            this.rInfantryRecruits.DataSource = recruits;
            this.rInfantryRecruits.DataBind();
        }
    }

    protected string TroopTypeString(TroopType type)
    {
        switch (type)
        {
            case TroopType.Spear:
                return "lính giáo";
            case TroopType.Sword:
                return "lính kiếm";
            case TroopType.Axe:
                return "lính rìu";
            default:
                return "";
        }
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

    protected void bttnRecruit_Click(object sender, EventArgs e)
    {
        

        int spear = 0, sword = 0, axe = 0;

        int.TryParse(this.txtSpear.Text, out spear);
        int.TryParse(this.txtSword.Text, out sword);
        int.TryParse(this.txtAxe.Text, out axe);
        if (spear > 0)
            if (this.village.VillageRecruitMethods.BeginRecruit(TroopType.Spear, spear, this.NHibernateSession) == null)
                lblError.Text = "Không đủ tài nguyên";
        
        if (sword > 0)
            if (this.village.VillageRecruitMethods.BeginRecruit(TroopType.Sword, sword, this.NHibernateSession) == null)
                lblError.Text = "Không đủ tài nguyên";
        if (axe > 0)
            if (this.village.VillageRecruitMethods.BeginRecruit(TroopType.Axe, axe, this.NHibernateSession) == null)
                lblError.Text = "Không đủ tài nguyên";

        if (lblError.Text.Equals(string.Empty))
            Response.Redirect("barrack.aspx?id=" + this.village.ID.ToString(), true);
    }
}
