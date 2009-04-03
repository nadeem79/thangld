<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Shoutbox.ascx.cs" Inherits="Shoutbox" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<center>

    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" EnableHistory="True"
        LoadingPanelID="pShoutbox">
        <div id="shoutbox_div" style="overflow: auto; width: 100%; height: 80%; text-align: left;">
                <div id="shoutbox_data" class="shoutbox_content">
                    <asp:Label ID="error" runat="server"></asp:Label>
                    <div>
                        <asp:Label ID="lblShoutboxData" runat="server"></asp:Label></div>
                </div>
                
            </div>
            <asp:Panel ID="pForm" runat="server">
            <telerik:RadTextBox ID="txtShoutboxInput" runat="server" EmptyMessage="Nội dung"
                Width="97%" CssClass="shoutbox_text_bg">
            </telerik:RadTextBox></div>
            <div>
                <asp:Button ID="bttnShout" runat="server" Text="Gửi tin" 
                    OnClick="bttnShout_Click" Height="100px" Width="107px"/></div>
                </asp:Panel>
    </telerik:RadAjaxPanel>

</center>

