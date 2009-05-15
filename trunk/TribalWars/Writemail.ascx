<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Writemail.ascx.cs"
    Inherits="writemail" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">
    .style1
    {
        width: 93%;
        height: 42px;
    }
    .style2
    {
        width: 90px;
    }
    .style3
    {
        width: 90px;
        height: 31px;
    }
    .style4
    {
        height: 31px;
    }
</style>
<table class="style1">
    <tr>
        <td class="style3">
            Người nhận :</td>
        <td class="style4">
                <asp:TextBox ID="Receiver" runat="server" Width="300px"></asp:TextBox>
                        
<asp:Label ID="error" runat="server" CssClass="error" ForeColor="#FF3300"></asp:Label>

        </td>
    </tr>
    <tr>
        <td class="style2">
            Tiêu đề :</td>
        <td>
                <asp:TextBox ID="Title" runat="server" Width="300px"></asp:TextBox>
                               
        </td>
    </tr>
</table>
                <telerik:RadEditor ID="Detail" runat="server" 
                Skin="Office2007" BackColor="White" Height="364px" 
    Width="600px">
<Content>
</Content>
                </telerik:RadEditor> 
<br />
<br />
<asp:Button ID="sendmail" runat="server" Text="Send" 
    onclick="sendmail_Click" Width="88px" />                
            <p style="width: 510px">
</p>


