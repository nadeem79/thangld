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
            session = NHibernateHelper.CreateSession();
            Player player = session.Load<Player>(Session["user"]);
            player.GraphicalVillage = true;
            trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
            session.Update(player);
            trans.Commit();
            Response.Redirect("village.aspx?id=" + this.CurrentVillage.ID.ToString(), true);
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
            if (trans != null)
                trans.Rollback();
        }
        finally
        {
            if (session != null)
                session.Close();
        }
    }
}
