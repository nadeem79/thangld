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
        this.NHibernateSession = master.NHibernateSession;
        village = master.CurrentVillage;
        ITransaction trans = null;
        if (Request["action"] == "build" && Request["building"] != null && BuildingTypeFactory.GetType(Request["building"]) != BuildingType.NoBuiding)
        {
            trans = this.NHibernateSession.BeginTransaction(IsolationLevel.ReadCommitted);
            BuildableStatus enumBuildStatus = this.village.PrepareBuild(BuildingTypeFactory.GetType(Request["building"]), this.NHibernateSession);
            if (enumBuildStatus != BuildableStatus.JustDoIt)
                this.lblError.Text = BuildableStatusFactory.ToString(enumBuildStatus);
            trans.Commit();
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
                trans = this.NHibernateSession.BeginTransaction();
                this.village.CancelBuild(build_id, this.NHibernateSession);
                trans.Commit();
            }
        }
        master.ClayLabel.Text = this.village.VillageResourceData.Clay.ToString();
        master.WoodLabel.Text = this.village.VillageResourceData.Wood.ToString();
        master.IronLabel.Text = this.village.VillageResourceData.Iron.ToString();

        IList<Build> lstBuild = this.village.GetPendingConstruction(this.NHibernateSession);
        if (lstBuild.Count > 0)
            lstBuild[0].Start = DateTime.Now;
        for (int i = 1; i < lstBuild.Count; i++)
        {
            TimeSpan time = lstBuild[i].End - lstBuild[i].Start;
            lstBuild[i].Start = lstBuild[i - 1].End;
            lstBuild[i].End = lstBuild[i].Start + time;
        }
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
                CustomControls_DemolishBuilding pDemolishing = (CustomControls_DemolishBuilding)Page.LoadControl("CustomControls/DemolishBuilding.ascx");
                this.phConstructing.Controls.Add(pDemolishing);
                break;
            default:
                CustomControls_ConstructBuilding pConstructing = (CustomControls_ConstructBuilding)Page.LoadControl("CustomControls/ConstructBuilding.ascx");
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
            session = NHibernateHelper.CreateSession();
            trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
            this.village.Name = this.txtName.Text;
            session.Update(this.village);
            trans.Commit();
            RadScriptManager.RegisterStartupScript(bttnChangeVillageName, bttnChangeVillageName.GetType(), "ChangeVillageName", "$('#city_name').html('" + this.village.Name + "');jQuery.facebox('Đổi tên thành phố: " + this.village.Name + "')", true);
        }
        catch(Exception ex)
        {
            
            if (trans != null && !trans.WasCommitted)
                trans.Rollback();
            ScriptManager.RegisterStartupScript(bttnChangeVillageName, bttnChangeVillageName.GetType(), "ShowException", "jQuery.facebox('" + ex.Message + "')", true);
        }
        finally
        {
            if (session!=null)
                session.Close();
        }
    }

    protected string FirstRow(int index)
    {
        return (index == 0) ? "class='timer'" : "";
    }
}
