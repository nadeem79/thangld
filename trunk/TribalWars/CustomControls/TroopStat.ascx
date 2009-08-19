<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TroopStat.ascx.cs" Inherits="CustomControls_TroopStat" %>
<h3>
    Defenses</h3>
<table class="vis" width="100%">
    <tbody>
        <tr>
            <th>
                Origin
            </th>
            <th width="40">
                <img src="images/unit_spear.png" title="Spear fighter" alt="">
            </th>
            <th width="40">
                <img src="images/unit_sword.png" title="Swordsman" alt="">
            </th>
            <th width="40">
                <img src="images/unit_axe.png" title="Axeman" alt="">
            </th>
            <th width="40">
                <img src="images/unit_spy.png" title="Scout" alt="">
            </th>
            <th width="40">
                <img src="images/unit_light.png" title="Light cavalry" alt="">
            </th>
            <th width="40">
                <img src="images/unit_heavy.png" title="Heavy cavalry" alt="">
            </th>
            <th width="40">
                <img src="images/unit_ram.png" title="Ram" alt="">
            </th>
            <th width="40">
                <img src="images/unit_catapult.png" title="Catapult" alt="">
            </th>
            <th width="40">
                <img src="images/unit_snob.png" title="Nobleman" alt="">
            </th>
        </tr>
        <tr>
            <td>
                From this village
            </td>
            <td>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.Spear) %>
            </td>
            <td>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.Sword) %>
            </td>
            <td>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.Axe) %>
            </td>
            <td>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.Scout) %>
            </td>
            <td>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.LightCavalry) %>
            </td>
            <td>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.HeavyCavalry) %>
            </td>
            <td>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.Ram) %>
            </td>
            <td>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.Catapult) %>
            </td>
            <td>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.Noble) %>
            </td>
        </tr>
        <asp:Repeater runat="server" ID="stationAtMeRepeater">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:HiddenField runat="server" ID="stationIdHiddenField" Value='<%# Eval("ID") %>' />
                        <asp:CheckBox runat="server" ID="withdrawStationCheckBox" />
                        <a href='<%# string.Format("\village_info.aspx?id={0}&village={1}\"", this.Village.ID, ((beans.Village)Eval("FromVillage")).ID)  %>'>
                            <%# ((beans.Village)Eval("FromVillage")).Name %>
                            (<%# ((beans.Village)Eval("FromVillage")).X.ToString("000") %>|<%# ((beans.Village)Eval("FromVillage")).Y.ToString("000") %>)</a>
                    </td>
                    <td>
                        <%# Functions.GetTroopQuantity((int)Eval("Spear")) %>
                    </td>
                    <td>
                        <%# Functions.GetTroopQuantity((int)Eval("Sword")) %>
                    </td>
                    <td>
                        <%# Functions.GetTroopQuantity((int)Eval("Axe")) %>
                    </td>
                    <td>
                        <%# Functions.GetTroopQuantity((int)Eval("Scout")) %>
                    </td>
                    <td>
                        <%# Functions.GetTroopQuantity((int)Eval("LightCavalry")) %>
                    </td>
                    <td>
                        <%# Functions.GetTroopQuantity((int)Eval("HeavyCavalry"))%>
                    </td>
                    <td>
                        <%# Functions.GetTroopQuantity((int)Eval("Ram")) %>
                    </td>
                    <td>
                        <%# Functions.GetTroopQuantity((int)Eval("Catapult")) %>
                    </td>
                    <td>
                        <%# Functions.GetTroopQuantity((int)Eval("Noble")) %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <th>
                Total
            </th>
            <th>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.SpearInVillage) %>
            </th>
            <th>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.SwordInVillage) %>
            </th>
            <th>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.AxeInVillage) %>
            </th>
            <th>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.ScoutInVillage) %>
            </th>
            <th>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.LightCavalryInVillage) %>
            </th>
            <th>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.HeavyCavalryInVillage) %>
            </th>
            <th>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.RamInVillage) %>
            </th>
            <th>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.CatapultInVillage) %>
            </th>
            <th>
                <% = Functions.GetTroopQuantity(this.Village.VillageTroopData.NobleInVillage) %>
            </th>
        </tr>
    </tbody>
</table>
<asp:Button ID="withdrawStationAtMeButton" runat="server" Text="Withdraw" 
    onclick="withdrawStationAtMeButton_Click" />
