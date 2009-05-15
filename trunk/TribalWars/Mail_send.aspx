<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="Mail_send.aspx.cs"
    Inherits="Mail_send" Title="Mail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
 <h2>Hòm thư đi</h2>
    <table width="100%">
        <tbody>
            <tr>
                <td valign="top">
                    <table class="vis" width="100" runat="server" id="Mail" visible="True">
                        <tbody>
                            <tr>
                                <td width="100">
                                    <asp:HyperLink ID="urlMailReviece" runat="server" NavigateUrl="~/list_mail.aspx">Thư đến</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td class="selected" width="100" >
                                    <asp:HyperLink ID="urlMailSend" runat="server" NavigateUrl="~/write_mail.aspx">Thư đi</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <asp:HyperLink ID="urlComposeMail" runat="server" NavigateUrl="~/write_mail.aspx">Viết thư</asp:HyperLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
               <td valign="top" width="100%">
                    <asp:GridView ID="gvMail" runat="server" AutoGenerateColumns="False" 
                        Width="100%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                        <Columns>
                            <asp:HyperLinkField
                                DataTextField="Title" HeaderText="Tiêu đề" 
                                DataNavigateUrlFormatString="mail_details.aspx?id={0}" 
                                DataNavigateUrlFields="ID">
                                <ItemStyle Width="60%" />
                            </asp:HyperLinkField>
                            <asp:HyperLinkField
                                DataTextField="To" HeaderText="Người nhận"
                                DataNavigateUrlFormatString="write_mail.aspx?id={0}" 
                                DataNavigateUrlFields="To"> 
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="Time" HeaderText="Thời gian" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
      