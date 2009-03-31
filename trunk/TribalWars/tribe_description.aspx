<%@ Page Title="" Language="C#" MasterPageFile="~/CustomForm.master" AutoEventWireup="true" CodeFile="tribe_description.aspx.cs" Inherits="tribe_description" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" 
            onclick="Button1_Click1" />
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

