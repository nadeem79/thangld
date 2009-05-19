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

    protected void Page_Load(object sender, EventArgs e)
    {
        village = ((inPage)this.Master).CurrentVillage;
        ISession session = NHibernateHelper.CreateSession();
        session.Lock(village, LockMode.None);
        if (Request["mode"] != null && Request["mode"] == "cancel_recruit")
        {
            int id = 0;
            int.TryParse(Request["recruit_id"], out id);
            if (id != 0)
            {
                ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
                this.village.CancelRecruit(id, session);
                trans.Commit();
                ((inPage)this.Master).WoodLabel.Text = this.village.Resources.Wood.ToString();
                ((inPage)this.Master).ClayLabel.Text = this.village.Resources.Clay.ToString();
                ((inPage)this.Master).IronLabel.Text = this.village.Resources.Iron.ToString();
            }
        }

        IList<Recruit> recruits = village.GetRecruit(session, BuildingType.Stable);
        DateTime last_complete = DateTime.Now;
        string sRecruitCommands = "";
        for (int i = 0; i < recruits.Count; i++)
        {
            sRecruitCommands += "<tr class='lit'>";
            sRecruitCommands += "<td>" + recruits[i].Quantity.ToString();
            switch (recruits[i].Troop)
            {
                case TroopType.Scout:
                    sRecruitCommands += " siêu điệp viên</td>";
                    break;
                case TroopType.Light:
                    sRecruitCommands += " kỵ binh</td>";
                    break;
                case TroopType.Heavy:
                    sRecruitCommands += " hiệp sỹ</td>";
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
            {
                last_complete = last_complete.AddSeconds(Recruit.RecruitTime(recruits[i - 1].Troop, recruits[i - 1].Quantity, this.village.Buildings.Stable));
            }

            sRecruitCommands += Functions.FormatTime(Recruit.RecruitTime(recruits[i].Troop, recruits[i].Quantity, this.village.Buildings.Stable)) + "</span></td>";
            sRecruitCommands += "<td>" + last_complete.AddSeconds(Recruit.RecruitTime(recruits[i].Troop, recruits[i].Quantity, this.village.Buildings.Stable)).ToString("HH:mm:ss 'ngày' dd/MM/yyyy ") + "</td>";
            sRecruitCommands += String.Format("<td><a href=\"stable.aspx?id={0}&mode=cancel_recruit&recruit_id={1}\">Hủy</a></td>", this.village.ID, recruits[i].ID);
            sRecruitCommands += "</tr>";
        }
        this.lblRecruiting.Text = sRecruitCommands;
        string s = Functions.FormatTime(beans.Recruit.GetPrice(beans.TroopType.Heavy, this.village.Buildings.Stable).BuildTime);
        session.Close();
        
    }

    protected void bttnRecruit_Click(object sender, EventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();
        //this.village.Update(DateTime.Now, session);
        ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        int scout = 0, light = 0, heavy = 0;

        int.TryParse(this.txtScout.Text, out scout);
        int.TryParse(this.txtLight.Text, out light);
        int.TryParse(this.txtHeavy.Text, out heavy);

        if (scout > 0)
            if (this.village.BeginRecruit(TroopType.Scout, scout, session) == null)
                lblError.Text = "Không đủ tài nguyên";

        if (light > 0)
            if (this.village.BeginRecruit(TroopType.Light, light, session) == null)
                lblError.Text = "Không đủ tài nguyên";
        if (heavy > 0)
            if (this.village.BeginRecruit(TroopType.Heavy, heavy, session) == null)
                lblError.Text = "Không đủ tài nguyên";
        trans.Commit();
        session.Close();
        if (lblError.Text.Equals(string.Empty))
            Response.Redirect("stable.aspx?id=" + this.village.ID.ToString(), true);
    }
}
