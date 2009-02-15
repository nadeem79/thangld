<%@ Page Language="C#" MasterPageFile="~/outPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs"
    Inherits="index" Title="TribalWars - Trang chủ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="container-block">
            <div class="container-top">
            </div>
            <div class="container">
                <div class="info-block">
                    <img src="images/bg-raven.gif" alt="" />
                    <h2>
                        Tribal Wars</h2>
                    <p>
                        Tribal Wars là game mô phỏng chiến tranh trung cổ chơi trên trình duyệt web.</p>
                    <a class="btn-kostenlos-anmelden" href="register.aspx">Đăng ký</a> <strong>Screenshots:</strong>
                    <ul class="screenshots">
                        <li><a href="javascript:toggle_screenshot(1)">
                            <img src="images/bg-screenshots-thumb-1.jpg" alt="" /></a></li>
                        <li><a href="javascript:toggle_screenshot(2)">
                            <img src="images/bg-screenshots-thumb-2.jpg" alt="" /></a></li>
                        <li class="last"><a href="javascript:toggle_screenshot(3)">
                            <img src="images/bg-screenshots-thumb-3.jpg" alt="" /></a></li>
                    </ul>
                    &nbsp;</div>
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
                                    <td rowspan="2" valign="top" align="right">
                                        Tên đăng nhập:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="username" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username"
                                            ErrorMessage="RequiredFieldValidator">Phải nhập username</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td rowspan="2" valign="top" align="right">
                                        Mật khẩu
                                    </td>
                                    <td>
                                        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password"
                                            ErrorMessage="RequiredFieldValidator">Phải nhập mật khẩu</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </label>
                        <asp:ImageButton ID="login" runat="server" ImageUrl="images/login1.png" OnClick="login_Click" />
                        <br style="clear: both;" />
                        <asp:CheckBox ID="cookie" runat="server" Text="Tự đăng nhập" />
                        </label>
                    </div>
                </div>
            </div>
            <div class="container-bottom">
            </div>
        </div>
    </div>
    </div> </div>
</asp:Content>
