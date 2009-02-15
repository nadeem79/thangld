<%@ Page Language="C#" MasterPageFile="~/outPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs"
    Inherits="Default2" Title="TribalWars - Đăng ký" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div id="screenshot" style="visibility: hidden" onclick="hide_screenshot();">
            <div id="screenshot_image">
            </div>
        </div>
        <div class="container-block-full">
            <div class="container-top-full">
            </div>
            <div class="container">
                <div class="info-block register">
                    <h3>
                        Mỗi người chơi chỉ được phép tạo một tài khoản</h3>
                    <br />
                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <label for="name">
                        User name:</label><br />
                    <asp:TextBox ID="username" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Phải chọn tên đăng nhập" ControlToValidate="username"></asp:RequiredFieldValidator>
                    <br />
                    <label for="password">
                        Password:</label><br />
                    <asp:TextBox ID="password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ErrorMessage="Phải nhập mật khẩu" ControlToValidate="password"></asp:RequiredFieldValidator>
                    <br />
                    <label for="password_confirm">
                        Repeat password:</label><br />
                    <asp:TextBox ID="retype_password" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Nhập sai mật khẩu" ControlToCompare="password" ControlToValidate="retype_password"></asp:CompareValidator>
                    <br />
                    <label for="email">
                        E-Mail:</label><br />
                    <span class="small">(Needed for activation)</span><br />
                    <asp:TextBox ID="email" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ErrorMessage="Email phải đúng định dạng" ControlToValidate="email" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <br /><label for="agb">
                        <asp:CheckBox ID="chkAgreement" runat="server" Text="Tôi đồng ý với các điều khoản đăng ký" />
                        </label>
&nbsp;<a href="javascript:popup_scroll('rules.php', 600, 480)">(Các điều khoản đăng ký)</a><br />
                    <asp:Button ID="bttnRegister" runat="server" Text="Đăng ký" 
                        onclick="bttnRegister_Click" />
                </div>
            </div>
            <div class="container-bottom-full">
            </div>
        </div>
    </div>
</asp:Content>
