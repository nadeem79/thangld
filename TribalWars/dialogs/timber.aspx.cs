using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using beans;

public partial class dialogs_timber : System.Web.UI.Page
{
    protected Village Village
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        int id = 0;
        int.TryParse(Request["id"], out id);
        Player p = session.Load<Player>(Session[Constant.NormalUserSessionSign]);
        this.Village = (from village in p.Villages
                        where village.ID == id
                        select village).SingleOrDefault<Village>();
        if (this.Village == null)
            this.Village = p.Villages[0];
    }
}
