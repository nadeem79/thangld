<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="report_details.aspx.cs"
    Inherits="report_details" %>

<%@ Reference Control="CustomControls/AttackReport.ascx" %>
<%@ Reference Control="CustomControls/InviteReport.ascx" %>
<%@ Reference Control="CustomControls/ResourceReceive.ascx" %>
<%@ Reference Control="CustomControls/SendResource.ascx" %>
<%@ Reference Control="CustomControls/SupportOtherReport.ascx" %>
<%@ Reference Control="CustomControls/TroopWithdrawal.ascx" %>
<%@ Reference Control="CustomControls/DefenseOtherReport.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">
    
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:Panel ID="pHasReport" runat="server" Visible="false">
        <h2>
            Báo cáo</h2>
        <table>
            <tbody>
                <tr>
                    <td valign="top">
                        <table class="vis" width="100" runat="server" id="navigator">
                            <tbody>
                                <tr>
                                    <td width="100">
                                        <a href="list_report.aspx?id=<% = this.village.ID %>">Tất cả</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <a href="list_report.aspx?id=<% = this.village.ID %>&type=1">Tất cả</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <a href="list_report.aspx?id=<% = this.village.ID %>&type=2">Phòng thủ</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <a href="list_report.aspx?id=<% = this.village.ID %>&type=3">Hỗ trợ</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <a href="list_report.aspx?id=<% = this.village.ID %>&type=4">Buôn bán</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top">
                        <table class="vis" style="border:1px solid black;">
                            <tbody>
                                <tr>
                                    <th width="140">
                                        Thông báo
                                    </th>
                                    <th width="400">
                                        &nbsp;<span id="label"><span id="labelText"><% = report.Title %>
                                        </span></span>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        Ngày:
                                    </td>
                                    <td>
                                        <% = report.Time.ToString("hh:mm:ss 'ngày' dd/MM/yyyy") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:PlaceHolder ID="panelReport" runat="server"></asp:PlaceHolder>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    <asp:Panel ID="pNoReport" runat="server" Visible="false">
        <h2>
            Lỗi: không tìm thấy báo cáo</h2>
    </asp:Panel>
</asp:Content>
