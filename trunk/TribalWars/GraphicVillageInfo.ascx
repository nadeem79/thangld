<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GraphicVillageInfo.ascx.cs"
    Inherits="GraphicVillageInfo" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Label ID="lblError" runat="server" ForeColor="#FF3300"></asp:Label>
<table width="100%">
    <tbody>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="bttnHideBuildingLevel" runat="server" OnClick="bttnHideBuildingLevel_Click">Xoá hiển thị nâng cấp công trình</asp:LinkButton>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="bttnHideBuildingLevel" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td align="right">
                <asp:LinkButton ID="bttnSwitchTextVillageOverview" runat="server" OnClick="bttnSwitchTextVillageOverview_Click">Hiển thị dạng văn bản</asp:LinkButton>
            </td>
        </tr>
    </tbody>
</table>
<table style="border: 1px solid rgb(128, 64, 0); background-color: rgb(241, 235, 221);
    direction: ltr;" align="center" cellpadding="0" cellspacing="0">
    <tbody>
        <tr>
            <td style="padding: 0pt;">
                <div style="position: relative;">
                    <img src="images/back_none.jpg" alt="" height="418" width="600" />
                    <img class="p_church" src="images/church_disabled.png" alt="" />
                    <img class="p_main_flag" src="images/mainflag3.gif" />
                    <img class="p_main" src="images/main3.png" alt="Village Headquarters" />
                    <img class="p_barracks" src="images/barracks3.png" alt="Barracks" />
                    <img class="p_stable" src="images/stable3.png" alt="Stable" />
                    <img class="p_garage" src="images/garage2.png" alt="Workshop" />
                    <img class="p_snob" src="images/snob1.png" alt="Academy" />
                    <img class="p_smith" src="images/smith3.png" alt="Smithy" />
                    <img class="p_place" src="images/place1.png" alt="Rally point" />
                    <img class="p_market" src="images/market3.png" alt="Market" />
                    <img class="p_wood" src="images/wood3.gif" alt="Timber camp" />
                    <img class="p_stone" src="images/stone3.gif" alt="Clay pit" />
                    <img class="p_iron" src="images/iron3.gif" alt="Iron mine" />
                    <img class="p_farm_field" src="images/farm3_field.png" alt="Farm" />
                    <img class="p_farm" src="images/farm3.png" alt="Farm" />
                    <img class="p_storage" src="images/storage3.png" alt="Warehouse" />
                    <img class="p_wall" src="images/wall3.png" alt="Wall" />
                    <img class="empty" src="images/empty.png" alt="" usemap="#map" />
                    <map name="map" id="map">
                        <area shape="poly" coords="373,187,417,129,407,72,329,65,306,99,311,150" href="headquarters.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Village Headquarters" title="Village Headquarters" />
                        <area shape="poly" coords="392,289,444,313,506,283,481,235,442,216,392,252" href="barrack.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Barracks" title="Barracks" />
                        <area shape="poly" coords="64,241,70,265,150,307,189,289,184,232,99,202" href="stable.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Stable" title="Stable" />
                        <area shape="poly" coords="284,358,362,361,402,321,369,283,346,278,291,320" href="workshop.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Workshop" title="Workshop" />
                        <area shape="poly" coords="206,149,257,125,229,60,185,80,156,111" href="academy.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Academy" title="Academy" />
                        <area shape="poly" coords="174,335,222,361,271,342,283,301,216,262" href="smithy.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Smithy" title="Smithy" />
                        <area shape="poly" coords="315,271,379,275,401,229,375,206,343,207" href="rally.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Rally point" title="Rally point" />
                        <area shape="poly" coords="214,149,234,228,313,230,330,169,273,122" href="market.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Market" title="Market" />
                        <area shape="poly" coords="472,379,523,417,583,373,528,330" href="wood.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Timber camp" title="Timber camp" />
                        <area shape="poly" coords="34,300,0,349,15,399,67,417,91,402,92,341" href="clay.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Clay pit" title="Clay pit" />
                        <area shape="poly" coords="0,55,45,90,93,58,89,6,39,9" href="iron.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Iron mine" title="Iron mine" />
                        <area shape="poly" coords="456,0,477,41,526,75,583,88,597,18,597,0" href="farm.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Farm" title="Farm" />
                        <area shape="poly" coords="96,192,153,218,195,215,193,148,133,121" href="warehouse.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Warehouse" title="Warehouse" />
                        <area shape="poly" coords="428,333,430,382,472,363,470,318" href="wall.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>"
                            alt="Wall" title="Wall" />
                    </map>
                    <div style="display: inline;" id="l_main" class="l_main" title="Village Headquarters">
                        <div class="label">
                            <a href="headquarters.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/main.png" class="middle" alt="Village Headquarters" />
                                <% Response.Write(this.CurrentVillage.Headquarter); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_barracks" class="l_barracks" title="Barracks">
                        <div class="label">
                            <a href="barrack.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/barracks.png" class="middle" alt="Barracks">
                                <% Response.Write(this.CurrentVillage.Barracks); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_stable" class="l_stable" title="Stable">
                        <div class="label">
                            <a href="stable.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/stable.png" class="middle" alt="Stable">
                                <% Response.Write(this.CurrentVillage.Stable); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_garage" class="l_garage" title="Workshop">
                        <div class="label">
                            <a href="workshop.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/garage.png" class="middle" alt="Workshop" />
                                <% Response.Write(this.CurrentVillage.Workshop); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_snob" class="l_snob" title="Academy">
                        <div class="label">
                            <a href="academy.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/snob.png" class="middle" alt="Academy">
                                <% Response.Write(this.CurrentVillage.Academy); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_smith" class="l_smith" title="Smithy">
                        <div class="label">
                            <a href="smithy.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/smith.png" class="middle" alt="Smithy" />
                                <% Response.Write(this.CurrentVillage.Smithy); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_place" class="l_place" title="Rally point">
                        <div class="label">
                            <a href="rally.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/place.png" class="middle" alt="Rally point" />
                                <% Response.Write(this.CurrentVillage.Rally); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_market" class="l_market" title="Market">
                        <div class="label">
                            <a href="market.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/market.png" class="middle" alt="Market" />
                                <% Response.Write(this.CurrentVillage.Market); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_wood" class="l_wood" title="Timber camp">
                        <div class="label">
                            <a href="wood.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/wood.png" class="middle" alt="Timber camp" />
                                <% Response.Write(this.CurrentVillage.TimberCamp); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_stone" class="l_stone" title="Clay pit">
                        <div class="label">
                            <a href="clay.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/stone.png" class="middle" alt="Clay pit" />
                                <% Response.Write(this.CurrentVillage.ClayPit); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_iron" class="l_iron" title="Iron mine">
                        <div class="label">
                            <a href="iron.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/iron.png" class="middle" alt="Iron mine" />
                                <% Response.Write(this.CurrentVillage.IronMine); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_farm" class="l_farm" title="Farm">
                        <div class="label">
                            <a href="farm.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/farm.png" class="middle" alt="Farm" />
                                <% Response.Write(this.CurrentVillage.Farm); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_storage" class="l_storage" title="Warehouse">
                        <div class="label">
                            <a href="warehouse.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/storage.png" class="middle" alt="Warehouse">
                                <% Response.Write(this.CurrentVillage.Warehouse); %></a></div>
                    </div>
                    <div style="display: inline;" id="l_wall" class="l_wall" title="Wall">
                        <div class="label">
                            <a href="wall.aspx?id=<% Response.Write(this.CurrentVillage.ID); %>">
                                <img src="images/wall.png" class="middle" alt="Wall" />
                                <% Response.Write(this.CurrentVillage.Wall); %></a></div>
                    </div>
                    <img class="npc_conversation" src="images/conversation.gif" />
                    <img class="npc_guard" src="images/guard.gif" /></div>
                <% if (!this.DisplayBuildingLevel) Response.Write("<script type='text/javascript'>overviewHideLevel();</script>"); %>
            </td>
        </tr>
    </tbody>
</table>
