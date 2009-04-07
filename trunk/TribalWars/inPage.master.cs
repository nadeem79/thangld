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
            if (ViewState["village"] == null)
                return this.village;
            return (Village)ViewState["village"];
        }
    }
    public Player Player
    {
        get { return this.player; }
    }

    public inPage()
    {
        this.Init += new EventHandler(inPage_Init);
    }

    void inPage_Init(object sender, EventArgs e)
    {

        if (object.Equals(Session["user"], null))
        {
            Response.Redirect("session_expired.aspx", true);
            return;
        }

        if (IsPostBack)
        {
            this.village = (Village)ViewState["village"];
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
        trans = session.BeginTransaction();
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
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ViewState["village"] = village;
            this.lblToogleShoutbox.Text = "<a href=\"javascript:void(0);\" onclick=\"ShowHideShoutbox('" + this.radShoutbox.ClientID + "')\">Shoutbox</a>";
        }
    }
}