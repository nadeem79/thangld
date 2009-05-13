<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="untribe.aspx.cs"
    Inherits="untribe" Title="Bang hội" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <h2>
        Bang hội</h2>
    <p>
        Để gia nhập hội nào, bạn phải có thư mời từ bang hội đó
    </p>
    <table class="vis">
        <tbody>
            <tr>
                <th colspan="2">
                    Tạo bang hội
                </th>
            </tr>
            <tr>
                <td>
                    Ký hiệu:<br>
                    (tối đa 6 ký tự)
                </td>
                <td>
                    <telerik:RadTextBox ID="txtTribeTagName" MaxLength="6" runat="server" CausesValidation="true">
                    </telerik:RadTextBox>
                    <div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập tag name"
                            ControlToValidate="txtTribeTagName"></asp:RequiredFieldValidator></div>
                </td>
            </tr>
            <tr>
                <td>
                    Tên:
                </td>
                <td>
                    <telerik:RadTextBox ID="txtTribeName" MaxLength="50" Width="300" runat="server">
                    </telerik:RadTextBox>
                    <div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nhập tên tribe"
                            ControlToValidate="txtTribeName"></asp:RequiredFieldValidator></div>
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Button ID="bttnCreateTribe" runat="server" Text="Tạo tribe" OnClick="bttnCreateTribe_Click" />
    <br>
    <table class="vis">
        <tbody>
            <tr>
                <th width="400">
                    Thư mời
                </th>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvInvite" runat="server" AutoGenerateColumns="False" Width="100%"
                        OnRowCommand="gvInvite_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Group" ShowHeader="False" />
                            <asp:ButtonField Text="Đồng ý" ShowHeader="False" CommandName="cmdAgree">
                                <ItemStyle Width="15%" />
                            </asp:ButtonField>
                            <asp:ButtonField Text="Từ chối" ShowHeader="False" CommandName="cmdReject">
                                <ItemStyle Width="15%" />
                            </asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
