<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TroopStat.ascx.cs" Inherits="TroopStat" %>
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
        <asp:Repeater runat="server" ID="stationAtMeRepeater" 
            onitemcommand="stationAtMeRepeater_ItemCommand">
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
    OnClick="withdrawStationAtMeButton_Click" Visible="False" />
<br style="clear: both;">
<asp:Repeater runat="server" ID="stationFromMeRepeater" OnItemCommand="stationFromMeRepeater_ItemCommand">
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
                <a href='<%# string.Format("village_info.aspx?id={0}&village={1}", this.Village.ID, ((beans.Village)Eval("AtVillage")).ID)  %>'>
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
                <asp:HiddenField runat="server" ID="stationHiddenField" Value='<%# Eval("ID") %>' />
                <a href='<%# string.Format("withdraw_troop.aspx?id={0}&station={1}", this.Village.ID, Eval("ID")) %>'>
                    some</a> -
                <asp:LinkButton runat="server" ID="withdrawAllButton">all</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
</asp:Repeater>
