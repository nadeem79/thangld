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

public partial class inPage : System.Web.UI.MasterPage
{
    private Player player;
    private beans.Village village;
    public beans.Village CurrentVillage
    {
        get
        {
            return this.village;
        }
    }
    public Player Player
    {
        get { return this.player; }
    }
    public Label WoodLabel
    {
        get { return this.lblWood; }
    }
    public Label ClayLabel 
    { 
        get { return this.lblClay; }
    }
    public Label IronLabel 
    {
        get { return this.lblIron; }
    }
    



    public inPage()
    {
        this.Init += new EventHandler(inPage_Init);
    }

    void inPage_Init(object sender, EventArgs e)
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


        this.player = session.Load<beans.Player>((int)Session["user"]);

        if (this.player == null)
        {
            session.Close();
            Response.Redirect("index.aspx", true);
        }
        trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        this.player.Update(DateTime.Now, session);
        trans.Commit();

        if (object.Equals(Request["id"], null) || (!int.TryParse(Request["id"], out id)))
            this.village = this.player.Villages[0];
        else
            this.village = this.player.GetVillage(id);
        
        if (this.village == null)
            this.village = this.player.Villages[0];
        

        int incomingAttackCount = village.GetIncomingAttackCount(session);
        int incomingSupportCount = village.GetIncomingSupportCount(session);

        DateTime stop = DateTime.Now;
        this.delay.Text = (stop - start).Milliseconds.ToString();

        if (player.Group == null)
            lTribe.NavigateUrl = "un_tribe.aspx?id=" + this.CurrentVillage.ID.ToString();
        else
            lTribe.NavigateUrl = "tribe.aspx?id=" + this.CurrentVillage.ID.ToString();

        session.Close();

        this.lblClay.Text = this.CurrentVillage.Clay.ToString();
        this.lblWood.Text = this.CurrentVillage.Wood.ToString();
        this.lblIron.Text = this.CurrentVillage.Iron.ToString();

        if (this.CurrentVillage.Wood == this.CurrentVillage.MaxResources)
            this.lblWood.ForeColor = System.Drawing.Color.Red;
        if (this.CurrentVillage.Clay == this.CurrentVillage.MaxResources)
            this.lblClay.ForeColor = System.Drawing.Color.Red;
        if (this.CurrentVillage.Iron == this.CurrentVillage.MaxResources)
            this.lblIron.ForeColor = System.Drawing.Color.Red;

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (this.village == null)
        //{
        //    ISession session;
        //    ITransaction trans;


        //    session = NHibernateHelper.CreateSession();
        //    trans = session.BeginTransaction(IsolationLevel.ReadCommitted);

        //    this.player = session.Load<beans.Player>((int)Session["user"]);

        //    if (this.player == null)
        //    {
        //        session.Close();
        //        Response.Redirect("index.aspx", true);
        //    }
        //    trans = session.BeginTransaction();
        //    this.player.Update(DateTime.Now, session);
        //    trans.Commit();
        //    int id = 0;
        //    if (object.Equals(Request["id"], null) || (!int.TryParse(Request["id"], out id)))
        //        this.village = this.player.Villages[0];
        //    else
        //        this.village = this.player.GetVillage(id);

        //    if (this.village == null)
        //        this.village = this.player.Villages[0];

        //    trans.Commit();
        //    session.Close();
        //}

        //if (!IsPostBack)
        //{
        //    //this.lblToogleShoutbox.Text = "<a href=\"javascript:void(0);\" onclick=\"ShowHideShoutbox('" + this.radShoutbox.ClientID + "')\">Shoutbox</a>";
        //}
    }
}