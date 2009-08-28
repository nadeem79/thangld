<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefenseOtherReport.ascx.cs"
    Inherits="CustomControls_DefenseOtherReport" %>
<table style="border: 1px solid rgb(222, 211, 185);" width="100%">
    <tbody>
        <tr>
            <th>Từ thành phố</th>
            <th><a href="village_info.aspx?id=<% = this.Village.ID %>&village=<% = DefenseOtherReport.FromVillage.ID %>"><% = DefenseOtherReport.FromVillage.Name%> (<% = DefenseOtherReport.FromVillage.X.ToString("000")%>|<% = DefenseOtherReport.FromVillage.Y.ToString("000")%>)</a></th>
        </tr>
        <tr>
            <td>Ở thành phố:</td>
            <td><a href="village_info.aspx?id=<% = this.Village.ID %>&village=<% = DefenseOtherReport.ToVillage.ID %>"><% = DefenseOtherReport.ToVillage.Name %> (<% = DefenseOtherReport.ToVillage.X.ToString("000") %>|<% = DefenseOtherReport.ToVillage.Y.ToString("000")%>)</a></td>
        </tr>
        <tr>
            <td>Chủ thành</td>
            <td><a href="user_info.aspx?id=<% = this.Village.ID %>&player=<% = DefenseOtherReport.ToVillage.Player.ID %>"><% = DefenseOtherReport.ToVillage.Player.Username %></a></td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="vis">
                    <tbody>
                        <tr class="center">
                            <td>
                            </td>
                            <td width="35">
                                <img src="images/unit_spear.png" title="Spear fighter" alt="" />
                            </td>
                            <td width="35">
                                <img src="images/unit_sword.png" title="Swordsman" alt="" />
                            </td>
                            <td width="35">
                                <img src="images/unit_axe.png" title="Axeman" alt="" />
                            </td>
                            <td width="35">
                                <img src="images/unit_spy.png" title="Scout" alt="" />
                            </td>
                            <td width="35">
                                <img src="images/unit_light.png" title="Light cavalry" alt="" />
                            </td>
                            <td width="35">
                                <img src="images/unit_heavy.png" title="Heavy cavalry" alt="" />
                            </td>
                            <td width="35">
                                <img src="images/unit_ram.png" title="Ram" alt="" />
                            </td>
                            <td width="35">
                                <img src="images/unit_catapult.png" title="Catapult" alt="" />
                            </td>
                            <td width="35">
                                <img src="images/unit_snob.png" title="Nobleman" alt="" />
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Số lượng:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.SpearDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.SwordDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.AxeDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.ScoutDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.LightCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.HeavyCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.RamDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.CatapultDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.NobleDefense)%>
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Tổn thất:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.SpearDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.SwordDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.AxeDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.ScoutDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.LightCavalryDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.HeavyCavalryDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.RamDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.CatapultDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReport.NobleDead)%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
