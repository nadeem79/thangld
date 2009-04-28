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
        ISession session = NHibernateHelper.CreateSession();
        Player user = session.Load<Player>(Session["user"]);
        int page;
        int.TryParse(Request["page"], out page);
        IList<Mail> lstMail = user.GetMailSend(page, session);
        this.gvMail.DataSource = lstMail;
        System.Web.UI.WebControls.HyperLinkField field = (HyperLinkField)this.gvMail.Columns[0];
        field.DataNavigateUrlFormatString = "Mail_details.aspx?id=" + this.village.ID.ToString();
        this.gvMail.DataBind();        
        session.Close();

    }
  

}
