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
                        Village Headquarters (<asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:text, barrack %>" />
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
                                        Village Headquarters</a> <span class="nowrap">(Level
                                            <% = this.village.Headquarter %>) </span>
                                </td>
                                <td>
                                    <img src="images/holz.png" title="Wood" alt="" /><asp:Label ID="lblHeadquarterWood" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="" /><asp:Label ID="lblHeadquarterClay" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="" /><asp:Label ID="lblHeadquarterIron" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt=""><asp:Label ID="lblHeadquarterPopulation" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
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
                                <td colspan="6" class="inactive" align="center">
                                    Building fully constructed
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=stable">
                                        <img src="images/stable.png" alt="">
                                        Stable</a> <span class="nowrap">(Level
                                            <% = this.village.Stable %>) </span>
                                </td>
                                <td colspan="6" class="inactive" align="center">
                                    Building fully constructed
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
                                    <img src="images/holz.png" title="Wood" alt="">953
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="">825
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="">826
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt="">3
                                </td>
                                <td>
                                    1:33:47
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
                                    <img src="images/holz.png" title="Wood" alt="">60000
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="">100000
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="">40000
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt="">16
                                </td>
                                <td>
                                    9:46:08
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
                                <td colspan="6" class="inactive" align="center">
                                    Building fully constructed
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=place">
                                        <img src="images/place.png" alt="">
                                        Rally point</a> <span class="nowrap">(Level 1) </span>
                                </td>
                                <td colspan="6" class="inactive" align="center">
                                    Building fully constructed
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
                                    <img src="images/holz.png" title="Wood" alt="">10172
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="">12889
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="">10172
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt="">67
                                </td>
                                <td>
                                    10:50:12
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
                                            <% = this.village.TimberCamp %>) </span>
                                </td>
                                <td colspan="6" class="inactive" align="center">
                                    Building fully constructed
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=stone">
                                        <img src="images/stone.png" alt="">
                                        Clay pit</a> <span class="nowrap">(Level
                                            <% = this.village.ClayPit %>) </span>
                                </td>
                                <td colspan="6" class="inactive" align="center">
                                    Building fully constructed
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=iron">
                                        <img src="images/iron.png" alt="">
                                        Iron mine</a> <span class="nowrap">(Level
                                            <% = this.village.IronMine %>) </span>
                                </td>
                                <td colspan="6" class="inactive" align="center">
                                    Building fully constructed
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=farm">
                                        <img src="images/farm.png" alt="">
                                        Farm</a> <span class="nowrap">(Level
                                            <% = this.village.Farm %>) </span>
                                </td>
                                <td colspan="6" class="inactive" align="center">
                                    Building fully constructed
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
                                    <img src="images/holz.png" title="Wood" alt="">43320
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="">40316
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="">18484
                                </td>
                                <td>
                                </td>
                                <td>
                                    17:36:11
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
                                    <img src="images/holz.png" title="Wood" alt="">50
                                </td>
                                <td>
                                    <img src="images/lehm.png" title="Clay" alt="">60
                                </td>
                                <td>
                                    <img src="images/eisen.png" title="Iron" alt="">50
                                </td>
                                <td>
                                    <img src="images/face.png" title="Villagers" alt="">2
                                </td>
                                <td>
                                    0:11:18
                                </td>
                                <td class="inactive" style="width: 200px;">
                                    The farm is too small
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=wall">
                                        <img src="images/wall.png" alt="">
                                        Wall</a> <span class="nowrap">(Level
                                            <% = this.village.Wall %>) </span>
                                </td>
                                <td colspan="6" class="inactive" align="center">
                                    Building fully constructed
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
                    <asp:TextBox ID="txtName" runat="server" Text=<%# this.village.Name %> 
                        Width="170px"></asp:TextBox>
                </td>
                <td>
                    <asp:UpdatePanel ID="pChangeName" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="bttnChangeVillageName" runat="server" Text="Đổi tên" 
                                onclick="bttnChangeVillageName_Click" />
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
