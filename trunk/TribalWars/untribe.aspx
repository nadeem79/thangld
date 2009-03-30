<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="untribe.aspx.cs" Inherits="untribe" Title="Bang hội" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" Enabled="true" Skin="Office2007" />
<h2>Bang hội</h2>

<p>Để gia nhập hội nào, bạn phải có thư mời từ bang hội đó
                                                                </p>

<table class="vis">
<tbody><tr><th colspan="2">Tạo bang hội</th></tr>
<tr><td>Ký hiệu:<br>(tối đa 6 ký tự)</td><td><telerik:RadTextBox ID="txtTribeTagName" MaxLength="6" runat="server" CausesValidation="true"></telerik:RadTextBox>
                                                                            <div><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                                ErrorMessage="Nhập tag name" ControlToValidate="txtTribeTagName"></asp:RequiredFieldValidator></div>
                                                                            </td></tr>

<tr><td>Tên:</td><td>
                                                                            <telerik:RadTextBox ID="txtTribeName" MaxLength="50" Width="300" Runat="server">
                                                                            </telerik:RadTextBox>
                                                                            <div><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                                ErrorMessage="Nhập tên tribe" ControlToValidate="txtTribeName"></asp:RequiredFieldValidator></div>
    </td></tr>
</tbody></table>

<asp:Button ID="bttnCreateTribe" runat="server" Text="Tạo tribe" onclick="bttnCreateTribe_Click" />
<br>
	
<table class="vis">
<tbody><tr><th width="400">Thư mời</th></tr>
<tr><td>
    <asp:GridView ID="gvInvite" runat="server" AutoGenerateColumns="False" 
        Width="100%" onrowcommand="gvInvite_RowCommand" >
        <Columns>
            <asp:BoundField DataField="Group" ShowHeader="False" />
            <asp:ButtonField Text="Đồng ý" ShowHeader="False" CommandName="cmdAgree" >
                <ItemStyle Width="15%" />
            </asp:ButtonField>
            <asp:ButtonField Text="Từ chối" ShowHeader="False" CommandName="cmdReject" >
                <ItemStyle Width="15%" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    </td></tr>
</tbody></table>				
    		
    			
</asp:Content>

