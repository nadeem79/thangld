<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserProfile.ascx.cs" Inherits="UserProfile" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table class="vis" width="100%">
    <tbody>
        <tr>
            <th colspan="2" class="style1">
                
                Thông tin cá nhân
            </th>
        </tr>
        <tr>
            <td width="15%">
                Ngày sinh:
            </td>
            <td>
                <telerik:RadDateInput ID="txtBirthdate" Runat="server"
                    DisplayDateFormat="d/M/yyyy" Width="192px"
                    MinDate="1950-01-01" DateFormat="d/M/yyyy">
                </telerik:RadDateInput>
            </td>
        </tr>
        <tr>
            <td>
                Giới tính:
            </td>
            <td>
                <asp:RadioButton ID="rdoMale" GroupName="gender" runat="server" Text="Nam" />
                <asp:RadioButton ID="rdoFemale" GroupName="gender" runat="server" Text="Nữ" />
            </td>
        </tr>
        <tr>
            <td>
                Địa chỉ:
            </td>
            <td>
                <telerik:RadTextBox ID="txtAddress" Runat="server" Width="500px">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Yahoo:
            </td>
            <td>
                <telerik:RadTextBox ID="txtYahoo" runat="server" Width="250px"></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Skype:
            </td>
            <td>
                <telerik:RadTextBox ID="txtSkype" runat="server" Width="250px"></telerik:RadTextBox>
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
                <telerik:RadEditor ID="txtPersonalText" runat="server" Skin="Office2007" BackColor="White">
                    <Content>
</Content>
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
