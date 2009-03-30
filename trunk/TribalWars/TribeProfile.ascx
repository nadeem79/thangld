<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TribeProfile.ascx.cs"
    Inherits="TribeProfile" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">

body	{ background-color: #d2c09e; background-image:url('images/bg-tile.jpg'); 
font-size:9pt; font-family: Verdana, Arial; width:100%; margin: 0; }

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

input, select { font-size: 8pt;
    width: 83px;
}

    .style1
    {
        border-collapse: separate;
    }
</style>
<table>
    <tr>
        <td valign="top">
            <table class="vis" width="100%">
                <tbody>
                    <tr>
                        <th colspan="2">
                            Thông tin bang hội
                        </th>
                    </tr>
                    <tr>
                        <td width="100">
                            Tên:
                        </td>
                        <td>
                            <% Response.Write(this.Tribe.Name); %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tag:
                        </td>
                        <td>
                            <% Response.Write(this.Tribe.Tag); %>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <a href="tribe.aspx?id=<%Response.Write(this.village.ID); %>&page=2">Danh sách thành viên</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
        <td valign="top">
            <table class="vis" width="300">
                <tbody>
                    <tr>
                        <th>
                            Mô tả
                        </th>
                    </tr>
                    <tr>
                        <td align="center">
                            <% Response.Write(this.Tribe.Description); %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Panel ID="pChangeDescription" runat="server">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <a href="#pChangeDescription">Đổi thông tin bang hội</a>
                                <div id="pChangeDescription">
                                    <table class="style1">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    Ký hiệu:<br />(tối đa 6 ký tự)
   
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtTribeTagName" runat="server" CausesValidation="true"  Skin="Office2007"
                                                        MaxLength="6"></telerik:RadTextBox>
                                                    <div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="txtTribeTagName" ErrorMessage="Nhập tag name"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Ảnh đại diện:<br />(png, gif, jpg)
                                                </td>
                                                <td>
                                                    <% if (this.Tribe.Avatar) Response.Write("<img src='data/images/tribe/" + this.tribe.ID.ToString() + ".jpg' alt='" + this.player.Username + "' /><br />"); %>
                                        <asp:LinkButton ID="aDeleteAvatar" runat="server" OnClick="aDeleteAvatar_Click">Xoá ảnh đại diện</asp:LinkButton>
                                        <asp:FileUpload ID="fileAvatar" runat="server" Width="500px" /><br />
                                        <span style="font-size: xx-small;">Kích thước tối đa 240x180, dung lượng tối đa 120kByte,
                                            (jpg, jpeg, png, gif)</span>
                                        <br />
                                        <asp:Label ID="lblAvatarError" runat="server" ForeColor="#FF3300"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tên:</td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtTribeName" Runat="server" MaxLength="50" Width="300" Skin="Office2007"></telerik:RadTextBox>
                                                    <div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="txtTribeName" ErrorMessage="Nhập tên tribe"></asp:RequiredFieldValidator>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Thông tin mô tả:</td>
                                                <td>
                                                    <telerik:RadEditor ID="txtChangeDescription" Runat="server">
                                                    </telerik:RadEditor>
                                                </td>
                                            </tr>
                                            <tr><td colspan="2"><asp:Button ID="bttnChangeDescription" runat="server" Text="Cập nhật" /></td></tr>
                                        </tbody>
                                        
                                    </table>
                                    
                                    <br>
                                
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
</table>
