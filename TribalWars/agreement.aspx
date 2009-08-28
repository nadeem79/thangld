<%@ Page Title="" Language="C#" MasterPageFile="~/outPage.master" AutoEventWireup="true" CodeFile="agreement.aspx.cs" Inherits="agreement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
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
                    <asp:Label ID="lblAgreement" runat="server"></asp:Label>
                </div>
            </div>
            <div class="container-bottom-full">
            </div>
        </div>
    </div>
    
</asp:Content>

