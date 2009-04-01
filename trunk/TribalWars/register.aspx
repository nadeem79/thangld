<%@ Page Language="C#" MasterPageFile="~/outPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs"
    Inherits="Default2" Title="TribalWars - Đăng ký" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Office2007" />
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
                        Tên đăng nhập:</label><br />
                    <br />
                    <telerik:RadTextBox ID="username" runat="server">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Phải chọn tên đăng nhập"
                        ControlToValidate="username"></asp:RequiredFieldValidator>
                    <br />
                    <label for="password">
                        Mật khẩu:</label><br />
                    <br />
                    <telerik:RadTextBox ID="password" runat="server" TextMode="Password">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Phải nhập mật khẩu"
                        ControlToValidate="password"></asp:RequiredFieldValidator>
                    <br />
                    <label for="password_confirm">
                        Nhập lại mật khẩu:</label><br />
                    <br />
                    <telerik:RadTextBox ID="retype_password" runat="server" TextMode="Password">
                    </telerik:RadTextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Nhập sai mật khẩu"
                        ControlToCompare="password" ControlToValidate="retype_password"></asp:CompareValidator>
                    <br />
                    <label for="email">
                        E-Mail:</label><br />
                    <br />
                    <telerik:RadTextBox ID="email" runat="server">
                    </telerik:RadTextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email phải đúng định dạng"
                        ControlToValidate="email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <br />
                    <label>
                        Ngày sinh (định dạng dd/mm/yyyy):<br />
                        <br />
                        <telerik:RadDateInput ID="txtBirthdate" DisplayDateFormat="d/M/yyyy" Width="192px"
                            MinDate="1950-01-01" DateFormat="d/M/yyyy" runat="server" EmptyMessage="Nhập ngày sinh">
                        </telerik:RadDateInput>
                    </label>
                    <br />
                    <label for="agb">
                        <asp:CheckBox ID="chkAgreement" runat="server" Text="Tôi đồng ý với các điều khoản đăng ký" />
                    </label>
                    &nbsp;<a href="javascript:popup_scroll('rules.php', 600, 480)">(Các điều khoản đăng
                        ký)</a><br />
                    <asp:Button ID="bttnRegister" runat="server" Text="Đăng ký" OnClick="bttnRegister_Click" />
                </div>
            </div>
            <div class="container-bottom-full">
            </div>
        </div>
    </div>
</asp:Content>
