<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="command.aspx.cs"
    Inherits="command" Title="Tấn công" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        <asp:Label ID="to_village_label" runat="server"></asp:Label></h2>
    <table class="vis" width="400">
        <tbody>
            <tr>
                <th colspan="3">
                    <span id="label"><span id="labelText">Command</span> </span><span id="edit" style="display: none;">
                        <input id="editInput" size="40" value="">
                        <input value="OK" onclick="editSubmit('label', 'labelText', 'edit', 'editInput', '')"
                            type="button"></span>
                </th>
            </tr>
            <tr>
                <td rowspan="2">
                    Từ</td>
                <td>
                    Player:
                </td>
                <td>
                    <asp:HyperLink ID="from_player" runat="server"></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    Thành phố:
                </td>
                <td>
                    <asp:HyperLink ID="from_village" runat="server"></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td rowspan="2">
                    Đến</td>
                <td>
                    Player:
                </td>
                <td>
                   <asp:HyperLink ID="to_player" runat="server"></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    Thành phố:
                </td>
                <td>
                    <asp:HyperLink ID="to_village" runat="server"></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Thời gian:                 </td>
                <td>
                    <asp:Label ID="land_time" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Còn:</td>
                <td>
                    <asp:Label ID="timer" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                <asp:HyperLink ID="rally_url" runat="server">» Rally point</asp:HyperLink>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <asp:Label ID="lblTroop" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblResources" runat="server"></asp:Label>
</asp:Content>
