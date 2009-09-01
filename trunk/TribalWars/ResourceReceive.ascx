<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ResourceReceive.ascx.cs"
    Inherits="ResourceReceive" %>
<table width="100%">
    <tbody>
        <tr>
            <th width="60">
                from:
            </th>
            <th>
                <a href="user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.ResourceReceiveReport.FromPlayer.ID %>"><% = this.ResourceReceiveReport.FromPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Village:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.ResourceReceiveReport.FromVillage.ID %>'><% = this.ResourceReceiveReport.FromVillage.Name %> (<% = this.ResourceReceiveReport.FromVillage.X.ToString("000") %>|<% = this.ResourceReceiveReport.FromVillage.Y.ToString("000") %>)</a>
            </td>
        </tr>
        <tr>
            <th>
                To:
            </th>
            <th>
                <a href="user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.ResourceReceiveReport.ToPlayer.ID %>"><% = this.ResourceReceiveReport.ToPlayer.Username %></a>
            </th>
        </tr>
        <tr>
            <td>
                Village:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.ResourceReceiveReport.ToVillage.ID %>'><% = this.ResourceReceiveReport.ToVillage.Name %> (<% = this.ResourceReceiveReport.ToVillage.X.ToString("000") %>|<% = this.ResourceReceiveReport.ToVillage.Y.ToString("000") %>)</a>
            </td>
        </tr>
    </tbody>
</table>
<br />
Resources:
<% = Functions.GetResourceString(beans.ResourcesType.Clay, this.ResourceReceiveReport.Clay) %>
<% = Functions.GetResourceString(beans.ResourcesType.Wood, this.ResourceReceiveReport.Wood)%>
<% = Functions.GetResourceString(beans.ResourcesType.Iron, this.ResourceReceiveReport.Iron)%>