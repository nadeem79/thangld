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

        if (this.Village[beans.BuildingType.Market] > 0)
            this.pConstructed.Visible = true;
        else
        {
            this.pNotConstruct.Visible = true;
            return;
        }

        string page = "";
        if (!object.Equals(Request["page"], null))
            page = Request["page"];

        switch (page)
        {
            case "merchant_status":
                MerchantStatus pMerchantStatus = (MerchantStatus)Page.LoadControl(@"MerchantStatus.ascx");
                pMerchantStatus.Village = this.Village;
                this.tblMenu.Rows[3].Cells[0].Attributes.Add("class", "selected");
                this.pMarket.Controls.Add(pMerchantStatus);
                break;
            case "make_offer":
                MakeMarketOffer pMakeMarketOffer = (MakeMarketOffer)Page.LoadControl(@"MakeMarketOffer.ascx");
                pMakeMarketOffer.Village = this.Village;
                this.tblMenu.Rows[1].Cells[0].Attributes.Add("class", "selected");
                this.pMarket.Controls.Add(pMakeMarketOffer);
                break;
            case "market":
                OtherOffers pOtherOffer = (OtherOffers)Page.LoadControl(@"OtherOffers.ascx");
                pOtherOffer.Village = this.Village;
                this.tblMenu.Rows[2].Cells[0].Attributes.Add("class", "selected");
                this.pMarket.Controls.Add(pOtherOffer);
                break;
            default:
                SendResource pSendResource = (SendResource)Page.LoadControl(@"SendResource.ascx");
                pSendResource.Village = this.Village;
                this.tblMenu.Rows[0].Cells[0].Attributes.Add("class", "selected");
                this.pMarket.Controls.Add(pSendResource);
                break;
        }
    }
}
