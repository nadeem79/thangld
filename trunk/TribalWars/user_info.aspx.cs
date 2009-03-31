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

public partial class user_info : System.Web.UI.Page
{
    protected Village village = null;
    protected Player player = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        inPage p = (inPage)this.Master;
        village = p.CurrentVillage;

        int player_id = 0;
        int.TryParse(Request["player"], out player_id);
        if (player_id == 0)
        {
            this.pUserExists.Visible = false;
            this.pUserNotFound.Visible = true;
            return;
        }

        ISession session = NHibernateHelper.CreateSession();
        this.player = session.Get<Player>(player_id);
        session.Close();

        if (this.player == null)
        {
            this.pUserExists.Visible = false;
            this.pUserNotFound.Visible = true;
            return;
        }

        this.pUserNotFound.Visible = false;
        this.pUserExists.Visible = true;
        this.gvVillages.DataSource = this.player.Villages;
        System.Web.UI.WebControls.HyperLinkField field = (HyperLinkField)this.gvVillages.Columns[0];
        field.DataNavigateUrlFormatString = "village_info.aspx?id=" + this.village.ID.ToString() + "&village={0}";
        this.gvVillages.DataBind();

        this.pSelf.Visible = (this.player.ID == (int)Session["user"]);
    }
}
