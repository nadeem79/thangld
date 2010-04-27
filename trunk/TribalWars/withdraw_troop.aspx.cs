using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class withdraw_troop : System.Web.UI.Page
{

    public Village Village
    {
        get;
        set;
    }

    public Station MyStation
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        inPage p = (inPage)this.Master;
        this.Village = p.CurrentVillage;

        int stationId = 0;
        if (!int.TryParse(Request["station"], out stationId))
        {
            Response.Redirect(string.Format("rally.aspx?id={0}&page=unit", this.Village), false);
            return;
        }

        NHibernate.ISession session = (NHibernate.ISession)Context.Items["NHibernateSession"];

        this.MyStation = this.Village.VillageTroopMethods.GetStationById(stationId, session);
        if (this.MyStation == null)
        {
            Response.Redirect(string.Format("rally.aspx?id={0}&page=unit", this.Village), false);
            return;
        }

    }

    protected void withdrawButton_Click(object sender, EventArgs e)
    {
        int spear, sword, axe, scout, lightCavalry, heavyCavalry, ram, catapult, noble;

        int.TryParse(this.spear.Text, out spear);
        int.TryParse(this.sword.Text, out sword);
        int.TryParse(this.axe.Text, out axe);
        int.TryParse(this.scout.Text, out scout);
        int.TryParse(this.lightCavalry.Text, out lightCavalry);
        int.TryParse(this.heavyCavalry.Text, out heavyCavalry);
        int.TryParse(this.ram.Text, out ram);
        int.TryParse(this.catapult.Text, out catapult);
        int.TryParse(this.noble.Text, out noble);

        if ((spear + sword + axe + scout + lightCavalry + heavyCavalry + ram + catapult + noble) <= 0)
            return;

        ISession session = (ISession)Context.Items["NHibernateSession"];

        this.Village.VillageTroopMethods.WithdrawStation(this.MyStation, spear, sword, axe, scout, lightCavalry, heavyCavalry, ram, catapult, noble, session);

        Response.Redirect(string.Format("rally.aspx?id={0}&page=unit", this.Village.ID), false);
    }
}
