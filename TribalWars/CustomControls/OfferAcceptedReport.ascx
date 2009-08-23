<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OfferAcceptedReport.ascx.cs"
    Inherits="CustomControls_OfferAcceptedReport" %>
<table style="border: 1px solid rgb(222, 211, 185);" width="100%">
    <tbody>
        <tr>
            <th width="100">
                Người mua:
            </th>
            <th>
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = OfferAcceptedReport.ToPlayer.ID %>'>
                    <% = OfferAcceptedReport.ToPlayer.Username%></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.OfferAcceptedReport.ToVillage.ID %>'>
                    <% = this.OfferAcceptedReport.ToVillage.Name%>
                    (<% = this.OfferAcceptedReport.ToVillage.X.ToString("000")%>|<% = this.OfferAcceptedReport.ToVillage.Y.ToString("000")%>)</a>
            </td>
        </tr>
        <tr>
            <th width="100">
                Người bán:
            </th>
            <th>
                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = OfferAcceptedReport.FromPlayer.ID %>'>
                    <% = OfferAcceptedReport.FromPlayer.Username%></a>
            </th>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href='village_info.aspx?id=<% = this.Village.ID %>&village=<% = this.OfferAcceptedReport.FromVillage.ID %>'>
                    <% = this.OfferAcceptedReport.FromVillage.Name%>
                    (<% = this.OfferAcceptedReport.FromVillage.X.ToString("000")%>|<% = this.OfferAcceptedReport.FromVillage.Y.ToString("000")%>)</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table style="border: 1px solid #DED3B9">
                    <tr>
                        <td>
                            <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = OfferAcceptedReport.FromPlayer.ID %>'>
                                <% = OfferAcceptedReport.FromPlayer.Username%></a> bán:
                        </td>
                        <td>
                            <% = Functions.GetResourceString(OfferAcceptedReport.SoldType, OfferAcceptedReport.SoldQuantity) %>
                        </td>
                        <tr>
                            <td>
                                <a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = OfferAcceptedReport.ToPlayer.ID %>'>
                                    <% = OfferAcceptedReport.ToPlayer.Username%></a> mua:
                            </td>
                            <td>
                                <% = Functions.GetResourceString(OfferAcceptedReport.BoughtType, OfferAcceptedReport.BoughtQuantity)%>
                            </td>
                </table>
                <br />
                The resources were shipped automatically.
            </td>
        </tr>
    </tbody>
</table>
