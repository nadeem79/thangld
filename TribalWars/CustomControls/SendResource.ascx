<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SendResource.ascx.cs"
    Inherits="CustomControls_SendResource" %>
<table class="vis">
    <tbody>
        <tr>
            <th>
                Merchants:
                <asp:Label ID="lblAvailableMerchant" runat="server"></asp:Label>/<% = this.Village.Buildings.Merchant %>
            </th>
            <th>
                Maximum transport amount:
                <% = (this.Village.Resources.Wood + this.Village.Resources.Clay + this.Village.Resources.Iron < this.Village.Buildings.Merchant * 1000) ? this.Village.Resources.Wood + this.Village.Resources.Clay + this.Village.Resources.Iron : this.Village.Buildings.Merchant * 1000%>
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
                                &nbsp;<a href="javascript:insertUnit('<% Response.Write(this.txtWood.ClientID); %>', <% = (this.Village.Resources.Wood < this.Village.Buildings.Merchant * 1000) ? this.Village.Resources.Wood : this.Village.Buildings.Merchant * 1000 %>)">(<% = (this.Village.Resources.Wood < this.Village.Buildings.Merchant * 1000) ? this.Village.Resources.Wood : this.Village.Buildings.Merchant * 1000 %>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/lehm.png" title="Clay" alt="">&nbsp;<asp:TextBox ID="txtClay" runat="server"></asp:TextBox>
                                &nbsp;<a href="javascript:insertUnit('<% Response.Write(this.txtClay.ClientID); %>', <% = (this.Village.Resources.Clay < this.Village.Buildings.Merchant * 1000) ? this.Village.Resources.Clay : this.Village.Buildings.Merchant * 1000 %>)">(<% = (this.Village.Resources.Clay < this.Village.Buildings.Merchant * 1000) ? this.Village.Resources.Clay : this.Village.Buildings.Merchant * 1000 %>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/eisen.png" title="Iron" alt="">&nbsp;<asp:TextBox ID="txtIron" runat="server"></asp:TextBox>
                                &nbsp;<a href="javascript:insertUnit('<% Response.Write(this.txtIron.ClientID); %>', <% = (this.Village.Resources.Iron < this.Village.Buildings.Merchant * 1000) ? this.Village.Resources.Iron : this.Village.Buildings.Merchant * 1000 %>)">(<% = (this.Village.Resources.Iron < this.Village.Buildings.Merchant * 1000) ? this.Village.Resources.Iron : this.Village.Buildings.Merchant * 1000 %>)</a>
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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="bttnSend" runat="server" Text="» OK «" OnClick="bttnSend_Click" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="bttnSend" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </tbody>
</table>
<h3>
    Your transports</h3>
<asp:Repeater ID="rMyTransport" runat="server">
    <HeaderTemplate>
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
                    <th></th>
                </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <td>
                <%# TypePrefix((beans.MoveType)DataBinder.Eval(Container.DataItem, "Type")) %> 
                <a href="<%# String.Format("village_info.aspx?id={0}&village={1}", this.Village.ID, ((beans.Village)(DataBinder.Eval(Container.DataItem, "To"))).ID) %>"><%# ((beans.Village)(DataBinder.Eval(Container.DataItem, "To"))).Name%></a>
            </td>
            <td>
                <%# DisplayResources((beans.MovingCommand)Container.DataItem)%>
            </td>
            <td>
                <%# MerchantCalculation((beans.MovingCommand)Container.DataItem) %>
            </td>
            <td>
                <%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime") - (DateTime)DataBinder.Eval(Container.DataItem, "StartTime")) %>
            </td>
            <td>
                <%# ((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime")).ToString("HH:mm:ss:'<span class=\"small inactive\">'fff'</span> ngày' dd:MM:yyyy") %>
            </td>
            <td>
                <span class="timer"><%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime") - DateTime.Now) %></span>
            </td>
    </ItemTemplate>
    <FooterTemplate>
        </tbody></table>
    </FooterTemplate>
</asp:Repeater>


<h3>
    Incoming transports</h3>
<asp:Repeater ID="rOutgoings" runat="server">
    <HeaderTemplate>
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
                    <th></th>
                </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <td>
                <%# TypePrefix((beans.MoveType)DataBinder.Eval(Container.DataItem, "Type")) %> 
                <a href="<%# String.Format("village_info.aspx?id={0}&village={1}", this.Village.ID, ((beans.Village)(DataBinder.Eval(Container.DataItem, "To"))).ID) %>"><%# ((beans.Village)(DataBinder.Eval(Container.DataItem, "To"))).Name%></a>
            </td>
            <td>
                <%# DisplayResources((beans.MovingCommand)Container.DataItem) %>
            </td>
            <td>
                <%# MerchantCalculation((beans.MovingCommand)Container.DataItem) %>
            </td>
            <td>
                <%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime") - (DateTime)DataBinder.Eval(Container.DataItem, "StartTime")) %>
            </td>
            <td>
                <%# ((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime")).ToString("HH:mm:ss:'<span class=\"small inactive\">'fff'</span> ngày' dd:MM:yyyy") %>
            </td>
            <td>
                <span class="timer"><%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime") - DateTime.Now) %></span>
            </td>
    </ItemTemplate>
    <FooterTemplate>
        </tbody></table>
    </FooterTemplate>
</asp:Repeater>
