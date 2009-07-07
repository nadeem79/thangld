<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConstructBuilding.ascx.cs"
    Inherits="CustomControls_ConstructBuilding" %>
<table class="vis">
    <tbody>
        <tr>
            <th width="220">
                Buildings
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </th>
            <th colspan="4">
                Requirements
            </th>
            <th width="100">
                Construction time(hh:mm:ss)
            </th>
            <th style="width: 200px;">
                Construct
            </th>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=main">
                    <img src="images/main.png" alt="" />
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:text, village_headquarter %>"></asp:Literal>
                </a><span class="nowrap">&nbsp;(Level
                    <% = this.Village.VillageBuildingData.Headquarter%>)</span>
            </td>
            <asp:Label ID="lblBuildHeadquarters" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=barracks">
                    <img src="images/barracks.png" alt="">
                    Barracks</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.Barracks %>) </span>
            </td>
            <asp:Label ID="lblBuildBarracks" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=stable">
                    <img src="images/stable.png" alt="" />
                    Stable</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.Stable%>) </span>
            </td>
            <asp:Label ID="lblBuildStable" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=garage">
                    <img src="images/garage.png" alt="" />
                    Workshop</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.Workshop%>) </span>
            </td>
            <asp:Label ID="lblBuildWorkshop" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=snob">
                    <img src="images/snob.png" alt="">
                    Academy</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.Academy%>) </span>
            </td>
            <asp:Label ID="lblBuildAcademy" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=smith">
                    <img src="images/smith.png" alt="">
                    Smithy</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.Smithy%>) </span>
            </td>
            <asp:Label ID="lblBuildSmithy" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=place">
                    <img src="images/place.png" alt="">
                    Rally point</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.Rally%>) </span>
            </td>
            <asp:Label ID="lblBuildRally" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=market">
                    <img src="images/market.png" alt="">
                    Market</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.Market%>) </span>
            </td>
            <asp:Label ID="lblBuildMarket" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=wood">
                    <img src="images/wood.png" alt="">
                    Timber camp</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.TimberCamp%>) </span>
            </td>
            <asp:Label ID="lblBuildTimberCamp" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=stone">
                    <img src="images/stone.png" alt="">
                    Clay pit</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.ClayPit%>) </span>
            </td>
            <asp:Label ID="lblBuildClayPit" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=iron">
                    <img src="images/iron.png" alt="">
                    Iron mine</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.IronMine%>) </span>
            </td>
            <asp:Label ID="lblBuildIronMine" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=farm">
                    <img src="images/farm.png" alt="">
                    Farm</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.Farm%>) </span>
            </td>
            <asp:Label ID="lblBuildFarm" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=storage">
                    <img src="images/storage.png" alt="">
                    Warehouse</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.Warehouse%>) </span>
            </td>
            <asp:Label ID="lblBuildWarehouse" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=hide">
                    <img src="images/hide.png" alt="">
                    Hiding place</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.HidingPlace%>) </span>
            </td>
            <asp:Label ID="lblBuildHidingPlace" runat="server"></asp:Label>
        </tr>
        <tr>
            <td>
                <a href="/game.php?village=51549&amp;screen=wall">
                    <img src="images/wall.png" alt="">
                    Wall</a> <span class="nowrap">(Level
                        <% = this.Village.VillageBuildingData.Wall%>) </span>
            </td>
            <asp:Label ID="lblBuildWall" runat="server"></asp:Label>
        </tr>
    </tbody>
</table>
