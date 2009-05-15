<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="write_mail.aspx.cs" 
    Inherits="write_mail" Title="WriteMail" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="Server">
    <h2>Viết thư</h2>
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
                                <td width="100">
                                    <asp:HyperLink ID="urlMailSend" runat="server" NavigateUrl="~/Mail_send.aspx">Thư đi</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td class="selected" width="100">
                                    <asp:HyperLink ID="urlComposeMail" runat="server" NavigateUrl="~/write_mail.aspx">Viết thư</asp:HyperLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
               <td valign="top" width="100%">
               <table class ="vis" width = "80%">
                <td>
                   <asp:PlaceHolder ID="Pmail" runat="server"></asp:PlaceHolder>
                </td>
               </table>
               </td>
            </tr>
        </tbody>
    </table>

 </asp:Content>
      
      