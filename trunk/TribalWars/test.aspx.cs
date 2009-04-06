using System;
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
    int i = 0;
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

    protected void Button1_Click1(object sender, EventArgs e)
    {
        i++;
        RadWindow window = new RadWindow();
        window.ID = "window" + i.ToString();
        window.NavigateUrl = "http://www.google.com";
        window.VisibleOnPageLoad = true;
        window.Modal = true;
        this.RadWindowManager1.Windows.Add(window);
    }
}
