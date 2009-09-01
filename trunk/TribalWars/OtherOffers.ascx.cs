using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;

public partial class OtherOffers : System.Web.UI.UserControl
{

    public Village Village
    {
        get;
        set;
    }

    protected string TribeName(Player player)
    {
        if (player.Group != null)
            return string.Format("[{0}]", player.Group.Name);
        return "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items["NHibernateSession"];


        IList<Offer> offers = this.Village.VillageMarketMethods.GetOffers(ResourcesType.Any, ResourcesType.Any, 0, 0, string.Empty, session);
            this.offerRepeater.DataSource = offers;
            this.offerRepeater.DataBind();


    }
    protected void offerRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
        {

            RepeaterItem ri = e.Item;
            //String numOfIssues = (String)((DataRowView)ri.DataItem)["numberofissues"];
            Offer offer = (Offer)e.Item.DataItem;
            int i = offer.ForQuantity;
            if (this.Village.VillageBuildingData.Merchant < Math.Ceiling((double)offer.ForQuantity / 1000))
            {
                e.Item.FindControl("notEoughMerchantPanel").Visible = true;
                return;
            }
            if (this.Village[offer.ForType] < offer.ForQuantity)
            {
                e.Item.FindControl("notEnoughResourcePanel").Visible = true;
                return;
            }
            e.Item.FindControl("canBuyPanel").Visible = true;

        }
        
    }

    protected void offerRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int quantity = 0;
            if (!int.TryParse(((TextBox)e.Item.FindControl("quantityTextBox")).Text, out quantity))
                return;

            if (quantity <= 0)
                return;

            int offerId = 0;
            if (!int.TryParse(((HiddenField)e.Item.FindControl("offerId")).Value, out offerId))
                return;

            ISession session = (ISession)Context.Items["NHibernateSession"];

            this.Village.VillageMarketMethods.AcceptOffer(offerId, quantity, session);
            string p = (Request["p"] == null) ? string.Format("&p={0}", Request["p"]) : "";
            Response.Redirect(string.Format("market.aspx?id={0}&page=market{1}", this.Village.ID, p), false);
        }
    }
}
