using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using Telerik.Web.UI;
using NHibernate;

public partial class CustomControls_MakeMarketOffer : System.Web.UI.UserControl
{
    public Village Village
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void createOfferButton_Click(object sender, EventArgs e)
    {
        int offerQuantity = 0, forQuantity = 0, maxTransportTime = 0, offerNumber = 0;
        ResourcesType offerType, forType;
        try
        {
            offerType = (ResourcesType)Enum.Parse(typeof(ResourcesType), this.offerTypeList.SelectedValue);
            forType = (ResourcesType)Enum.Parse(typeof(ResourcesType), this.forTypeList.SelectedValue);
        }
        catch
        {
            RadScriptManager.RegisterStartupScript(createOfferButton, createOfferButton.GetType(), "ShowException", "jQuery.facebox('Chọn tài nguyên');", true);
            return;
        }

        if (!int.TryParse(this.offerTextBox.Text, out offerQuantity)
            || !int.TryParse(this.maxDurationTextBox.Text, out maxTransportTime)
            || !int.TryParse(this.forTextBox.Text, out forQuantity)
            || !int.TryParse(this.offerCountTextBox.Text, out offerNumber))
        {
            RadScriptManager.RegisterStartupScript(createOfferButton, createOfferButton.GetType(), "ShowException", "jQuery.facebox('Nhập đầy đủ dữ liệu');", true);
            return;
        }

        ISession session = (ISession)Context.Items["NHibernateSession"];

        Offer offer = this.Village.CreateOffer(offerType, offerQuantity, forType, forQuantity, maxTransportTime, offerNumber);
        offer.Save(session);
        RadScriptManager.RegisterStartupScript(createOfferButton, createOfferButton.GetType(), "DONE", "reload();", true);
    }
}
