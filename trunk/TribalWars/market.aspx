<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true"
    CodeFile="market.aspx.cs" Inherits="market" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="images/big_buildings/market3.png" title="Market" alt="">
                </td>
                <td>
                    <h2>
                        Market Level <% = this.Village.Buildings.Market %></h2>
                    On the market you can trade with other players.
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <table>
        <tbody>
            <tr>
                <td valign="top">
                    <table class="vis">
                        <tbody>
                            <tr>
                                <td width="100">
                                    <a href="market.aspx?id=<%= this.Village.ID %>">Gửi tài nguyên</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="market.aspx?id=<%= this.Village.ID %>&page=make_offer">Your offers</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="market.aspx?id=<%= this.Village.ID %>&page=market">Other offers</a>
                                </td>
                            </tr>
                            <tr>
                                <td class="selected" width="100">
                                    <a href=""market.aspx?id=<%= this.Village.ID %>&page=status"">Merchant status</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top">
                    
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
