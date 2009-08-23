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
        ISession session = (ISession)Context.Items["NHibernateSession"];
        IList<Offer> offers = this.Village.VillageMarketMethods.GetMyOffers(session);
        if (offers.Count > 0)
        {
            this.myOfferRepeater.DataSource = offers;
            this.myOfferRepeater.DataBind();
        }
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

        Offer offer = this.Village.VillageMarketMethods.CreateOffer(offerType, offerQuantity, forType, forQuantity, maxTransportTime, offerNumber);
        offer.Save(session);
        RadScriptManager.RegisterStartupScript(createOfferButton, createOfferButton.GetType(), "DONE", "reload();", true);
    }

    protected void deleteOfferButton_Click(object sender, EventArgs e)
    {
        for (int cnt = 0; cnt < myOfferRepeater.Items.Count; cnt++)
        {
            // your checkbox ; type casting
            CheckBox cbId = (CheckBox)myOfferRepeater.Items[cnt].FindControl("checkSelectCheckBox");


            if (cbId.Checked)
            {
                int id = 0;
                string offerId = ((System.Web.UI.HtmlControls.HtmlInputHidden)myOfferRepeater.Items[cnt].FindControl("offerId")).Value;

                if (!int.TryParse(offerId, out id))
                    continue;

                ISession session = (ISession)Context.Items["NHibernateSession"];
                this.Village.VillageMarketMethods.DeleteOffer(id, session);

            }
        }

        Response.Redirect(string.Format("market.aspx?id={0}&page=make_offer", this.Village.ID), false);
    }

    protected void increaseOfferButton_Click(object sender, EventArgs e)
    {
        for (int cnt = 0; cnt < myOfferRepeater.Items.Count; cnt++)
        {
            // your checkbox ; type casting
            CheckBox cbId = (CheckBox)myOfferRepeater.Items[cnt].FindControl("checkSelectCheckBox");


            if (cbId.Checked)
            {
                int id = 0;
                int quantity = 0;
                string offerId = ((System.Web.UI.HtmlControls.HtmlInputHidden)myOfferRepeater.Items[cnt].FindControl("offerId")).Value;

                if (!int.TryParse(offerId, out id))
                    continue;
                if (!int.TryParse(quantityTextBox.Text, out quantity) || quantity <= 0)
                    continue;

                ISession session = (ISession)Context.Items["NHibernateSession"];
                this.Village.VillageMarketMethods.IncreaseOffer(id, quantity, session);

            }
        }

        Response.Redirect(string.Format("market.aspx?id={0}&page=make_offer", this.Village.ID), false);
    }

    protected void decreaseOfferButton_Click(object sender, EventArgs e)
    {
        for (int cnt = 0; cnt < myOfferRepeater.Items.Count; cnt++)
        {
            // your checkbox ; type casting
            CheckBox cbId = (CheckBox)myOfferRepeater.Items[cnt].FindControl("checkSelectCheckBox");


            if (cbId.Checked)
            {
                int id = 0;
                int quantity = 0;
                string offerId = ((System.Web.UI.HtmlControls.HtmlInputHidden)myOfferRepeater.Items[cnt].FindControl("offerId")).Value;

                if (!int.TryParse(offerId, out id))
                    continue;
                if (!int.TryParse(quantityTextBox.Text, out quantity) || quantity <= 0)
                    continue;

                ISession session = (ISession)Context.Items["NHibernateSession"];
                this.Village.VillageMarketMethods.DecreaseOffer(id, quantity, session);

            }
        }

        Response.Redirect(string.Format("market.aspx?id={0}&page=make_offer", this.Village.ID), false);
    }
}
