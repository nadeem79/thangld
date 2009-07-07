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

    public barrack()
    {
        this.PreInit += new EventHandler(barrack_PreInit);
        this.LoadComplete += new EventHandler(barrack_LoadComplete);
    }

    protected void barrack_PreInit(object sender, EventArgs e)
    {
        this.NHibernateSession = NHibernateHelper.CreateSession();
        
    }

    protected void barrack_LoadComplete(object sender, EventArgs e)
    {
        if (this.NHibernateSession != null)
            this.NHibernateSession.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {



        village = ((inPage)this.Master).CurrentVillage;
        this.NHibernateSession.Lock(this.village, LockMode.None);

        if (Request["mode"] != null && Request["mode"] == "cancel_recruit")
        {
            int id = 0;
            int.TryParse(Request["recruit_id"], out id);
            if (id != 0)
            {
                ITransaction trans = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
                this.village.CancelRecruit(id, this.NHibernateSession);
                trans.Commit();
                ((inPage)this.Master).WoodLabel.Text = this.village.VillageResourceData.Wood.ToString();
                ((inPage)this.Master).ClayLabel.Text = this.village.VillageResourceData.Clay.ToString();
                ((inPage)this.Master).IronLabel.Text = this.village.VillageResourceData.Iron.ToString();
            }
        }

        IList<Recruit> recruits = village.GetRecruit(this.NHibernateSession, BuildingType.Barracks);
        string sRecruitCommands = "";
        DateTime last_complete = DateTime.Now;
        DateTime complete = DateTime.Now;
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
            {
                sRecruitCommands += "<span class='timer'>";
                last_complete = recruits[i].LastUpdate;
            }
            else
                last_complete = complete;
            complete = last_complete + TimeSpan.FromSeconds(beans.Recruit.GetPrice(recruits[i].Troop, this.village[beans.BuildingType.Barracks]).BuildTime * recruits[i].Quantity);
            sRecruitCommands += Functions.FormatTime(beans.Recruit.GetPrice(recruits[i].Troop, this.village[beans.BuildingType.Barracks]).BuildTime * recruits[i].Quantity) + "</span></td>";
            sRecruitCommands += String.Format("<td>{0}</td>", complete.ToString("HH:mm:ss 'ngày' dd/MM/yyyy"));

            sRecruitCommands += "<td><a href=\"barrack.aspx?id=" + this.village.ID.ToString() + "&mode=cancel_recruit&recruit_id=" + recruits[i].ID.ToString() + "\">Huỷ</a></td>";
        }
        this.lblRecruiting.Text = sRecruitCommands;
    }



    protected void bttnRecruit_Click(object sender, EventArgs e)
    {
        

        int spear = 0, sword = 0, axe = 0;

        int.TryParse(this.txtSpear.Text, out spear);
        int.TryParse(this.txtSword.Text, out sword);
        int.TryParse(this.txtAxe.Text, out axe);
        ITransaction trans = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
        if (spear > 0)
            if (this.village.BeginRecruit(TroopType.Spear, spear, this.NHibernateSession) == null)
                lblError.Text = "Không đủ tài nguyên";
        
        if (sword > 0)
            if (this.village.BeginRecruit(TroopType.Sword, sword, this.NHibernateSession) == null)
                lblError.Text = "Không đủ tài nguyên";
        if (axe > 0)
            if (this.village.BeginRecruit(TroopType.Axe, axe, this.NHibernateSession) == null)
                lblError.Text = "Không đủ tài nguyên";
        trans.Commit();

        if (lblError.Text.Equals(string.Empty))
            Response.Redirect("barrack.aspx?id=" + this.village.ID.ToString(), true);
    }
}
