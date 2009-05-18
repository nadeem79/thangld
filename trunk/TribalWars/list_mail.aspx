<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="list_mail.aspx.cs"
    Inherits="list_mail" Title="Mail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
 <h2>Hòm thư đến</h2>
    <table width="100%">
        <tbody>
            <tr>
                <td valign="top">
                    <table class="vis" width="100" runat="server" id="Mail" visible="True">
                        <tbody>
                            <tr>
                                <td class="selected" width="100">
                                    <asp:HyperLink ID="urlMailReviece" runat="server" NavigateUrl="~/list_mail.aspx">Thư đến</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <asp:HyperLink ID="urlMailSend" runat="server" NavigateUrl="~/Mail_send.aspx">Thư đi</asp:HyperLink>
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
                                DataNavigateUrlFields="Id">
                            <ItemStyle Width="60%" />   
                            </asp:HyperLinkField>
                            <asp:HyperLinkField
                                DataTextField="From" HeaderText="Người gửi"
                                DataNavigateUrlFormatString="write_mail.aspx?id={0}" 
                                DataNavigateUrlFields="From"> 
                            </asp:HyperLinkField>    
                            <asp:BoundField DataField="Time" HeaderText="Thời gian" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
      