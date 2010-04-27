<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="user_profile.aspx.cs"
    Inherits="user_profile" Title="Thông tin tài khoản" ValidateRequest="false" %>
<%@ Reference Control="UserProfile.ascx" %>
<%@ Reference Control="ChangeEmailAddress.ascx" %>
<%@ Reference Control="ChangePassword.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 128px;
        }
    </style>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <h2>
        Settings</h2>
    <table width="100%">
        <tbody>
            <tr>
                <td valign="top" class="style1">
                    <table class="vis" width="100%" runat="server" id="tbProfileType">
                        <tbody>
                            <tr>
                                <td width="100">
                                    <a href="user_profile.aspx?id=<%Response.Write(this.village.ID); %>">Tài khoản</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="user_profile.aspx?id=<%Response.Write(this.village.ID); %>&type=1">Email</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="user_profile.aspx?id=<%Response.Write(this.village.ID); %>&type=2">Mật khẩu</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top">
                    <asp:PlaceHolder ID="pProfile" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
