<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserProfile.ascx.cs" Inherits="UserProfile" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table class="vis" width="100%">
    <tbody>
        <tr>
            <th colspan="2">
                Thông tin cá nhân
            </th>
        </tr>
        <tr>
            <td width="15%">
                Ngày sinh:
            </td>
            <td>
                <asp:DropDownList ID="cbDay" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="cbMonth" runat="server" Height="16px" Width="86px">
                    <asp:ListItem Text="Tháng một" Value="01"></asp:ListItem>
                    <asp:ListItem Text="Tháng hai" Value="02"></asp:ListItem>
                    <asp:ListItem Text="Tháng ba" Value="03"></asp:ListItem>
                    <asp:ListItem Text="Tháng bốn" Value="04"></asp:ListItem>
                    <asp:ListItem Text="Tháng năm" Value="05"></asp:ListItem>
                    <asp:ListItem Text="Tháng sáu" Value="06"></asp:ListItem>
                    <asp:ListItem Text="Tháng bảy" Value="07"></asp:ListItem>
                    <asp:ListItem Text="Tháng tám" Value="08"></asp:ListItem>
                    <asp:ListItem Text="Tháng chín" Value="09"></asp:ListItem>
                    <asp:ListItem Text="Tháng mười" Value="10"></asp:ListItem>
                    <asp:ListItem Text="Tháng mười một" Value="11"></asp:ListItem>
                    <asp:ListItem Text="Tháng mười hai" Value="12"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="cbYear" runat="server" Width="50px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Giới tính:
            </td>
            <td>
                <asp:RadioButton ID="rdoMale" runat="server" Text="Nam" />
                <asp:RadioButton ID="rdoFemale" runat="server" Text="Nữ" />
            </td>
        </tr>
        <tr>
            <td>
                Địa chỉ:
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Yahoo:
            </td>
            <td>
                <asp:TextBox ID="txtYahoo" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Skype:
            </td>
            <td>
                <asp:TextBox ID="txtSkype" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Ảnh đại diện:
            </td>
            <td>
                <% if (this.player.Avatar) Response.Write("<img src='data/images/members/" + this.player.ID.ToString() + ".jpg' alt='" + this.player.Username + "' /><br />"); %>
                <asp:LinkButton ID="aDeleteAvatar" runat="server" OnClick="aDeleteAvatar_Click">Xoá ảnh đại diện</asp:LinkButton>
                <asp:FileUpload ID="fileAvatar" runat="server" Width="500px" /><br />
                <span style="font-size: xx-small;">Kích thước tối đa 240x180, dung lượng tối đa 120kByte,
                    (jpg, jpeg, png, gif)</span>
                <br />
                <asp:Label ID="lblAvatarError" runat="server" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" width="100%">
            </td>
        </tr>
    </tbody>
</table>
<br>
<table class="vis" width="100%">
    <tbody>
        <tr>
            <th colspan="2">
                Tự giới thiệu:
            </th>
        </tr>
        <tr>
            <td colspan="2">
                <telerik:RadEditor ID="txtPersonalText" runat="server">
                </telerik:RadEditor> 
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="bttnChangePlayerProfile" runat="server" Text="OK" OnClick="bttnChangePlayerProfile_Click" />
            </td>
        </tr>
    </tbody>
</table>
