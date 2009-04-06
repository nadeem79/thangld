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
                        
                        Trại ngựa cấp <% Response.Write(this.village.Stable); %></h2>
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
    <table class="vis">
        <tbody>
            <tr>
                <th width="150">
                    Training
                </th>
                <th width="120">
                    Duration
                </th>
                <th width="200">
                    Completion
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
                    <a href="javascript:popup_scroll('popup_unit.php?unit=spy', 520, 520)">
                        <img src="images/unit_spy.png" alt="">
                        Scout</a>
                </td>
                <td class="nowrap">
                    <img src="images/holz.png" title="Wood" alt="">
                    50
                </td>
                <td class="nowrap">
                    <img src="images/lehm.png" title="Clay" alt="">
                    50
                </td>
                <td class="nowrap">
                    <img src="images/eisen.png" title="Iron" alt="">
                    20
                </td>
                <td class="nowrap">
                    <img src="images/face.png" title="Villagers" alt="">
                    2
                </td>
                <td>
                    0:03:08
                </td>
                <td>
                    <% Response.Write(this.village.Scout.ToString()); %>/<%Response.Write(this.village.InVillageScout.ToString()); %>
                </td>
                <td>
                    <asp:TextBox ID="txtScout" runat="server" Width="33px"></asp:TextBox>
                    &nbsp;(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.txtScout.ClientID); %>', <% Response.Write(this.village.MaxRecruit(beans.TroopType.Scout)); %>)"><%Response.Write(this.village.MaxRecruit(beans.TroopType.Scout)); %></a>)
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
                    125
                </td>
                <td class="nowrap">
                    <img src="images/lehm.png" title="Clay" alt="">
                    100
                </td>
                <td class="nowrap">
                    <img src="images/eisen.png" title="Iron" alt="">
                    250
                </td>
                <td class="nowrap">
                    <img src="images/face.png" title="Villagers" alt="">
                    4
                </td>
                <td>
                    0:06:15
                </td>
                <td>
                    <% Response.Write(this.village.Light.ToString()); %>/<%Response.Write(this.village.InVillageLight.ToString()); %>
                </td>
                <td>
                    <asp:TextBox ID="txtLight" runat="server" Width="33px"></asp:TextBox>
                    &nbsp;(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.txtLight.ClientID); %>', <% Response.Write(this.village.MaxRecruit(beans.TroopType.Light)); %>)"><%Response.Write(this.village.MaxRecruit(beans.TroopType.Light)); %></a>)
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
                    200
                </td>
                <td class="nowrap">
                    <img src="images/lehm.png" title="Clay" alt="">
                    150
                </td>
                <td class="nowrap">
                    <img src="images/eisen.png" title="Iron" alt="">
                    600
                </td>
                <td class="nowrap">
                    <img src="images/face.png" title="Villagers" alt="">
                    6
                </td>
                <td>
                    0:12:29
                </td>
                <td>
                    <% Response.Write(this.village.Heavy.ToString()); %>/<%Response.Write(this.village.InVillageHeavy.ToString()); %>
                </td>
                <td>
                    <asp:TextBox ID="txtHeavy" runat="server" Width="33px"></asp:TextBox>
                    &nbsp;(<a href="javascript:void(0);" onclick="insertUnit('<% Response.Write(this.txtHeavy.ClientID); %>', <% Response.Write(this.village.MaxRecruit(beans.TroopType.Heavy)); %>)"><%Response.Write(this.village.MaxRecruit(beans.TroopType.Heavy)); %></a>)
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
