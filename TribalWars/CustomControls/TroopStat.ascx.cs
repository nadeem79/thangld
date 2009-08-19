using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class CustomControls_TroopStat : System.Web.UI.UserControl
{

    

    public Village Village
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];

        this.Village.PrepareStationData(session);

        if (this.Village.StationsAtMe.Count > 0)
        {
            this.stationAtMeRepeater.DataSource = this.Village.StationsAtMe;
            this.stationAtMeRepeater.DataBind();
        }
        if (this.Village.StationsFromMe.Count > 0)
        {
            this.stationFromMeRepeater.DataSource = this.Village.StationsFromMe;
            this.stationFromMeRepeater.DataBind();
        }
    }

    protected void stationFromMeRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
        {

            int stationId = 0;
            if (!int.TryParse(((HiddenField)e.Item.FindControl("stationHiddenField")).Value, out stationId))
                return;

            ISession session = (ISession)Context.Items["NHibernateSession"];

            this.Village.WithdrawStation(stationId, session);
        }
    }

    protected void withdrawSomeButton_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        int stationId = 0;
        if (int.TryParse(b.CommandArgument, out stationId))
            return;

        ISession session = (ISession)Context.Items["NHibernateSession"];
        Station station = Station.GetById(stationId, session);
        if (station.FromVillage != this.Village)
            return;

        this.villageNameLiteral.Text = string.Format("{0} ({1}|{2})", station.AtVillage.Name, station.AtVillage.X.ToString("000"), station.AtVillage.Y.ToString("000"));
        this.spearLiteral1.Text = this.spearLiteral2.Text = station.Spear.ToString();
        this.swordLiteral1.Text = this.swordLiteral2.Text = station.Sword.ToString();
        this.axeLiteral1.Text = this.axeLiteral2.Text = station.Axe.ToString();
        this.scoutLiteral1.Text = this.scoutLiteral2.Text = station.Scout.ToString();
        this.lightCavalryLiteral1.Text = this.lightCavalryLiteral2.Text = station.LightCavalry.ToString();
        this.heavyCavalryLiteral1.Text = this.heavyCavalryLiteral2.Text = station.HeavyCavalry.ToString();
        this.ramLiteral1.Text = this.ramLiteral2.Text = station.Ram.ToString();
        this.catapultLiteral1.Text = this.catapultLiteral2.Text = station.Catapult.ToString();
        this.nobleLiteral1.Text = this.nobleLiteral2.Text = station.Noble.ToString();

        ScriptManager.RegisterStartupScript(withdrawSomeButton, withdrawSomeButton.GetType(), "Confirm", "$.facebox($('#withdrawPanel').html().replace(/_unit/gi, ''));", true);
    }

    protected void withdrawStationAtMeButton_Click(object sender, EventArgs e)
    {
        for (int cnt = 0; cnt < stationAtMeRepeater.Items.Count; cnt++)
        {
            // your checkbox ; type casting
            CheckBox cbId = ((CheckBox)stationAtMeRepeater.Items[cnt].FindControl("checkDeleteCheckBox"));


            if (cbId.Checked)
            {
                int stationId = 0;
                if (!int.TryParse(((HiddenField)stationAtMeRepeater.Items[cnt].FindControl("stationIdHiddenField")).Value, out stationId))
                    continue;

                ISession session = (ISession)Context.Items["NHibernateSession"];
                this.Village.WithdrawStation(stationId, session);
            }
        }
        Response.Redirect(Request.Url.ToString(), false);
    }
}
