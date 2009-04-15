<%@ Page Title="Phân quyền thành viên" Language="C#" MasterPageFile="~/dialogs/dialog_template.master"
    AutoEventWireup="true" CodeFile="tribe_member.aspx.cs" Inherits="dialogs_tribe_member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dialog" runat="Server">
    <asp:Panel ID="pNotEnoughPrivilage" runat="server">
        <h2>
            Bạn không có quyền truy cập trang này</h2>
    </asp:Panel>
    <asp:Panel ID="pCanChange" runat="server">
        <h3>
            change privileges on Player DreamingFighter</h3>
        <p>
            Here you can set the privileges for the players in your tribe. The duke privileges
            should only be given to players you know VERY well and that you can fully trust.
        </p>
        <h5>
            <asp:CheckBox ID="chkDuke" runat="server" />
            <img src="../images/found.png" alt="Duke" title="Duke">
            Chủ hội
        </h5>
        <p>
            Sets status to duke. A duke possesses all tribal privileges, can disband or rename
            the tribe, set the homepage and chat-channel, administer the tribal forum and name
            other members dukes.</p>
        <h5>
            <asp:CheckBox ID="chkBaron" runat="server" />
            <img src="../images/lead.png" alt="Baron" title="Baron">
            Phó hội
        </h5>
        <p>
            Barons can set privileges and titles of other members and disband members. They
            can receive other privileges as well that can be given by the dukes.</p>
        <h5>
            <asp:CheckBox ID="chkInviter" runat="server" />
            <img src="../images/invite.png" alt="Invite" title="Invite">
            Tuyển mộ
        </h5>
        <p>
            The player has permission to invite other players into the tribe.</p>
        <h5>
            <asp:CheckBox ID="chkDiplomate" runat="server" />
            <img src="../images/diplomacy.png" alt="Diplomacy" title="Diplomacy">
            Ngoại giao</h5>
        <p>
            This privilege allows a member to change the tribal profile and set alliances and
            NAPs.</p>
        <h3>
            Title</h3>
        <p>
            Tribal status:
            <asp:TextBox ID="txtTribeTitle" runat="server" Width="212px"></asp:TextBox>
        </p>
        <h5>
            &nbsp;<asp:Button ID="bttnChangeMemberPrivilage" runat="server" Text="OK" />
            <asp:Button ID="bttnCancel" runat="server" Text="Bỏ" />
        </h5>
    </asp:Panel>
</asp:Content>
