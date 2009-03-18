<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="user_info.aspx.cs"
    Inherits="user_info"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pUserNotFound" runat="server">
        <h2>
            Người chơi không tồn tại
        </h2>
    </asp:Panel>
    <asp:Panel ID="pUserExists" runat="server">
        <h2>
            Player
            <% Response.Write(player["username"]); %></h2>
        <table width="100%">
            <tbody>
                <tr>
                    <td valign="top" width="40%">
                        <table class="vis" width="100%">
                            <tbody>
                                <tr>
                                    <th>
                                        <% Response.Write(player["username"]); %>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <a href='write_message.aspx?id=51549&player=<% Response.Write(player["username"]); %>'>
                                            » Write message</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <br />
                        <asp:GridView ID="gvVillages" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:HyperLinkField DataNavigateUrlFields="current_village,id" DataNavigateUrlFormatString="village_info.aspx?id={0}&amp;village={1}"
                                    DataTextField="name" HeaderText="Thành phố" />
                                <asp:BoundField DataField="coord" HeaderText="Toạ độ">
                                    <ItemStyle Width="15%" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td align="right" valign="top" width="50%">
                        <table class="vis" width="100%">
                            <tbody>
                                <tr>
                                    <th colspan="2">
                                        Hồ sơ cá nhân
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        Ngày sinh:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAge" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Gender:
                                    </td>
                                    <td>
                                        <% Response.Write((bool)player["sex"] ? "Nam" : "Nữ"); %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Địa chỉ:
                                    </td>
                                    <td>
                                        <% Response.Write(player["address"]); %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email:
                                    </td>
                                    <td>
                                        <% Response.Write(player["email"]); %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        IM:
                                    </td>
                                    <td>
                                        <asp:Image ID="imgYahoo" runat="server" />
                                        <asp:Image ID="imgSkype" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Image ID="imgAvatar" runat="server" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <br>
                        <table class="vis" width="100%">
                            <tbody>
                                <tr>
                                    <th>
                                        Personal text
                                    </th>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <% Response.Write(player["description"]); %>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>
