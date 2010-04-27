<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.ascx.cs"
    Inherits="ChangePassword" %>
<h3>
    Đổi mật khẩu</h3>
<p>
    <asp:Label ID="lblError" runat="server" Font-Bold="False" Font-Size="Medium" ForeColor="Red"></asp:Label>
</p>
<table class="vis">
    <tbody>
        <tr>
            <td>
                <label for="old_passwd">
                    Mật khẩu cũ:</label>
            </td>
            <td>
                <asp:TextBox ID="txtOldPassword" TextMode="Password" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
                    ErrorMessage="Phải nhập mật khẩu cũ"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label for="new_passwd">
                    Mật khẩu mới:</label>
            </td>
            <td>
                <asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                    ErrorMessage="Phải nhập mật khẩu"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label for="new_passwd_rpt">
                    Nhập lại mật khẩu:</label>
            </td>
            <td>
                <asp:TextBox ID="txtRepeatPassword" TextMode="Password" runat="server" Width="300px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Nhập sai mật khẩu"
                    ControlToValidate="txtRepeatPassword" ControlToCompare="txtNewPassword"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;<asp:Button ID="bttnChangePassword" runat="server" Height="26px" Width="100px"
                    OnClick="bttnChangePassword_Click" Text="Đổi mật khẩu" />
            </td>
        </tr>
    </tbody>
</table>
