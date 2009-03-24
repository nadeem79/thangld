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
            Chúa đất
            <% Response.Write(this.player.Username); %></h2>
        <table width="100%">
            <tbody>
                <tr>
                    <td valign="top" width="40%">
                        <table class="vis" width="100%">
                            <tbody>
                                <tr>
                                    <th>
                                        <% Response.Write(this.player.Username); %>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <a href='write_message.aspx?id=<% Response.Write(this.village.ID); %>&player=<% Response.Write(this.player.ID); %>'>
                                            » Gửi tin nhắn</a>
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
                                        Thông tin cá nhân
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        Ngày sinh:
                                    </td>
                                    <td>
                                        <% Response.Write(this.player.Birthdate.ToString("dd/MM/yyyy")); %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Giới tính:
                                    </td>
                                    <td>
                                        <% Response.Write(this.player.Gender); %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Địa chỉ:
                                    </td>
                                    <td>
                                        <% Response.Write(this.player.Address); %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email:
                                    </td>
                                    <td>
                                        <% Response.Write(this.player.Email); %>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        IM:
                                    </td>
                                    <td>
                                        <% if (!this.player.Yahoo.Trim().Equals(string.Empty)) Response.Write(@"<a href='ymsgr:sendIM?" + this.player.Yahoo + "' title='Gửi tin nhắn Yahoo tới " + this.player.Username + "'><img src='http://opi.yahoo.com/online?m=g&t=2&u=" + this.player.Yahoo + "' /><a>"); %>
                                        <% if (!this.player.Skype.Trim().Equals(string.Empty)) Response.Write(@"<a href='skype:" + this.player.Skype + "?call' title='Gọi điện thoại skype tới " + this.player.Username + "'><img src='http://mystatus.skype.com/smallicon/" + this.player.Skype + "' /><a>"); %>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <% if (!this.player.Avatar.Trim().Equals(string.Empty)) Response.Write("<img src='data/images/" + this.player.Avatar + "'"); %>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <br>
                        <table class="vis" width="100%">
                            <tbody>
                                <tr>
                                    <th>
                                        Về bản thân:
                                    </th>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <% Response.Write(this.player.Description); %>
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
