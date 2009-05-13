using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using beans;
using System.Data;

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
    protected beans.ResearchPrice Spear
    {
        get;
        set;
    }
    protected beans.ResearchPrice Sword
    {
        get;
        set;
    }
    protected beans.ResearchPrice Axe
    {
        get;
        set;
    }
    protected beans.ResearchPrice Scout
    {
        get;
        set;
    }
    protected beans.ResearchPrice Light
    {
        get;
        set;
    }
    protected beans.ResearchPrice Heavy
    {
        get;
        set;
    }
    protected beans.ResearchPrice Ram
    {
        get;
        set;
    }
    protected beans.ResearchPrice Catapult
    {
        get;
        set;
    }

    protected string TroopToString(TroopType type)
    {
        switch (type)
        {
            case TroopType.Spear:
                return "Lính giáo";
                break;
            case TroopType.Sword:
                return "Lính kiếm";
                break;
            case TroopType.Axe:
                return "Lính rìu";
                break;
            case TroopType.Scout:
                return "Do thám";
                break;
            case TroopType.Light:
                return "Kỵ binh";
                break;
            case TroopType.Heavy:
                return "Hiệp sỹ";
                break;
            case TroopType.Ram:
                return "Xe phá thành";
                break;
            case TroopType.Catapult:
                return "Máy bắn đá";
                break;
            default:
                return "";
                break;
        }
    }

    public smithy()
    {
        this.PreInit += new EventHandler(smithy_PreInit);
        this.LoadComplete += new EventHandler(smithy_LoadComplete);
    }

    protected void smithy_PreInit(object sender, EventArgs e)
    {
        this.NHibernateSession = NHibernateHelper.CreateSession();
    }

    protected void smithy_LoadComplete(object sender, EventArgs e)
    {
        
        if (this.NHibernateSession != null)
            this.NHibernateSession.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Village = ((inPage)this.Master).CurrentVillage;
        this.NHibernateSession.Lock(this.Village, LockMode.None);
        if (this.Village.Research.ResearchSpear > 0)
            this.imgSpear.ImageUrl = @"images/unit_big/spear.png";
        else if (this.Village.Research.ResearchSpear == 0)
            this.imgSpear.ImageUrl = @"images/unit_big/spear_grey.png";
        else
            this.imgSpear.ImageUrl = @"images/unit_big/spear_cross.png";

        if (this.Village.Research.ResearchSword > 0)
            this.imgSword.ImageUrl = @"images/unit_big/sword.png";
        else if (this.Village.Research.ResearchSword == 0)
            this.imgSword.ImageUrl = @"images/unit_big/sword_grey.png";
        else
            this.imgSword.ImageUrl = @"images/unit_big/sword_cross.png";

        if (this.Village.Research.ResearchAxe > 0)
            this.imgAxe.ImageUrl = @"images/unit_big/axe.png";
        else if (this.Village.Research.ResearchAxe == 0)
            this.imgAxe.ImageUrl = @"images/unit_big/axe_grey.png";
        else
            this.imgAxe.ImageUrl = @"images/unit_big/axe_cross.png";

        if (this.Village.Research.ResearchScout > 0)
            this.imgScout.ImageUrl = @"images/unit_big/spy.png";
        else if (this.Village.Research.ResearchScout == 0)
            this.imgScout.ImageUrl = @"images/unit_big/spy_grey.png";
        else
            this.imgScout.ImageUrl = @"images/unit_big/spy_cross.png";

        if (this.Village.Research.ResearchLight > 0)
            this.imgLight.ImageUrl = @"images/unit_big/light.png";
        else if (this.Village.Research.ResearchLight == 0)
            this.imgLight.ImageUrl = @"images/unit_big/light_grey.png";
        else
            this.imgLight.ImageUrl = @"images/unit_big/light_cross.png";

        if (this.Village.Research.ResearchHeavy > 0)
            this.imgHeavy.ImageUrl = @"images/unit_big/heavy.png";
        else if (this.Village.Research.ResearchHeavy == 0)
            this.imgHeavy.ImageUrl = @"images/unit_big/heavy_grey.png";
        else
            this.imgHeavy.ImageUrl = @"images/unit_big/heavy_cross.png";

        if (this.Village.Research.ResearchRam > 0)
            this.imgRam.ImageUrl = @"images/unit_big/ram.png";
        else if (this.Village.Research.ResearchRam == 0)
            this.imgRam.ImageUrl = @"images/unit_big/ram_grey.png";
        else
            this.imgRam.ImageUrl = @"images/unit_big/ram_cross.png";

        if (this.Village.Research.ResearchCatapult > 0)
            this.imgCatapult.ImageUrl = @"images/unit_big/catapult.png";
        else if (this.Village.Research.ResearchCatapult == 0)
            this.imgCatapult.ImageUrl = @"images/unit_big/catapult_grey.png";
        else
            this.imgCatapult.ImageUrl = @"images/unit_big/catapult_cross.png";

        this.Spear = beans.Research.GetPrice(TroopType.Spear, this.Village.GetTotalResearchLevel(TroopType.Spear, this.NHibernateSession) + 1, this.Village[BuildingType.Smithy]);
        this.Sword = beans.Research.GetPrice(TroopType.Sword, this.Village.GetTotalResearchLevel(TroopType.Sword, this.NHibernateSession) + 1, this.Village[BuildingType.Smithy]);
        this.Axe = beans.Research.GetPrice(TroopType.Axe, this.Village.GetTotalResearchLevel(TroopType.Axe, this.NHibernateSession) + 1, this.Village[BuildingType.Smithy]);
        this.Scout = beans.Research.GetPrice(TroopType.Scout, this.Village.GetTotalResearchLevel(TroopType.Scout, this.NHibernateSession) + 1, this.Village[BuildingType.Smithy]);
        this.Light = beans.Research.GetPrice(TroopType.Light, this.Village.GetTotalResearchLevel(TroopType.Light, this.NHibernateSession) + 1, this.Village[BuildingType.Smithy]);
        this.Heavy = beans.Research.GetPrice(TroopType.Heavy, this.Village.GetTotalResearchLevel(TroopType.Heavy, this.NHibernateSession) + 1, this.Village[BuildingType.Smithy]);
        this.Ram = beans.Research.GetPrice(TroopType.Ram, this.Village.GetTotalResearchLevel(TroopType.Ram, this.NHibernateSession) + 1, this.Village[BuildingType.Smithy]);
        this.Catapult = beans.Research.GetPrice(TroopType.Catapult, this.Village.GetTotalResearchLevel(TroopType.Catapult, this.NHibernateSession) + 1, this.Village[BuildingType.Smithy]);

        IList<Research> lstResearches = this.Village.GetPendingResearch(this.NHibernateSession);
        for (int i = 1; i < lstResearches.Count; i++)
            lstResearches[i].Start = lstResearches[i - 1].End;

        this.researches.DataSource = lstResearches;
        this.researches.DataBind();
    }


    protected void bttnCancelResearch_Click(object sender, EventArgs e)
    {
        LinkButton bttnCancel = (LinkButton)sender;
        int id = 0;
        int.TryParse(bttnCancel.CommandArgument, out id);

        if (id == 0)
            return;

        Research research = NHibernateSession.Get<Research>(id);
        if (research == null)
            return;

        ITransaction trans = NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
        this.Village.CancelResearch(research, this.NHibernateSession);
        trans.Commit();
        Response.Redirect(String.Format("smithy.aspx?id={0}", this.Village.ID), false);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ITransaction transaction = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
        ResearchableStatus status = this.Village.PrepareResearch(TroopType.Scout, this.NHibernateSession);
        if (status == ResearchableStatus.JustDoIt)
            Response.Redirect(String.Format("smithy.aspx?id={0}", this.Village.ID), false);
        else
            ScriptManager.RegisterStartupScript(bttnUpgradeScout, bttnUpgradeScout.GetType(), "ShowException", "jQuery.facebox('" + beans.ResearchableStatusFactory.ToString(status) + "');", true);
        transaction.Commit();
    }
    protected void bttnUpgradeSpear_Click(object sender, EventArgs e)
    {
        ITransaction transaction = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
        ResearchableStatus status = this.Village.PrepareResearch(TroopType.Spear, this.NHibernateSession);
        if (status == ResearchableStatus.JustDoIt)
            Response.Redirect(String.Format("smithy.aspx?id={0}", this.Village.ID), false);
        else
            ScriptManager.RegisterStartupScript(bttnUpgradeSpear, bttnUpgradeSpear.GetType(), "ShowException", "jQuery.facebox('" + beans.ResearchableStatusFactory.ToString(status) + "');", true);
        transaction.Commit();
    }
    protected void bttnUpgradeSword_Click(object sender, EventArgs e)
    {
        ITransaction transaction = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
        ResearchableStatus status = this.Village.PrepareResearch(TroopType.Sword, this.NHibernateSession);
        if (status == ResearchableStatus.JustDoIt)
            Response.Redirect(String.Format("smithy.aspx?id={0}", this.Village.ID), false);
        else
            ScriptManager.RegisterStartupScript(bttnUpgradeSword, bttnUpgradeSword.GetType(), "ShowException", "jQuery.facebox('" + beans.ResearchableStatusFactory.ToString(status) + "');", true);
        transaction.Commit();
    }
    protected void bttnUpgradeAxe_Click(object sender, EventArgs e)
    {
        ITransaction transaction = null;
        try
        {
            transaction = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
            ResearchableStatus status = this.Village.PrepareResearch(TroopType.Axe, this.NHibernateSession);
            if (status == ResearchableStatus.JustDoIt)
                Response.Redirect(String.Format("smithy.aspx?id={0}", this.Village.ID), false);
            else
                ScriptManager.RegisterStartupScript(bttnUpgradeAxe, bttnUpgradeAxe.GetType(), "ShowException", "jQuery.facebox('" + beans.ResearchableStatusFactory.ToString(status) + "');", true);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(bttnUpgradeAxe, bttnUpgradeAxe.GetType(), "ShowException", "jQuery.facebox('" + ex.Message + "');", true);
        }
        finally
        {
            if (transaction != null)
                transaction.Rollback();
        }
    }
    protected void bttnUpgradeLight_Click(object sender, EventArgs e)
    {
        ITransaction transaction = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
        ResearchableStatus status = this.Village.PrepareResearch(TroopType.Light, this.NHibernateSession);
        if (status == ResearchableStatus.JustDoIt)
            Response.Redirect(String.Format("smithy.aspx?id={0}", this.Village.ID), false);
        else
            ScriptManager.RegisterStartupScript(bttnUpgradeLight, bttnUpgradeLight.GetType(), "ShowException", "jQuery.facebox('" + beans.ResearchableStatusFactory.ToString(status) + "');", true);
        transaction.Commit();
    }
    protected void bttnUpgradeHeavy_Click(object sender, EventArgs e)
    {
        ITransaction transaction = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
        ResearchableStatus status = this.Village.PrepareResearch(TroopType.Heavy, this.NHibernateSession);
        if (status == ResearchableStatus.JustDoIt)
            Response.Redirect(String.Format("smithy.aspx?id={0}", this.Village.ID), false);
        else
            ScriptManager.RegisterStartupScript(bttnUpgradeHeavy, bttnUpgradeHeavy.GetType(), "ShowException", "jQuery.facebox('" + beans.ResearchableStatusFactory.ToString(status) + "');", true);
        transaction.Commit();
    }
    protected void bttnUpgradeRam_Click(object sender, EventArgs e)
    {
        ITransaction transaction = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
        ResearchableStatus status = this.Village.PrepareResearch(TroopType.Ram, this.NHibernateSession);
        if (status == ResearchableStatus.JustDoIt)
            Response.Redirect(String.Format("smithy.aspx?id={0}", this.Village.ID), false);
        else
            ScriptManager.RegisterStartupScript(bttnUpgradeRam, bttnUpgradeRam.GetType(), "ShowException", "jQuery.facebox('" + beans.ResearchableStatusFactory.ToString(status) + "');", true);
        transaction.Commit();
    }
    protected void bttnUpgradeCatapult_Click(object sender, EventArgs e)
    {
        ITransaction transaction = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
        ResearchableStatus status = this.Village.PrepareResearch(TroopType.Catapult, this.NHibernateSession);
        if (status == ResearchableStatus.JustDoIt)
            Response.Redirect(String.Format("smithy.aspx?id={0}", this.Village.ID), false);
        else
            ScriptManager.RegisterStartupScript(bttnUpgradeCatapult, bttnUpgradeCatapult.GetType(), "ShowException", "jQuery.facebox('" + beans.ResearchableStatusFactory.ToString(status) + "');", true);
        transaction.Commit();
    }
}
