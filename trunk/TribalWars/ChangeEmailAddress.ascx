<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangeEmailAddress.ascx.cs"
    Inherits="ChangeEmailAddress" %>
<h3>
    Thay đổi địa chỉ email</h3>
<p>
    <asp:Label ID="lblError" runat="server" Font-Bold="False" Font-Size="Medium" 
        ForeColor="Red"></asp:Label>
</p>
<table class="vis">
    <tbody>
        <tr>
            <td>
                Địa chỉ email mới:
            </td>
            <td>
                <asp:TextBox ID="email" runat="server" Width="300px"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Phải nhập địa chỉ email" ControlToValidate="email"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email phải đúng định dạng"
                    ControlToValidate="email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Mật khẩu:
            </td>
            <td>
                <asp:TextBox ID="password" runat="server" TextMode="Password" Width="300px"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Phải nhập mật khẩu"
                    ControlToValidate="password"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </tbody>
</table>
<asp:Button ID="bttnChangeEmail" runat="server" Text="OK" 
    onclick="bttnChangeEmail_Click" />
<br />
<br />

<br>
<table class="vis">
    <tbody>
        <tr>
            <td>
                Địa chỉ mail hiện tại:
            </td>
            <td>
                <b><% Response.Write(this.player.Email); %></b>
            </td>
        </tr>
    </tbody>
</table>
