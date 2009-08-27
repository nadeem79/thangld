<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="list_report.aspx.cs"
    Inherits="list_report" Title="Báo cáo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script language='JavaScript'>
        checked = false;
        function checkedAll() {
            if (checked == false) { checked = true } else { checked = false }
            for (var i = 0; i < document.getElementById('aspnetForm').elements.length; i++) {
                document.getElementById('aspnetForm').elements[i].checked = checked;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <h2>
        Báo cáo</h2>
    <table width="100%" class="checkboxPanel">
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
                                    <a href="list_report.aspx?id=<% = this.village.ID %>&type=1">Tấn công</a>
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
                            <tr>
                                <td width="100">
                                    <a href="list_report.aspx?id=<% = this.village.ID %>&type=5">Khác</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top" width="100%">
                <table cellspacing="0" rules="all" border="1" style="border-color: Black; border-width: 1px;
                                    border-style: Solid; width: 100%; border-collapse: collapse;">
                                    <tbody>
                                        <tr>
                                            <th>
                                            </th>
                                            <th>
                                                <center>
                                                    Tiêu đề</center>
                                            </th>
                                            <th width="160">
                                                <center>
                                                    Thời gian</center>
                                            </th>
                                        </tr>
                        <asp:Repeater runat="server" ID="gvReports" 
                            onitemcommand="gvReports_ItemCommand" EnableViewState="true">
                            <ItemTemplate>
                            <form method="post" action="<% = Request.Url.ToString() %>">
                                <tr>
                                    <td>
                                        <asp:CheckBox runat="server" ID="checkReport" /><asp:HiddenField runat="server" ID="hiddenReportID"
                                            Value='<%# Eval("ID") %>' />
                                    </td>
                                    <td>
                                        <a href="report_details.aspx?id=<% = this.village.ID %>&report=<%# Eval("ID") %>">
                                            <%# Eval("Title") %> <%# UnreadNotify((bool)Eval("Unread")) %></a>
                                    </td>
                                    <td>
                                        <%# ((DateTime)Eval("Time")).ToString("HH:mm:ss 'ngày' dd/MM")%>
                                    </td>
                                </tr>
                                </form>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                                <th><input type="checkbox" onchange="checkedAll" /></th>
                                <th>
                                    <asp:Button ID="bttnDeleteReports" runat="server" Text="Xoá" OnClick="bttnDeleteReports_Clicked" /></th>
                                <th></th>
                            </tr>
                                </tbody> </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
