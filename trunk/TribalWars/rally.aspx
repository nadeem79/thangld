<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="rally.aspx.cs"
    Inherits="rally" Title="Medieval War - Trại Lính" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type="text/css">
#<% = this.pAttackConfirm.ClientID %>
{
    float:left;
    margin-left:5px;
}
#<% = this.pSupportConfirm.ClientID %>
{
    float:left;
    margin-left:5px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Modal="true" InitialBehavior="Pin"
        Width="500" style="z-index:1;">
    </telerik:RadWindowManager>
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
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.spear.ClientID); %>', <% Response.Write(this.village.Troop.Spear.ToString()); %>)"><% Response.Write(this.village.Troop.Spear.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_sword.png" title="Swordsman" alt="" />
                                                    <asp:TextBox ID="sword" runat="server" Width="50px">
                                                    </asp:TextBox>
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.sword.ClientID); %>', <% Response.Write(this.village.Troop.Sword.ToString()); %>)"><% Response.Write(this.village.Troop.Sword.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_axe.png" title="Axeman" alt="" />
                                                    <asp:TextBox ID="axe" runat="server" Width="50px">
                                                    </asp:TextBox>
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.axe.ClientID); %>', <% Response.Write(this.village.Troop.Axe.ToString()); %>)"><% Response.Write(this.village.Troop.Axe.ToString()); %></a>)</span>
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
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.scout.ClientID); %>', <% Response.Write(this.village.Troop.Scout.ToString()); %>)"><% Response.Write(this.village.Troop.Scout.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_light.png" title="Light cavalry" alt="" />
                                                    <asp:TextBox ID="light" runat="server" Width="50px">
                                                    </asp:TextBox>
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.light.ClientID); %>', <% Response.Write(this.village.Troop.Light.ToString()); %>)"><% Response.Write(this.village.Troop.Light.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_heavy.png" title="Heavy cavalry" alt="" />
                                                    <asp:TextBox ID="heavy" runat="server" Width="50px">
                                                    </asp:TextBox>
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.heavy.ClientID); %>', <% Response.Write(this.village.Troop.Heavy.ToString()); %>)"><% Response.Write(this.village.Troop.Heavy.ToString()); %></a>)</span>
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
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.ram.ClientID); %>', <% Response.Write(this.village.Troop.Ram.ToString()); %>)"><% Response.Write(this.village.Troop.Ram.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_catapult.png" title="Catapult" alt="" />
                                                    <asp:TextBox ID="catapult" runat="server" Width="50px">
                                                    </asp:TextBox>
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.catapult.ClientID); %>', <% Response.Write(this.village.Troop.Catapult.ToString()); %>)"><% Response.Write(this.village.Troop.Catapult.ToString()); %></a>)</span>
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
                                                    <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.noble.ClientID); %>', <% Response.Write(this.village.Troop.Noble.ToString()); %>)"><% Response.Write(this.village.Troop.Noble.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table>
                        <tbody>
                            <tr>
                                <td rowspan="2">
                                    X:<asp:TextBox ID="x" runat="server" MaxLength="3" Width="50"></asp:TextBox>
                                    Y:
                                    <asp:TextBox ID="y" runat="server" MaxLength="3" Width="50"></asp:TextBox>
                                </td>
                                <td valign="top">
                                </td>
                                <td valign="top">
                                </td>
                                <td rowspan="2">
                                </td>
                                <td rowspan="2">
                                    <asp:UpdatePanel ID="pAttackConfirm" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="bttnAttack" runat="server" Font-Size="10pt" Text="Attack" OnClick="bttnAttack_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="bttnAttack" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel> 
                                    <asp:UpdatePanel ID="pSupportConfirm" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="bttnSupport" runat="server" Font-Size="10pt" Text="Support" OnClick="bttnSupport_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="bttnSupport" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <h3>
                        Troop movements</h3>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <th width="250">
                                    Lệnh đến:
                                </th>
                                <th width="160">
                                    Thời gian
                                </th>
                                <th width="100">
                                    Cập nhật trong
                                </th>
                            </tr>
                            <asp:Label ID="lblInwardsCommand" runat="server"></asp:Label>
                        </tbody>
                    </table>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <th width="250">
                                    Lệnh đi:
                                </th>
                                <th width="160">
                                    Thời gian
                                </th>
                                <th width="100">
                                    Cập nhật trong
                                </th>
                            </tr>
                            <asp:Label ID="lblOutwardsCommand" runat="server"></asp:Label>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
