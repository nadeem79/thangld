using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;

public partial class TribeMembers : System.Web.UI.UserControl
{

    protected Group tribe;
    protected Village village;

    public Village Village
    {
        get { return this.village; }
        set { this.village = value; }
    }
    public Group Tribe
    {
        get { return this.tribe; }
        set { this.tribe = value; }
    }
    public Player Member
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        NHibernate.ISession session = NHibernateHelper.CreateSession();
        this.Member = session.Get<Player>(Session["user"]);
        this.tribe = this.Member.Group;
        this.drTribeMembers.DataSource = this.Member.Group.Members;
        this.drTribeMembers.DataBind();
        session.Close();
    }
}
