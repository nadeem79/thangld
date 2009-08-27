<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TroopCommand.ascx.cs" Inherits="CustomControls_TroopCommand" %>
<h3>
    Give commands</h3>
<p>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></p>
<table>
    <tbody>
        <tr>
            <td valign="top" width="150">
                <table class="vis" width="100%">
                    <tbody>
                        <tr>
                            <td>
                                <img src="images/unit_spear.png" title="Spear fighter" alt="" />
                                <asp:TextBox ID="spear" runat="server" Width="50px">
                                </asp:TextBox>
                                <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.spear.ClientID); %>', <% Response.Write(this.Village.VillageTroopData.Spear.ToString()); %>)"><% Response.Write(this.Village.VillageTroopData.Spear.ToString()); %></a>)</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/unit_sword.png" title="Swordsman" alt="" />
                                <asp:TextBox ID="sword" runat="server" Width="50px">
                                </asp:TextBox>
                                <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.sword.ClientID); %>', <% Response.Write(this.Village.VillageTroopData.Sword.ToString()); %>)"><% Response.Write(this.Village.VillageTroopData.Sword.ToString()); %></a>)</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/unit_axe.png" title="Axeman" alt="" />
                                <asp:TextBox ID="axe" runat="server" Width="50px">
                                </asp:TextBox>
                                <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.axe.ClientID); %>', <% Response.Write(this.Village.VillageTroopData.Axe.ToString()); %>)"><% Response.Write(this.Village.VillageTroopData.Axe.ToString()); %></a>)</span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
            <td valign="top" width="150">
                <table class="vis" width="100%">
                    <tbody>
                        <tr>
                            <td>
                                <img src="images/unit_spy.png" title="Scout" alt="" />
                                <asp:TextBox ID="scout" runat="server" Width="50px">
                                </asp:TextBox>
                                <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.scout.ClientID); %>', <% Response.Write(this.Village.VillageTroopData.Scout.ToString()); %>)"><% Response.Write(this.Village.VillageTroopData.Scout.ToString()); %></a>)</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/unit_light.png" title="Light cavalry" alt="" />
                                <asp:TextBox ID="light" runat="server" Width="50px">
                                </asp:TextBox>
                                <span>(<a href="javascript:void(0);" onclick="insertUnit('<% = this.light.ClientID %>', <% = this.Village.VillageTroopData.LightCavalry %>)"><% = this.Village.VillageTroopData.LightCavalry %></a>)</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/unit_heavy.png" title="Heavy cavalry" alt="" />
                                <asp:TextBox ID="heavy" runat="server" Width="50px">
                                </asp:TextBox>
                                <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.heavy.ClientID); %>', <% = this.Village.VillageTroopData.HeavyCavalry %>)"><% = this.Village.VillageTroopData.HeavyCavalry %></a>)</span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
            <td valign="top" width="150">
                <table class="vis" width="100%">
                    <tbody>
                        <tr>
                            <td>
                                <img src="images/unit_ram.png" title="Ram" alt="" />
                                <asp:TextBox ID="ram" runat="server" Width="50px">
                                </asp:TextBox>
                                <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.ram.ClientID); %>', <% Response.Write(this.Village.VillageTroopData.Ram.ToString()); %>)"><% Response.Write(this.Village.VillageTroopData.Ram.ToString()); %></a>)</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/unit_catapult.png" title="Catapult" alt="" />
                                <asp:TextBox ID="catapult" runat="server" Width="50px">
                                </asp:TextBox>
                                <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.catapult.ClientID); %>', <% Response.Write(this.Village.VillageTroopData.Catapult.ToString()); %>)"><% Response.Write(this.Village.VillageTroopData.Catapult.ToString()); %></a>)</span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
            <td valign="top" width="150">
                <table class="vis" width="100%">
                    <tbody>
                        <tr>
                            <td>
                                <img src="images/unit_snob.png" title="Nobleman" alt="" />
                                <asp:TextBox ID="noble" runat="server" Width="50px">
                                </asp:TextBox>
                                <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.noble.ClientID); %>', <% Response.Write(this.Village.VillageTroopData.Noble.ToString()); %>)"><% Response.Write(this.Village.VillageTroopData.Noble.ToString()); %></a>)</span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
