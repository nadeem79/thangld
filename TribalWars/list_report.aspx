<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="list_report.aspx.cs"
    Inherits="list_report" Title="Báo cáo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <h2>Báo cáo</h2>
    <table width="100%">
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
                    <asp:GridView ID="gvReports" runat="server" AutoGenerateColumns="False" 
                        Width="100%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                        <Columns>
                            <asp:HyperLinkField
                                DataTextField="Title" HeaderText="Tiêu đề" 
                                DataNavigateUrlFormatString="report_details.aspx?id={0}" 
                                DataNavigateUrlFields="ID">
                                <ItemStyle Width="75%" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="Time" HeaderText="Thời gian" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
