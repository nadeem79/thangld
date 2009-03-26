<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="command.aspx.cs"
    Inherits="command" Title="Tấn công" %>
<%@ Reference Control="AttackCommand.ascx" %>
<%@ Reference Control="SupportCommand.ascx" %>
<%@ Reference Control="ReturnCommand.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pCommandNotFound" runat="server">
        <h2>
            Lệnh không tồn tại hoặc hết thời hạn
        </h2>
    </asp:Panel>
    <asp:Panel ID="pCommandFound" runat="server">
        <asp:PlaceHolder ID="pCommand" runat="server"></asp:PlaceHolder>
    </asp:Panel>
</asp:Content>
