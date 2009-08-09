using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using NHibernate;
using NHibernate.Linq;
using beans;
using Telerik.Web.UI;
using System.Collections.Generic;

public partial class test : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();

        Village v = session.Get<Village>(24);
        v[BuildingType.Academy] = 0;
        v[BuildingType.Barracks] = 0;
        v[BuildingType.ClayPit] = 0;
        v[BuildingType.Farm] = 0;
        v[BuildingType.Headquarter] = 0;
        v[BuildingType.HidingPlace] = 0;
        v[BuildingType.IronMine] = 0;
        v[BuildingType.Market] = 0;
        v[BuildingType.Rally] = 0;
        v[BuildingType.Smithy] = 0;
        v[BuildingType.Stable] = 0;
        v[BuildingType.TimberCamp] = 0;
        v[BuildingType.Wall] = 0;
        v[BuildingType.Warehouse] = 0;
        v[BuildingType.Workshop] = 0;
        v.Points = 0;
        v.Population = 0;

        v.UpgradeBuilding(BuildingType.Headquarter, 20);
        v.UpgradeBuilding(BuildingType.Farm, 20);
        v.UpgradeBuilding(BuildingType.ClayPit, 20);
        v.UpgradeBuilding(BuildingType.IronMine, 20);
        v.UpgradeBuilding(BuildingType.TimberCamp, 20);
        v.UpgradeBuilding(BuildingType.Rally, 1);
        v.UpgradeBuilding(BuildingType.Stable, 5);
        v.UpgradeBuilding(BuildingType.Barracks, 5);
        v.UpgradeBuilding(BuildingType.Workshop, 5);
        v.UpgradeBuilding(BuildingType.Smithy, 10);
        v.UpgradeBuilding(BuildingType.Warehouse, 30);
        

        session.Update(v);
        session.Flush();
        session.Close();
    }

    protected void bttnSend_Click(object sender, EventArgs e)
    {
        
    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
        
    }
}
