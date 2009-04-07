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
                        <% = this.village.Headquarter %>)</h2>
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
                                        <img src="images/main.png" alt="">
                                        <asp:Literal runat="server" Text="<%$ Resources:text, village_headquarter %>"></asp:Literal></a>
                                    <span class="nowrap">(Level
                                        <% = this.village.Headquarter %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.headquarter.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.headquarter.Clay %>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.headquarter.Iron %>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.headquarter.Population %>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.headquarter.BuildTime) %>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=barracks">
                                        <img src="images/barracks.png" alt="">
                                        Barracks</a> <span class="nowrap">(Level
                                            <% = this.village.Barracks %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.barrack.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.barrack.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.barrack.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.barrack.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.barrack.BuildTime)%>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=stable">
                                        <img src="images/stable.png" alt="">
                                        Stable</a> <span class="nowrap">(Level
                                            <% = this.village.Stable %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.stable.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.stable.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.stable.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.stable.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.stable.BuildTime)%>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=garage">
                                        <img src="images/garage.png" alt="">
                                        Workshop</a> <span class="nowrap">(Level
                                            <% = this.village.Workshop %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.workshop.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.workshop.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.workshop.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.workshop.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.workshop.BuildTime)%>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=snob">
                                        <img src="images/snob.png" alt="">
                                        Academy</a> <span class="nowrap">(Level
                                            <% =this.village.Academy %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.academy.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.academy.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.academy.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.academy.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.academy.BuildTime)%>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=smith">
                                        <img src="images/smith.png" alt="">
                                        Smithy</a> <span class="nowrap">(Level
                                            <% = this.village.Smithy %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.smithy.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.smithy.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.smithy.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.smithy.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.smithy.BuildTime)%>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=place">
                                        <img src="images/place.png" alt="">
                                        Rally point</a> <span class="nowrap">(Level 1) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.rally.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.rally.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.rally.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.rally.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.rally.BuildTime)%>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=market">
                                        <img src="images/market.png" alt="">
                                        Market</a> <span class="nowrap">(Level
                                            <% = this.village.Market %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.market.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.market.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.market.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.market.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.market.BuildTime)%>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=wood">
                                        <img src="images/wood.png" alt="">
                                        Timber camp</a> <span class="nowrap">(Level
                                            <% = this.village.Workshop %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.timber.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.timber.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.timber.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.timber.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.timber.BuildTime)%>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=stone">
                                        <img src="images/stone.png" alt="">
                                        Clay pit</a> <span class="nowrap">(Level
                                            <% = this.village.ClayPit %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.clay.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.clay.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.clay.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.clay.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.clay.BuildTime)%>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=iron">
                                        <img src="images/iron.png" alt="">
                                        Iron mine</a> <span class="nowrap">(Level
                                            <% = this.village.IronMine %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.iron.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.iron.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.iron.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.iron.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.iron.BuildTime)%>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=farm">
                                        <img src="images/farm.png" alt="">
                                        Farm</a> <span class="nowrap">(Level
                                            <% = this.village.Farm %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.farm.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.farm.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.farm.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.farm.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.farm.BuildTime)%>
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=storage">
                                        <img src="images/storage.png" alt="">
                                        Warehouse</a> <span class="nowrap">(Level
                                            <% = this.village.Warehouse %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.warehouse.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.warehouse.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.warehouse.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.warehouse.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.warehouse.BuildTime)%>
                                </td>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=main&amp;action=build&amp;id=storage&amp;h=b56c">
                                        Expansion to level 29</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=hide">
                                        <img src="images/hide.png" alt="">
                                        Hiding place</a> <span class="nowrap">(not constructed) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><% = this.hiding.Wood %>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><% = this.hiding.Clay%>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><% = this.hiding.Iron%>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><% = (int)this.hiding.Population%>
                                </td>
                                <td>
                                    <% = Functions.FormatTime(this.hiding.BuildTime)%>
                                </td>
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
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
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
