using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using NHibernate;
using beans;
using System.Collections.Generic;

public partial class inPage : System.Web.UI.MasterPage
{

    private beans.Village village = null;
    public beans.Village CurrentVillage
    {
        get
        {
            return this.village;
        }
    }

    public inPage()
    {
        this.Init += new EventHandler(inPage_Init);
    }

    void inPage_Init(object sender, EventArgs e)
    {

        DateTime start = DateTime.Now;
        int id;
        ISession session;
        ITransaction trans;
        if (object.Equals(Session["user"], null))
        {
            Response.Redirect("index.aspx", true);
            return;
        }

        session = NHibernateHelper.CreateSession();

        
        beans.Player currentUser = session.Load<beans.Player>((int)Session["user"]);
        
        if (currentUser == null)
        {
            session.Close();
            Response.Redirect("index.aspx", true);
        }

        trans = session.BeginTransaction();
        currentUser.Update(DateTime.Now, session);
        
        
        
        if (object.Equals(Request["id"], null) || (!int.TryParse(Request["id"], out id)))
            this.village = currentUser.Villages[0];
        else
            this.village = currentUser.GetVillage(id, session);

        if (this.village == null)
            this.village = currentUser.Villages[0];

        int incomingAttackCount = village.GetIncomingAttackCount(session);
        int incomingSupportCount = village.GetIncomingSupportCount(session);

        

        DateTime stop = DateTime.Now;
        this.delay.Text = (stop - start).Milliseconds.ToString();
        this.time.Text = start.ToString("dd/MM/yyyy hh:mm:ss");
        trans.Commit();
        session.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}