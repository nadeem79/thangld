<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TroopWithdrawal.ascx.cs" Inherits="CustomControls_TroopWithdrawal" %>



<table width="100%">
    <tbody>
        <tr>
            <th width="60">
                from:
            </th>
            <th>
                <a href="user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.SupportWithdawalReport.OriginalPlayer.ID %>"><% = this.SupportWithdawalReport.OriginalPlayer.Username%></a>
            </th>
        </tr>
        <tr>
            <td>
                Village:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.SupportWithdawalReport.FromVillage.ID %>'><% = this.SupportWithdawalReport.FromVillage.Name %> (<% = this.SupportWithdawalReport.OriginalVillage.X.ToString("000") %>|<% = this.SupportWithdawalReport.OriginalVillage.Y.ToString("000")%>)</a>
            </td>
        </tr>
        <tr>
            <th>
                To:
            </th>
            <th>
                <a href="user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.SupportWithdawalReport.OriginalPlayer.ID %>"><% = this.SupportWithdawalReport.OriginalPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Village:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.SupportWithdawalReport.OriginalVillage.ID %>'><% = this.SupportWithdawalReport.OriginalVillage.Name%> (<% = this.SupportWithdawalReport.OriginalVillage.X.ToString("000")%>|<% = this.SupportWithdawalReport.OriginalVillage.Y.ToString("000") %>)</a>
            </td>
        </tr>
    </tbody>
</table>