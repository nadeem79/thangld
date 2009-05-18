<%@ Page Language="C#" MasterPageFile="~/ainPage.master" AutoEventWireup="true" CodeFile="aUser.aspx.cs"
    Inherits="aUser" Title="Danh sách User" %>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
 <h2>Danh sách User</h2>
    <table width="100%">
        <tbody>
            <tr>
                <td valign="top" width="100%">
                    <asp:GridView ID="gvuser" runat="server" AutoGenerateColumns="False" 
                        Width="100%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="5%" DataField="Id" HeaderText="STT" />                      
                            <asp:HyperLinkField
                                DataTextField="Username" HeaderText="Tên Tài khoản"
                                DataNavigateUrlFormatString="auser_details.aspx?id={0}" 
                                DataNavigateUrlFields="Id">
                            <ItemStyle Width="40%" />   
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="Email" HeaderText="Hòm thư" />
                         
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
      