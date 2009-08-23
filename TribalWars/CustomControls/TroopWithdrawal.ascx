<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TroopWithdrawal.ascx.cs"
    Inherits="CustomControls_TroopWithdrawal" %>
<table width="100%">
    <tbody>
        <tr>
            <th width="60">
                from:
            </th>
            <th>
                <a href="user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.SupportWithdawalReport.OriginalPlayer.ID %>">
                    <% = this.SupportWithdawalReport.OriginalPlayer.Username%></a>
            </th>
        </tr>
        <tr>
            <td>
                Village:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.SupportWithdawalReport.FromVillage.ID %>'>
                    <% = this.SupportWithdawalReport.FromVillage.Name %>
                    (<% = this.SupportWithdawalReport.OriginalVillage.X.ToString("000") %>|<% = this.SupportWithdawalReport.OriginalVillage.Y.ToString("000")%>)</a>
            </td>
        </tr>
        <tr>
            <th>
                To:
            </th>
            <th>
                <a href="user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.SupportWithdawalReport.OriginalPlayer.ID %>">
                    <% = this.SupportWithdawalReport.OriginalPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Village:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.SupportWithdawalReport.OriginalVillage.ID %>'>
                    <% = this.SupportWithdawalReport.OriginalVillage.Name%>
                    (<% = this.SupportWithdawalReport.OriginalVillage.X.ToString("000")%>|<% = this.SupportWithdawalReport.OriginalVillage.Y.ToString("000") %>)</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="vis">
                    <tbody>
                        <tr class="center">
                            <td>
                            </td>
                            <td width="35">
                                <img src="images/unit_spear.png" title="Spear fighter" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_sword.png" title="Swordsman" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_axe.png" title="Axeman" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_spy.png" title="Scout" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_light.png" title="Light cavalry" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_heavy.png" title="Heavy cavalry" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_ram.png" title="Ram" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_catapult.png" title="Catapult" alt="">
                            </td>
                            <td width="35">
                                <img src="images/unit_snob.png" title="Nobleman" alt="">
                            </td>
                        </tr>
                        <tr class="center">
                            <td>
                                Số lượng:
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportWithdawalReport.Spear)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportWithdawalReport.Sword)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportWithdawalReport.Axe)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportWithdawalReport.Scout)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportWithdawalReport.LightCavalry)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportWithdawalReport.HeavyCavalry)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportWithdawalReport.Ram)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportWithdawalReport.Catapult)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportWithdawalReport.Noble)%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
