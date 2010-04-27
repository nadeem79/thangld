<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OfferAcceptedReport.ascx.cs"
    Inherits="OfferAcceptedReport" %>
<table style="border: 1px solid rgb(222, 211, 185);" width="100%">
    <tbody>
        <tr>
            <th width="100">
                Người mua:
            </th>
            <th>
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = OfferAcceptedReportEntity.ToPlayer.ID %>'>
                    <% = OfferAcceptedReportEntity.ToPlayer.Username%></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.OfferAcceptedReportEntity.ToVillage.ID %>'>
                    <% = this.OfferAcceptedReportEntity.ToVillage.Name%>
                    (<% = this.OfferAcceptedReportEntity.ToVillage.X.ToString("000")%>|<% = this.OfferAcceptedReportEntity.ToVillage.Y.ToString("000")%>)</a>
            </td>
        </tr>
        <tr>
            <th width="100">
                Người bán:
            </th>
            <th>
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = OfferAcceptedReportEntity.FromPlayer.ID %>'>
                    <% = OfferAcceptedReportEntity.FromPlayer.Username%></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.OfferAcceptedReportEntity.FromVillage.ID %>'>
                    <% = this.OfferAcceptedReportEntity.FromVillage.Name%>
                    (<% = this.OfferAcceptedReportEntity.FromVillage.X.ToString("000")%>|<% = this.OfferAcceptedReportEntity.FromVillage.Y.ToString("000")%>)</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table style="border: 1px solid #DED3B9">
                    <tr>
                        <td>
                            <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = OfferAcceptedReportEntity.FromPlayer.ID %>'>
                                <% = OfferAcceptedReportEntity.FromPlayer.Username%></a> bán:
                        </td>
                        <td>
                            <% = Functions.GetResourceString(OfferAcceptedReportEntity.SoldType, OfferAcceptedReportEntity.SoldQuantity) %>
                        </td>
                        <tr>
                            <td>
                                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = OfferAcceptedReportEntity.ToPlayer.ID %>'>
                                    <% = OfferAcceptedReportEntity.ToPlayer.Username%></a> mua:
                            </td>
                            <td>
                                <% = Functions.GetResourceString(OfferAcceptedReportEntity.BoughtType, OfferAcceptedReportEntity.BoughtQuantity)%>
                            </td>
                </table>
                <br />
                The resources were shipped automatically.
            </td>
        </tr>
    </tbody>
</table>
