<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="village_info.aspx.cs"
    Inherits="village_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pVillageNotFound" runat="server">
        <h2>
            Thành phố không tồn tại</h2>
    </asp:Panel>
    <asp:Panel ID="pHasVillage" runat="server">
        <h2>
            Thành phố <% Response.Write(this.target.Name); %></h2>
        <table class="vis left" style="margin-right: 10px;" width="50%">
            <tbody>
                <tr>
                    <th colspan="2">
                        <% Response.Write(this.target.Name); %>
                    </th>
                </tr>
                <tr>
                    <td width="80">
                        Tọa độ:
                    </td>
                    <td>
                        <% Response.Write(this.target.X.ToString("000")); %>|<% Response.Write(this.target.Y.ToString("000")); %>
                    </td>
                </tr>
                <tr>
                    <td>
                        Chủ thành:
                    </td>
                    <td>
                        <a href='user_info.aspx?id=<% Response.Write(this.village.ID); %>&player=<% Response.Write(this.target.Owner.ID); %>'><% Response.Write(this.target.Owner.Username); %></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <a href='map.aspx?id=<% Response.Write(this.village.ID); %>&target=<% Response.Write(this.target.ID); %>'>» Bản đồ</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <a href='rally.aspx?id=<% Response.Write(this.village.ID); %>&target=<% Response.Write(this.target.ID); %>'>
                            » Gửi quân</a>
                    </td>
                </tr>
                <asp:Panel ID="pIsOwner" runat="server">
                <tr>
                    <td colspan="2">
                        <a href='village.aspx?id=<% Response.Write(this.target.ID); %>'>» Quản lý thành phố</a>
                    </td>
                </tr>
                </asp:Panel>
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>
