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

        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player player = session.Get<Player>(Session["user"]);


        if (player.Group != null)
        {
            Response.Redirect("tribe.aspx?ID=" + this.village.ID.ToString(), true);
        }
        if (player.Group == null)
        {
            this.invites = player.Invites;
            this.gvInvite.DataSource = this.invites;

            this.gvInvite.DataBind();
        }
    }


    protected void gvInvite_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        if (e.CommandName == "cmdAgree")
        {
            Player currentPlayer = session.Get<Player>(Session["user"]);
            currentPlayer.Group = this.invites[int.Parse((string)e.CommandArgument)].Group;
            currentPlayer.TribePermission = TribePermission.Member;
            session.Update(currentPlayer);
            session.Delete(this.invites[int.Parse((string)e.CommandArgument)]);
            Response.Redirect("tribe.aspx?id=" + this.village.ID.ToString(), true);
        }
        else if (e.CommandName == "cmdReject")
        {
            session.Delete(this.invites[int.Parse((string)e.CommandArgument)]);
            Response.Redirect("untribe.aspx?id=" + this.village.ID.ToString(), true);
        }
    }

    protected void bttnCreateTribe_Click(object sender, EventArgs e)
    {
        Group group = new Group();
        group.Tag = this.txtTribeTagName.Text;
        group.Name = this.txtTribeName.Text;
        group.Description = "";

        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player player = session.Get<Player>(Session["user"]);
        session.Save(group);
        player.Group = group;
        player.TribePermission = TribePermission.Duke;
        session.Update(player);
        Response.Redirect("tribe.aspx?id=" + this.village.ID.ToString(), true);
    }
}
