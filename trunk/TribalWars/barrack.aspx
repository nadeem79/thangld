<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="barrack.aspx.cs"
    Inherits="barrack"  %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" Skin="Vista" />
    <table>
        <tbody>
            <tr>
                <td>
                    <img src="images/barracks3.png" title="Barracks" alt="" />
                </td>
                <td>
                    <h2>
                        <asp:Literal runat="server" Text="<%$ Resources:text, barrack %>" /> <asp:Literal runat="server" Text="<%$ Resources:text, level %>" /> <%Response.Write(this.village.Buildings.Barracks); %></h2>
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:text, barrack_description %>" />
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <br />
    <asp:Label ID="lblError" runat="server" Font-Size="14pt" ForeColor="Red"></asp:Label>
    <br />
    <br />
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
            <asp:Label ID="lblRecruiting" runat="server"></asp:Label>
        </tbody>
    </table>
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
                    <a href="javascript:popup_scroll('popup_unit.php?unit=spear', 520, 520)">
                        <img src="images/unit_spear.png" alt="">
                        Lính giáo</a>
                </td>
                <td class="nowrap">
                    <img src="images/holz.png" title="Wood" alt="" />
                    50
                </td>
                <td class="nowrap">
                    <img src="images/lehm.png" title="Clay" alt="" />
                    30
                </td>
                <td class="nowrap">
                    <img src="images/eisen.png" title="Iron" alt="" />
                    10
                </td>
                <td class="nowrap">
                    <img src="images/face.png" title="Villagers" alt="" />
                    1
                </td>
                <td>
                    <% = Functions.FormatTime(beans.Recruit.GetPrice(beans.TroopType.Spear, this.village[beans.BuildingType.Barracks]).BuildTime) %>
                </td>
                <td>
                    <% Response.Write(this.village.Troop.Spear.ToString()); %>/<%Response.Write(this.village.Troop.InVillageSpear.ToString()); %>
                </td>
                <td>
                    <asp:TextBox ID="txtSpear" runat="server" Width="33px"></asp:TextBox>
                    (<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.txtSpear.ClientID); %>', <% Response.Write(this.village.MaxRecruit(beans.TroopType.Spear)); %>)"><%Response.Write(this.village.MaxRecruit(beans.TroopType.Spear)); %></a>)
                </td>
            </tr>
            <tr class="row_a">
                <td>
                    <a href="javascript:popup_scroll('popup_unit.php?unit=sword', 520, 520)">
                        <img src="images/unit_sword.png" alt="">
                        Lính kiếm</a>
                </td>
                <td class="nowrap">
                    <img src="images/holz.png" title="Wood" alt="">
                    30
                </td>
                <td class="nowrap">
                    <img src="images/lehm.png" title="Clay" alt="">
                    30
                </td>
                <td class="nowrap">
                    <img src="images/eisen.png" title="Iron" alt="">
                    70
                </td>
                <td class="nowrap">
                    <img src="images/face.png" title="Villagers" alt="">
                    1
                </td>
                <td>
                    <% = Functions.FormatTime(beans.Recruit.GetPrice(beans.TroopType.Sword, this.village[beans.BuildingType.Barracks]).BuildTime) %>
                </td>
                <td>
                    <% Response.Write(this.village.Troop.Sword.ToString()); %>/<%Response.Write(this.village.Troop.InVillageSword.ToString()); %>
                </td>
                <td>
                    <asp:TextBox ID="txtSword" runat="server" Width="33px"></asp:TextBox>
                    (<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.txtSword.ClientID); %>', <% Response.Write(this.village.MaxRecruit(beans.TroopType.Sword)); %>)"><%Response.Write(this.village.MaxRecruit(beans.TroopType.Sword)); %></a>)
                </td>
            </tr>
            <tr class="row_a">
                <td>
                    <a href="javascript:popup_scroll('popup_unit.php?unit=axe', 520, 520)">
                        <img src="images/unit_axe.png" alt="">
                        Lính rìu</a>
                </td>
                <td class="nowrap">
                    <img src="images/holz.png" title="Wood" alt="">
                    60
                </td>
                <td class="nowrap">
                    <img src="images/lehm.png" title="Clay" alt="">
                    30
                </td>
                <td class="nowrap">
                    <img src="images/eisen.png" title="Iron" alt="">
                    40
                </td>
                <td class="nowrap">
                    <img src="images/face.png" title="Villagers" alt="">
                    1
                </td>
                <td>
                    <% = Functions.FormatTime(beans.Recruit.GetPrice(beans.TroopType.Axe, this.village[beans.BuildingType.Barracks]).BuildTime) %>
                </td>
                <td>
                    <% Response.Write(this.village.Troop.Axe.ToString()); %>/<%Response.Write(this.village.Troop.InVillageAxe.ToString()); %>
                </td>
                <td>
                    <asp:TextBox ID="txtAxe" runat="server" Width="33px"></asp:TextBox>
                    (<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.txtAxe.ClientID); %>', <% Response.Write(this.village.MaxRecruit(beans.TroopType.Axe)); %>)"><%Response.Write(this.village.MaxRecruit(beans.TroopType.Axe)); %></a>)
                </td>
            </tr>
            <tr>
                <td colspan="8" align="right">
                    &nbsp;<asp:Button ID="bttnRecruit" runat="server" Font-Size="10pt" Text="Xây quân"
                        OnClick="bttnRecruit_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
