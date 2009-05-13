using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;

public partial class market : System.Web.UI.Page
{
    protected beans.Village Village
    {
        get;
        set;
    }
    private ISession NHibernateSession
    {
        get;
        set;
    }
    public market()
    {
        this.PreInit += new EventHandler(market_PreInit);
        this.LoadComplete += new EventHandler(market_LoadComplete);
    }
    protected void market_PreInit(object sender, EventArgs e)
    {
        this.NHibernateSession = NHibernateHelper.CreateSession();
    }
    protected void market_LoadComplete(object sender, EventArgs e)
    {
        if (this.NHibernateSession != null)
            this.NHibernateSession.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Village = ((inPage)this.Master).CurrentVillage;
    }
}
