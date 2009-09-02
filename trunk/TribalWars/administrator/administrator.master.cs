using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using Telerik.Web.UI;

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
    }

    void administrator_administrator_Init(object sender, EventArgs e)
    {
        if (object.Equals(Session[Constant.StaffUserSessionSign], null))
        {
            Response.Redirect("login.aspx", true);
            return;
            //Session[Constant.StaffUserSessionSign] = 1;
        }

        this.NHibernateSession = (ISession)Context.Items[Constant.NHibernateSessionSign];
        this.CurrentPlayer = Player.GetPlayerByID((int)Session[Constant.StaffUserSessionSign], this.NHibernateSession);

        if (this.CurrentPlayer.StaffGroups.Count == 0)
        {
            Session.Remove(Constant.StaffUserSessionSign);
            Response.Redirect("login.aspx", true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        //this.menu.FindNodeByUrl(Request.Url.ToString()).ParentNode.ExpandChildNodes();
        this.Label1.Text = string.Format("ga - {0} - bb", menu.Nodes[0].Value);
    }

    public RadTreeView Menu
    {
        get { return this.menu; }
    }

    protected void bttnRestartServer_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        TribalWarsEngine.Start(session);
    }
}
