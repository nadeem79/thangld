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

        if (this.CurrentPlayer.Username == "thangld")
        {
            this.CurrentPlayer.StaffGroups.Add(new StaffGroup());
            this.CurrentPlayer.StaffGroups[0].Permissions = new List<Permission>();
            this.CurrentPlayer.StaffGroups[0].Permissions.Add(new Permission(JobEnum.MemberManagement, "read write"));
            this.CurrentPlayer.StaffGroups[0].Permissions.Add(new Permission(JobEnum.StaffGroupManagement, "read write"));
            this.CurrentPlayer.StaffGroups[0].Permissions.Add(new Permission(JobEnum.NumericSettings, ""));
            this.CurrentPlayer.StaffGroups[0].Permissions.Add(new Permission(JobEnum.RestartServer, ""));
            this.CurrentPlayer.StaffGroups[0].Permissions.Add(new Permission(JobEnum.TextSettings, ""));
        }

        if (this.CurrentPlayer.StaffGroups.Count == 0)
        {
            Session.Remove(Constant.StaffUserSessionSign);
            Response.Redirect("login.aspx", true);
        }

        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public RadTreeView Menu
    {
        get { return this.menu; }
    }

    protected void menu_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        RadTreeNode parent = menu.FindNodeByValue(JobEnum.NumericSettings.ToString());
        if (parent == null)
            return;
        
        RadTreeNode restartNode = parent.Nodes.FindNodeByValue(JobEnum.RestartServer.ToString());
        if (restartNode == null)
            return;

        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        ServicesList.ConfigurationService.RestartServer(this.CurrentPlayer, session);
    }
}
