using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using beans;
using NHibernate;

public partial class shoutbox : System.Web.UI.Page
{
    protected Player currentPlayer;
    protected void Page_Load(object sender, EventArgs e)
    {


            if (Request["group_chat"] == null)
            {
                this.Shoutbox.Group = null;
            }
            else
            {
                ISession session = (ISession)Context.Items["NHibernateSession"];
                currentPlayer = session.Get<Player>(Session["user"]);
                this.Shoutbox.Group = currentPlayer.Group;
            }

 

    }
}
