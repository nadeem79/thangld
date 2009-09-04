<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/administrator.master" AutoEventWireup="true" CodeFile="change_staff_permission.aspx.cs" Inherits="administrator_change_staff_permission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center><h1>Sửa thông tin nhóm quyền</h1></center>

<table border="0">
    <tbody>
        <tr>
            <td>Tên: </td>
            <td><asp:TextBox runat="server" ID="txtGroupName"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Numeric settings:</td>
            <td><asp:CheckBox runat="server" ID="chkNumeric" /></td>
        </tr>
        <tr>
            <td>Text Settings:</td>
            <td><asp:CheckBox runat="server" ID="chkText" /></td>
        </tr>
        <tr>
            <td>Khởi động lại hệ thống:</td>
            <td><asp:CheckBox runat="server" ID="chkRestartServer" /></td>
        </tr>
        <tr>
            <td class="style1">Nhóm quản trị:</td>
            <td class="style1"><asp:TextBox runat="server" ID="txtStaffPrivilege"></asp:TextBox><asp:CheckBox runat="server" ID="chkStaffManagement" /></td>
        </tr>
        <tr>
            <td>Thành viên:</td>
            <td><asp:TextBox runat="server" ID="txtMemberPrivilege"></asp:TextBox><asp:CheckBox runat="server" ID="chkMemberManagement" /></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server" ID="bttnChange" Text="Thay đổi" 
                    OnClientClick="return confirm('Thay đổi quyền nhóm?');" 
                    onclick="bttnChange_Click" /></td>
        </tr>
    </tbody>
</table>
</asp:Content>

