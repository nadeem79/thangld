<%@ Page Title="Phân quyền thành viên" Language="C#" MasterPageFile="~/dialogs/dialog_template.master"
    AutoEventWireup="true" CodeFile="tribe_member.aspx.cs" Inherits="dialogs_tribe_member" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style>
#<%=pAttackConfirm.ClientID%>
{
    float:left;
}
#<%=UpdatePanel1.ClientID%>
{
    float:left;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="dialog" runat="Server">
    <asp:Panel ID="pNotEnoughPrivilage" runat="server">
        <h2>
            Bạn không có quyền truy cập trang này</h2>
    </asp:Panel>
    <asp:Panel ID="pUserNotFound" runat="server">
        <h2>
            Người chơi không tồn tại, hoặc phải là thành viên bang hội</h2>
    </asp:Panel>
    <asp:Panel ID="pCanChange" runat="server">
        <h3>
            Thay đổi quyền cho thành viên
            <% = this.Member.Username %></h3>
        <p>
            Thay đổi quyền cá nhân của thành viên trong bang hội.
        </p>
        <asp:Panel ID="pDukePrivilage" runat="server">
            <h5>
                <asp:CheckBox ID="chkDuke" runat="server" />
                <img src="../images/found.png" alt="Duke" title="Duke">
                Chủ hội
            </h5>
            <p>
                Đặt quyền chủ hội. Chủ hội là thành viên có quyền cao nhất trong bang, có thể giải
                tán hoặc đổi tên bang hội, hoặc cấp quyền chủ hội cho thành viên khác</p>
        </asp:Panel>
        <h5>
            <asp:CheckBox ID="chkBaron" runat="server" />
            <img src="../images/lead.png" alt="Baron" title="Baron">
            Phó hội
        </h5>
        <p>
            Phó hội có thể cấp quyền nickname cho các thành viên khác, hoặc đuổi thành viên
            khỏi hội. Phó hội là người có quyền lực thứ nhì trong hội, chỉ không có quyền đặt
            chủ hội</p>
        <h5>
            <asp:CheckBox ID="chkInviter" runat="server" />
            <img src="../images/invite.png" alt="Invite" title="Invite">
            Tuyển mộ
        </h5>
        <p>
            Mời người chơi khác tham gia hội</p>
        <h5>
            <asp:CheckBox ID="chkDiplomate" runat="server" />
            <img src="../images/diplomacy.png" alt="Diplomacy" title="Diplomacy">
            Ngoại giao</h5>
        <p>
            Đặt thông tin ngoại giao cho hội</p>
        <h3>
            Title</h3>
        <p>
            Tribal status:
            <asp:TextBox ID="txtTribeTitle" runat="server" Width="212px"></asp:TextBox>
        </p>
        <asp:UpdatePanel ID="pAttackConfirm" runat="server" >
            <ContentTemplate>
                <asp:Button ID="bttnChangeMemberPrivilage" runat="server" Text="OK" OnClick="bttnChangeMemberPrivilage_Click" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="bttnChangeMemberPrivilage" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="bttnCancel" runat="server" Text="Bỏ" OnClick="bttnCancel_Click" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="bttnCancel" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
