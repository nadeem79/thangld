using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class list_mail : System.Web.UI.Page
{
    protected Village village;
    protected string UnreadStatus(bool unread)
    {
        if (unread)
            return "(chưa đọc)";
        return "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.village = ((inPage)this.Master).CurrentVillage;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        Player user = session.Load<Player>(Session["user"]);
        int deleteId = 0;
        if (int.TryParse(Request["delete"], out deleteId))
            user.DeleteMail(deleteId, session);

        int page;
        int.TryParse(Request["page"], out page);
        IList<Mail> lstMail = user.GetMailToMe(page, session);

        if (lstMail.Count > 0)
        {
            this.rMails.DataSource = lstMail;
            this.rMails.DataBind();
        }
    }
  

}
