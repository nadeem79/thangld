using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using System.Data;

/// <summary>
/// Summary description for HttpModule
/// </summary>
public class NHibernateHttpModule:IHttpModule
{
    public NHibernateHttpModule()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region IHttpModule Members

    public void Dispose()
    {
        //throw new NotImplementedException();
    }

    public void Init(HttpApplication context)
    {
        context.BeginRequest += new EventHandler(this.context_BeginRequest);
        context.EndRequest += new EventHandler(this.context_EndRequest);
    }

    private void context_BeginRequest(object sender, EventArgs e)
    {
        log4net.Config.XmlConfigurator.Configure();
        if (HttpContext.Current.Request.Path.ToLower().IndexOf(".aspx") <= -1)
            return;

        HttpApplication application = (HttpApplication)sender;
        HttpContext context = application.Context;

        ISession session = NHibernateHelper.CreateSession();
        session.BeginTransaction(IsolationLevel.ReadCommitted);
        context.Items["NHibernateSession"] = session;
    }

    private void context_EndRequest(object sender, EventArgs e)
    {

        if (HttpContext.Current.Request.Path.ToLower().IndexOf(".aspx") <= -1)
            return;


        HttpApplication application = (HttpApplication)sender;
        HttpContext context = application.Context;

        //((ISession)context.Items["NHibernateSession"]).Flush();
        ((ISession)context.Items["NHibernateSession"]).Transaction.Commit();
        ((ISession)context.Items["NHibernateSession"]).Close();
        context.Items["NHibernateSession"] = null;
    }

    #endregion
}
