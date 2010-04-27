<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/administrator.master" AutoEventWireup="true" CodeFile="staff_group_member.aspx.cs" Inherits="administrator_staff_group_member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1>Thành viên nhóm quản trị <% = this.StaffGroup.Name %></h1></center>
    
    <fieldset>
        <legend>Thêm thành viên</legend>
        Thành viên: <asp:TextBox runat="server" ID="txtNewStaffName" Width="477px"></asp:TextBox>
        <asp:Button runat="server" ID="bttnAddStaff" Text="Thêm thành viên" 
            onclick="bttnAddStaff_Click" />
    </fieldset>
    <asp:Repeater runat="server" ID="rptGroupStaffs" 
        onitemcommand="rptGroupStaffs_ItemCommand">
        <HeaderTemplate>
            <table>
                <tbody>
                    <tr>
                        <th>ID</th>
                        <th>Tên</th>
                        <th>Rời nhóm</th>
                    </tr>
        </HeaderTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("ID") %></td>
                <td><%# Eval("Username") %></td>
                <td><asp:LinkButton runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="DismissStaff">Rời nhóm</asp:LinkButton></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

