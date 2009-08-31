<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="rally.aspx.cs"
    Inherits="rally" Title="Medieval War - Trại Lính" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%@ Reference Control="CustomControls/TroopCommand.ascx" %>
<%@ Reference Control="CustomControls/TroopStat.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
<asp:Panel ID="pNotConstruct" runat="server" Visible="false">
        <h1>Công trình chưa được xây dựng</h1>
    </asp:Panel>
    <asp:Panel ID="pConstructed" runat="server" Visible="false">
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="images/place1.png" title="Rally point" alt="" />
                </td>
                <td>
                    <h2>
                        Rally point Level <% = this.village.VillageBuildingData.Rally %></h2>
                    On the rally point your fighters meet. Here you can command your armies.
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <table width="100%">
        <tbody>
            <tr>
                <td valign="top" width="100">
                    <table class="vis" id="tblMenu" runat="server">
                        <tbody>
                            <tr>
                                <td width="100">
                                    <a href="rally.aspx?id=<%=this.village.ID %>">Commands</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="rally.aspx?id=<%=this.village.ID %>&page=unit">Troops</a>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <a href="rally.aspx?id=<%=this.village.ID %>&page=sim">Simulator</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top" width="*">
                    <asp:PlaceHolder ID="troopPanel" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </tbody>
    </table>
    </asp:Panel>
</asp:Content>
