using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using NHibernate.Linq;
using beans;

public partial class dialogs_gfufutfuyfuyf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        IList<Player> players = (from player in session.Linq<Player>()
                                 select player).ToList<Player>();

        foreach (Player p in players)
        {
            p.Password = Utilities.Encrypt(p.Password);
            session.Update(p);
        }
    }
}
