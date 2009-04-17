<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="tribe.aspx.cs"
    Inherits="tribe" Title="Bang hội" ValidateRequest="false" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Reference Control="TribeProfile.ascx" %>
<%@ Reference Control="TribeMembers.ascx" %>
<%@ Reference Control="TribeDiplomacy.ascx" %>
<%@ Reference Control="CustomControls/TribeShoutbox.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
<% if (!IsPostBack)
   {  %>
    <table runat="server" id="navigator">
        <tr align="center">
            <td width="150">
                <a href="tribe.aspx?id=<% = this.village.ID %>">Thông tin bang hội</a>
            </td>
            <td width="150">
                <a href="tribe.aspx?id=<% = this.village.ID %>&page=1">Thành viên</a>
            </td>
            <td width="150">
                <a href="tribe.aspx?id=<% = this.village.ID %>&page=2">Ngoại giao</a>
            </td>
            <td width="150">
                <a href="tribe.aspx?id=<% = this.village.ID %>&page=3">Diễn đàn bang</a>
            </td>
        </tr>
    </table>
    <%} %>
    <asp:PlaceHolder ID="pTribePage" runat="server"></asp:PlaceHolder>
</asp:Content>