<br style="clear: both;">
<asp:Repeater runat="server" ID="stationFromMeRepeater" 
    onitemcommand="stationFromMeRepeater_ItemCommand">
    <HeaderTemplate>
        <h3>
            Troops in other villages</h3>
        <table class="vis">
            <tbody>
                <tr>
                    <th width="320">
                        Village
                    </th>
                    <th width="40">
                        <img src="images/unit_spear.png" title="Spear fighter" alt="">
                    </th>
                    <th width="40">
                        <img src="images/unit_sword.png" title="Swordsman" alt="">
                    </th>
                    <th width="40">
                        <img src="images/unit_axe.png" title="Axeman" alt="">
                    </th>
                    <th width="40">
                        <img src="images/unit_spy.png" title="Scout" alt="">
                    </th>
                    <th width="40">
                        <img src="images/unit_light.png" title="Light cavalry" alt="">
                    </th>
                    <th width="40">
                        <img src="images/unit_heavy.png" title="Heavy cavalry" alt="">
                    </th>
                    <th width="40">
                        <img src="images/unit_ram.png" title="Ram" alt="">
                    </th>
                    <th width="40">
                        <img src="images/unit_catapult.png" title="Catapult" alt="">
                    </th>
                    <th width="40">
                        <img src="images/unit_snob.png" title="Nobleman" alt="">
                    </th>
                    <th>
                        withdraw
                    </th>
                </tr>
    </HeaderTemplate>
    <FooterTemplate>
        </tbody> </table>
    </FooterTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <a href='<%# string.Format("\village_info.aspx?id={0}&village={1}\"", this.Village.ID, ((beans.Village)Eval("AtVillage")).ID)  %>'>
                    <%# ((beans.Village)Eval("AtVillage")).Name%>
                    (<%# ((beans.Village)Eval("AtVillage")).X.ToString("000")%>|<%# ((beans.Village)Eval("AtVillage")).Y.ToString("000")%>)</a>
            </td>
            <td>
                <%# Functions.GetTroopQuantity((int)Eval("Spear")) %>
            </td>
            <td>
                <%# Functions.GetTroopQuantity((int)Eval("Sword")) %>
            </td>
            <td>
                <%# Functions.GetTroopQuantity((int)Eval("Axe")) %>
            </td>
            <td>
                <%# Functions.GetTroopQuantity((int)Eval("Scout")) %>
            </td>
            <td>
                <%# Functions.GetTroopQuantity((int)Eval("LightCavalry")) %>
            </td>
            <td>
                <%# Functions.GetTroopQuantity((int)Eval("HeavyCavalry"))%>
            </td>
            <td>
                <%# Functions.GetTroopQuantity((int)Eval("Ram")) %>
            </td>
            <td>
                <%# Functions.GetTroopQuantity((int)Eval("Catapult")) %>
            </td>
            <td>
                <%# Functions.GetTroopQuantity((int)Eval("Noble")) %>
            </td>
            <td>
                <asp:HiddenField runat="server" ID="stationHiddenField" Value=<%# Eval("ID") %> />
                <a href="javascript:void(0);" onclick="__doPostBack('<% = this.withdrawSomeButton.UniqueID %>', '<%# Eval("ID") %>')">some</a>
                -
                <asp:LinkButton runat="server" ID="withdrawAllButton">all</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
</asp:Repeater>
<asp:UpdatePanel RenderMode="Inline" ID="withdrawSomePanel" runat="server">
    <ContentTemplate>
    <div id="withdrawPanel" style="display:none;">
        <h3>
            Rút quân từ <asp:Literal runat="server" ID="villageNameLiteral"></asp:Literal></h3>
            <form method="post" action=<% = Request.Url.ToString() %>>
        <table>
            <tr>
                <td width="150" valign="top">
                    <table class="vis" width="100%">
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=spear', 520, 520)">
                                    <img src="images/unit_spear.png" title="Spear fighter" alt="" /></a>
                                <input name="unit_spear" type="text" size="5" tabindex="1" value="" class="unitsInput"
                                    maxunits="0" />
                                <a href="javascript:insertUnit('unit_spear', <asp:Literal runat="server" ID="spearLiteral1"></asp:Literal>)">(<asp:Literal runat="server" ID="spearLiteral2"></asp:Literal>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=sword', 520, 520)">
                                    <img src="images/unit_sword.png" title="Swordsman" alt="" /></a>
                                <input name="unit_sword" type="text" size="5" tabindex="2" value="" class="unitsInput"
                                    maxunits="0" />
                                <a href="javascript:insertUnit('unit_sword', <asp:Literal runat="server" ID="swordLiteral1"></asp:Literal>)">(<asp:Literal runat="server" ID="swordLiteral2"></asp:Literal>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=axe', 520, 520)">
                                    <img src="images/unit_axe.png" title="Axeman" alt="" /></a>
                                <input name="unit_axe" type="text" size="5" tabindex="3" value="100" class="unitsInput"
                                    maxunits="100" />
                                <a href="javascript:insertUnit('unit_axe', <asp:Literal runat="server" ID="axeLiteral1"></asp:Literal>)">(<asp:Literal runat="server" ID="axeLiteral2"></asp:Literal>)</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="150" valign="top">
                    <table class="vis" width="100%">
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=spy', 520, 520)">
                                    <img src="images/unit_spy.png" title="Scout" alt="" /></a>
                                <input name="unit_scout" type="text" size="5" tabindex="4" value="" class="unitsInput" maxunits="0" />
                                <a href="javascript:insertUnit('unit_scout', <asp:Literal runat="server" ID="scoutLiteral1"></asp:Literal>)">(<asp:Literal runat="server" ID="scoutLiteral2"></asp:Literal>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=light', 520, 520)">
                                    <img src="images/unit_light.png" title="Light cavalry" alt="" /></a>
                                <input name="unit_lightCavalry" type="text" size="5" tabindex="5" value="" class="unitsInput"
                                    maxunits="0" />
                                <a href="javascript:insertUnit('unit_lightCavalry', <asp:Literal runat="server" ID="lightCavalryLiteral1"></asp:Literal>)">(<asp:Literal runat="server" ID="lightCavalryLiteral2"></asp:Literal>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=heavy', 520, 520)">
                                    <img src="images/unit_heavy.png" title="Heavy cavalry" alt="" /></a>
                                <input name="unit_heavyCavalry" type="text" size="5" tabindex="6" value="" class="unitsInput"
                                    maxunits="0" />
                                <a href="javascript:insertUnit('unit_heavyCavalry', <asp:Literal runat="server" ID="heavyCavalryLiteral1"></asp:Literal>)">(<asp:Literal runat="server" ID="heavyCavalryLiteral2"></asp:Literal>)</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="150" valign="top">
                    <table class="vis" width="100%">
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=ram', 520, 520)">
                                    <img src="images/unit_ram.png" title="Ram" alt="" /></a>
                                <input name="unit_ram" type="text" size="5" tabindex="7" value="" class="unitsInput" maxunits="0" />
                                <a href="javascript:insertUnit('unit_ram', <asp:Literal runat="server" ID="ramLiteral1"></asp:Literal>)">(<asp:Literal runat="server" ID="ramLiteral2"></asp:Literal>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=catapult', 520, 520)">
                                    <img src="images/unit_catapult.png" title="Catapult" alt="" /></a>
                                <input name="unit_catapult" type="text" size="5" tabindex="8" value="" class="unitsInput"
                                    maxunits="0" />
                                <a href="javascript:insertUnit('unit_catapult', <asp:Literal runat="server" ID="catapultLiteral1"></asp:Literal>)">(<asp:Literal runat="server" ID="catapultLiteral2"></asp:Literal>)</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="150" valign="top">
                    <table class="vis" width="100%">
                        <tr>
                            <td>
                                <a href="javascript:popup_scroll('popup_unit.php?unit=snob', 520, 520)">
                                    <img src="images/unit_snob.png" title="Nobleman" alt="" /></a>
                                <input name="unit_noble" type="text" size="5" tabindex="9" value="" class="unitsInput"
                                    maxunits="0" />
                                <a href="javascript:insertUnit('unit_noble', <asp:Literal runat="server" ID="nobleLiteral1"></asp:Literal>)">(<asp:Literal runat="server" ID="nobleLiteral2"></asp:Literal>)</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <input type="submit" value="&raquo; OK «" style="font-size: 10pt;" />
        </form></div>
        <div style="display:none;">
    <asp:Button runat="server" ID="withdrawSomeButton" Text="Withdraw Some" 
                onclick="withdrawSomeButton_Click" />
</div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="withdrawSomeButton" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
