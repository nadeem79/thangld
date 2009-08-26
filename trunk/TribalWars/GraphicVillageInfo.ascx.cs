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
using Telerik.Web.UI;
using beans;
using NHibernate;

public partial class GraphicVillageInfo : System.Web.UI.UserControl
{

    protected Village village;
    protected bool displayBuildingLevel;

    public bool DisplayBuildingLevel
    {
        get { return this.displayBuildingLevel; }
        set { this.displayBuildingLevel = value; }
    }

    public Village CurrentVillage
    {
        get { return this.village; }
        set { this.village = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DisplayBuildingLevel)
            this.bttnHideBuildingLevel.Text = "Hiển thị nâng cấp công trình";
    }

    protected void bttnSwitchTextVillageOverview_Click(object sender, EventArgs e)
    {
        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            Player player = session.Load<Player>(Session["user"]);
            player.GraphicalVillage = false;
            session.Update(player);
            Response.Redirect("village.aspx?id=" + this.CurrentVillage.ID.ToString(), false);
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
        }
    }

    protected void bttnHideBuildingLevel_Click(object sender, EventArgs e)
    {
        ISession session = null;
        try
        {
            session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            Player player = session.Load<Player>(Session["user"]);
            player.ShowBuildingLevel = !player.ShowBuildingLevel;
            session.Update(player);

            if (player.ShowBuildingLevel)
            {
                RadScriptManager.RegisterStartupScript(bttnHideBuildingLevel, bttnHideBuildingLevel.GetType(), "ShowBuildingLevel", "$('div.label').show();", true);
                this.bttnHideBuildingLevel.Text = "Bỏ hiển thị nâng cấp công trình";
                
            }
            else
            {
                RadScriptManager.RegisterStartupScript(bttnHideBuildingLevel, bttnHideBuildingLevel.GetType(), "HideBuildingLevel", "$('div.label').hide();", true);
                this.bttnHideBuildingLevel.Text = "Hiển thị nâng cấp công trình";
            }
        }
        catch (Exception exc)
        {
            this.lblError.Text = exc.Message;
        }
    }
}
