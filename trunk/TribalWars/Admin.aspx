<%@ Page Language="C#" MasterPageFile="~/outPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs"
    Inherits="admin" Title="TribalWars - Trang chủ" %>
<%@ Reference Control="aLoginBox.ascx" %>
<%@ Reference Control="aPlayerBox.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="container-block">
            <div class="container-top">
            </div>
            <div class="container">
                <div class="info-block">
                    <img src="images/bg-raven.gif" alt="" />
                    <h2>
                        <a href="">Tribal Wars</a></h2>
                    <p>
                        Tribal Wars là game mô phỏng chiến tranh trung cổ chơi trên trình duyệt web.</p>
                    <strong>
                    Screenshots:</strong>
                    <ul class="screenshots">
                        <li><a href="images/screenshot-1.jpg" class="lightbox">
                            <img src="images/bg-screenshots-thumb-1.jpg" alt="" /></a></li>
                        <li><a href="images/screenshot-2.jpg" class="lightbox">
                            <img src="images/bg-screenshots-thumb-2.jpg" alt="" /></a></li>
                        <li class="last"><a href="images/screenshot-3.jpg" class="lightbox">
                            <img src="images/bg-screenshots-thumb-3.jpg" alt="" /></a></li>
                        <li> <strong>
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </strong>
                        </li>
                    </ul>
                </div>
                <asp:PlaceHolder ID="pBox" runat="server"></asp:PlaceHolder>
            </div>
            <div class="container-bottom">
            </div>
        </div>
    </div>
</asp:Content>
