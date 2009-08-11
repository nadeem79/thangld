using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomControls_MerchantStatus : System.Web.UI.UserControl
{
    public NHibernate.ISession Session
    {
        get;
        set;
    }
    public beans.Village Village
    {
        get;
        set;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //this.lblMerchantOnTheWay.Text = (this.Village.MerchantOfVillage - this.Village.Merchant).ToString();
        //this.lblMerchantOnTheWayHome.Text = this.Village.MerchantOnTheWayHome(this.Session).ToString();
    }
}
