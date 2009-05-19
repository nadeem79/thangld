using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;
using NHibernate;
using beans;
using System.Collections.Generic;
using Telerik.Web.UI;

public partial class ainPage : System.Web.UI.MasterPage
{
    private Admin admin;
    public Admin Admin
    {
        get { return this.Admin; }
    }


    public ainPage()
    {
        this.Init += new EventHandler(inPage_Init);
    }

    void inPage_Init(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Session["user"] = 1;

        if (object.Equals(Session["user"], null))
        {
            Response.Redirect("session_expired.aspx", true);
            return;
        }

        DateTime start = DateTime.Now;
        int id;
        ISession session;
        ITransaction trans;


        session = NHibernateHelper.CreateSession();

        this.admin = session.Load<beans.Admin>((int)Session["user"]);

        if (this.Admin == null)
        {
            session.Close();
            Response.Redirect("index.aspx", true);
        }
        trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        trans.Commit();
        session.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}