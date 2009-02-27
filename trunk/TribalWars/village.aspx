﻿<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="village.aspx.cs"
    Inherits="village" Title="Medieval War - Thành phố" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Village overview <asp:Label ID="name" runat="server"></asp:Label></h2>
    <table>
        <tr>
            <td width="450" valign="top">
                <table class="vis" width="100%">
                    <tr>
                        <th colspan="1">
                            Buildings
                        </th>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/main.png" alt="" />
                            <asp:HyperLink ID="headquarter_url" runat="server" NavigateUrl="~/index.aspx">Nhà chính</asp:HyperLink>
                            (Level
                            <asp:Label ID="headquarter" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/barracks.png" alt="" />
                            <asp:HyperLink ID="barrack_url" runat="server" NavigateUrl="~/index.aspx">Bộ binh</asp:HyperLink>
                            &nbsp;(Level
                            <asp:Label ID="barrack" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/stable.png" alt="" />
                            <asp:HyperLink ID="stable_url" runat="server" NavigateUrl="~/index.aspx">Kỵ binh</asp:HyperLink>
                            (Level
                            <asp:Label ID="stable" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/garage.png" alt="" />
                            <asp:HyperLink ID="workshop_url" runat="server" NavigateUrl="~/index.aspx">Nhà xe</asp:HyperLink>
                            (Level
                            <asp:Label ID="workshop" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/snob.png" alt="" />
                            <asp:HyperLink ID="academy_url" runat="server" NavigateUrl="~/index.aspx">Academy</asp:HyperLink>
                            (Level
                            <asp:Label ID="academy" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/smith.png" alt="" />
                            <asp:HyperLink ID="smithy_url" runat="server" NavigateUrl="~/index.aspx">Xưởng nghiên cứu</asp:HyperLink>
                            (Level
                            <asp:Label ID="smithy" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/place.png" alt="" />
                            <asp:HyperLink ID="rally_url" runat="server" NavigateUrl="~/index.aspx">Trại lính</asp:HyperLink>
                            (Level
                            <asp:Label ID="rally" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/market.png" alt="" />
                            <asp:HyperLink ID="market_url" runat="server" NavigateUrl="~/index.aspx">Chợ</asp:HyperLink>(Level
                            <asp:Label ID="market" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/wood.png" alt="" />
                            <asp:HyperLink ID="timbercamp_url" runat="server" NavigateUrl="~/index.aspx">Trại gỗ</asp:HyperLink>
                            (Level
                            <asp:Label ID="timbercamp" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/stone.png" alt="" />
                            <asp:HyperLink ID="claypit_url" runat="server" NavigateUrl="~/index.aspx">Trại đất</asp:HyperLink>
                            (Level
                            <asp:Label ID="claypit" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/iron.png" alt="" />
                            <asp:HyperLink ID="ironmine_url" runat="server" NavigateUrl="~/index.aspx">Mỏ kim loại</asp:HyperLink>
                            (Level
                            <asp:Label ID="ironmine" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/farm.png" alt="" />
                            <asp:HyperLink ID="farm_url" runat="server" NavigateUrl="~/index.aspx">Dân cư</asp:HyperLink>
                            (Level
                            <asp:Label ID="farm" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/storage.png" alt="" />
                            <asp:HyperLink ID="storage_url" runat="server" NavigateUrl="~/index.aspx">Nhà kho</asp:HyperLink>
                            (Level
                            <asp:Label ID="storage" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/hide.png" alt="" />
                            <asp:HyperLink ID="hide_url" runat="server" NavigateUrl="~/index.aspx">Kho tàng</asp:HyperLink>
                            (Level
                            <asp:Label ID="hide" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/wall.png" alt="" />
                            <asp:HyperLink ID="wall_url" runat="server">Tường</asp:HyperLink>
                            (Level
                            <asp:Label ID="wall" runat="server" Text=""></asp:Label>)
                        </td>
                    </tr>
                </table>
                <br />
            </td>
            <td valign="top">
                <table class="vis" width="100%">
                    <tr>
                        <th colspan="2">
                            Production
                        </th>
                    </tr>
                    <tr class="nowrap">
                        <td width="70">
                            <img src="images/holz.png" title="Wood" alt="" />
                            Wood
                        </td>
                        <td>
                            <strong>
                                <asp:Label ID="wood" runat="server"></asp:Label></strong> per hour
                        </td>
                    </tr>
                    <tr class="nowrap">
                        <td>
                            <img src="images/lehm.png" title="Clay" alt="" />
                            Clay
                        </td>
                        <td>
                            <strong>
                                <asp:Label ID="clay" runat="server"></asp:Label></strong> per hour
                        </td>
                    </tr>
                    <asp:Label ID="lbl123" runat="server"></asp:Label>
                    <tr class="nowrap">
                        <td>
                            <img src="images/eisen.png" title="Iron" alt="" />
                            Iron
                        </td>
                        <td>
                            <strong>
                                <asp:Label ID="iron" runat="server"></asp:Label></strong> per hour
                        </td>
                    </tr>
                </table>
                <br />
                <table class="vis" width="100%">
                    <tr>
                        <th>
                            Units
                        </th>
                    </tr>
                    <asp:Label ID="lblTroops" runat="server"></asp:Label>
                </table>
                <br />
            </td>
        </tr>
    </table>

</asp:Content>