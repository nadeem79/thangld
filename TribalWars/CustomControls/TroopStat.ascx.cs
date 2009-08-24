using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using Telerik.Web.UI;

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

        if (this.Village.StationsAtMe.Count > 0)
        {
            this.stationAtMeRepeater.DataSource = this.Village.StationsAtMe;
            this.stationAtMeRepeater.DataBind();
            this.withdrawStationAtMeButton.Visible = true;
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

            this.Village.VillageTroopMethods.WithdrawStation(stationId, session);
        }
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
                this.Village.VillageTroopMethods.SendBackStation(stationId, session);
            }
        }
        Response.Redirect(Request.Url.ToString(), false);
    }
    protected void stationAtMeRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
