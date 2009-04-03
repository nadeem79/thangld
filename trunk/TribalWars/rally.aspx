<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="rally.aspx.cs"
    Inherits="rally" Title="Medieval War - Trại Lính" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .radtooltip_Default
        {
            filter: alpha(opacity=80);
            -moz-opacity: .8;
            opacity: .8;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="images/place1.png" title="Rally point" alt="">
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
                    <table>
                        <tbody>
                            <tr>
                                <td valign="top" width="150">
                                    <table class="vis" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_spear.png" title="Spear fighter" alt="">
                                                    <asp:TextBox ID="spear" runat="server" Width="50px">
                                                    </asp:TextBox> <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.spear.ClientID); %>', <% Response.Write(this.village.Spear.ToString()); %>)"><% Response.Write(this.village.Spear.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_sword.png" title="Swordsman" alt="">
                                                    <asp:TextBox ID="sword" runat="server" Width="50px">
                                                    </asp:TextBox> <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.sword.ClientID); %>', <% Response.Write(this.village.Sword.ToString()); %>)"><% Response.Write(this.village.Sword.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_axe.png" title="Axeman" alt="" />
                                                    <asp:TextBox ID="axe" runat="server" Width="50px">
                                                    </asp:TextBox> <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.axe.ClientID); %>', <% Response.Write(this.village.Axe.ToString()); %>)"><% Response.Write(this.village.Axe.ToString()); %></a>)</span>
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
                                                    <img src="images/unit_spy.png" title="Scout" alt="">
                                                    <asp:TextBox ID="scout" runat="server" Width="50px">
                                                    </asp:TextBox> <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.scout.ClientID); %>', <% Response.Write(this.village.Scout.ToString()); %>)"><% Response.Write(this.village.Scout.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_light.png" title="Light cavalry" alt="">
                                                    <asp:TextBox ID="light" runat="server" Width="50px">
                                                    </asp:TextBox> <span>(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.scout.ClientID); %>', <% Response.Write(this.village.Scout.ToString()); %>)"><% Response.Write(this.village.Scout.ToString()); %></a>)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_heavy.png" title="Heavy cavalry" alt="">
                                                    <telerik:RadTextBox ID="heavy" runat="server" Width="50px">
                                                    </telerik:RadTextBox>
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
                                                    <img src="images/unit_ram.png" title="Ram" alt="">
                                                    <telerik:RadTextBox ID="ram" runat="server" Width="50px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="images/unit_catapult.png" title="Catapult" alt="">
                                                    <telerik:RadTextBox ID="catapult" runat="server" Width="50px">
                                                    </telerik:RadTextBox>
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
                                                    <img src="images/unit_snob.png" title="Nobleman" alt="">
                                                    <telerik:RadTextBox ID="noble" runat="server" Width="50px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td rowspan="2">
                                            x: &nbsp;y: &nbsp;
                                        </td>
                                        <td valign="top">
                                        </td>
                                        <td valign="top">
                                        </td>
                                        <td rowspan="2">
                                            <asp:Button ID="bttnAttack" runat="server" CssClass="attack" Font-Size="10pt" Text="Attack"
                                                OnClick="bttnAttack_Click" />
                                            &nbsp;
                                        </td>
                                        <td rowspan="2">
                                            <asp:Button ID="bttnSupport" runat="server" CssClass="support" Font-Size="10pt" Text="Support"
                                                OnClick="bttnSupport_Click" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <telerik:RadTextBox ID="RadTextBox1" runat="server">
                            </telerik:RadTextBox>
                            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"></asp:Button>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
