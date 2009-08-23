using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class Mail_send : System.Web.UI.Page
{
    protected Village village;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.village = ((inPage)this.Master).CurrentVillage;
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player user = session.Load<Player>(Session["user"]);
        int page;
        int.TryParse(Request["page"], out page);

        IList<Mail> mails = user.GetMailFromMe(page, session);
        if (mails.Count > 0)
        {
            this.rMails.DataSource = mails;
            this.rMails.DataBind();
        }

    }
  

}
