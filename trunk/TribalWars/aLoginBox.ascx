﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="aLoginBox.ascx.cs" Inherits="aLoginBox" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div class="login-block">
    <h2 style="text-align: left; margin-bottom: 15px;">
        Tribal Wars - Đăng nhập
    </h2>
    <asp:Label ID="error" runat="server" CssClass="error" ForeColor="#FF3300"></asp:Label>
    <span style="font-size:11px;">Tên đăng nhập:</span><br />
    <asp:TextBox ID="username" runat="server" ValidationGroup="Login"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username" ValidationGroup="Login"
        ErrorMessage="RequiredFieldValidator" Text="Nhập username"></asp:RequiredFieldValidator>
    <br />
    Mật khẩu:<br />
    <asp:TextBox ID="password" runat="server" ValidationGroup="Login" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password"
        ErrorMessage="RequiredFieldValidator" ValidationGroup="Login">Nhập mật khẩu</asp:RequiredFieldValidator>
    <table width="100%" >
        <tr>
        </tr>
    </table>
    <asp:ImageButton ID="login" runat="server" ImageUrl="images/login1.png" OnClick="login_Click" />
</div>