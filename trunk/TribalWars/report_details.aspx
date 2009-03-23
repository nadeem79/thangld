<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="report_details.aspx.cs"
    Inherits="report_details" %>

<%@ Reference Control="AttackReportPanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                        <a href="report_details.aspx?id=<%Response.Write(this.village.ID); %>">Tất cả</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <a href="report_details.aspx?id=<%Response.Write(this.village.ID); %>&type=1">Tấn công</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <a href="report_details.aspx?id=<%Response.Write(this.village.ID); %>&type=2">Phòng
                                            thủ</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <a href="report_details.aspx?id=<%Response.Write(this.village.ID); %>&type=3">Hỗ trợ</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <a href="report_details.aspx?id=<%Response.Write(this.village.ID); %>&type=4">Buôn bán</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top" width="100%">
                        <asp:PlaceHolder ID="pReport" runat="server"></asp:PlaceHolder>
                        <asp:Panel ID="pNoReport" runat="server">
                            <h2>
                                Lỗi: không tìm thấy báo cáo</h2>
                        </asp:Panel>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>
