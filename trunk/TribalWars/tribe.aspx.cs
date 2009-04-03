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

using beans;
using NHibernate;

public partial class tribe : System.Web.UI.Page
{

    protected Village village;
    protected Group currentTribe;
    public Group Tribe
    {
        get { return this.currentTribe; }
        set { this.currentTribe = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.village = ((inPage)this.Master).CurrentVillage;
        ISession session = NHibernateHelper.CreateSession();
        Player player = session.Get<Player>(Session["user"]);
        if (player.Group == null)
        {
            session.Close();
            Response.Redirect("untribe.aspx?id=" + this.village.ID.ToString(), true);
        }
        
        
        int page = 0;
        int.TryParse(Request["page"], out page);
        this.navigator.Rows[0].Cells[page].Attributes.Add("class", "selected");
        switch (TribePageTypeFactory.GetTribePage(page))
        {
            case TribePageType.MembersPage:
                TribeMembers ucTribeMembers = (TribeMembers)Page.LoadControl("TribeMembers.ascx");
                ucTribeMembers.Village = village;
                this.pTribePage.Controls.Add(ucTribeMembers);
                break;
            case TribePageType.DiplomacyPage:
                TribeDiplomacy ucDiplomacyPage = (TribeDiplomacy)Page.LoadControl("TribeDiplomacy.ascx");
                ucDiplomacyPage.Village = village;
                this.pTribePage.Controls.Add(ucDiplomacyPage);
                break;
            default:
                TribeProfile ucProfilePage = (TribeProfile)Page.LoadControl("TribeProfile.ascx");
                ucProfilePage.Tribe = player.Group;
                ucProfilePage.Village = village;
                this.pTribePage.Controls.Add(ucProfilePage);
                break;
        }
        session.Close();
    }
}
