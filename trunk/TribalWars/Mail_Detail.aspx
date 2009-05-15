<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="Mail_detail.aspx.cs"
    Inherits="Mail_detail" Title="Mail" %>

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
                                <td width="100" >
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
                    
                   <table class="vis" width="80%">
                       <tr>
                           <td style="background-color: #DFCCA6" class="style2">
                               Tiêu đề :</td>
                           <td colspan="3" class="style1" 
                               style="background-color: #DFCCA6; font-weight: 700;">
                               <% =Detail.Title %></td>
                       </tr>
                       <tr>
                           <td width="25%">
                               Người gửi :</td>
                           <td width="25%">
                               <% =Detail.To %></td>
                           <td width="25%">
                               Người nhận :</td>
                           <td width="25%">
                               <% =Detail.From %></td>
                       </tr>
                       <tr>
                           <td class="style1" >
                               </td>
                           <td class="style1">
                               </td>
                           <td class="style1" >
                               </td>
                           <td class="style1">
                               </td>
                       </tr>
                       <tr>
                           <td colspan="4" style="border: thin solid #993300; background-color: #FFFFFF" >
                           <% = Detail.Detail %>
                           </td>
                       </tr>
                       <tr>
                           <td >
                               &nbsp;</td>
                           <td>
                               &nbsp;</td>
                           <td >
                               &nbsp;</td>
                           <td>
                               &nbsp;</td>
                       </tr>
                   </table>
                    
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
      <asp:Content ID="Content3" runat="server" contentplaceholderid="head">

          <style type="text/css">
              .style1
              {
                  height: 20px;
              }
              .style2
              {
                  height: 20px;
                  font-weight: bold;
              }
          </style>

</asp:Content>

      