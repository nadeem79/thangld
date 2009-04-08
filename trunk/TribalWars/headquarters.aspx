<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true"
    CodeFile="headquarters.aspx.cs" Inherits="headquarters" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <table width="100%">
        <tbody>
            
            <tr>
                <td>
                    <img src="images/main_big.png" alt="Village Headquarters">
                </td>
                <td width="100%">
                    <h2>
                        Village Headquarters (<asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:text, level %>" />
                        <% = (int)this.wall.Population%>)</h2>
                    In the village headquarters you can construct new buildings or upgrade existing
                    ones. The higher the level of your headquarters, the faster the constructions will
                    be finished. As soon as your village headquarters are upgraded to level 15, you
                    will be able to demolish buildings.
                </td>
                <td style="white-space: nowrap;" align="right" valign="top">
                    <a href="help2.php?article=buildings" target="_blank">buildings Help pages </a>
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <br />
    <table cellpadding="0" cellspacing="0">
        <tbody>
            <tr>
                <td valign="top">
                    <table class="vis">
                        <tbody>
                            <tr>
                                <td class="selected" width="100">
                                    <a href="/game.php?village=51549&amp;screen=main&amp;mode=build">Construct</a>
                                </td>
                                <td width="100">
                                    <a href="/game.php?village=51549&amp;screen=main&amp;mode=destroy">Demolition</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="vis">
                        <tbody>
                            <tr>
                                <th width="220">
                                    Buildings
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
                                        <asp:Literal runat="server" Text="<%$ Resources:text, village_headquarter %>"></asp:Literal></a>
                                    <span class="nowrap"> (Level
                                        <% = Functions.FormatTime(this.wall.BuildTime)%>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = (int)this.hiding.Population%>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = Functions.FormatTime(this.hiding.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.village.Wall %>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = this.wall.Wood %>
                                </td>
                                <td>
                                    <% = this.wall.Clay%>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeHeadquarter" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=barracks">
                                        <img src="images/barracks.png" alt="">
                                        Barracks</a> <span class="nowrap">(Level
                                            <% = this.wall.Iron%>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = (int)this.wall.Population%>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = Functions.FormatTime(this.wall.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = (int)this.hiding.Population%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = Functions.FormatTime(this.hiding.BuildTime)%>
                                </td>
                                <td>
                                    <% = this.village.Wall %>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeBarrack" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=stable">
                                        <img src="images/stable.png" alt="" />
                                        Stable</a> <span class="nowrap">(Level
                                            <% = this.wall.Wood %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.wall.Clay%>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.wall.Iron%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = (int)this.wall.Population%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = Functions.FormatTime(this.wall.BuildTime)%>
                                </td>
                                <td>
                                    <% = (int)this.hiding.Population%>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeStable" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=garage">
                                        <img src="images/garage.png" alt="" />
                                        Workshop</a> <span class="nowrap">(Level
                                            <% = Functions.FormatTime(this.hiding.BuildTime)%>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.village.Wall %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.wall.Wood %>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.wall.Clay%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = this.wall.Iron%>
                                </td>
                                <td>
                                    <% = (int)this.wall.Population%>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeWorkshop" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=snob">
                                        <img src="images/snob.png" alt="">
                                        Academy</a> <span class="nowrap">(Level
                                            <% = Functions.FormatTime(this.wall.BuildTime)%>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = (int)this.hiding.Population%>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = Functions.FormatTime(this.hiding.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.village.Wall %>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = this.wall.Wood %>
                                </td>
                                <td>
                                    <% = this.wall.Clay%>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeAcademy" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=smith">
                                        <img src="images/smith.png" alt="">
                                        Smithy</a> <span class="nowrap">(Level
                                            <% = this.wall.Iron%>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = (int)this.wall.Population%>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = Functions.FormatTime(this.wall.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = (int)this.hiding.Population%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = Functions.FormatTime(this.hiding.BuildTime)%>
                                </td>
                                <td>
                                    <% = this.village.Wall %>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeSmithy" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=place">
                                        <img src="images/place.png" alt="">
                                        Rally point</a> <span class="nowrap">(Level 1) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.wall.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.wall.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.wall.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.wall.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.wall.BuildTime)%>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeRally" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=market">
                                        <img src="images/market.png" alt="">
                                        Market</a> <span class="nowrap">(Level
                                            <% = (int)this.hiding.Population%>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = Functions.FormatTime(this.hiding.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.village.Wall %>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.wall.Wood %>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = this.wall.Clay%>
                                </td>
                                <td>
                                    <% = this.wall.Iron%>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeMarket" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=wood">
                                        <img src="images/wood.png" alt="">
                                        Timber camp</a> <span class="nowrap">(Level
                                            <% = (int)this.wall.Population%>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = Functions.FormatTime(this.wall.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = (int)this.hiding.Population%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = Functions.FormatTime(this.hiding.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = this.village.Wall %>
                                </td>
                                <td>
                                    <% = this.wall.Wood %>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeTimbercamp" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=stone">
                                        <img src="images/stone.png" alt="">
                                        Clay pit</a> <span class="nowrap">(Level
                                            <% = this.wall.Clay%>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.wall.Iron%>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = (int)this.wall.Population%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = Functions.FormatTime(this.wall.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.hiding.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.hiding.BuildTime)%>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeClaypit" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=iron">
                                        <img src="images/iron.png" alt="">
                                        Iron mine</a> <span class="nowrap">(Level
                                            <% = this.village.Wall %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.wall.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.wall.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.wall.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.wall.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.wall.BuildTime)%>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeIronmine" runat="server" 
                                        >Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=farm">
                                        <img src="images/farm.png" alt="">
                                        Farm</a> <span class="nowrap">(Level
                                            <% = (int)this.hiding.Population%>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = Functions.FormatTime(this.hiding.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.village.Wall %>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.wall.Wood %>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = this.wall.Clay%>
                                </td>
                                <td>
                                    <% = this.wall.Iron%>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeFarm" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=storage">
                                        <img src="images/storage.png" alt="">
                                        Warehouse</a> <span class="nowrap">(Level
                                            <% = (int)this.wall.Population%>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = Functions.FormatTime(this.wall.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = (int)this.hiding.Population%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = Functions.FormatTime(this.hiding.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = this.village.Wall %>
                                </td>
                                <td>
                                    <% = this.wall.Wood %>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeWarehouse" runat="server">Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=hide">
                                        <img src="images/hide.png" alt="">
                                        Hiding place</a> <span class="nowrap">(Level <% = this.wall.Clay%>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.wall.Iron%>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = (int)this.wall.Population%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = Functions.FormatTime(this.wall.BuildTime)%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.hiding.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.hiding.BuildTime)%>
                                </td>
                                <td  style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeHidingplace" runat="server" 
                                        >Nâng cấp</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=wall">
                                        <img src="images/wall.png" alt="">
                                        Wall</a> <span class="nowrap">(Level
                                            <% = this.village.Wall %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.wall.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.wall.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.wall.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.wall.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.wall.BuildTime)%>
                                </td>
                                <td style="width: 200px;">
                                   <asp:LinkButton ID="bttnUpgradeHeadquarter13" runat="server" 
                                        >Nâng cấp</asp:LinkButton></td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Vista" DecoratedControls="All" />
    <table>
        <tbody>
            <tr>
                <th colspan="3">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:text, change_village_name %>" />:
                </th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Text="<%# this.village.Name %>" Width="170px"></asp:TextBox>
                </td>
                <td>
                    <asp:UpdatePanel ID="pChangeName" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="bttnChangeVillageName" runat="server" Text="Đổi tên" OnClick="bttnChangeVillageName_Click" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="bttnChangeVillageName" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
