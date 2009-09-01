<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InviteReport.ascx.cs"
    Inherits="InviteReport" %>
    
<a href='user_info.aspx?id=<% = this.Village.ID %>&player=<% = this.InviteReportEntity.Inviter.ID %>'><% = this.InviteReportEntity.Inviter.Username %></a> mời bạn gia nhập
bang hội <a href='group_info.aspx?id=<% = this.Village.ID %>&group=<% = this.InviteReportEntity.Group.ID %>'><% = this.InviteReportEntity.Group.Name %> (<% = this.InviteReportEntity.Group.Tag %>)</a>
<br />
<br />

<a href='untribe.aspx?id=<% = this.Village.ID %>'>Xem thư mời</a>