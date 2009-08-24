using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using NHibernate.Linq;
using beans;
using System.Data;
using Telerik.Web.UI;

public partial class smithy : System.Web.UI.Page
{

    private ISession NHibernateSession
    {
        get;
        set;
    }
    protected beans.Village Village
    {
        get;
        set;
    }
    protected ResearchPrice AttackPrice
    {
        get;
        set;
    }
    protected ResearchPrice DefensePrice
    {
        get;
        set;
    }
    protected ResearchPrice SpeedPrice
    {
        get;
        set;
    }

    protected string ResearchToString(ResearchType type)
    {
        switch (type)
        {
            case ResearchType.Speed:
                return "tốc độ";
            case ResearchType.Attack:
                return "chỉ số tấn công";
            case ResearchType.Defense:
                return "chỉ số phòng thủ";
            default:
                return "";
        }
    }
    protected string FirstRow(int index)
    {
        return (index == 0) ? "class='timer'" : "";
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.Village = ((inPage)this.Master).CurrentVillage;
        ISession session = (ISession)Context.Items["NHibernateSession"];

        IList<Research> researches = this.Village.Researches;

        this.AttackPrice = Research.GetPrice(ResearchType.Attack, this.Village.VillageResearchMethods.MaxAttackLevel, this.Village[BuildingType.Smithy]);
        this.DefensePrice = Research.GetPrice(ResearchType.Defense, this.Village.VillageResearchMethods.MaxDefenseLevel, this.Village[BuildingType.Smithy]);
        this.SpeedPrice = Research.GetPrice(ResearchType.Speed, this.Village.VillageResearchMethods.MaxSpeedLevel, this.Village[BuildingType.Smithy]);

        if (this.Village.VillageResearchMethods.CanResearch(ResearchType.Attack, this.Village.VillageResearchMethods.MaxAttackLevel))
            this.panelUpgradeAttack.Visible = true;
        else
            this.cannotUpgradeAttack.Visible = true;
        if (this.Village.VillageResearchMethods.CanResearch(ResearchType.Defense, this.Village.VillageResearchMethods.MaxDefenseLevel))
            this.panelUpgradeDefense.Visible = true;
        else
            this.cannotUpgradeDefense.Visible = true;
        if (this.Village.VillageResearchMethods.CanResearch(ResearchType.Speed, this.Village.VillageResearchMethods.MaxSpeedLevel))
            this.panelUpgradeSpeed.Visible = true;
        else
            this.cannotUpgradeSpeed.Visible = true;

        if (researches.Count > 0)
        {
            this.rptResearches.DataSource = researches;
            this.rptResearches.DataBind();
        }
    }


    protected void bttnUpgradeAttack_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];
        try
        {
            Research research = this.Village.VillageResearchMethods.CreateResearch(ResearchType.Attack, session);
            Response.Redirect(string.Format("smithy.aspx?id={0}", this.Village.ID), false);
        }
        catch (TribalWarsException ex)
        {
            RadScriptManager.RegisterStartupScript(bttnUpgradeAttack, bttnUpgradeAttack.GetType(), "Exception", string.Format( "$.facebox('{0}');", ex.Message), true);
        }
    }
    protected void bttnUpgradeDefense_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];
        try
        {
            Research research = this.Village.VillageResearchMethods.CreateResearch(ResearchType.Defense, session);
            Response.Redirect(string.Format("smithy.aspx?id={0}", this.Village.ID), false);
        }
        catch (TribalWarsException ex)
        {
            RadScriptManager.RegisterStartupScript(bttnUpgradeAttack, bttnUpgradeAttack.GetType(), "Exception", string.Format("$.facebox('{0}');", ex.Message), true);
        }
    }
    protected void bttnUpgradeSpeed_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];
        try
        {
            Research research = this.Village.VillageResearchMethods.CreateResearch(ResearchType.Speed, session);
            Response.Redirect(string.Format("smithy.aspx?id={0}", this.Village.ID), false);
        }
        catch (TribalWarsException ex)
        {
            RadScriptManager.RegisterStartupScript(bttnUpgradeAttack, bttnUpgradeAttack.GetType(), "Exception", string.Format("$.facebox('{0}');", ex.Message), true);
        }
    }
    protected void bttnCancelResearch_Click(object sender, EventArgs e)
    {
        
    }

    protected void rptResearches_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int researchId = 0;
        if (!int.TryParse(e.CommandArgument.ToString(), out researchId))
            return;

        ISession session = (ISession)Context.Items["NHibernateSession"];
        this.Village.VillageResearchMethods.CancelResearch(researchId, session);
        Response.Redirect(string.Format("smithy.aspx?id={0}", this.Village.ID), false);
    }
}
