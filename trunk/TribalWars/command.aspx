<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="command.aspx.cs"
    Inherits="command" Title="Tấn công" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pCommandNotFound" runat="server">
        <h2>
            Lệnh không tồn tại hoặc hết thời hạn
        </h2>
    </asp:Panel>
    <asp:Panel ID="pCommandFound" runat="server">
        <h2>
            <asp:Label ID="lblAttackType" runat="server"></asp:Label> thành phố
            <% Response.Write(this.current.To.Name); %></h2>
        <table class="vis" width="400">
            <tbody>
                <tr>
                    <th colspan="3">
                        <span id="labelText">Tấn công</span>
                    </th>
                </tr>
                <tr>
                    <td rowspan="2">
                        Từ
                    </td>
                    <td>
                        Lãnh chúa:
                    </td>
                    <td>
                        <a href="user_info.aspx?id=<% Response.Write(this.village.ID); %>&player=<% Response.Write(this.current.From.Owner.ID); %>">
                            <%Response.Write(this.current.From.Owner.Username); %></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Thành phố:
                    </td>
                    <td>
                        <a href="village_info.aspx?id=<% Response.Write(this.village.ID); %>&village=<% Response.Write(this.current.From.ID); %>">
                            <% Response.Write(this.current.From.Name); %>
                            (<% Response.Write(this.current.From.X.ToString("000")); %>|<% Response.Write(this.current.From.Y.ToString("000")); %>)</a>
                    </td>
                </tr>
                <tr>
                    <td rowspan="2">
                        Đến
                    </td>
                    <td>
                        Lãnh chúa:
                    </td>
                    <td>
                        <a href="user_info.aspx?id=<% Response.Write(this.village.ID); %>&player=<% Response.Write(this.current.To.Owner.ID); %>">
                            <%Response.Write(this.current.To.Owner.Username); %></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Thành phố:
                    </td>
                    <td>
                        <a href="village_info.aspx?id=<% Response.Write(this.village.ID); %>&village=<% Response.Write(this.current.To.ID); %>">
                            <% Response.Write(this.current.To.Name); %>
                            (<% Response.Write(this.current.To.X.ToString("000")); %>|<% Response.Write(this.current.To.Y.ToString("000")); %>)</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Thời gian:
                    </td>
                    <td>
                        <% Response.Write(this.current.LandingTime.ToString("dd/MM/yyyy HH:mm:ss") + "<span class='abc'>" + this.current.LandingTime.Millisecond.ToString("000") + "</span>"); %>
                        <asp:Label ID="land_time" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Còn:
                    </td>
                    <td>
                        <% Response.Write(Functions.FormatTime(this.current.LandingTime - DateTime.Now)); %>
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
    </asp:Panel>
</asp:Content>
