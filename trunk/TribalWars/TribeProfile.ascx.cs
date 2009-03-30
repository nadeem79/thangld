using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using beans;
using NHibernate;

public partial class TribeProfile : System.Web.UI.UserControl
{

    protected Group tribe;
    protected Village village;
    public Group Tribe
    {
        get { return this.tribe; }
        set { this.tribe = value; }
    }
    public Village Village
    {
        get { return this.village; }
        set { this.village = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();
        Player player = session.Get<Player>(Session["user"]);
        TribePermission p = player.TribePermission & TribePermission.ChangeTribeDescription;
        if ((player.TribePermission & TribePermission.ChangeTribeDescription) != TribePermission.ChangeTribeDescription)
            this.pChangeDescription.Visible = false;
        session.Close();
    }
}
