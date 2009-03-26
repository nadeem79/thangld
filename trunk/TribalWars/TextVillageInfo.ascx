<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextVillageInfo.ascx.cs"
    Inherits="TextVillageInfo" %>
    <asp:Label ID="lblError" runat="server" ForeColor="#FF3300"></asp:Label>
<table class="vis" width="100%">
    <tr>
        <th colspan="1">
            Công trình
        </th>
    </tr>
    <tr>
        <td width="240">
            <img src="images/main.png" alt="" />
            <a href="headquarters.aspx?id=<% Response.Write(this.current.ID); %>">Nhà chính</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Headquarter); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/barracks.png" alt="" />
            <a href="barrack.aspx?id=<% Response.Write(this.current.ID); %>">Bộ binh</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Barracks); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/stable.png" alt="" />
            <a href="stable.aspx?id=<% Response.Write(this.current.ID); %>">Kỵ binh</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Stable); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/garage.png" alt="" />
            <a href="workshop.aspx?id=<% Response.Write(this.current.ID); %>">Nhà xe</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Workshop); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/snob.png" alt="" />
            <a href="academy.aspx?id=<% Response.Write(this.current.ID); %>">Trường đại học</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Academy); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/smith.png" alt="" />
            <a href="smithy.aspx?id=<% Response.Write(this.current.ID); %>">Xưởng nghiên cứu</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Smithy.ToString()); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/place.png" alt="" />
            <a href="rally.aspx?id=<% Response.Write(this.current.ID); %>">Trại lính</a></asp:HyperLink>
            &nbsp;(Cấp
            <% Response.Write(this.current.Rally.ToString()); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/market.png" alt="" />
            <a href="market.aspx?id=<% Response.Write(this.current.ID); %>">Chợ</a>
            &nbsp; (Cấp
            <% Response.Write(this.current.Market); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/wood.png" alt="" />
            <a href="wood.aspx?id=<% Response.Write(this.current.ID); %>">Trại gỗ</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.TimberCamp); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/stone.png" alt="" />
            <a href="clay.aspx?id=<% Response.Write(this.current.ID); %>">Trại đất sét</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.ClayPit); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/iron.png" alt="" />
            <a href="iron.aspx?id=<% Response.Write(this.current.ID); %>">Mỏ kim loại</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.IronMine); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/farm.png" alt="" />
            <a href="farm.aspx?id=<% Response.Write(this.current.ID); %>">Dân cư</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Farm); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/storage.png" alt="" />
            <a href="warehouse.aspx?id=<% Response.Write(this.current.ID); %>">Nhà kho</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Warehouse); %>
            )
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/hide.png" alt="" />
            <a href="hidden.aspx?id=<% Response.Write(this.current.ID); %>">Kho tàng</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.HidingPlace); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/wall.png" alt="" />
            <a href="wall.aspx?id=<% Response.Write(this.current.ID); %>">Tường thành</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Wall.ToString()); %>)
        </td>
    </tr>
</table>
<br />
<asp:LinkButton ID="bttnSwitchGraphicsVillageOverview" runat="server" 
    onclick="bttnSwitchGraphicsVillageOverview_Click">Hiển thị dạng đồ hoạ</asp:LinkButton>

