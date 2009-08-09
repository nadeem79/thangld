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

public partial class TribeMembers : System.Web.UI.UserControl
{

    protected Group tribe;
    protected Village village;

    public Village Village
    {
        get { return this.village; }
        set { this.village = value; }
    }
    public Group Tribe
    {
        get { return this.tribe; }
        set { this.tribe = value; }
    }
    public Player Member
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        NHibernate.ISession session = (ISession)Context.Items["NHibernateSession"];
        this.Member = session.Get<Player>(Session["user"]);
        this.Member.Group.GetMembers(session);
        this.drTribeMembers.DataSource = this.Member.Group.Members;
        this.drTribeMembers.DataBind();

        if (((this.Member.TribePermission & TribePermission.Inviter) != TribePermission.Inviter) || (this.Tribe != this.Member.Group))
            this.pInviting.Visible = false;

    }

    protected void bttnInvite_Click(object sender, EventArgs e)
    {
        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = (ISession)Context.Items["NHibernateSession"];
            trans = session.BeginTransaction(IsolationLevel.ReadCommitted);

            Player me = session.Load<Player>(Session["user"]);
            IList<beans.Error> lstErrors = me.InvitePlayer(this.txtUser.Text, session);
            if (lstErrors.Count>0)
            {
                string errors = "";
                foreach (Error error in lstErrors)
                    errors += String.Format("{0}{1}", error.Text, Environment.NewLine);
                ScriptManager.RegisterStartupScript(bttnInvite, bttnInvite.GetType(), "ShowException", "jQuery.facebox('" + errors + "');", true);
            }

            ScriptManager.RegisterStartupScript(bttnInvite, bttnInvite.GetType(), "ShowException", "jQuery.facebox('Gửi thư mời gia nhập thành công');", true);
            trans.Commit();
        }
        catch (Exception ex)
        {
            if (trans!=null)
                trans.Rollback();
            RadScriptManager.RegisterStartupScript(bttnInvite, bttnInvite.GetType(), "ShowException", "jQuery.facebox('" + ex.Message + "');", true);
        }

        

        
        
    }
}
