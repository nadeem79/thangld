<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="village.aspx.cs"
    Inherits="village" Title="Medieval War - Thành phố" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <span id="test"></span>
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
                            &nbsp;(Cấp <% Response.Write(this.current.Headquarter.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/barracks.png" alt="" />
                            <a href="barrack.aspx?id=<% Response.Write(this.current.ID.ToString()); %>">Bộ binh</a>
                            &nbsp;(Cấp <% Response.Write(this.current.Barracks.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/stable.png" alt="" />
                            <a href="stable.aspx?id=<% Response.Write(this.current.ID.ToString()); %>">Kỵ binh</a>
                            &nbsp;(Cấp
                            <% Response.Write(this.current.Stable.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/garage.png" alt="" />
                            <a href="workshop.aspx?id=<% Response.Write(this.current.ID.ToString()); %>">Nhà xe</a>
                            &nbsp;(Cấp <% Response.Write(this.current.Workshop.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/snob.png" alt="" />
                            <asp:HyperLink ID="academy_url" runat="server" NavigateUrl="~/index.aspx">Academy</asp:HyperLink>
                            &nbsp;(Cấp <% Response.Write(this.current.Academy.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/smith.png" alt="" />
                            <asp:HyperLink ID="smithy_url" runat="server" NavigateUrl="~/index.aspx">Xưởng nghiên cứu</asp:HyperLink>
                            &nbsp;(Cấp <% Response.Write(this.current.Smithy.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/place.png" alt="" />
                            <a href="rally.aspx?id=<% Response.Write(this.current.ID.ToString()); %>">Trại lính</a></asp:HyperLink>
                            &nbsp;(Cấp <% Response.Write(this.current.Rally.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/market.png" alt="" />
                            <asp:HyperLink ID="market_url" runat="server" NavigateUrl="~/index.aspx">Chợ</asp:HyperLink>
                            &nbsp; (Cấp <% Response.Write(this.current.Market.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/wood.png" alt="" />
                            <a href="wood.aspx?id=<% Response.Write(this.current.ID.ToString()); %>">Trại gỗ</a>
                            &nbsp;(Cấp <% Response.Write(this.current.TimberCamp.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/stone.png" alt="" />
                            <a href="clay.aspx?id=<% Response.Write(this.current.ID.ToString()); %>">Trại đất sét</a>
                            &nbsp;(Cấp <% Response.Write(this.current.ClayPit.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/iron.png" alt="" />
                            <a href="iron.aspx?id=<% Response.Write(this.current.ID.ToString()); %>">Mỏ kim loại</a>
                            &nbsp;(Cấp <% Response.Write(this.current.IronMine.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/farm.png" alt="" />
                            <asp:HyperLink ID="farm_url" runat="server" NavigateUrl="~/index.aspx">Dân cư</asp:HyperLink>
                            &nbsp;(Cấp <% Response.Write(this.current.Farm.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/storage.png" alt="" />
                            <asp:HyperLink ID="storage_url" runat="server" NavigateUrl="~/index.aspx">Nhà kho</asp:HyperLink>
                            &nbsp;(Cấp <% Response.Write(this.current.Warehouse.ToString()); %> )
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/hide.png" alt="" />
                            <asp:HyperLink ID="hide_url" runat="server" NavigateUrl="~/index.aspx">Kho tàng</asp:HyperLink>
                            &nbsp;(Cấp <% Response.Write(this.current.HidingPlace.ToString()); %>)
                        </td>
                    </tr>
                    <tr>
                        <td width="240">
                            <img src="images/wall.png" alt="" />
                            <asp:HyperLink ID="wall_url" runat="server">Tường</asp:HyperLink>
                            &nbsp;(Cấp <% Response.Write(this.current.Wall.ToString()); %>)
                        </td>
                    </tr>
                </table>
                <br />
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
                                <% Response.Write(this.current.ProductPerHour(beans.ResourcesType.Wood).ToString()); %></strong> mỗi giờ
                        </td>
                    </tr>
                    <tr class="nowrap">
                        <td>
                            <img src="images/lehm.png" title="Clay" alt="" />
                            Gạch
                        </td>
                        <td>
                            <strong>
                                <% Response.Write(this.current.ProductPerHour(beans.ResourcesType.Clay).ToString()); %></strong> mỗi giờ
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
                                <% Response.Write(this.current.ProductPerHour(beans.ResourcesType.Iron).ToString()); %></strong> mỗi giờ
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
