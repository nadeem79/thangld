using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using Telerik.Web.UI;

public partial class dialogs_tribe_member : System.Web.UI.Page
{
    protected Player Member
    {
        get;
        set;
    }
    private ISession session = null;
    private ITransaction transaction = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        int member_id = 0;
        int.TryParse(Request["member"], out member_id);
        if (member_id <= 0)
        {
            pNotEnoughPrivilage.Visible = false;
            pCanChange.Visible = false;
            pUserNotFound.Visible = true;
            return;
        }

        try
        {

            Player p = session.Load<Player>(Session["user"]);
            if (p == null || (p.TribePermission & TribePermission.Baron) != TribePermission.Baron)
            {
                pNotEnoughPrivilage.Visible = true;
                pCanChange.Visible = false;
                pUserNotFound.Visible = false;
                return;
            }

            this.Member = session.Get<Player>(member_id);

            if (this.Member == null || this.Member.Group != p.Group)
            {
                pNotEnoughPrivilage.Visible = false;
                pCanChange.Visible = false;
                pUserNotFound.Visible = true;
                return;
            }

            if ((p.TribePermission & TribePermission.Baron) != TribePermission.Baron)
            {
                pNotEnoughPrivilage.Visible = true;
                pCanChange.Visible = false;
                pUserNotFound.Visible = false;
                return;
            }

            if ((int)p.TribePermission < (int)this.Member.TribePermission)
            {
                pNotEnoughPrivilage.Visible = true;
                pCanChange.Visible = false;
                pUserNotFound.Visible = false;
                return;
            }

            pNotEnoughPrivilage.Visible = false;
            pUserNotFound.Visible = false;

            if (p.TribePermission != TribePermission.Duke)
                this.pDukePrivilage.Visible = false;

            if (this.Member.TribePermission == TribePermission.Inviter)
                this.chkInviter.Checked = true;
            else if (this.Member.TribePermission == TribePermission.DiplomateOfficer)
                this.chkDiplomate.Checked = true;
            else if (this.Member.TribePermission == TribePermission.Baron)
                this.chkBaron.Checked = true;
            else if (this.Member.TribePermission == TribePermission.Duke)
                this.chkDuke.Checked = true;

        }
        catch (Exception exception)
        {
            
        }
        finally
        {
        }
    }

    protected void bttnChangeMemberPrivilage_Click(object sender, EventArgs e)
    {
        TribePermission permission = TribePermission.Member;
        if (chkDuke.Checked)
            permission = TribePermission.Duke;
        else if (chkBaron.Checked)
            permission = TribePermission.Baron;
        else if (chkDiplomate.Checked)
            permission = TribePermission.DiplomateOfficer;
        else if (chkInviter.Checked)
            permission = TribePermission.Inviter;
        
        try
        {

            Player me = session.Load<Player>(Session["user"]);
            IList<beans.Error> lstErrors = me.SetMemberPrivilageAndTitle(this.Member, permission, this.txtTribeTitle.Text, session);

            if (lstErrors.Count>0)
            {
                string errors = "";
                foreach (Error error in lstErrors)
                    errors += error.Text;
                RadScriptManager.RegisterStartupScript(bttnChangeMemberPrivilage, bttnChangeMemberPrivilage.GetType(), "ShowException", "jQuery.facebox('" + errors + "');", true);
                transaction.Rollback();
            }

            RadScriptManager.RegisterStartupScript(bttnChangeMemberPrivilage, bttnChangeMemberPrivilage.GetType(), "SendAttack", "CloseAndRefresh();", true);
        }
        catch(Exception exception)
        {
            RadScriptManager.RegisterStartupScript(bttnChangeMemberPrivilage, bttnChangeMemberPrivilage.GetType(), "ShowException", "jQuery.facebox('" + exception.Message + "');", true);
        }
        finally
        {
        }
    }

    protected void bttnCancel_Click(object sender, EventArgs e)
    {
        RadScriptManager.RegisterStartupScript(bttnChangeMemberPrivilage, bttnChangeMemberPrivilage.GetType(), "SendAttack", "Close();", true);
    }
}