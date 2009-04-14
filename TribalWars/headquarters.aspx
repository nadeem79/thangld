<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true"
    CodeFile="headquarters.aspx.cs" Inherits="headquarters" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 118px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <table width="100%">
        <tbody>
            <tr>
                <td class="style1">
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
    <asp:Label ID="lblError" runat="server" Font-Size="Large" ForeColor="#FF3300"></asp:Label>
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
                    <asp:Repeater ID="rConstructing" runat="server">
                        <HeaderTemplate>
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <th width="220">
                                            Construction assignment
                                        </th>
                                        <th width="100">
                                            Duration
                                        </th>
                                        <th>
                                            Completion
                                        </th>
                                        <th width="202">
                                            Cancellation
                                        </th>
                                    </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                        <tr class="lit">
                        <td>
                            <%# beans.BuildingTypeFactory.ToString((beans.BuildingType)DataBinder.Eval(Container.DataItem, "Building")) %>
                        </td>
                        <td>
                            <span <%# this.FirstRow(Container.ItemIndex)%>><%# Functions.FormatTime((DateTime)DataBinder.Eval(Container.DataItem, "End") - (DateTime)DataBinder.Eval(Container.DataItem, "Start"))%></span>
                        </td>
                        <td>
                            <%# ((DateTime)DataBinder.Eval(Container.DataItem, "End")).ToString("hh:mm:ss dd/MM/yyyy") %>
                        </td>
                        <td>
                            <a href="headquarters.aspx?id=<% = this.village.ID %>&action=cancel_build&command=<%# DataBinder.Eval(Container.DataItem, "ID") %>" >Huỷ</a>
                        </td>
                        </tr>
                        
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td>
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
                                        <asp:Literal runat="server" Text="<%$ Resources:text, village_headquarter %>"></asp:Literal>
                                    </a><span class="nowrap">&nbsp;(Level
                                        <% = this.village.Headquarter %>)</span>
                                </td>
                                <asp:Label ID="lblBuildHeadquarters" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=barracks">
                                        <img src="images/barracks.png" alt="">
                                        Barracks</a> <span class="nowrap">(Level
                                            <% = this.village.Barracks %>) </span>
                                </td>
                                <asp:Label ID="lblBuildBarracks" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=stable">
                                        <img src="images/stable.png" alt="" />
                                        Stable</a> <span class="nowrap">(Level
                                            <% = this.village.Stable %>) </span>
                                </td>
                                <asp:Label ID="lblBuildStable" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=garage">
                                        <img src="images/garage.png" alt="" />
                                        Workshop</a> <span class="nowrap">(Level
                                            <% = this.village.Workshop %>) </span>
                                </td>
                                <asp:Label ID="lblBuildWorkshop" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=snob">
                                        <img src="images/snob.png" alt="">
                                        Academy</a> <span class="nowrap">(Level
                                            <% = this.village.Academy %>) </span>
                                </td>
                                <asp:Label ID="lblBuildAcademy" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=smith">
                                        <img src="images/smith.png" alt="">
                                        Smithy</a> <span class="nowrap">(Level
                                            <% = this.village.Smithy %>) </span>
                                </td>
                                <asp:Label ID="lblBuildSmithy" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=place">
                                        <img src="images/place.png" alt="">
                                        Rally point</a> <span class="nowrap">(Level
                                            <% = this.village.Rally %>) </span>
                                </td>
                                <asp:Label ID="lblBuildRally" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=market">
                                        <img src="images/market.png" alt="">
                                        Market</a> <span class="nowrap">(Level
                                            <% = this.village.Market %>) </span>
                                </td>
                                <asp:Label ID="lblBuildMarket" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=wood">
                                        <img src="images/wood.png" alt="">
                                        Timber camp</a> <span class="nowrap">(Level
                                            <% = this.village.TimberCamp %>) </span>
                                </td>
                                <asp:Label ID="lblBuildTimberCamp" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=stone">
                                        <img src="images/stone.png" alt="">
                                        Clay pit</a> <span class="nowrap">(Level
                                            <% = this.village.ClayPit %>) </span>
                                </td>
                                <asp:Label ID="lblBuildClayPit" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=iron">
                                        <img src="images/iron.png" alt="">
                                        Iron mine</a> <span class="nowrap">(Level
                                            <% = this.village.IronMine %>) </span>
                                </td>
                                <asp:Label ID="lblBuildIronMine" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=farm">
                                        <img src="images/farm.png" alt="">
                                        Farm</a> <span class="nowrap">(Level
                                            <% = (int)this.village.Farm %>) </span>
                                </td>
                                <asp:Label ID="lblBuildFarm" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=storage">
                                        <img src="images/storage.png" alt="">
                                        Warehouse</a> <span class="nowrap">(Level
                                            <% = this.village.Warehouse %>) </span>
                                </td>
                                <asp:Label ID="lblBuildWarehouse" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=hide">
                                        <img src="images/hide.png" alt="">
                                        Hiding place</a> <span class="nowrap">(Level
                                            <% = this.village.HidingPlace %>) </span>
                                </td>
                                <asp:Label ID="lblBuildHidingPlace" runat="server"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/game.php?village=51549&amp;screen=wall">
                                        <img src="images/wall.png" alt="">
                                        Wall</a> <span class="nowrap">(Level
                                            <% = this.village.Wall %>) </span>
                                </td>
                                <asp:Label ID="lblBuildWall" runat="server"></asp:Label>
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
                    <asp:TextBox ID="txtName" runat="server" Width="170px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="bttnChangeVillageName" runat="server" Text="Đổi tên" OnClick="bttnChangeVillageName_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
