<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="administrator_login" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập - Trang quản trị</title>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/facebox.js"></script>
    <link rel="stylesheet" type="text/css" href="css/facebox.css" />
    
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <center>

            <telerik:RadScriptManager ID="RadScriptManager1" runat="server" OutputCompression="Forced"></telerik:RadScriptManager>
            <telerik:RadFormDecorator runat="server" RegisterWithScriptManager="true" />
            <h1>
                Đăng nhập</h1>
                <h1>
                    <telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" />
            </h1>
                <asp:UpdatePanel runat="server" ID="panel1">
                    <ContentTemplate>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
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
                            <asp:Button ID="authenticationButton" runat="server" Text="Đăng nhập" />
                            <asp:CustomValidator ID="AuthenticationValidator" runat="server" 
                                ErrorMessage="Tên đăng nhập hoặc mật khẩu không đúng" 
                                onservervalidate="CustomValidator1_ServerValidate" ControlToValidate="usernameTextBox"></asp:CustomValidator>
                        </td>
                    </tr>
                </tbody>
            </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="authenticationButton" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            
        </center>
    </div>
    </form>
</body>
</html>
