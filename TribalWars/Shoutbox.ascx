<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Shoutbox.ascx.cs" Inherits="Shoutbox" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<script>
	var loaded = true;
</script>
<center>
    <div class="shoutbox">
        <div class="head_shoutbox">
            <div class="title_com">
                <img src="images/nut_head_trang.png" border="0" />
                SHOUTBOX
            </div>
        </div>
        <div id="sub1" class="box_component">
            <table style="width: 100%;" id="main_shoutbox_block" cellpadding="1" cellspacing="0">
                <tbody>
                    <tr>
                        <td>
                            <div id="shoutbox_div" style="overflow: auto; width: 100%; height: 280px; text-align: left;">
                                <div id="shoutbox_data" class="shoutbox_content">
                                    <asp:UpdatePanel ID="pShoutbox" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="error" runat="server"></asp:Label><br />
                                            <div>
                                                <asp:Label ID="lblShoutboxData" runat="server"></asp:Label></div>
                                            <div>
                                                <asp:Label ID="lblNewData" runat="server" CssClass="shoutbox_content"></asp:Label></div>
                                            <asp:TextBox ID="txtShoutboxInput" runat="server" CssClass="shoutbox_text_bg"></asp:TextBox>
                                            <asp:Button ID="Button1" runat="server" Text="Gửi tin" OnClick="Button1_Click" />
                                            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="5000">
                                            </asp:Timer>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="footer"></div>
</center>
<script>
    $('#shoutbox_div').animate({scrollTop: $('#<% Response.Write(this.lblShoutboxData.ClientID); %>')[0].scrollHeight});
</script>


