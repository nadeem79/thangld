﻿using System;
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
using Telerik.Web.UI;

public partial class test : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //ISession session = NHibernateHelper.CreateSession();
        
        //ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        //Group g = session.Get<Group>(1);
        //Group g2 = session.Get<Group>(4);
        //this.Button1.Text = g.Allies.Count.ToString();
        //session.DisableFilter("AllyFilter");
        //g.Allies.Add(g2);
        //trans.Commit();
        //session.Close();


    }

    protected void bttnSend_Click(object sender, EventArgs e)
    {
        this.lblConfirm.Text = this.txtInput.Text;
        pAttack.Show();  
    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
        if (this.txtInput.Text == "111")
        {
            this.txtInput.Text = "abc";
        }
        else
            this.txtInput.Text = "xys";
    }
}
