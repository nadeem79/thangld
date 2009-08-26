<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="stable.aspx.cs"
    Inherits="stable"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="images/stable3.png" title="Stable" alt="">
                </td>
                <td>
                    <h2>
                        
                        Trại ngựa cấp <% Response.Write(this.village.VillageBuildingData.Stable); %></h2>
                    In the stables you can recruit cavalry. The higher its level the faster the recruitment
                    of the troops will be finished.
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <br />
    <asp:Label ID="lblError" runat="server" Font-Size="14pt" ForeColor="Red"></asp:Label>
   <br />
    <br />
    <asp:Repeater runat="server" ID="rCavalryRecruits">
        <HeaderTemplate>
            <table class="vis">
        <tbody>
            <tr>
                <th width="150">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:text, training %>" />
                </th>
                <th width="120">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:text, duration %>" />
                </th>
                <th width="300">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:text, completion %>" />
                </th>
                <th width="120">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:text, cancel %>" />
                </th>
            </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </tbody></table>
        </FooterTemplate>
        <ItemTemplate>
            <tr class='lit'>
                <td>
                    <%# Eval("Quantity") %> <%# TroopTypeString((beans.TroopType)Eval("Troop")) %>
                </td>
                <td>
                    <span <%# this.FirstRow(Container.ItemIndex) %>><%# this.FirstRowTime(Container.ItemIndex, (beans.Recruit)Container.DataItem)%></span>
                </td>
                <td>
                    <%# ((DateTime)Eval("FinishTime")).ToString("HH:mm:ss 'ngày' dd/MM/yyyy")%>
                </td>
                <td>
                    <a href="stable.aspx?id=<% = this.village.ID %>&mode=cancel_recruit&recruit_id=<%# Eval("ID") %>">Huỷ</a>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <table class="vis">
        <tbody>
            <tr>
                <th width="190">
                    Unit
                </th>
                <th colspan="4" width="200">
                    Requirements
                </th>
                <th width="120">
                    Time (hh:mm:ss)
                </th>
                <th>
                    In the village/total
                </th>
                <th>
                    Recruit
                </th>
            </tr>
            <tr class="row_a">
                <td>
                    <a href="javascript:popup_scroll('popup_unit.php?unit=spy', 520, 520)">
                        <img src="images/unit_spy.png" alt="">
                        Scout</a>
                </td>
                <td class="nowrap">
                    <img src="images/holz.png" title="Wood" alt="">
                    <% = this.scoutPrice.Wood %>
                </td>
                <td class="nowrap">
                    <img src="images/lehm.png" title="Clay" alt="">
                    <% = this.scoutPrice.Clay %>
                </td>
                <td class="nowrap">
                    <img src="images/eisen.png" title="Iron" alt="">
                    <% = this.scoutPrice.Iron %>
                </td>
                <td class="nowrap">
                    <img src="images/face.png" title="Villagers" alt="">
                    <% = this.scoutPrice.Population %>
                </td>
                <td>
                    <% = Functions.FormatTime(scoutPrice.BuildTime) %>
                </td>
                <td>
                    <% Response.Write(this.village.VillageTroopData.Scout.ToString()); %>/<%Response.Write(this.village.VillageTroopData.ScoutOfVillage.ToString()); %>
                </td>
                <td>
                    <asp:TextBox ID="txtScout" runat="server" Width="33px"></asp:TextBox>
                    &nbsp;(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.txtScout.ClientID); %>', <% Response.Write(this.village.VillageRecruitMethods.MaxRecruit(beans.TroopType.Scout)); %>)"><%Response.Write(this.village.VillageRecruitMethods.MaxRecruit(beans.TroopType.Scout)); %></a>)
                </td>
            </tr>
            <tr class="row_a">
                <td>
                    <a href="javascript:popup_scroll('popup_unit.php?unit=light', 520, 520)">
                        <img src="images/unit_light.png" alt="">
                        Light cavalry</a>
                </td>
                <td class="nowrap">
                    <img src="images/holz.png" title="Wood" alt="">
                    <% = this.lightCavalryPrice.Wood %>
                </td>
                <td class="nowrap">
                    <img src="images/lehm.png" title="Clay" alt="">
                    <% = this.lightCavalryPrice.Clay %>
                </td>
                <td class="nowrap">
                    <img src="images/eisen.png" title="Iron" alt="">
                    <% = this.lightCavalryPrice.Iron %>
                </td>
                <td class="nowrap">
                    <img src="images/face.png" title="Villagers" alt="">
                    <% = this.lightCavalryPrice.Population %>
                </td>
                <td>
                    <% = Functions.FormatTime(this.lightCavalryPrice.BuildTime)%>
                </td>
                <td>
                    <% Response.Write(this.village.VillageTroopData.LightCavalry.ToString()); %>/<%Response.Write(this.village.VillageTroopData.LightCavalryOfVillage.ToString()); %>
                </td>
                <td>
                    <asp:TextBox ID="txtLight" runat="server" Width="33px"></asp:TextBox>
                    &nbsp;(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.txtLight.ClientID); %>', <% Response.Write(this.village.VillageRecruitMethods.MaxRecruit(beans.TroopType.Light)); %>)"><%Response.Write(this.village.VillageRecruitMethods.MaxRecruit(beans.TroopType.Light)); %></a>)
                </td>
            </tr>
            <tr class="row_a">
                <td>
                    <a href="javascript:popup_scroll('popup_unit.php?unit=heavy', 520, 520)">
                        <img src="images/unit_heavy.png" alt="">
                        Heavy cavalry</a>
                </td>
                <td class="nowrap">
                    <img src="images/holz.png" title="Wood" alt="">
                    <% = this.heavyCavalryPrice.Wood %>
                </td>
                <td class="nowrap">
                    <img src="images/lehm.png" title="Clay" alt="">
                    <% = this.heavyCavalryPrice.Clay %>
                </td>
                <td class="nowrap">
                    <img src="images/eisen.png" title="Iron" alt="">
                    <% = this.heavyCavalryPrice.Iron %>
                </td>
                <td class="nowrap">
                    <img src="images/face.png" title="Villagers" alt="">
                    <% = this.heavyCavalryPrice.Population %>
                </td>
                <td>
                    <% = Functions.FormatTime(heavyCavalryPrice.BuildTime)%>
                </td>
                <td>
                    <% Response.Write(this.village.VillageTroopData.HeavyCavalry.ToString()); %>/<%Response.Write(this.village.VillageTroopData.HeavyCavalryOfVillage.ToString()); %>
                </td>
                <td>
                    <asp:TextBox ID="txtHeavy" runat="server" Width="33px"></asp:TextBox>
                    &nbsp;(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.txtHeavy.ClientID); %>', <% Response.Write(this.village.VillageRecruitMethods.MaxRecruit(beans.TroopType.Heavy)); %>)"><%Response.Write(this.village.VillageRecruitMethods.MaxRecruit(beans.TroopType.Heavy)); %></a>)
                </td>
            </tr>
            <tr>
                <td colspan="8" align="right">
                    <asp:Button ID="bttnRecruit" runat="server" Font-Size="10pt" Text="Xây quân" OnClick="bttnRecruit_Click" />
                    &nbsp;
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
