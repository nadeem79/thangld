using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using beans;

public partial class TribeShoutbox : System.Web.UI.UserControl
{

    public Group Group
    {
        get;
        set;
    }

    public int Size
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Shoutbox1.Group = this.Group;
        //this.Shoutbox1.Size = this.Size;
        this.Radwindow1.NavigateUrl = string.Format("../shoutbox.aspx?group_chat={0}", Group.ID);
        this.Radwindow1.Title = Group.Name;
        this.Radwindow1.Behaviors = Telerik.Web.UI.WindowBehaviors.None;
        this.Radwindow1.InitialBehaviors = Telerik.Web.UI.WindowBehaviors.Pin | Telerik.Web.UI.WindowBehaviors.Maximize;
    }
}
