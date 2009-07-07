<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="report_details.aspx.cs"
    Inherits="report_details" %>

<%@ Reference Control="AttackReportPanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:Panel ID="pHasReport" runat="server">
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
                    <td valign="top" width="100%">
                        <table class="vis">
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
                        <% = report.Time.ToString("hh:mm:ss:'<span class=\"small hidden\">'ff'</span> ngày' dd/MM/yyyy") %>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="border: 1px solid black; padding: 4px;" valign="top">
                        <% = report.Description.Description %>
                    </td>
                </tr>
            </tbody>
        </table>
        </td> </tr> </tbody> </table>
    </asp:Panel>
    <asp:Panel ID="pNoReport" runat="server">
        <h2>
            Lỗi: không tìm thấy báo cáo</h2>
    </asp:Panel>
</asp:Content>
