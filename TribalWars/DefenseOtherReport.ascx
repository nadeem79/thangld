<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefenseOtherReport.ascx.cs"
    Inherits="DefenseOtherReport" %>
<table style="border: 1px solid rgb(222, 211, 185);" width="100%">
    <tbody>
        <tr>
            <th>Từ thành phố</th>
            <th><a href="village_info.aspx?id=<% = this.Village.ID %>&village=<% = DefenseOtherReportEntity.FromVillage.ID %>"><% = DefenseOtherReportEntity.FromVillage.Name%> (<% = DefenseOtherReportEntity.FromVillage.X.ToString("000")%>|<% = DefenseOtherReportEntity.FromVillage.Y.ToString("000")%>)</a></th>
        </tr>
        <tr>
            <td>Ở thành phố:</td>
            <td><a href="village_info.aspx?id=<% = this.Village.ID %>&village=<% = DefenseOtherReportEntity.ToVillage.ID %>"><% = DefenseOtherReportEntity.ToVillage.Name%> (<% = DefenseOtherReportEntity.ToVillage.X.ToString("000") %>|<% = DefenseOtherReportEntity.ToVillage.Y.ToString("000")%>)</a></td>
        </tr>
        <tr>
            <td>Chủ thành</td>
            <td><a href="user_info.aspx?id=<% = this.Village.ID %>&player=<% = DefenseOtherReportEntity.ToVillage.Player.ID %>"><% = DefenseOtherReportEntity.ToVillage.Player.Username%></a></td>
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
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.SpearDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.SwordDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.AxeDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.ScoutDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.LightCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.HeavyCavalryDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.RamDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.CatapultDefense)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.NobleDefense)%>
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Tổn thất:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.SpearDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.SwordDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.AxeDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.ScoutDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.LightCavalryDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.HeavyCavalryDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.RamDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.CatapultDead)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.DefenseOtherReportEntity.NobleDead)%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
