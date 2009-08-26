<%@ Page Title="" Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true"
    CodeFile="headquarters.aspx.cs" Inherits="headquarters" %>

<%@ Reference Control="CustomControls/ConstructBuilding.ascx" %>
<%@ Reference Control="CustomControls/DemolishBuilding.ascx" %>
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
                        <% = this.village.VillageBuildingData.Headquarter %>)</h2>
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
                                    <%# beans.BuildingTypeFactory.ToString((beans.BuildingType)DataBinder.Eval(Container.DataItem, "Building")) %> level <%# Eval("Level") %>
                                </td>
                                <td>
                                    <span <%# this.FirstRow(Container.ItemIndex)%>>
                                    <%# this.FirstRowTime(Container.ItemIndex, (beans.Build)Container.DataItem)%></span>
                                </td>
                                <td>
                                    <%# ((DateTime)DataBinder.Eval(Container.DataItem, "End")).ToString("lúc HH:mm:ss 'ngày' dd/MM/yyyy") %>
                                </td>
                                <td>
                                    <a href="headquarters.aspx?id=<% = this.village.ID %>&action=cancel_build&command=<%# DataBinder.Eval(Container.DataItem, "ID") %>">
                                        Huỷ</a>
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
                    <asp:PlaceHolder ID="phConstructing" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </tbody>
    </table>
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
                    <asp:UpdatePanel runat="server" ID="pChangeName" Visible="true">
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
