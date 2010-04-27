<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OtherOffers.ascx.cs" Inherits="OtherOffers" %>
<table class="vis">
    <tbody>
        <tr>
            <th>
                Merchants:
                <% = this.Village.VillageBuildingData.Merchant %>/<% = this.Village.VillageBuildingData.MerchantOfVillage %>
            </th>
            <th>
                Maximum transport amount:
                <% = (this.Village.VillageResourceData.Wood + this.Village.VillageResourceData.Clay + this.Village.VillageResourceData.Iron < this.Village.VillageBuildingData.Merchant * 1000) ? this.Village.VillageResourceData.Wood + this.Village.VillageResourceData.Clay + this.Village.VillageResourceData.Iron : this.Village.VillageBuildingData.Merchant * 1000%>
            </th>
        </tr>
    </tbody>
</table>
<h3>
    Other offers</h3>

<table class="vis">
    <tbody>
        <tr>
            <td>
                Search:
            </td>
            <td>
                <select name="res_sell">
                    <option value="all" selected="selected">all</option>
                    <option value="wood">Wood</option>
                    <option value="stone">Clay</option>
                    <option value="iron">Iron</option>
                </select>
            </td>
            <td width="10">
            </td>
            <td>
                Maximum delivery time
            </td>
            <td>
                <input name="trader_time_max_hours" value="72" size="4" type="text">
                Hours
            </td>
            <td rowspan="4">
                <input value="Search" type="submit">
            </td>
        </tr>
        <tr>
            <td>
                Offer
            </td>
            <td>
                <select name="res_buy">
                    <option value="all" selected="selected">all</option>
                    <option value="wood">Wood</option>
                    <option value="stone">Clay</option>
                    <option value="iron">Iron</option>
                </select>
            </td>
            <td>
            </td>
            <td>
                Maximum ratio:
            </td>
            <td>
                <input name="ratio_max" value="0.85" size="4" type="text">
                (e.g.: 1.8)
            </td>
        </tr>
        <tr>
            <td colspan="4">
                Offers of tribe members only:
            </td>
            <td>
                <input value="7045" name="only_ally" type="checkbox">
            </td>
        </tr>
        <tr>
            <td>
                Order by:
            </td>
            <td colspan="4">
                <select name="order_by">
                    <option value="trader_time" selected="selected">Duration</option>
                    <option value="ratio">Ratio</option>
                    <option value="count">Availability</option>
                </select>
            </td>
        </tr>
    </tbody>
</table>
</form>
<asp:Repeater runat="server" ID="offerRepeater" 
    onitemcommand="offerRepeater_ItemCommand" 
    OnItemDataBound="offerRepeater_ItemDataBound">
    <HeaderTemplate>
        <table class="vis">
    <tbody>
        <tr>
            <th>
                Offer
            </th>
            <th>
                For
            </th>
            <th>
                Player
            </th>
            <th>
                Duration
            </th>
            <th>
                Ratio
            </th>
            <th>
                Availability
            </th>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <%# Functions.GetImageUrl(((beans.Offer)Container.DataItem).OfferType) %>
                <%# Eval("OfferQuantity") %>
            </td>
            <td>
                <%# Functions.GetImageUrl((beans.ResourcesType)DataBinder.Eval(Container.DataItem, "ForType"))%> <%# DataBinder.Eval(Container.DataItem, "ForQuantity")%>
            </td>
            <td>
                <a href=<%# string.Format("\"user_info.aspx?id={0}&player={1}\"", this.Village.ID, ((beans.Village)DataBinder.Eval(Container.DataItem, "AtVillage")).Player.ID)%>><%# ((beans.Village)DataBinder.Eval(Container.DataItem, "AtVillage")).Player.Username %> <%# TribeName(((beans.Village)DataBinder.Eval(Container.DataItem, "AtVillage")).Player) %></a>
            </td>
            <td>
                <%# Functions.FormatTime((long)beans.Map.MovingTime(this.Village, (beans.Village)DataBinder.Eval(Container.DataItem, "AtVillage"), beans.TroopType.Merchant))%>
            </td>
            <td>
                <%# ((int)DataBinder.Eval(Container.DataItem, "OfferQuantity") / (int)DataBinder.Eval(Container.DataItem, "ForQuantity")).ToString("0.00")%>
            </td>
            <td>
                <%# Eval("OfferNumber") %> offers
            </td>
            <td>
                <asp:Panel runat="server" ID="canBuyPanel" Visible="false">
                    <asp:TextBox runat="server" ID="quantityTextBox" Text="1"></asp:TextBox>
                    <asp:Button runat="server" ID="buyButton" Text="Buy" />
                    <asp:HiddenField runat="server" ID="offerId" Value='<%# Eval("ID") %>' />
                </asp:Panel>
                <asp:Panel runat="server" ID="notEnoughResourcePanel" Visible="false">
                    Không đủ tài nguyên</asp:Panel>
                <asp:Panel runat="server" ID="notEoughMerchantPanel" Visible="false">
                    Không đủ merchant</asp:Panel>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody></table>
    </FooterTemplate>
</asp:Repeater>
