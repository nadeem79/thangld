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
            master.ClayLabel.Text = this.village.Clay.ToString();
            master.WoodLabel.Text = this.village.Wood.ToString();
            master.IronLabel.Text = this.village.Iron.ToString();
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
        this.rConstructing.DataSource = lstBuild;
        this.rConstructing.DataBind();

        if (!IsPostBack)
        {
            this.lblBuildHeadquarters.Text = this.BuildableStatusToString(BuildingType.Headquarter, session);
            this.lblBuildBarracks.Text = this.BuildableStatusToString(BuildingType.Barracks, session);
            this.lblBuildStable.Text = this.BuildableStatusToString(BuildingType.Stable, session);
            this.lblBuildWorkshop.Text = this.BuildableStatusToString(BuildingType.Workshop, session);
            this.lblBuildAcademy.Text = this.BuildableStatusToString(BuildingType.Academy, session);
            this.lblBuildMarket.Text = this.BuildableStatusToString(BuildingType.Market, session);
            this.lblBuildTimberCamp.Text = this.BuildableStatusToString(BuildingType.TimberCamp, session);
            this.lblBuildClayPit.Text = this.BuildableStatusToString(BuildingType.ClayPit, session);
            this.lblBuildIronMine.Text = this.BuildableStatusToString(BuildingType.IronMine, session);
            this.lblBuildFarm.Text = this.BuildableStatusToString(BuildingType.Farm, session);
            this.lblBuildWarehouse.Text = this.BuildableStatusToString(BuildingType.Warehouse, session);
            this.lblBuildHidingPlace.Text = this.BuildableStatusToString(BuildingType.HidingPlace, session);
            this.lblBuildWall.Text = this.BuildableStatusToString(BuildingType.Wall, session);
            this.lblBuildRally.Text = this.BuildableStatusToString(BuildingType.Rally, session);
            this.lblBuildSmithy.Text = this.BuildableStatusToString(BuildingType.Smithy, session);
        }

        session.Close();
        
    }

    private string BuildableStatusToString(beans.BuildingType type, ISession session)
    {
        BuildableStatus enumCanBuild = this.village.CanBuild(type, session);
        string strResult = "";
        if (enumCanBuild == BuildableStatus.JustDoIt)
        {
            BuildPrice price = beans.Build.GetPrice(type, this.village.GetTotalBuildingLevel(type, session), this.village[beans.BuildingType.Headquarter]);
            strResult += "<td><img src=\"images/holz.png\" title=\"Wood\" alt=\"\" />" + price.Wood + "</td>";
            strResult += "<td><img src=\"images/lehm.png\" title=\"Clay\" alt=\"\" />" + price.Clay + "</td>";
            strResult += "<td><img src=\"images/eisen.png\" title=\"Iron\" alt=\"\" />" + price.Iron + "</td>";
            strResult += "<td><img src=\"images/face.png\" title=\"Villagers\" alt=\"\" />" + Math.Round(price.Population, MidpointRounding.AwayFromZero) + "</td>";
            strResult += "<td>" + Functions.FormatTime(price.BuildTime) + "</td>";
            strResult += "<td align=\"center\"><a href=\"headquarters.aspx?id=" + this.village.ID + "&action=build&building=" + (int)type + "\">Nâng cấp</td>";
        }
        else if (enumCanBuild == BuildableStatus.BuildingLevelExceed)
        {
            strResult += "<td colspan=\"6\" align=\"center\"><span class=\"inactive\">" + beans.BuildableStatusFactory.ToString(BuildableStatus.BuildingLevelExceed) + "</span></td>";
        }
        else
        {
            BuildPrice price = beans.Build.GetPrice(type, this.village.GetTotalBuildingLevel(type, session), this.village[beans.BuildingType.Headquarter]);
            strResult += "<td><img src=\"images/holz.png\" title=\"Wood\" alt=\"\" />" + price.Wood + "</td>";
            strResult += "<td><img src=\"images/lehm.png\" title=\"Clay\" alt=\"\" />" + price.Clay + "</td>";
            strResult += "<td><img src=\"images/eisen.png\" title=\"Iron\" alt=\"\" />" + price.Iron + "</td>";
            strResult += "<td><img src=\"images/face.png\" title=\"Villagers\" alt=\"\" />" + Math.Round(price.Population, MidpointRounding.AwayFromZero) + "</td>";
            strResult += "<td>" + Functions.FormatTime(price.BuildTime) + "</td>";
            strResult += "<td align=\"center\"><span class=\"inactive\">" + beans.BuildableStatusFactory.ToString(enumCanBuild) + "</span></td>";
        }
        return strResult;
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
        }
        catch(Exception ex)
        {
            if (trans != null && !trans.WasCommitted)
                trans.Rollback();
            RadScriptManager.RegisterStartupScript(bttnChangeVillageName, bttnChangeVillageName.GetType(), "ShowException", "jQuery.facebox('" + ex.Message + "')", true);
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
