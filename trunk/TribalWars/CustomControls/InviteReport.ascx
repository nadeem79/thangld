<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InviteReport.ascx.cs"
    Inherits="CustomControls_InviteReport" %>
    
<a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.InviteReport.Inviter.ID %>'><% = this.InviteReport.Inviter.Username %></a> mời bạn gia nhập
bang hội <a href='group_info.aspx?id=<% = this.Village.ID %>&group=<% = this.InviteReport.Group.ID %>'><% = this.InviteReport.Group.Name %> (<% = this.InviteReport.Group.Tag %>)</a>
<br />
<br />

<a href='untribe.aspx?id=<% = this.Village.ID %>'>Xem thư mời</a>