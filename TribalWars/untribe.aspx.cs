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

using NHibernate;
using beans;
using System.Collections.Generic;

public partial class untribe : System.Web.UI.Page
{

    IList<TribeInvite> invites;
    protected Village village;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.village = ((inPage)this.Master).CurrentVillage;

        ISession session = NHibernateHelper.CreateSession();
        Player player = session.Get<Player>(Session["user"]);


        if (player.Group != null)
        {
            session.Close();
            Response.Redirect("tribe.aspx?ID=" + this.village.ID.ToString(), true);
        }
        if (player.Group == null)
        {
            this.invites = player.Invites;
            this.gvInvite.DataSource = this.invites;

            this.gvInvite.DataBind();
        }
        session.Close();
    }


    protected void gvInvite_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        ISession session = NHibernateHelper.CreateSession();
        ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        if (e.CommandName == "cmdAgree")
        {
            Player currentPlayer = session.Get<Player>(Session["user"]);
            currentPlayer.Group = this.invites[int.Parse((string)e.CommandArgument)].Group;
            currentPlayer.TribePermission = TribePermission.Member;
            session.Update(currentPlayer);
            session.Delete(this.invites[int.Parse((string)e.CommandArgument)]);
            trans.Commit();
            session.Close();
            Response.Redirect("tribe.aspx?id=" + this.village.ID.ToString(), true);
        }
        else if (e.CommandName == "cmdReject")
        {
            session.Delete(this.invites[int.Parse((string)e.CommandArgument)]);
            trans.Commit();
            session.Close();
            Response.Redirect("untribe.aspx?id=" + this.village.ID.ToString(), true);
        }
    }

    protected void bttnCreateTribe_Click(object sender, EventArgs e)
    {
        Group group = new Group();
        group.Tag = this.txtTribeTagName.Text;
        group.Name = this.txtTribeName.Text;
        group.Description = "";

        ISession session = NHibernateHelper.CreateSession();
        Player player = session.Get<Player>(Session["user"]);
        ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        session.Save(group);
        player.Group = group;
        player.TribePermission = TribePermission.Duke;
        session.Update(player);
        trans.Commit();
        session.Close();
        Response.Redirect("tribe.aspx?id=" + this.village.ID.ToString(), true);
    }
}
