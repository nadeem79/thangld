<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="withdraw_troop.aspx.cs" Inherits="withdraw_troop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

    <h3>
        Rút quân từ <a href='<% = string.Format("village_info.aspx?id={0}&village={1}", this.Village.ID, this.MyStation.AtVillage.ID) %>'><% = this.MyStation.AtVillage.Name %> (<% = this.MyStation.AtVillage.X.ToString("000") %>|<% = this.MyStation.AtVillage.Y.ToString("000") %>)</a></h3>
        <table>
            <tr>
                <td width="200" valign="top">
                    <table class="vis" width="100%">
                        <tr>
                            <td>
                            
                                <a href="javascript:popup_scroll('popup_unit.php?unit=spear', 520, 520)">
                                    <img src="images/unit_spear.png" title="Spear fighter" alt="" /></a>
                                <asp:TextBox ID="spear" runat="server"></asp:TextBox>
&nbsp;<a href="javascript:insertUnit('<% = this.spear.ClientID %>', <% = this.MyStation.Spear %>)">(<% = this.MyStation.Spear %>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=sword', 520, 520)">
                                    <img src="images/unit_sword.png" title="Swordsman" alt="" /></a>
                                <asp:TextBox ID="sword" runat="server"></asp:TextBox>
&nbsp;<a href="javascript:insertUnit('<% = this.sword.ClientID %>', <% = this.MyStation.Sword %>)">(<% = this.MyStation.Sword %>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=axe', 520, 520)">
                                    <img src="images/unit_axe.png" title="Axeman" alt="" /></a>
                                <asp:TextBox ID="axe" runat="server"></asp:TextBox>
&nbsp;<a href="javascript:insertUnit('<% = this.axe.ClientID %>', <% = this.MyStation.Axe %>)">(<% = this.MyStation.Axe %>)</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="200" valign="top">
                    <table class="vis" width="100%">
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=spy', 520, 520)">
                                    <img src="images/unit_spy.png" title="Scout" alt="" /></a>
                                <asp:TextBox ID="scout" runat="server"></asp:TextBox>
&nbsp;<a href="javascript:insertUnit('<% = this.scout.ClientID %>', <% = this.MyStation.Scout %>)">(<% = this.MyStation.Scout %>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=light', 520, 520)">
                                    <img src="images/unit_light.png" title="Light cavalry" alt="" /></a>
                                <asp:TextBox ID="lightCavalry" runat="server"></asp:TextBox>
&nbsp;<a href="javascript:insertUnit('<% = this.lightCavalry.ClientID %>', <% = this.MyStation.LightCavalry %>)">(<% = this.MyStation.LightCavalry %>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=heavy', 520, 520)">
                                    <img src="images/unit_heavy.png" title="Heavy cavalry" alt="" /></a>
                                <asp:TextBox ID="heavyCavalry" runat="server"></asp:TextBox>
&nbsp;<a href="javascript:insertUnit('<% = this.heavyCavalry.ClientID %>', <% = this.MyStation.HeavyCavalry %>)">(<% = this.MyStation.HeavyCavalry %>)</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="200" valign="top">
                    <table class="vis" width="100%">
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=ram', 520, 520)">
                                    <img src="images/unit_ram.png" title="Ram" alt="" /></a>
                                <asp:TextBox ID="ram" runat="server"></asp:TextBox>
&nbsp;<a href="javascript:insertUnit('<% = this.ram.ClientID %>', <% = this.MyStation.Ram %>)">(<% = this.MyStation.Ram %>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=catapult', 520, 520)">
                                    <img src="images/unit_catapult.png" title="Catapult" alt="" /></a>
                                <asp:TextBox ID="catapult" runat="server"></asp:TextBox>
&nbsp;<a href="javascript:insertUnit('<% = this.catapult.ClientID %>', <% = this.MyStation.Catapult %>)">(<% = this.MyStation.Catapult %>)</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="200" valign="top">
                    <table class="vis" width="100%">
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=snob', 520, 520)">
                                    <img src="images/unit_snob.png" title="Nobleman" alt="" /></a>
                                <asp:TextBox ID="noble" runat="server"></asp:TextBox>
&nbsp;<a href="javascript:insertUnit('<% = this.noble.ClientID %>', <% = this.MyStation.Noble %>)">(<% = this.MyStation.Noble %>)</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        &nbsp;<asp:Button ID="withdrawButton" runat="server" Text="OK" 
        onclick="withdrawButton_Click" />

</asp:Content>

