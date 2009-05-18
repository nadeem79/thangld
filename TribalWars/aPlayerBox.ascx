<%@ Control Language="C#" AutoEventWireup="true" CodeFile="aPlayerBox.ascx.cs" Inherits="aPlayerBox" %>
<div class="login-block">
    <asp:Label ID="error" runat="server" CssClass="error" ForeColor="#FF3300"></asp:Label>
    <h2>
        Xin chào
        <% Response.Write(this.Admin.Username); %></h2>
        <br />
        <br />
        <a href="village.aspx">Vào game</a><br />
        <a href="logout.aspx">Thoát</a>
<
