<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TribeDiplomacy.ascx.cs"
    Inherits="TribeDiplomacy" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<p>
    On this page your relations with other tribes are administered. The settings are
    <strong>non-binding within the game</strong>, but villages will be coloured accordingly
    on the map. The status is visible only to tribe members and may be changed by tribal
    diplomats only.</p>
<table class="vis" width="300">
    <tr>
        <th colspan="2">
            Đồng minh
        </th>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvAllies" runat="server">
            </asp:GridView>
        </td>
    </tr>
</table>
<br />
<table class="vis" width="300">
    <tr>
        <th colspan="2">
            Trung lập
        </th>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvNaps" runat="server" Width="100%">
            </asp:GridView>
        </td>
    </tr>
</table>
<br />
<table class="vis" width="300">
    <tr>
        <th colspan="2">
            Thù địch
        </th>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvEnemies" runat="server">
            </asp:GridView>
        </td>
    </tr>
</table>
<h3>
    Add relationship</h3>
Tribe tag:&nbsp;
<telerik:RadTextBox ID="txtTag" runat="server">
</telerik:RadTextBox>
<telerik:RadComboBox ID="cbRelation" runat="server">
</telerik:RadComboBox>
<asp:Button ID="bttnAddRelation" runat="server" Text="OK" />
