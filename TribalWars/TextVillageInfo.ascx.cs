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

using beans;
using NHibernate;

public partial class TextVillageInfo : System.Web.UI.UserControl
{

    protected Village current;
    public Village CurrentVillage
    {
        get { return this.current; }
        set { this.current = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void bttnSwitchGraphicsVillageOverview_Click(object sender, EventArgs e)
    {
        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            Player player = session.Load<Player>(Session["user"]);
            player.GraphicalVillage = true;
            session.Update(player);
            Response.Redirect("village.aspx?id=" + this.CurrentVillage.ID.ToString(), false);
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
        }
    }
}
