<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="village.aspx.cs"
    Inherits="village" Title="Medieval War - Thành phố" %>

<%@ Reference Control="GraphicVillageInfo.ascx" %>
<%@ Reference Control="TextVillageInfo.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <span id="test"></span>
    <h2>
        Thành phố
        <% Response.Write(this.current.Name); %></h2>
    <table>
        <tr>
            <td width="450" valign="top">
                <asp:PlaceHolder ID="pVillageInfo" runat="server"></asp:PlaceHolder>
            </td>
            <td valign="top">
                <table class="vis" width="100%">
                    <tr>
                        <th colspan="2">
                            Năng suất
                        </th>
                    </tr>
                    <tr class="nowrap">
                        <td width="70">
                            <img src="images/holz.png" title="Wood" alt="" />
                            Gỗ
                        </td>
                        <td>
                            <strong>
                                <% Response.Write(this.current.ProductPerHour(beans.ResourcesType.Wood).ToString()); %></strong>
                            mỗi giờ
                        </td>
                    </tr>
                    <tr class="nowrap">
                        <td>
                            <img src="images/lehm.png" title="Clay" alt="" />
                            Gạch
                        </td>
                        <td>
                            <strong>
                                <% Response.Write(this.current.ProductPerHour(beans.ResourcesType.Clay).ToString()); %></strong>
                            mỗi giờ
                        </td>
                    </tr>
                    <asp:Label ID="lbl123" runat="server"></asp:Label>
                    <tr class="nowrap">
                        <td>
                            <img src="images/eisen.png" title="Iron" alt="" />
                            Kim loại
                        </td>
                        <td>
                            <strong>
                                <% Response.Write(this.current.ProductPerHour(beans.ResourcesType.Iron).ToString()); %></strong>
                            mỗi giờ
                        </td>
                    </tr>
                </table>
                <br />
                <table class="vis" width="100%">
                    <tr>
                        <th>
                            Quân trong thành
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pSpears" runat="server">
                                <img src="images/unit_spear.png" alt="" />
                                <% = this.current.VillageTroopData.SpearInVillage %> <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:text, spear %>" /></asp:Panel>
                            <asp:Panel ID="pSword" runat="server">
                                <img src="images/unit_sword.png" alt="" />
                                <% = this.current.VillageTroopData.SwordInVillage %> <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:text, sword %>" /></asp:Panel>
                            <asp:Panel ID="pAxe" runat="server">
                                <img src="images/unit_axe.png" alt="" />
                                <% = this.current.VillageTroopData.AxeInVillage%> <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:text, axe %>" /></asp:Panel>
                            <asp:Panel ID="pScout" runat="server">
                                <img src="images/unit_spy.png" alt="" />
                                <% = this.current.VillageTroopData.ScoutInVillage%> <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:text, scout %>" /></asp:Panel>
                            <asp:Panel ID="pLight" runat="server">
                                <img src="images/unit_light.png" alt="" />
                                <% = this.current.VillageTroopData.LightCavalryInVillage%> <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:text, light %>" /></asp:Panel>
                            <asp:Panel ID="pHeavy" runat="server">
                                <img src="images/unit_heavy.png" alt="" />
                                <% = this.current.VillageTroopData.HeavyCavalryInVillage%> <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:text, heavy %>" /></asp:Panel>
                            <asp:Panel ID="pRam" runat="server">
                                <img src="images/unit_ram.png" alt="" />
                                <% = this.current.VillageTroopData.RamInVillage%> <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:text, ram %>" /></asp:Panel>
                            <asp:Panel ID="pCatapult" runat="server">
                                <img src="images/unit_catapult.png" alt="" />
                                <% = this.current.VillageTroopData.CatapultInVillage%> <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:text, catapult %>" /></asp:Panel>
                            <asp:Panel ID="pNoble" runat="server">
                                <img src="images/unit_snob.png" alt="" />
                                <% = this.current.VillageTroopData.NobleInVillage%> <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:text, noble %>" /></asp:Panel>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
