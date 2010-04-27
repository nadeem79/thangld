using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using System.Data;
using Telerik.Web.UI;

public partial class headquarters : System.Web.UI.Page
{
    protected ISession NHibernateSession
    {
        get;
        set;
    }
    protected Village village;
    protected BuildPrice headquarter, barrack, stable, workshop, academy, smithy, rally, market, timber, clay, iron, farm, warehouse, hiding, wall;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        inPage master = (inPage)this.Master;
        this.NHibernateSession = (ISession)Context.Items[Constant.NHibernateSessionSign];
        village = master.CurrentVillage;

        if (this.village[BuildingType.Headquarter] > 0)
            this.pConstructed.Visible = true;
        else
        {
            this.pNotConstruct.Visible = true;
            return;
        }

        ITransaction trans = null;
        if (Request["action"] == "build" && Request["building"] != null && BuildingTypeFactory.GetType(Request["building"]) != BuildingType.NoBuiding)
        {
            BuildableStatus enumBuildStatus = this.village.VillageBuildingMethods.PrepareBuild(BuildingTypeFactory.GetType(Request["building"]), this.NHibernateSession);
            if (enumBuildStatus != BuildableStatus.JustDoIt)
                this.lblError.Text = BuildableStatusFactory.ToString(enumBuildStatus);

            master.ClayLabel.Text = this.village.VillageResourceData.Clay.ToString();
            master.IronLabel.Text = this.village.VillageResourceData.Iron.ToString();
            master.WoodLabel.Text = this.village.VillageResourceData.Wood.ToString();
        }

        if (Request["action"] == "demolish" && Request["building"] != null && BuildingTypeFactory.GetType(Request["building"]) != BuildingType.NoBuiding)
        {
            trans = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
            trans.Commit();
        }

        if (Request["action"] == "cancel_build" && Request["command"] != null)
        {
            int build_id = 0;
            int.TryParse(Request["command"], out build_id);
            if (build_id != 0)
            {
                this.village.VillageBuildingMethods.CancelBuild(build_id, this.NHibernateSession);
            }
        }
        master.ClayLabel.Text = this.village.VillageResourceData.Clay.ToString();
        master.WoodLabel.Text = this.village.VillageResourceData.Wood.ToString();
        master.IronLabel.Text = this.village.VillageResourceData.Iron.ToString();

        //IList<Build> lstBuild = this.village.VillageBuildingMethods.GetPendingConstruction(this.NHibernateSession);
        IList<Build> lstBuild = this.village.Builds;

        if (lstBuild.Count > 0)
        {
            this.rConstructing.DataSource = lstBuild;
            this.rConstructing.DataBind();
        }
        if (!IsPostBack)
            this.txtName.Text = this.village.Name;

        switch (Request["page"])
        {
            case "destroy":
                DemolishBuilding pDemolishing = (DemolishBuilding)Page.LoadControl("DemolishBuilding.ascx");
                this.phConstructing.Controls.Add(pDemolishing);
                break;
            default:
                ConstructBuilding pConstructing = (ConstructBuilding)Page.LoadControl("ConstructBuilding.ascx");
                pConstructing.Village = this.village;
                pConstructing.NHibernateSession = this.NHibernateSession;
                this.phConstructing.Controls.Add(pConstructing);
                break;
        } 

        
    }

    

    protected void bttnChangeVillageName_Click(object sender, EventArgs e)
    {
        
        ISession session = null;
        ITransaction trans = null;
        try
        {
            session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            this.village.Name = this.txtName.Text;
            session.Update(this.village);
            RadScriptManager.RegisterStartupScript(bttnChangeVillageName, bttnChangeVillageName.GetType(), "ChangeVillageName", "$('#city_name').html('" + this.village.Name + "');jQuery.facebox('Đổi tên thành phố: " + this.village.Name + "')", true);
        }
        catch(Exception ex)
        {
            
            if (trans != null && !trans.WasCommitted)
                trans.Rollback();
            ScriptManager.RegisterStartupScript(bttnChangeVillageName, bttnChangeVillageName.GetType(), "ShowException", "jQuery.facebox('" + ex.Message + "')", true);
        }
    }

    protected string FirstRow(int index)
    {
        return (index == 0) ? "class='timer'" : "";
    }

    protected string FirstRowTime(int index, Build build)
    {
        if (index == 0)
            return Functions.FormatTime(build.End - DateTime.Now);
        return Functions.FormatTime(build.End - build.Start);
    }

}
