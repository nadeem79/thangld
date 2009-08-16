<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="rally.aspx.cs"
    Inherits="rally" Title="Medieval War - Trại Lính" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="images/place1.png" title="Rally point" alt="" />
                </td>
                <td>
                    <h2>
                        Rally point Level 1</h2>
                    On the rally point your fighters meet. Here you can command your armies.
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <table width="100%">
        <tbody>
            <tr>
                <td valign="top" width="100">
                    <table class="vis" width="100%">
                        <tbody>
                            <tr>
                                <td class="selected" width="100">
                                    <a href="/game.php?village=51549&amp;screen=place&amp;mode=command">Commands</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="/game.php?village=51549&amp;screen=place&amp;mode=units">Troops</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="/game.php?village=51549&amp;screen=place&amp;mode=sim">Simulator</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="/game.php?village=51549&amp;screen=place&amp;mode=neighbor">Neighboring villages</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top" width="*">
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
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.spear.ClientID); %>', <% Response.Write(this.village.VillageTroopData.Spear.ToString()); %>)"><% Response.Write(this.village.VillageTroopData.Spear.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_sword.png" title="Swordsman" alt="" />
                                                    <asp:TextBox ID="sword" runat="server" Width="50px">
                                                    </asp:TextBox>
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.sword.ClientID); %>', <% Response.Write(this.village.VillageTroopData.Sword.ToString()); %>)"><% Response.Write(this.village.VillageTroopData.Sword.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_axe.png" title="Axeman" alt="" />
                                                    <asp:TextBox ID="axe" runat="server" Width="50px">
                                                    </asp:TextBox>
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.axe.ClientID); %>', <% Response.Write(this.village.VillageTroopData.Axe.ToString()); %>)"><% Response.Write(this.village.VillageTroopData.Axe.ToString()); %></a>)</span>
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
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.scout.ClientID); %>', <% Response.Write(this.village.VillageTroopData.Scout.ToString()); %>)"><% Response.Write(this.village.VillageTroopData.Scout.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_light.png" title="Light cavalry" alt="" />
                                                    <asp:TextBox ID="light" runat="server" Width="50px">
                                                    </asp:TextBox>
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% = this.light.ClientID %>', <% = this.village.VillageTroopData.LightCavalry %>)"><% = this.village.VillageTroopData.LightCavalry %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_heavy.png" title="Heavy cavalry" alt="" />
                                                    <asp:TextBox ID="heavy" runat="server" Width="50px">
                                                    </asp:TextBox>
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.heavy.ClientID); %>', <% = this.village.VillageTroopData.HeavyCavalry %>)"><% = this.village.VillageTroopData.HeavyCavalry %></a>)</span>
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
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.ram.ClientID); %>', <% Response.Write(this.village.VillageTroopData.Ram.ToString()); %>)"><% Response.Write(this.village.VillageTroopData.Ram.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_catapult.png" title="Catapult" alt="" />
                                                    <asp:TextBox ID="catapult" runat="server" Width="50px">
                                                    </asp:TextBox>
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.catapult.ClientID); %>', <% Response.Write(this.village.VillageTroopData.Catapult.ToString()); %>)"><% Response.Write(this.village.VillageTroopData.Catapult.ToString()); %></a>)</span>
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
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.noble.ClientID); %>', <% Response.Write(this.village.VillageTroopData.Noble.ToString()); %>)"><% Response.Write(this.village.VillageTroopData.Noble.ToString()); %></a>)</span>
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
                        <a href='village_info.aspx?id=<% = this.village.ID %>&village=<asp:Literal runat="server" ID="toVillageIdSpan"></asp:Literal>' target="_blank" >
                            <asp:Literal runat="server" ID="toVillageName"></asp:Literal> (<asp:Literal runat="server" ID="toVillageXSpan"></asp:Literal>|<asp:Literal runat="server" ID="toVillageYSpan"></asp:Literal>)</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Chủ thành:
                    </td>
                    <td>
                        <a href="user_info.aspx?id=<% = this.village.ID %>&player=<asp:Literal runat="server" ID="toVillageOwnerIdSpan"></asp:Literal>">
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="bttnAttack" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="bttnSupport" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </div>
                    
                    <h3>
                        Troop movements</h3>
                    <asp:Repeater ID="outgoingRepeater" runat="server">
                        <HeaderTemplate>
                            <table class="vis">
                                <tbody>
                                    <tr>
                                        <th width="250">
                                            Outgoing
                                        </th>
                                        <th width="160">
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
                                    <a href="command.aspx?id=<% = this.village.ID %>&command=<%# DataBinder.Eval(Container.DataItem, "ID") %>">
                                        Tấn công
                                        <%# ((beans.Village)DataBinder.Eval(Container.DataItem, "ToVillage")).Name %>
                                        (<%# ((beans.Village)DataBinder.Eval(Container.DataItem, "ToVillage")).X.ToString("000") %>|<%# ((beans.Village)DataBinder.Eval(Container.DataItem, "ToVillage")).Y.ToString("000") %>)</a>
                                </td>
                                <td>
                                    <%# ((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime")).ToString("HH:mm:ss:'<span class=\"small inactive\">'fff'</span> ngày' dd:MM:yyyy")%>
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
                                        <th width="250">
                                            Incoming
                                        </th>
                                        <th width="160">
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
                                    <a href="command.aspx?id=<% = this.village.ID %>&command=<%# DataBinder.Eval(Container.DataItem, "ID") %>">
                                        <%# TypePrefix((beans.MoveType)DataBinder.Eval(Container.DataItem, "Type")) %>
                                        <%# ((beans.Village)DataBinder.Eval(Container.DataItem, "ToVillage")).Name %>
                                        (<%# ((beans.Village)DataBinder.Eval(Container.DataItem, "ToVillage")).X.ToString("000") %>|<%# ((beans.Village)DataBinder.Eval(Container.DataItem, "ToVillage")).Y.ToString("000") %>)</a>
                                </td>
                                <td>
                                    <%# ((DateTime)DataBinder.Eval(Container.DataItem, "LandingTime")).ToString("HH:mm:ss:'<span class=\"small inactive\">'fff'</span> ngày' dd:MM:yyyy")%>
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
                </td>
            </tr>
            
        </tbody>
    </table>
    
    <div style="display:none;">
        <asp:Button ID="confirmAttackButton" runat="server" Text="Confirm attack" 
            onclick="confirmAttackButton_Click" />
        <asp:Button ID="confirmSupportButton" runat="server" Text="Confirm support" 
            onclick="confirmSupportButton_Click" />
    </div>
    
</asp:Content>
