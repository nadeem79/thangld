<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SupportSendBackReport.ascx.cs" Inherits="CustomControls_SupportSendBackReport" %>
<table width="100%">
    <tbody>
        <tr>
            <th width="60">
                from:
            </th>
            <th>
                <a href="user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.SupportSendbackReport.OriginalPlayer.ID %>">
                    <% = this.SupportSendbackReport.OriginalPlayer.Username%></a>
            </th>
        </tr>
        <tr>
            <td>
                Village:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.SupportSendbackReport.FromVillage.ID %>'>
                    <% = this.SupportSendbackReport.FromVillage.Name %>
                    (<% = this.SupportSendbackReport.OriginalVillage.X.ToString("000") %>|<% = this.SupportSendbackReport.OriginalVillage.Y.ToString("000")%>)</a>
            </td>
        </tr>
        <tr>
            <th>
                To:
            </th>
            <th>
                <a href="user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.SupportSendbackReport.OriginalPlayer.ID %>">
                    <% = this.SupportSendbackReport.OriginalPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Village:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.SupportSendbackReport.OriginalVillage.ID %>'>
                    <% = this.SupportSendbackReport.OriginalVillage.Name%>
                    (<% = this.SupportSendbackReport.OriginalVillage.X.ToString("000")%>|<% = this.SupportSendbackReport.OriginalVillage.Y.ToString("000") %>)</a>
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
                                <% = Functions.GetTroopQuantity(this.SupportSendbackReport.Spear)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportSendbackReport.Sword)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportSendbackReport.Axe)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportSendbackReport.Scout)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportSendbackReport.LightCavalry)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportSendbackReport.HeavyCavalry)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportSendbackReport.Ram)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportSendbackReport.Catapult)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportSendbackReport.Noble)%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
