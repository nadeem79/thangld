using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;
using beans;
using NHibernate;

public partial class village_info : System.Web.UI.Page
{
    protected Village village = null;
    protected Village target = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        inPage p = (inPage)this.Master;
        village = p.CurrentVillage;

        int village_id;
        int.TryParse(Request["village"], out village_id);
        if (village_id == 0)
        {
            Response.Redirect("village.aspx?id=" + this.village.ToString(), true);
            return;
        }

        ISession session = NHibernateHelper.CreateSession();
        target = session.Get<Village>(village_id);
        session.Close();

        if (target == null)
        {
            this.pHasVillage.Visible = false;
            this.pVillageNotFound.Visible = true;
            return;
        }

        this.pHasVillage.Visible = true;
        this.pVillageNotFound.Visible = false;

        if (this.target.Owner.ID == (int)Session["user"])
            this.pIsOwner.Visible = true;
        else
            this.pIsOwner.Visible = false;
    }
}
