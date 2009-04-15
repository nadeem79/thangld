using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class dialogs_tribe_member : System.Web.UI.Page
{
    protected Player Member
    {
        get;
        set;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        int member_id = 0;
        int.TryParse(Request["member"], out member_id);
        if (member_id <= 0)
        {
            pNotEnoughPrivilage.Visible = true;
            pCanChange.Visible = false;
            return;
        }


        ISession session = null;
        try
        {
            session = NHibernateHelper.CreateSession();

            Player p = session.Load<Player>(Session["user"]);
            if (p == null || (p.TribePermission & TribePermission.Baron) != TribePermission.Baron)
            {
                pNotEnoughPrivilage.Visible = true;
                pCanChange.Visible = false;
                return;
            }

            this.Member = session.Load<Player>(member_id);
            if (this.Member == null || this.Member.Group != p.Group || (int)p.TribePermission < (int)this.Member.TribePermission)
            {
                pNotEnoughPrivilage.Visible = true;
                pCanChange.Visible = false;
                return;
            }

            if (this.Member.TribePermission == TribePermission.Inviter)
                this.chkInviter.Checked = true;
            else if (this.Member.TribePermission == TribePermission.DiplomateOfficer)
                this.chkDiplomate.Checked = true;
            else if (this.Member.TribePermission == TribePermission.Baron)
                this.chkBaron.Checked = true;
            else if (this.Member.TribePermission == TribePermission.Duke)
                this.chkDuke.Checked = true;

        }
        catch { }
        finally
        {
            if (session != null && session.IsOpen)
                session.Close();
        }
    }
}
