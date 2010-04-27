using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using System.Data;
using Telerik.Web.UI;

public partial class TribeDiplomacy : System.Web.UI.UserControl
{
    protected Village _village;
    public Village Village
    {
        get { return this._village; }
        set { this._village = value; }
    }

    public ISession NHibernateSession
    {
        get;
        set;
    }

    public TribePermission DiplomacyPermission
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {


        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = (ISession)Context.Items["NHibernateSession"];
            trans = session.BeginTransaction();
            Player p = session.Get<Player>(Session["user"]);
            p.Group.GetDiplomateInfo(session);
            if (Request["action"] == "diplomacy")
            {
                int g = 0;
                int.TryParse(Request["tribe"], out g);
                if (g != 0)
                {
                    Group tribe = session.Get<Group>(g);
                    if (tribe != null)
                    {
                        p.SetDiplomacy(tribe, TribeDiplomate.NoRelation, session);
                        p.Group.Allies.Remove(tribe);
                        p.Group.Enemies.Remove(tribe);
                        p.Group.Naps.Remove(tribe);
                    }

                }
            }

            

            this.gvAllies.DataSource = p.Group.Allies;
            this.gvEnemies.DataSource = p.Group.Enemies;
            this.gvNaps.DataSource = p.Group.Naps;
            this.gvNaps.DataBind();
            this.gvEnemies.DataBind();
            this.gvAllies.DataBind();
            trans.Commit();

            this.pDiplomate.Visible = p.CheckPrivilage(TribePermission.DiplomacyInteract);

        }
        catch 
        {
            if (trans != null && !trans.WasCommitted)
                trans.Rollback();
        }
    }

    protected void bttnAddRelation_Click(object sender, EventArgs e)
    {
        TribeDiplomate type = TribeDiplomateFactory.GetDiplomacy(this.cbRelation.SelectedValue);
        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = (ISession)Context.Items["NHibernateSession"];
            trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
            Player player = session.Get<Player>(Session["user"]);
            
            Group g = Group.GetGroupByTagName(this.txtTag.Text, session);
            if (g == null)
            {
                ScriptManager.RegisterStartupScript(bttnAddRelation, bttnAddRelation.GetType(), "TribeNotFound", "jQuery.facebox('" + Resources.text.tribe_not_found + "');", true);
                trans.Rollback();
                return;
            }
            
            player.SetDiplomacy(g, type, session);
            trans.Commit();
            ScriptManager.RegisterStartupScript(bttnAddRelation, bttnAddRelation.GetType(), "Refresh", "window.location.reload(true);", true);

        }
        catch (NHibernate.Exceptions.GenericADOException ex)
        {
            RadScriptManager.RegisterStartupScript(bttnAddRelation, bttnAddRelation.GetType(), "ShowException", "jQuery.facebox('" + ex.Message + "');", true);
            if (trans != null || !trans.WasCommitted)
                trans.Rollback();
        }
        catch (Exception ex)
        {
            RadScriptManager.RegisterStartupScript(bttnAddRelation, bttnAddRelation.GetType(), "ShowException", "jQuery.facebox('" + ex.Message + " - " + ex.GetType() + "');", true);
            if (trans != null || !trans.WasCommitted)
                trans.Rollback();
        }

    }
}
