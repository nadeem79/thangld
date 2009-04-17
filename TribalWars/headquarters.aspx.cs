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

    protected Village village;
    protected BuildPrice headquarter, barrack, stable, workshop, academy, smithy, rally, market, timber, clay, iron, farm, warehouse, hiding, wall;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        inPage master = (inPage)this.Master;
        village = master.CurrentVillage;
        ISession session = null;
        ITransaction trans = null;

        session = NHibernateHelper.CreateSession();
        try
        {
            if (Request["action"] == "build" && Request["building"] != null && BuildingTypeFactory.GetType(Request["building"]) != BuildingType.NoBuiding)
            {
                trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
                BuildableStatus enumBuildStatus = this.village.PrepareBuild(BuildingTypeFactory.GetType(Request["building"]), session);
                if (enumBuildStatus != BuildableStatus.JustDoIt)
                    this.lblError.Text = BuildableStatusFactory.ToString(enumBuildStatus);
                trans.Commit();
            }

            if (Request["action"] == "demolish" && Request["building"] != null && BuildingTypeFactory.GetType(Request["building"]) != BuildingType.NoBuiding)
            {
                trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
                trans.Commit();
            }

            if (Request["action"] == "cancel_build" && Request["command"] != null)
            {
                int build_id = 0;
                int.TryParse(Request["command"], out build_id);
                if (build_id != 0)
                {

                    trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
                    this.village.CancelBuild(build_id, session);
                    trans.Commit();
                }
            }
            master.ClayLabel.Text = this.village.Resources.Clay.ToString();
            master.WoodLabel.Text = this.village.Resources.Wood.ToString();
            master.IronLabel.Text = this.village.Resources.Iron.ToString();
        }
        catch (Exception ex)
        {
            trans.Rollback();
            this.lblError.Text = ex.Message;
        }

        IList<Build> lstBuild = this.village.GetPendingConstruction(session);
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
                this.phConstructing.Controls.Add(pConstructing);
                break;
        } 

        session.Close();
        
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
