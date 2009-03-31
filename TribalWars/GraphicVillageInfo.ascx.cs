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

public partial class GraphicVillageInfo : System.Web.UI.UserControl
{

    protected Village village;
    protected bool displayBuildingLevel;

    public bool DisplayBuildingLevel
    {
        get { return this.displayBuildingLevel; }
        set { this.displayBuildingLevel = value; }
    }

    public Village CurrentVillage
    {
        get { return this.village; }
        set { this.village = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DisplayBuildingLevel)
            this.bttnHideBuildingLevel.Text = "Hiển thị nâng cấp công trình";
    }

    protected void bttnSwitchTextVillageOverview_Click(object sender, EventArgs e)
    {
        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = NHibernateHelper.CreateSession();
            Player player = session.Load<Player>(Session["user"]);
            player.GraphicalVillage = false;
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

    protected void bttnHideBuildingLevel_Click(object sender, EventArgs e)
    {
        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = NHibernateHelper.CreateSession();
            Player player = session.Load<Player>(Session["user"]);
            player.ShowBuildingLevel = !player.ShowBuildingLevel;
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
