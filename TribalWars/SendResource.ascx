<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SendResource.ascx.cs"
    Inherits="SendResource" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table class="vis">
    <tbody>
        <tr>
            <th>
                Merchants:
                <asp:Label ID="lblAvailableMerchant" runat="server"></asp:Label>/<% = this.Village.VillageBuildingData.MerchantOfVillage %>
            </th>
            <th>
                Maximum transport amount:
                <% = (this.Village.VillageResourceData.Wood + this.Village.VillageResourceData.Clay + this.Village.VillageResourceData.Iron < this.Village.VillageBuildingData.Merchant * 1000) ? this.Village.VillageResourceData.Wood + this.Village.VillageResourceData.Clay + this.Village.VillageResourceData.Iron : this.Village.VillageBuildingData.Merchant * 1000%>
            </th>
        </tr>
    </tbody>
</table>
<table>
    <tbody>
        <tr>
            <td valign="top">
                <table class="vis">
                    <tbody>
                        <tr>
                            <th>
                                Resources
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/holz.png" title="Wood" alt="">&nbsp;<asp:TextBox ID="txtWood" runat="server"></asp:TextBox>
                                &nbsp;<a href="javascript:insertUnit('<% Response.Write(this.txtWood.ClientID); %>', <% = (this.Village.VillageResourceData.Wood < this.Village.VillageBuildingData.Merchant * 1000) ? this.Village.VillageResourceData.Wood : this.Village.VillageBuildingData.Merchant * 1000 %>)">(<% = (this.Village.VillageResourceData.Wood < this.Village.VillageBuildingData.Merchant * 1000) ? this.Village.VillageResourceData.Wood : this.Village.VillageBuildingData.Merchant * 1000%>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/lehm.png" title="Clay" alt="">&nbsp;<asp:TextBox ID="txtClay" runat="server"></asp:TextBox>
                                &nbsp;<a href="javascript:insertUnit('<% Response.Write(this.txtClay.ClientID); %>', <% = (this.Village.VillageResourceData.Clay < this.Village.VillageBuildingData.Merchant * 1000) ? this.Village.VillageResourceData.Clay : this.Village.VillageBuildingData.Merchant * 1000 %>)">(<% = (this.Village.VillageResourceData.Clay < this.Village.VillageBuildingData.Merchant * 1000) ? this.Village.VillageResourceData.Clay : this.Village.VillageBuildingData.Merchant * 1000%>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/eisen.png" title="Iron" alt="">&nbsp;<asp:TextBox ID="txtIron" runat="server"></asp:TextBox>
                                &nbsp;<a href="javascript:insertUnit('<% Response.Write(this.txtIron.ClientID); %>', <% = (this.Village.VillageResourceData.Iron < this.Village.VillageBuildingData.Merchant * 1000) ? this.Village.VillageResourceData.Iron : this.Village.VillageBuildingData.Merchant * 1000 %>)">(<% = (this.Village.VillageResourceData.Iron < this.Village.VillageBuildingData.Merchant * 1000) ? this.Village.VillageResourceData.Iron : this.Village.VillageBuildingData.Merchant * 1000%>)</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
            <td valign="top">
                <table class="vis">
                    <tbody>
                        <tr>
                            <th colspan="3">
                                Destination
                            </th>
                        </tr>
                        <tr>
                            <td>
                                x:
                                <asp:TextBox ID="txtX" runat="server"></asp:TextBox>
                                &nbsp;y:
                                <asp:TextBox ID="txtY" runat="server"></asp:TextBox>
                                &nbsp;
                            </td>
                            <td>
                                <a href="javascript:inlinePopup('own', 'targets.php?village=51549&amp;building=market&amp;mode=own', popup_options)">
                                    » Your own</a><br>
                            </td>
                            <td valign="top">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:UpdatePanel ID="panel2" runat="server">
                <ContentTemplate>
                    <asp:Button ID="bttnSend" runat="server" Text="» OK «" OnClick="bttnSend_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>
                
                <div>
                    <div style="display:none;" id="confirmDialog">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <h2>
                                    Confirm transport</h2>
                                <table class="vis" width="350">
                                    <tbody>
                                        <tr>
                                            <th colspan="2">
                                                Transport
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                Destination:
                                            </td>
                                            <td>
                                                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<asp:Literal runat="server" ID="targetVillageID"></asp:Literal>'>
                                                    <asp:Literal runat="server" ID="targetVillageName"></asp:Literal></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Player:
                                            </td>
                                            <td>
                                                <a href='user_info.aspx?id=<% = this.Village.ID %>&village=<asp:Literal runat="server" ID="targetPlayerID"></asp:Literal>'>
                                                    <asp:Literal runat="server" ID="targetPlayerName"></asp:Literal></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="150">
                                                Resources:
                                            </td>
                                            <td width="200">
                                                <asp:Literal runat="server" ID="claySpan"></asp:Literal>
                                                <asp:Literal runat="server" ID="woodSpan"></asp:Literal>
                                                <asp:Literal runat="server" ID="ironSpan"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Merchants required:
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="merchantRequiredSpan"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Duration (each way):
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="durationSpan"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Arrival:
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="arrivalSpan"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Return:
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="returnSpan"></asp:Literal>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br>
                                
                                <input type="button" value="Confirm" onclick="__doPostBack('<% = this.bttnConfirmSend.UniqueID%>', '')" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="bttnSend" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </td>
        </tr>
    </tbody>
</table>
<asp:Repeater ID="rMyTransport" runat="server">
    <HeaderTemplate>
        <h3>
            Incoming transports</h3>
        <table class="vis">
            <tbody>
                <tr>
                    <th>
                        Destination
                    </th>
                    <th>
                        Goods
                    </th>
                    <th>
                        Duration
                    </th>
                    <th>
                        arrival time
                    </th>
                    <th>
                        Arrival in
                    </th>
                    <th>
                    </th>
                </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
        <td>
            <%# TypePrefix((beans.MoveType)DataBinder.Eval(Container.DataItem, "Type")) %>
            <a href="<%# String.Format("village_info.aspx?id={0}&village={1}", this.Village.ID, ((beans.Village)(DataBinder.Eval(Container.DataItem, "ToVillage"))).ID) %>">
                <%# ((beans.Village)(DataBinder.Eval(Container.DataItem, "FromVillage"))).Name%> (<%# ((beans.Village)(DataBinder.Eval(Container.DataItem, "FromVillage"))).X.ToString("000")%>|<%# ((beans.Village)(DataBinder.Eval(Container.DataItem, "FromVillage"))).Y.ToString("000")%>)</a>
        </td>
        <td>
            <%# DisplayResources((beans.MovingCommand)Container.DataItem)%>
        </td>
        <td>
            <%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime") - (DateTime)DataBinder.Eval(Container.DataItem, "StartingTime"))%>
        </td>
        <td>
            <%# ((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime")).ToString("HH:mm:ss:'<span class=\"small inactive\">'fff'</span> ngày' dd:MM:yyyy") %>
        </td>
        <td>
            <span class="timer">
                <%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime") - DateTime.Now) %></span>
        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody></table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="rOutgoings" runat="server">
    <HeaderTemplate>
        <h3>
            Your transports</h3>
        <table class="vis">
            <tbody>
                <tr>
                    <th>
                        Destination
                    </th>
                    <th>
                        Goods
                    </th>
                    <th>
                        Merchants
                    </th>
                    <th>
                        Duration
                    </th>
                    <th>
                        arrival time
                    </th>
                    <th>
                        Arrival in
                    </th>
                    <th>
                    </th>
                </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
        <td>
            Gửi đến 
            <a href="<%# String.Format("village_info.aspx?id={0}&village={1}", this.Village.ID, ((beans.Village)(DataBinder.Eval(Container.DataItem, "ToVillage"))).ID) %>">
                <%# ((beans.Village)(DataBinder.Eval(Container.DataItem, "ToVillage"))).Name %> (<%# ((beans.Village)(DataBinder.Eval(Container.DataItem, "ToVillage"))).X.ToString("000")%>|<%# ((beans.Village)(DataBinder.Eval(Container.DataItem, "ToVillage"))).Y.ToString("000")%>)</a>
        </td>
        <td>
            <%# Functions.GetResourceString(beans.ResourcesType.Clay, (int)Eval("Clay")) %>
            <%# Functions.GetResourceString(beans.ResourcesType.Wood, (int)Eval("Wood")) %>
            <%# Functions.GetResourceString(beans.ResourcesType.Iron, (int)Eval("Iron")) %>
        </td>
        <td>
            <%# MerchantCalculation((beans.MovingCommand)Container.DataItem) %>
        </td>
        <td>
            <%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime") - (DateTime)DataBinder.Eval(Container.DataItem, "StartingTime")) %>
        </td>
        <td>
            <%# ((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime")).ToString("HH:mm:ss:'<span class=\"small inactive\">'fff'</span> ngày' dd:MM:yyyy") %>
        </td>
        <td>
            <span class="timer">
                <%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime") - DateTime.Now) %></span>
        </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody></table>
    </FooterTemplate>
</asp:Repeater>
<div style="display:none;"><asp:Button ID="bttnConfirmSend" runat="server" Text="Send" OnClick="bttnConfirmSend_Click" /></div>
