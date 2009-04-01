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


    protected void Page_Load(object sender, EventArgs e)
    {
        NHibernate.ISession session = NHibernateHelper.CreateSession();
        Player player = session.Get<Player>(Session["user"]);
        this.gvTribeMembers.DataSource = player.Group.Members;
        this.tribe = player.Group;
        System.Web.UI.WebControls.HyperLinkField field = (HyperLinkField)this.gvTribeMembers.Columns[0];
        field.DataNavigateUrlFormatString = "user_info.aspx?id=" + this.village.ID.ToString() + "&player={0}";
        this.gvTribeMembers.DataBind();
        session.Close();
    }
}
