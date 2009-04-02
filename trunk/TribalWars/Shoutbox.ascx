<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Shoutbox.ascx.cs" Inherits="Shoutbox" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">
function check()
{
if (<% Response.Write(txtShoutboxInput.ClientID); %>.value="")
return false;
}
</script>
<center>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
            <div id="shoutbox_div" style="overflow: auto; width: 100%; height: 80%; text-align: left;">
                <div id="shoutbox_data" class="shoutbox_content">
                    <asp:Label ID="error" runat="server"></asp:Label>
                    <div>
                        <asp:Label ID="lblShoutboxData" runat="server"></asp:Label></div>
                </div>
                <asp:Timer ID="Timer1" runat="server" Interval="5000" ontick="Timer1_Tick">
                </asp:Timer>
            </div>
            <telerik:RadTextBox ID="txtShoutboxInput" runat="server" EmptyMessage="Nội dung"
                Width="97%" CssClass="shoutbox_text_bg">
            </telerik:RadTextBox></div>
            <div>
                <asp:Button ID="bttnShout" runat="server" Text="Gửi tin" OnClick="bttnShout_Click" OnClientClick="return check();" /></div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="bttnShout" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
</center>

