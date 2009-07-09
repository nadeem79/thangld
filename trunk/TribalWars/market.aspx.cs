using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;

public partial class market : System.Web.UI.Page
{
    protected beans.Village Village
    {
        get;
        set;
    }
    private ISession NHibernateSession
    {
        get;
        set;
    }
    public market()
    {
        this.PreInit += new EventHandler(market_PreInit);
        this.LoadComplete += new EventHandler(market_LoadComplete);
    }
    protected void market_PreInit(object sender, EventArgs e)
    {
        this.NHibernateSession = NHibernateHelper.CreateSession();
        
    }
    protected void market_LoadComplete(object sender, EventArgs e)
    {
        if (this.NHibernateSession != null)
            this.NHibernateSession.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Village = ((inPage)this.Master).CurrentVillage;
        this.NHibernateSession.Lock(this.Village, LockMode.None);
        string page = "";
        if (!object.Equals(Request["page"], null))
            page = Request["page"];

        switch (page)
        {
            case "merchant_status":
                CustomControls_MerchantStatus pMerchantStatus = (CustomControls_MerchantStatus)Page.LoadControl(@"CustomControls/MerchantStatus.ascx");
                pMerchantStatus.Village = this.Village;
                pMerchantStatus.Session = this.NHibernateSession;
                this.tblMenu.Rows[3].Cells[0].Attributes.Add("class", "selected");
                this.pMarket.Controls.Add(pMerchantStatus);
                break;
            default:
                CustomControls_SendResource pSendResource = (CustomControls_SendResource)Page.LoadControl(@"CustomControls/SendResource.ascx");
                pSendResource.Village = this.Village;
                pSendResource.Session = this.NHibernateSession;
                this.tblMenu.Rows[0].Cells[0].Attributes.Add("class", "selected");
                this.pMarket.Controls.Add(pSendResource);
                break;
        }
    }
}
