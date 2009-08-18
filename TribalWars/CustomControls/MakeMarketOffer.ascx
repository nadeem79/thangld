<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MakeMarketOffer.ascx.cs"
    Inherits="CustomControls_MakeMarketOffer" %>
<table class="vis">
    <tbody>
        <tr>
            <th>
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
    Create offer</h3>
<asp:UpdatePanel runat="server" ID="makeOfferPanel">
    <ContentTemplate>
        <table class="vis">
            <tbody>
                <tr>
                    <td>
                        Offer
                    </td>
                    <td>
                        &nbsp;<asp:TextBox ID="offerTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="offerTypeList" RepeatDirection="Horizontal">
                            <asp:ListItem Value="2" Text="<img src='../images/resources/wood.png' title='Wood' alt='' />"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<img src='../images/resources/clay.png' title='Clay' alt='' />"></asp:ListItem>
                            <asp:ListItem Value="3" Text="<img src='../images/resources/iron.png' title='Iron' alt='' />"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        For:
                    </td>
                    <td>
                        &nbsp;<asp:TextBox ID="forTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="forTypeList" RepeatDirection="Horizontal">
                            <asp:ListItem Value="2" Text="<img src='../images/resources/wood.png' title='Wood' alt='' />"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<img src='../images/resources/clay.png' title='Clay' alt='' />"></asp:ListItem>
                            <asp:ListItem Value="3" Text="<img src='../images/resources/iron.png' title='Iron' alt='' />"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Maximum Duration:
                    </td>
                    <td>
                        &nbsp;<asp:TextBox ID="maxDurationTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Hours
                    </td>
                </tr>
                <tr>
                    <td>
                        Number of offers:
                    </td>
                    <td>
                        &nbsp;<asp:TextBox ID="offerCountTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Offers
                    </td>
                </tr>
            </tbody>
        </table>
        <asp:Button ID="createOfferButton" runat="server" Text="Create" OnClick="createOfferButton_Click" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="createOfferButton" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<asp:Repeater ID="myOfferRepeater" runat="server">
    <HeaderTemplate>
        <h3>
            Your offers</h3>
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
                        Quantity
                    </th>
                    <th>
                        created
                    </th>
                    <th>
                        Maximum Duration
                    </th>
                </tr>
    </HeaderTemplate>
    <FooterTemplate>
        </tbody> </table>
    </FooterTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <input name="id_499252" type="checkbox"><img src="/graphic/lehm.png?1" title="Clay"
                    alt="">1<span class="grey">.</span>000
            </td>
            <td>
                <img src="/graphic/eisen.png?1" title="Iron" alt="">1<span class="grey">.</span>000
            </td>
            <td>
                3
            </td>
            <td>
                today at 05:50
            </td>
            <td>
                5 hours
            </td>
        </tr>
    </ItemTemplate>
</asp:Repeater>
