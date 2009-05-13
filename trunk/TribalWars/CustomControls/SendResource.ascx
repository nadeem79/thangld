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
                Maximum transport amount: <% = (this.Village.Resources.Wood + this.Village.Resources.Clay + this.Village.Resources.Iron < this.Village.Buildings.Merchant * 1000) ? this.Village.Resources.Wood + this.Village.Resources.Clay + this.Village.Resources.Iron : this.Village.Buildings.Merchant * 1000%>
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
<table class="vis">
    <tbody>
        <tr>
            <th width="200">
                Destination
            </th>
            <th width="80">
                Goods
            </th>
            <th>
                Merchants
            </th>
            <th width="70">
                Duration
            </th>
            <th width="100">
                arrival time
            </th>
            <th width="70">
                Arrival in
            </th>
        </tr>
        <tr>
            <td>
                Transport to<br>
                <a href="/game.php?village=51549&amp;screen=info_village&amp;id=50547">K75 I kill landlubbers!
                    (513|728) K75</a>
            </td>
            <td>
                <img src="/graphic/lehm.png?1" title="Clay" alt="">1<span class="grey">.</span>000
            </td>
            <td>
                1
            </td>
            <td>
                0:24:44
            </td>
            <td>
                today at 18:21
            </td>
            <td>
                <span class="timer">0:08:12</span>
            </td>
            <td style="display: none;">
            </td>
        </tr>
        <tr>
            <td>
                Return from<br>
                <a href="/game.php?village=51549&amp;screen=info_village&amp;id=39848">002 Bravo (534|701)
                    K75</a>
            </td>
            <td>
            </td>
            <td>
                1
            </td>
            <td>
                3:02:53
            </td>
            <td>
                today at 18:39
            </td>
            <td>
                <span class="timer">0:26:54</span>
            </td>
            <td style="display: none;">
            </td>
        </tr>
    </tbody>
</table>
<h3>
    Incoming transports</h3>
<table class="vis">
    <tbody>
        <tr>
            <th width="160">
                Origin
            </th>
            <th width="80">
                Goods
            </th>
            <th width="100">
                arrival time
            </th>
            <th width="70">
                Arrival in
            </th>
        </tr>
        <tr>
            <td>
                Delivery from<br>
                <a href="/game.php?village=51549&amp;screen=info_village&amp;id=50547">K75 I kill landlubbers!
                    (513|728) K75</a>
            </td>
            <td>
                <img src="/graphic/eisen.png?1" title="Iron" alt="">1<span class="grey">.</span>000
            </td>
            <td>
                today at 18:21
            </td>
            <td>
                <span class="timer">0:08:12</span>
            </td>
        </tr>
    </tbody>
</table>
