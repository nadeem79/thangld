using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
public partial class Mail_detail : System.Web.UI.Page
{
    protected Village village;
    protected Mail Detail;
    protected void Page_Load(object sender, EventArgs e)
    {
        int mail_id;
        ISession session = NHibernateHelper.CreateSession();
        int.TryParse(Request["mail"], out mail_id);
        Player user = session.Load<Player>(Session["user"]);
        Detail = user.GetMailDetail(mail_id, session);
        session.Close();
    }
    protected void delete_click(object sender, EventArgs e)
    {
        ISession session = null;
        int types;
        session = NHibernateHelper.CreateSession();
        int.TryParse(Request["type"], out types);
        if (types == 1)
        {
            Detail.ReceiverDelete = true;
        }
        else Detail.SenderDelete = true;
        session.Save(Detail);
        session.Close();
    }
}