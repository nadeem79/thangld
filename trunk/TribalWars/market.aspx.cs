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
    public Label ClayLabel
    {
        get;
        set;
    }
    public Label WoodLabel
    {
        get;
        set;
    }
    public Label IronLabel
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Village = ((inPage)this.Master).CurrentVillage;
        this.NHibernateSession = (ISession)Context.Items["NHibernateSession"];
        string page = "";
        if (!object.Equals(Request["page"], null))
            page = Request["page"];

        switch (page)
        {
            case "merchant_status":
                CustomControls_MerchantStatus pMerchantStatus = (CustomControls_MerchantStatus)Page.LoadControl(@"CustomControls/MerchantStatus.ascx");
                pMerchantStatus.Village = this.Village;
                this.tblMenu.Rows[3].Cells[0].Attributes.Add("class", "selected");
                this.pMarket.Controls.Add(pMerchantStatus);
                break;
            case "make_offer":
                CustomControls_MakeMarketOffer pMakeMarketOffer = (CustomControls_MakeMarketOffer)Page.LoadControl(@"CustomControls/MakeMarketOffer.ascx");
                pMakeMarketOffer.Village = this.Village;
                this.tblMenu.Rows[1].Cells[0].Attributes.Add("class", "selected");
                this.pMarket.Controls.Add(pMakeMarketOffer);
                break;
            default:
                CustomControls_SendResource pSendResource = (CustomControls_SendResource)Page.LoadControl(@"CustomControls/SendResource.ascx");
                pSendResource.Village = this.Village;
                this.tblMenu.Rows[0].Cells[0].Attributes.Add("class", "selected");
                this.pMarket.Controls.Add(pSendResource);
                break;
        }
    }
}
