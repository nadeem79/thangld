<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginBox.ascx.cs" Inherits="LoginBox" %>
<style type="text/css">
    .login-block
    {
        float: right;
        width: 250px;
        margin: 0 49px 0 0;
        padding: 15px 0 0;
        display: inline;
    }
    *
    {
        font: 10px/12px Verdana, Arial, Helvetica, sans-serif;
    }
    .login-block h2
    {
        text-align: center;
    }
    h2
    {
        margin: 0;
        font-size: 18px;
        line-height: 20px;
        color: #000;
    }
    .error
    {
        color: rgb(180, 0, 0);
        font-weight: bold;
        font-size: 14px;
    }
    .login-block div
    {
        overflow: hidden;
        margin: 0 0 25px;
        z-index: -999;
    }
    .login-block label
    {
        display: block;
        margin: 0;
        padding: 0 0 6px;
        width: 249px;
        overflow: hidden;
        z-index: -999;
    }
    td
    {
        font-size: 9pt;
    }
    .login-block label span
    {
        float: right;
        width: 120px;
        height: 18px;
        padding: 3px;
        background: url( 'images/bg-input-text.jpg' ) no-repeat;
        z-index: -999;
    }
    html
    {
        height: 100%;
        background: url( 'images/background.jpg' );
    }
    body
    {
        margin: 0;
    }
</style>
<div class="login-block">
    <h2 style="text-align: left; margin-bottom: 15px;">
        Tribal Wars - Đăng nhập
    </h2>
    <asp:Label ID="error" runat="server" CssClass="error" ForeColor="#FF3300"></asp:Label>
    <br />
    <div>
        <label for="user" title="Trang chủ">
            <table border="0" width="100%">
                <tr>
                    <td valign="top" align="right">
                        Tên đăng nhập:
                    </td>
                    <td>
                        <asp:TextBox ID="username" runat="server"></asp:TextBox>
                        <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username"
                            ErrorMessage="RequiredFieldValidator">Phải nhập username</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        Mật khẩu: 
                    </td>
                    <td>
                        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                        <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password"
                            ErrorMessage="RequiredFieldValidator">Phải nhập mật khẩu</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        Vào game: 
                    </td>
                    <td>
                        <asp:CheckBox ID="chkPlayGame" runat="server" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                        Tự đăng nhập: 
                    </td>
                    <td>
                        <asp:CheckBox ID="chkRemember" runat="server" />
                    </td>
                </tr>
            </table>
        </label>
        <asp:ImageButton ID="login" runat="server" ImageUrl="images/login1.png" OnClick="login_Click" />
    </div>
</div>
