<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/administrator.master"
    AutoEventWireup="true" CodeFile="create_staff_groups.aspx.cs" Inherits="administrator_create_staff_groups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <h1>
            Tạo nhóm quản trị mới</h1>
    </center>
    <div style="margin-bottom: 10px; margin-top: 10px;">
        <div style="width: 100px; text-align: right; margin-right: 5px; float: left;">
            Tên nhóm:
        </div>
        <div style="float: left;">
            <asp:TextBox Width="800px" ID="txtKey" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator1" ControlToValidate="txtKey"
                runat="server" ErrorMessage="Nhập key"></asp:RequiredFieldValidator></div>
        <div style="clear: both">
        </div>
    </div>
</asp:Content>
