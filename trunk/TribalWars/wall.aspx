<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="wall.aspx.cs" Inherits="wall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<asp:Panel ID="pNotConstruct" runat="server" Visible="false">
        <h1>Công trình chưa được xây dựng</h1>
    </asp:Panel>
    <asp:Panel ID="pConstructed" runat="server" Visible="false">
<table><tbody><tr><td><img src="images/big_buildings/wall3.png" title="Wall" alt=""></td><td><h2>Wall Level <% = this.Village.VillageBuildingData.Wall%></h2>The wall defends your village against your enemies' troops. The higher its level the better the basic defense of your village. It also increases the defensive strength of your troops.</td></tr></tbody></table><br><table class="vis">
<tbody><tr><td width="200">Current</td>
<td width="200"><strong><% = this.Village.VillageBuildingData.BasicDefense %></strong> basic defence</td>
<td width="200"><strong><% = (this.Village.VillageBuildingData.Fortified * 100).ToString("0.00")%>%</strong> Defensive bonus</td>
</tr>


</tbody></table>
</asp:Panel>
</asp:Content>

