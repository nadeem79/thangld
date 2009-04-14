using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using System.Data;

public partial class base_page : System.Web.UI.Page
{
    private beans.Player _player;
    private beans.Village _village;
    public beans.Village CurrentVillage
    {
        get
        {
            return this._village;
        }
    }
    public beans.Player Player
    {
        get { return this._player; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
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


        this._player = session.Load<beans.Player>((int)Session["user"]);

        if (this.Player == null)
        {
            session.Close();
            Response.Redirect("index.aspx", true);
        }
        trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        this.Player.Update(DateTime.Now, session);
        trans.Commit();

        if (object.Equals(Request["id"], null) || (!int.TryParse(Request["id"], out id)))
            this._village = this.Player.Villages[0];
        else
            this._village = this.Player.GetVillage(id);

        if (this.CurrentVillage == null)
            this._village = this.Player.Villages[0];


        int incomingAttackCount = CurrentVillage.GetIncomingAttackCount(session);
        int incomingSupportCount = CurrentVillage.GetIncomingSupportCount(session);

        session.Close();
    }
}
