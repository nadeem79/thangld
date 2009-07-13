<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="administrator_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập - Trang quản trị</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <h1>
                Đăng nhập</h1>
            <asp:Label ID="errorLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
            <table style="text-align:left;">
                <tbody>
                    <tr>
                        <td>
                            Tên đăng nhập:
                        </td>
                        <td>
                            <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox> <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập tên đăng nhập" ControlToValidate="usernameTextBox"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mật khẩu:
                        </td>
                        <td>
                            <asp:TextBox TextMode="Password" ID="passwordTextBox" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nhập mật khẩu" ControlToValidate="passwordTextBox"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center">
                            <asp:Button ID="authenticationButton" runat="server" Text="Đăng nhập" 
                                onclick="authenticationButton_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
