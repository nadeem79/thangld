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
        BuildableStatus enumCanBuild = this.Village.VillageBuildingMethods.CanBuild(type, session);
        string strResult = "";
        if (enumCanBuild == BuildableStatus.JustDoIt)
        {
            BuildPrice price = null;
            switch (type)
            {
                case BuildingType.Headquarter:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopHeadquarterLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Barracks:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopBarrackLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Stable:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopStableLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Workshop:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopWorkshopLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Academy:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopAcademyLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Smithy:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopSmithyLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Rally:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopRallyPointLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Market:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopMarketLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.TimberCamp:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopTimberCampLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.ClayPit:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopClayPitLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.IronMine:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopIronMineLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Farm:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopFarmLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Warehouse:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopWarehouseLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.HidingPlace:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopHiddenPlaceLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Wall:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopWallLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                default:
                    break;
            }
            
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
            BuildPrice price = null;
            switch (type)
            {
                case BuildingType.Headquarter:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopHeadquarterLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Barracks:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopBarrackLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Stable:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopStableLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Workshop:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopWorkshopLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Academy:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopAcademyLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Smithy:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopSmithyLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Rally:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopRallyPointLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Market:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopMarketLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.TimberCamp:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopTimberCampLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.ClayPit:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopClayPitLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.IronMine:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopIronMineLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Farm:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopFarmLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Warehouse:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopWarehouseLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.HidingPlace:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopHiddenPlaceLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                case BuildingType.Wall:
                    price = beans.Build.GetPrice(type, this.Village.VillageBuildingMethods.TopWallLevel + 1, this.Village[beans.BuildingType.Headquarter]);
                    break;
                default:
                    break;
            }
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
