﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using System.Data;
public partial class Mail_detail : System.Web.UI.Page
{
    protected Village village;
    protected Mail Detail;
    protected void Page_Load(object sender, EventArgs e)
    {
        int mail_id;
        ISession session = (ISession)Context.Items["NHibernateSession"];
        int.TryParse(Request["mail"], out mail_id);
        Player user = session.Load<Player>(Session["user"]);
        Detail = user.GetMailDetail(mail_id, session);
    }
    protected void delete_click(object sender, EventArgs e)
    {
        
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ISession session = null;
        int types;
        session = (ISession)Context.Items["NHibernateSession"];
        int.TryParse(Request["type"], out types);
        ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        if (types == 1)
            Detail.ReceiverDelete = true;
        else 
            Detail.SenderDelete = true;
        session.Update(Detail);
        trans.Commit();
        
    }
}