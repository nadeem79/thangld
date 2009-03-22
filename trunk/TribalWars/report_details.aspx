<%@ Reference VirtualPath= "AttackReportPanel.ascx" %>
<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="report_details.aspx.cs"
    Inherits="report_details" %>
    

<%@ Register src="AttackReportPanel.ascx" tagname="AttackReportPanel" tagprefix="uc1" %>
    

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
                                        <a href="report_details.aspx?id=<%Response.Write(this.village.ID); %>&type=2">Phòng thủ</a>
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
                                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top" width="100%">
                        <table class="vis">
                            <tbody>
                                <tr>
                                    <th width="140">
                                        Subject
                                    </th>
                                    <th width="400">
                                        &nbsp;<span id="label"><span id="labelText"><% Response.Write(this.report.Title); %>
                                        </span></span><span id="edit" style="display: none;">
                                            <input id="editInput" size="40" value="Lastdra attacks 002 Thu Huong (534|701)">
                                            <input value="OK" onclick="editSubmit('label', 'labelText', 'edit', 'editInput', '')"
                                                type="submit"></span>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        Sent
                                    </td>
                                    <td>
                                        <% Response.Write(this.report.Time); %>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="border: 1px solid black; padding: 4px;" height="160" valign="top">
                                        <asp:Panel ID="pReportArea" runat="server">
                                            <uc1:AttackReportPanel ID="AttackReportPanel1" runat="server" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="vis" align="center" width="100%">
                            <tbody>
                                <tr>
                                    <td align="center" width="20%">
                                        <a href="/game.php?village=51549&amp;screen=report&amp;mode=forward&amp;id=17808678">
                                            forward</a>
                                    </td>
                                    <td align="center" width="20%">
                                        <a href="/game.php?village=51549&amp;screen=report&amp;mode=all&amp;action=del_one&amp;id=17808678&amp;h=296c">
                                            Delete</a>
                                    </td>
                                    <td align="center" width="20%">
                                        <a href="/game.php?village=51549&amp;screen=report&amp;mode=all&amp;view=17919899">&lt;&lt;</a>
                                    </td>
                                    <td align="center" width="20%">
                                        <a href="/game.php?village=51549&amp;screen=report&amp;mode=all&amp;view=17774313">&gt;&gt;</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    <asp:Panel ID="pNoReport" runat="server">
        <h2>
            Lỗi: không tìm thấy báo cáo</h2>
    </asp:Panel>
</asp:Content>
