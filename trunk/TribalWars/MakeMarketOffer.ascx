<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MakeMarketOffer.ascx.cs"
    Inherits="MakeMarketOffer" %>
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
                    <th></th>
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
                <asp:CheckBox ID="checkSelectCheckBox" runat="server" ToolTip='<%# DataBinder.Eval(Container.DataItem, "ID")  %>' />
                <input type="hidden" runat="server" id="offerId" value='<%# DataBinder.Eval(Container.DataItem, "ID")  %>' />
            </td>
            <td>
                <%# Functions.GetImageUrl((beans.ResourcesType)DataBinder.Eval(Container.DataItem, "OfferType")) %> <%# DataBinder.Eval(Container.DataItem, "OfferQuantity")%>
            </td>
            <td>
                <%# Functions.GetImageUrl((beans.ResourcesType)DataBinder.Eval(Container.DataItem, "ForType"))%> <%# DataBinder.Eval(Container.DataItem, "ForQuantity")%>
            </td>
            <td>
                <%# DataBinder.Eval(Container.DataItem, "OfferNumber")%>
            </td>
            <td>
                <%# ((DateTime)DataBinder.Eval(Container.DataItem, "CreateTime")).ToString("HH:mm:ss 'ngày' dd:MM:yyyy")%>
            </td>
            <td>
                <%# DataBinder.Eval(Container.DataItem, "MaxTransportTime")%> h
            </td>
        </tr>
    </ItemTemplate>
</asp:Repeater>

<asp:Button ID="deleteOfferButton" runat="server" Text="Delete" 
    onclick="deleteOfferButton_Click" />&nbsp
    <asp:TextBox ID="quantityTextBox" runat="server" Text="1">
    </asp:TextBox> &nbsp
    

<asp:Button ID="increaseOfferButton" runat="server" Text="Increase offer" 
    onclick="increaseOfferButton_Click" />&nbsp
<asp:Button ID="decreaseOfferButton" runat="server" Text="Decrease offer" 
    onclick="decreaseOfferButton_Click" />