<asp:UpdatePanel runat="server" ID="updatePanel">
    <ContentTemplate>
        <table>
            <tbody>
                <tr>
                    <td rowspan="2">
                        X:<asp:TextBox ID="x" runat="server" MaxLength="3" Width="50"></asp:TextBox>
                        Y:
                        <asp:TextBox ID="y" runat="server" MaxLength="3" Width="50"></asp:TextBox>
                    </td>
                    <td valign="top">
                        <asp:Button ID="bttnAttack" runat="server" Font-Size="10pt" Text="Attack" OnClick="bttnAttack_Click" />
                    </td>
                    <td valign="top">
                        <asp:Button ID="bttnSupport" runat="server" Font-Size="10pt" Text="Support" OnClick="bttnSupport_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div id="commandPanel" style="display:none;">
            <h2>
                <asp:Literal runat="server" ID="commandTypeSpan"></asp:Literal></h2>
        <table class="vis" width="300">
            <tbody>
                <tr>
                    <th colspan="2">
                        Đặt lệnh
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:Literal runat="server" ID="typeSpan"></asp:Literal>:
                    </td>
                    <td>
                        <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<asp:Literal runat="server" ID="toVillageIdSpan"></asp:Literal>' target="_blank" >
                            <asp:Literal runat="server" ID="toVillageName"></asp:Literal> (<asp:Literal runat="server" ID="toVillageXSpan"></asp:Literal>|<asp:Literal runat="server" ID="toVillageYSpan"></asp:Literal>)</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Chủ thành:
                    </td>
                    <td>
                        <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<asp:Literal runat="server" ID="toVillageOwnerIdSpan"></asp:Literal>'>
                            <asp:Literal runat="server" ID="toVillageOwnerNameSpan"></asp:Literal></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Thời gian:
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="durationSpan"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        Đến lúc:
                    </td>
                    <td id="date_arrival">
                        <asp:Literal runat="server" ID="landingTimeSpan"></asp:Literal>
                    </td>
                </tr>
            </tbody>
        </table>
            <br />
            <table class="vis">
                <tbody>
                    <tr>
                        <th width="50">
                            <img src="images/unit_spear.png" title="Spear fighter" alt="" />
                        </th>
                        <th width="50">
                            <img src="images/unit_sword.png" title="Swordsman" alt="">
                        </th>
                        <th width="50">
                            <img src="images/unit_axe.png" title="Axeman" alt="" />
                        </th>
                        <th width="50">
                            <img src="images/unit_spy.png" title="Scout" alt="" />
                        </th>
                        <th width="50">
                            <img src="images/unit_light.png" title="Light cavalry" alt="" />
                        </th>
                        <th width="50">
                            <img src="images/unit_heavy.png" title="Heavy cavalry" alt="" />
                        </th>
                        <th width="50">
                            <img src="images/unit_ram.png" title="Ram" alt="" />
                        </th>
                        <th width="50">
                            <img src="images/unit_catapult.png" title="Catapult" alt="" />
                        </th>
                        <th width="50">
                            <img src="images/unit_snob.png" title="Nobleman" alt="" style="height: 18px; width: 18px" />
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal runat="server" ID="spearSpan"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="swordSpan"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="axeSpan"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="scoutSpan"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="lightCavalrySpan"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="heavyCavalrySpan"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="ramSpan"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="catapultSpan"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="nobleSpan"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9">
                            <asp:Literal runat="server" ID="buttonNameSpan"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="bttnAttack" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="bttnSupport" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
    
                    
<h3>
    Troop movements</h3>
<asp:Repeater ID="outgoingRepeater" runat="server">
    <HeaderTemplate>
        <table class="vis">
            <tbody>
                <tr>
                    <th width="350">
                        Outgoing
                    </th>
                    <th width="200">
                        Arrival time
                    </th>
                    <th width="100">
                        Arrival in
                    </th>
                </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <a href="command.aspx?id=<% = this.Village.ID %>&command=<%# DataBinder.Eval(Container.DataItem, "ID") %>">
                    <%# TypePrefix((beans.MoveType)DataBinder.Eval(Container.DataItem, "Type")) %>
                    <%# ((beans.Village)DataBinder.Eval(Container.DataItem, "ToVillage")).Name %>
                    (<%# ((beans.Village)DataBinder.Eval(Container.DataItem, "ToVillage")).X.ToString("000") %>|<%# ((beans.Village)DataBinder.Eval(Container.DataItem, "ToVillage")).Y.ToString("000") %>)</a>
            </td>
            <td>
                <%# ((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime")).ToString("HH:mm:ss:'<span class=\"small inactive\">'fff'</span> ngày' dd/MM")%>
            </td>
            <td>
                <span class="timer">
                    <%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime") - DateTime.Now) %></span>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody> </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="incomingRepeater" runat="server">
    <HeaderTemplate>
        <table class="vis">
            <tbody>
                <tr>
                    <th width="350">
                        Incoming
                    </th>
                    <th width="200">
                        Arrival time
                    </th>
                    <th width="100">
                        Arrival in
                    </th>
                </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <a href="command.aspx?id=<% = this.Village.ID %>&command=<%# DataBinder.Eval(Container.DataItem, "ID") %>">
                    <%# TypePrefix((beans.MoveType)DataBinder.Eval(Container.DataItem, "Type")) %> từ
                    <%# ((beans.Village)DataBinder.Eval(Container.DataItem, "FromVillage")).Name %>
                    (<%# ((beans.Village)DataBinder.Eval(Container.DataItem, "FromVillage")).X.ToString("000")%>|<%# ((beans.Village)DataBinder.Eval(Container.DataItem, "FromVillage")).Y.ToString("000")%>)</a>
            </td>
            <td>
                <%# ((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime")).ToString("HH:mm:ss'<span class=\"small inactive\">:'fff'</span> ngày' dd/MM")%>
            </td>
            <td>
                <span class="timer">
                    <%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime") - DateTime.Now) %></span>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody> </table>
    </FooterTemplate>
</asp:Repeater>
<div style="display: none;">
    <asp:Button ID="confirmAttackButton" runat="server" Text="Confirm attack" OnClick="confirmAttackButton_Click" />
    <asp:Button ID="confirmSupportButton" runat="server" Text="Confirm support" OnClick="confirmSupportButton_Click" />
</div>
