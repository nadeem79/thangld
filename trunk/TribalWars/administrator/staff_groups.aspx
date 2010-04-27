<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/administrator.master"
    AutoEventWireup="true" CodeFile="staff_groups.aspx.cs" Inherits="administrator_staff_groups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <h1>
            Nhóm quản trị</h1>
    </center>
    <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
            <asp:Repeater ID="rptStaffGroups" runat="server" 
                onitemcommand="rptStaffGroups_ItemCommand">
                <HeaderTemplate>
                    <table border="1" width="90%">
                        <tbody>
                            <tr>
                                <th>
                                    ID
                                </th>
                                <th>
                                    Tên
                                </th>
                                <th>
                                    Danh sách thành viên
                                </th>
                                <th>
                                    Xoá
                                </th>
                            </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("ID") %>
                        </td>
                        <td>
                            <a href="change_staff_permission.aspx?group=<%# Eval("ID") %>">
                                <%# Eval("Name") %></a>
                        </td>
                        <td>
                            <a href="staff_group_member.aspx?group=<%# Eval("ID") %>">
                                <%# Eval("Name") %></a>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="bttnDeleteStaffGroup" CommandName="DeleteStaffGroup" CommandArgument='<%# Eval("ID") %>' Text="Xoá" OnClientClick="return confirm('Xoá nhóm?');"></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <fieldset>
                <legend>Nhóm mới</legend>Tên nhóm:
                <asp:TextBox runat="server" ID="txtGroupName"></asp:TextBox>
                <asp:Button OnClientClick="return confirm('Tạo nhóm?');" Text="Nhóm mới" runat="server"
                    ID="bttnCreateNewStaffGroup" OnClick="bttnCreateNewStaffGroup_Click" />
            </fieldset>
</asp:Content>
