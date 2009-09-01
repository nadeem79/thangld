<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SupportOtherReport.ascx.cs"
    Inherits="SupportOtherReport" %>
<table style="border: 1px solid rgb(222, 211, 185);" width="100%">
    <tbody>
        <tr>
            <th width="100">
                Từ:
            </th>
            <th>
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = SupportReport.FromPlayer.ID %>'>
                    <% = SupportReport.FromPlayer.Username%></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.SupportReport.FromVillage.ID %>'>
                    <% = this.SupportReport.FromVillage.Name%>
                    (<% = this.SupportReport.FromVillage.X.ToString("000")%>|<% = this.SupportReport.FromVillage.Y.ToString("000")%>)</a>
            </td>
        </tr>
        <tr>
            <th width="100">
                Đến:
            </th>
            <th>
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = SupportReport.ToPlayer.ID %>'>
                    <% = SupportReport.ToPlayer.Username%></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.SupportReport.ToVillage.ID %>'>
                    <% = this.SupportReport.ToVillage.Name %>
                    (<% = this.SupportReport.ToVillage.X.ToString("000")%>|<% = this.SupportReport.ToVillage.Y.ToString("000")%>)</a>
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
                                <% = Functions.GetTroopQuantity(this.SupportReport.Spear) %>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportReport.Sword)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportReport.Axe)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportReport.Scout)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportReport.LightCavalry)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportReport.HeavyCavalry)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportReport.Ram)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportReport.Catapult)%>
                            </td>
                            <td>
                                <% = Functions.GetTroopQuantity(this.SupportReport.Noble)%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
