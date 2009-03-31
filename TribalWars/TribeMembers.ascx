<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TribeMembers.ascx.cs" Inherits="TribeMembers" %>
<h2>THÀNH VIÊN <% Response.Write(this.Tribe.Tag); %></h2>

<asp:GridView ID="gvTribeMembers" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:HyperLinkField DataNavigateUrlFields="Username" Text="Thành viên" />
    </Columns>
</asp:GridView>
