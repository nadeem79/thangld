<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Shoutbox.ascx.cs" Inherits="Shoutbox" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<center>
    <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="bttnShout">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblShoutboxData" />
                    <telerik:AjaxUpdatedControl ControlID="txtShoutboxInput" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    &nbsp;<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" EnableHistory="True"
        LoadingPanelID="pShoutbox" EnableAJAX="true">
        <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick" Enabled="true">
        </asp:Timer>
        <div id="shoutbox_div" style="overflow: auto; width: 100%; height: 80%; text-align: left;">
            <div id="shoutbox_data" class="shoutbox_content">
                <asp:Label ID="error" runat="server"></asp:Label>
                <div>
                    <asp:Label ID="lblShoutboxData" runat="server"></asp:Label></div>
            </div>
        </div>
    </telerik:RadAjaxPanel>
    <asp:Panel ID="pForm" runat="server">
        <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" EnableHistory="True" LoadingPanelID="pShoutbox"
            EnableAJAX="true">
            <telerik:RadTextBox ID="txtShoutboxInput" runat="server" EmptyMessage="Nội dung"
                Width="97%" CssClass="shoutbox_text_bg">
            </telerik:RadTextBox>
        </telerik:RadAjaxPanel>
        <div style="margin-bottom:20px;">
            <asp:Button ID="bttnShout" runat="server" Text="Gửi tin" OnClick="bttnShout_Click"
                Height="100px" Width="107px" /></div>
    </asp:Panel>
    <script type="text/javascript">
        $('#shoutbox_div').animate({ scrollTop: $('#shoutbox_div')[0].scrollHeight });
    </script>
</center>
