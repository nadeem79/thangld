using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class TribeDiplomacy : System.Web.UI.UserControl
{
    protected Village _village;
    public Village Village
    {
        get { return this._village; }
        set { this._village = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.cbRelation.Items.Add(new Telerik.Web.UI.RadComboBoxItem(TribeDiplomate.Ally.ToString(), "2"));
        this.cbRelation.Items.Add(new Telerik.Web.UI.RadComboBoxItem(TribeDiplomate.NAP.ToString(), "1"));
        this.cbRelation.Items.Add(new Telerik.Web.UI.RadComboBoxItem(TribeDiplomate.Enemy.ToString(), "3"));

        ISession session = NHibernateHelper.CreateSession();
        Player p = session.Get<Player>(Session["user"]);
        this.gvAllies.DataSource = p.Group.Allies;
        this.gvEnemies.DataSource = p.Group.Enemies;
        this.gvNaps.DataSource = p.Group.Naps;
        this.gvNaps.DataBind();
        this.gvEnemies.DataBind();
        this.gvAllies.DataBind();
        session.Close();
    }
}
