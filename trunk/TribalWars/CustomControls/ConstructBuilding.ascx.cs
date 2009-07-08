using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class CustomControls_ConstructBuilding : System.Web.UI.UserControl
{

    public Village Village
    {
        get;
        set;
    }
    public ISession NHibernateSession
    {
        get;
        set;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblBuildHeadquarters.Text = this.BuildableStatusToString(BuildingType.Headquarter, this.NHibernateSession);
        this.lblBuildBarracks.Text = this.BuildableStatusToString(BuildingType.Barracks, this.NHibernateSession);
        this.lblBuildStable.Text = this.BuildableStatusToString(BuildingType.Stable, this.NHibernateSession);
        this.lblBuildWorkshop.Text = this.BuildableStatusToString(BuildingType.Workshop, this.NHibernateSession);
        this.lblBuildAcademy.Text = this.BuildableStatusToString(BuildingType.Academy, this.NHibernateSession);
        this.lblBuildMarket.Text = this.BuildableStatusToString(BuildingType.Market, this.NHibernateSession);
        this.lblBuildTimberCamp.Text = this.BuildableStatusToString(BuildingType.TimberCamp, this.NHibernateSession);
        this.lblBuildClayPit.Text = this.BuildableStatusToString(BuildingType.ClayPit, this.NHibernateSession);
        this.lblBuildIronMine.Text = this.BuildableStatusToString(BuildingType.IronMine, this.NHibernateSession);
        this.lblBuildFarm.Text = this.BuildableStatusToString(BuildingType.Farm, this.NHibernateSession);
        this.lblBuildWarehouse.Text = this.BuildableStatusToString(BuildingType.Warehouse, this.NHibernateSession);
        this.lblBuildHidingPlace.Text = this.BuildableStatusToString(BuildingType.HidingPlace, this.NHibernateSession);
        this.lblBuildWall.Text = this.BuildableStatusToString(BuildingType.Wall, this.NHibernateSession);
        this.lblBuildRally.Text = this.BuildableStatusToString(BuildingType.Rally, this.NHibernateSession);
        this.lblBuildSmithy.Text = this.BuildableStatusToString(BuildingType.Smithy, this.NHibernateSession);
    }

    private string BuildableStatusToString(beans.BuildingType type, ISession session)
    {
        BuildableStatus enumCanBuild = this.Village.CanBuild(type, session);
        string strResult = "";
        if (enumCanBuild == BuildableStatus.JustDoIt)
        {
            BuildPrice price = beans.Build.GetPrice(type, this.Village.GetTotalBuildingLevel(type, session) + 1, this.Village[beans.BuildingType.Headquarter]);
            strResult += "<td><img src=\"images/holz.png\" title=\"Wood\" alt=\"\" />" + price.Wood + "</td>";
            strResult += "<td><img src=\"images/lehm.png\" title=\"Clay\" alt=\"\" />" + price.Clay + "</td>";
            strResult += "<td><img src=\"images/eisen.png\" title=\"Iron\" alt=\"\" />" + price.Iron + "</td>";
            strResult += "<td><img src=\"images/face.png\" title=\"Villagers\" alt=\"\" />" + Math.Round(price.Population, MidpointRounding.AwayFromZero) + "</td>";
            strResult += "<td>" + Functions.FormatTime(price.BuildTime) + "</td>";
            strResult += "<td align=\"center\"><a href=\"headquarters.aspx?id=" + this.Village.ID + "&action=build&building=" + (int)type + "\">Nâng cấp</td>";
        }
        else if (enumCanBuild == BuildableStatus.BuildingLevelExceed)
        {
            strResult += "<td colspan=\"6\" align=\"center\"><span class=\"inactive\">" + beans.BuildableStatusFactory.ToString(BuildableStatus.BuildingLevelExceed) + "</span></td>";
        }
        else
        {
            BuildPrice price = beans.Build.GetPrice(type, this.Village.GetTotalBuildingLevel(type, session) + 1, this.Village[beans.BuildingType.Headquarter]);
            strResult += "<td><img src=\"images/holz.png\" title=\"Wood\" alt=\"\" />" + price.Wood + "</td>";
            strResult += "<td><img src=\"images/lehm.png\" title=\"Clay\" alt=\"\" />" + price.Clay + "</td>";
            strResult += "<td><img src=\"images/eisen.png\" title=\"Iron\" alt=\"\" />" + price.Iron + "</td>";
            strResult += "<td><img src=\"images/face.png\" title=\"Villagers\" alt=\"\" />" + Math.Round(price.Population, MidpointRounding.AwayFromZero) + "</td>";
            strResult += "<td>" + Functions.FormatTime(price.BuildTime) + "</td>";
            strResult += "<td align=\"center\"><span class=\"inactive\">" + beans.BuildableStatusFactory.ToString(enumCanBuild) + "</span></td>";
        }
        return strResult;
    }
}
