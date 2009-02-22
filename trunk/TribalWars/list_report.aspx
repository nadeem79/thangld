<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="list_report.aspx.cs"
    Inherits="list_report" Title="Báo cáo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Báo cáo</h2>
    <table width="100%">
        <tbody>
            <tr>
                <td valign="top">
                    <table class="vis" width="100" runat="server" id="navigator">
                        <tbody>
                            <tr>
                                <td width="100">
                                    <asp:HyperLink ID="urlAllReports" runat="server" NavigateUrl="~/report_details.aspx">Tất cả</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <asp:HyperLink ID="urlAttackReports" runat="server" NavigateUrl="~/report_details.aspx?type=1">Tấn công</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <asp:HyperLink ID="urlDefenseReports" runat="server" NavigateUrl="~/report_details.aspx?type=2">Phòng thủ</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <asp:HyperLink ID="urlSupportReports" runat="server" NavigateUrl="~/report_details.aspx?type=3">Hỗ trợ</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <asp:HyperLink ID="urlMarketReports" runat="server" NavigateUrl="~/report_details.aspx?type=4">Buôn bán</asp:HyperLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top" width="100%">
                    <asp:GridView ID="gvReports" runat="server" AutoGenerateColumns="False" 
                        Width="100%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="current_village,id" DataNavigateUrlFormatString="report_details.aspx?id={0}&amp;report={1}"
                                DataTextField="title" HeaderText="Tiêu đề">
                                <ItemStyle Width="75%" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="create_time" HeaderText="Thời gian" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
