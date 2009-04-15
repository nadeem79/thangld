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
    public ISession Session
    {
        get;
        set;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Session = null;
            try
            {
                this.Session = NHibernateHelper.CreateSession();
                this.lblBuildHeadquarters.Text = this.BuildableStatusToString(BuildingType.Headquarter, Session);
                this.lblBuildBarracks.Text = this.BuildableStatusToString(BuildingType.Barracks, Session);
                this.lblBuildStable.Text = this.BuildableStatusToString(BuildingType.Stable, Session);
                this.lblBuildWorkshop.Text = this.BuildableStatusToString(BuildingType.Workshop, Session);
                this.lblBuildAcademy.Text = this.BuildableStatusToString(BuildingType.Academy, Session);
                this.lblBuildMarket.Text = this.BuildableStatusToString(BuildingType.Market, Session);
                this.lblBuildTimberCamp.Text = this.BuildableStatusToString(BuildingType.TimberCamp, Session);
                this.lblBuildClayPit.Text = this.BuildableStatusToString(BuildingType.ClayPit, Session);
                this.lblBuildIronMine.Text = this.BuildableStatusToString(BuildingType.IronMine, Session);
                this.lblBuildFarm.Text = this.BuildableStatusToString(BuildingType.Farm, Session);
                this.lblBuildWarehouse.Text = this.BuildableStatusToString(BuildingType.Warehouse, Session);
                this.lblBuildHidingPlace.Text = this.BuildableStatusToString(BuildingType.HidingPlace, Session);
                this.lblBuildWall.Text = this.BuildableStatusToString(BuildingType.Wall, Session);
                this.lblBuildRally.Text = this.BuildableStatusToString(BuildingType.Rally, Session);
                this.lblBuildSmithy.Text = this.BuildableStatusToString(BuildingType.Smithy, Session);
            }
            catch { }
            finally
            {
                if (this.Session != null && this.Session.IsOpen)
                    this.Session.Close();
            }
            
        }
    }

    private string BuildableStatusToString(beans.BuildingType type, ISession session)
    {
        BuildableStatus enumCanBuild = this.Village.CanBuild(type, session);
        string strResult = "";
        if (enumCanBuild == BuildableStatus.JustDoIt)
        {
            BuildPrice price = beans.Build.GetPrice(type, this.Village.GetTotalBuildingLevel(type, session), this.Village[beans.BuildingType.Headquarter]);
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
