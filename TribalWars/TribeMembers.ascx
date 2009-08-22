<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TribeMembers.ascx.cs"
    Inherits="TribeMembers" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadWindowManager ID="RadWindowManager1" runat="server"  Modal="true"
        Width="700" Height="500" Style="z-index:1000">
    </telerik:RadWindowManager>
<h2>
    THÀNH VIÊN
    <% Response.Write(this.Tribe.Tag); %></h2>
<asp:Panel ID="pInviting" runat="server">
    <asp:UpdatePanel runat="server" ID="pChangeName" Visible="true">
        <ContentTemplate>
            <telerik:RadTextBox ID="txtUser" runat="server" EmptyMessage="Tên người chơi" Width="125px">
            </telerik:RadTextBox>
            &nbsp;
            <asp:Button ID="bttnInvite" runat="server" OnClick="bttnInvite_Click" Text="Mời tham gia bang hội" style="width:auto;" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="bttnInvite" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Panel>
<table>
    <tbody>
        <tr>
            <td>
                <table class="vis">
                    <tbody>
                        <tr>
                            <th>
                                Thành viên
                            </th>
                            <th>
                                Số thứ tự
                            </th>
                            <th>
                                Tổng điểm
                            </th>
                            <% if ((this.Member.TribePermission & beans.TribePermission.Baron) == beans.TribePermission.Baron)
                               { %>
                            <th>
                                Quyền thành viên
                            </th>
                            <%} %>
                        </tr>
                        <asp:Repeater ID="drTribeMembers" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <a href="user_info.aspx?id=<% = this.village.ID %>&player=<%# DataBinder.Eval(Container.DataItem, "ID") %>";">
                                            <%# DataBinder.Eval(Container.DataItem, "Username") %></a> <%# DataBinder.Eval(Container.DataItem, "TribeTitle") %>
                                    </td>
                                    <td>
                                        <%# Container.ItemIndex + 1 %>
                                    </td>
                                    <td>
                                        <%# DataBinder.Eval(Container.DataItem, "Point") %>
                                    </td>
                                    <% if ((this.Member.TribePermission & beans.TribePermission.Baron) == beans.TribePermission.Baron)
                                       { %>
                                    <td>
                                        <a href="javascript:void(0);" onclick="window.radopen('dialogs/tribe_member.aspx?member=<%# DataBinder.Eval(Container.DataItem, "ID") %>');">Thay đổi</a>
                                    </td>
                                    <%} %>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </tbody>
</table>
