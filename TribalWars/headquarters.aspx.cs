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
        
        village = ((inPage)this.Master).CurrentVillage;
        if (!IsPostBack)
        {
            this.headquarter = Build.GetPrice(BuildingType.Headquarter, village[BuildingType.Headquarter], village[BuildingType.Headquarter]);
            this.barrack = Build.GetPrice(BuildingType.Barracks, village[BuildingType.Barracks], village[BuildingType.Barracks]);
            this.stable = Build.GetPrice(BuildingType.Stable, village[BuildingType.Stable], village[BuildingType.Stable]);
            this.workshop = Build.GetPrice(BuildingType.Workshop, village[BuildingType.Workshop], village[BuildingType.Workshop]);
            this.academy = Build.GetPrice(BuildingType.Academy, village[BuildingType.Academy], village[BuildingType.Academy]);
            this.smithy = Build.GetPrice(BuildingType.Smithy, village[BuildingType.Smithy], village[BuildingType.Smithy]);
            this.rally = Build.GetPrice(BuildingType.Rally, village[BuildingType.Rally], village[BuildingType.Rally]);
            this.market = Build.GetPrice(BuildingType.Market, village[BuildingType.Market], village[BuildingType.Market]);
            this.timber = Build.GetPrice(BuildingType.TimberCamp, village[BuildingType.TimberCamp], village[BuildingType.TimberCamp]);
            this.clay = Build.GetPrice(BuildingType.ClayPit, village[BuildingType.ClayPit], village[BuildingType.ClayPit]);
            this.iron = Build.GetPrice(BuildingType.IronMine, village[BuildingType.IronMine], village[BuildingType.IronMine]);
            this.farm = Build.GetPrice(BuildingType.Farm, village[BuildingType.Farm], village[BuildingType.Farm]);
            this.warehouse = Build.GetPrice(BuildingType.Warehouse, village[BuildingType.Warehouse], village[BuildingType.Warehouse]);
            this.hiding = Build.GetPrice(BuildingType.HidingPlace, village[BuildingType.HidingPlace], village[BuildingType.HidingPlace]);
            this.wall = Build.GetPrice(BuildingType.Wall, village[BuildingType.Wall], village[BuildingType.Wall]);
            this.txtName.Text = this.village.Name;

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
            RadScriptManager.RegisterStartupScript(bttnChangeVillageName, bttnChangeVillageName.GetType(), "ChangeVillageName", "$(\"#city_name\").html(\"" + this.village.Name + "\")", true);
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
}
