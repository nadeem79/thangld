<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/administrator.master" AutoEventWireup="true" CodeFile="change_text.aspx.cs" Inherits="administrator_change_text" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:UpdatePanel runat="server" ID="updatePanel">
    <ContentTemplate>
        <div style="margin-bottom:10px;margin-top:10px;">
        <div style="width:100px;text-align:right;margin-right:5px;float:left;">Key: </div>
        <div style="float:left;"><asp:TextBox Width="800px" ID="txtKey" runat="server" Enabled="false" ></asp:TextBox>
        <br /><asp:RequiredFieldValidator  SetFocusOnError="true" ID="RequiredFieldValidator1" ControlToValidate="txtKey" runat="server" ErrorMessage="Nhập key"></asp:RequiredFieldValidator></div>
        
        <div style="clear:both"></div>
    </div>
    <div style="margin-bottom:10px;margin-top:10px;">
        <div style="width:100px;text-align:right;margin-right:5px;float:left;">Value: </div>
        <div style="float:left;">
        
            <telerik:radeditor Width="800px" ID="txtValue" runat="server"></telerik:RadEditor><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtValue" runat="server" SetFocusOnError="true" ErrorMessage="Nhập value"></asp:RequiredFieldValidator>
        </div>
        <div style="clear:both"></div>
    </div>
    
    <center><asp:Button ID="bttnChangeText" runat="server" Text="Thay đổi" 
        onclick="bttnChangeText_Click" /></center>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="bttnChangeText" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>

    

</asp:Content>

