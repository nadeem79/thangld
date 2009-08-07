using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class administrator_administrator : System.Web.UI.MasterPage
{
    public Player CurrentPlayer
    {
        get;
        set;
    }
    public ISession NHibernateSession
    {
        get;
        set;
    }

    public administrator_administrator()
    {
        this.Init += new EventHandler(administrator_administrator_Init);
        this.PreRender += new EventHandler(administrator_administrator_PreRender);
    }

    void administrator_administrator_PreRender(object sender, EventArgs e)
    {
        this.NHibernateSession.Close();
    }

    void administrator_administrator_Init(object sender, EventArgs e)
    {
        if (object.Equals(Session["staffID"], null))
        {
            //Response.Redirect("login.aspx", false);
            //return;
            Session["staffID"] = 1;
        }

        this.NHibernateSession = NHibernateHelper.CreateSession();
        this.CurrentPlayer = Player.GetPlayerByID((int)Session["staffID"], this.NHibernateSession);
        if (this.CurrentPlayer.Type != UserType.Moderator && this.CurrentPlayer.Type != UserType.Administrator)
        {
            Session.Remove("staffID");
            Response.Redirect("login.aspx", false);
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}
