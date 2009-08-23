using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;

public partial class CustomControls_MerchantStatus : System.Web.UI.UserControl
{

    public beans.Village Village
    {
        get;
        set;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];
        int merchantOnTheWay = this.Village.VillageTransportMethods.GetMerchantOnTheWay(session);
        this.lblMerchantOnTheWay.Text = merchantOnTheWay.ToString();
        this.lblMerchantOnTheWayHome.Text = (this.Village.VillageBuildingData.MerchantOfVillage - this.Village.VillageBuildingData.Merchant - merchantOnTheWay).ToString();
        //this.lblMerchantOnTheWayHome.Text = this.Village.MerchantOnTheWayHome(this.Session).ToString();
    }
}
