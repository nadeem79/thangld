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
            <a href="headquarters.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.Headquarter] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>>Nhà chính</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.Headquarter); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/barracks.png" alt="" />
            <a href="barrack.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.Barracks] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>>Bộ binh</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.Barracks); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/stable.png" alt="" />
            <a href="stable.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.Stable] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>">Kỵ binh</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.Stable); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/garage.png" alt="" />
            <a href="workshop.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.Workshop] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>">Nhà xe</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.Workshop); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/snob.png" alt="" />
            <a href="academy.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.Academy] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>">Trường đại học</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.Academy); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/smith.png" alt="" />
            <a href="smithy.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.Smithy] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>">Xưởng nghiên cứu</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.Smithy.ToString()); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/place.png" alt="" />
            <a href="rally.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.Rally] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>>Trại lính</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.Rally.ToString()); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/market.png" alt="" />
            <a href="market.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.Market] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>>Chợ</a>
            &nbsp; (Cấp
            <% Response.Write(this.current.Buildings.Market); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/wood.png" alt="" />
            <a href="wood.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.TimberCamp] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>>Trại gỗ</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.TimberCamp); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/stone.png" alt="" />
            <a href="clay.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.ClayPit] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>">Trại đất sét</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.ClayPit); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/iron.png" alt="" />
            <a href="iron.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.IronMine] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>">Mỏ kim loại</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.IronMine); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/farm.png" alt="" />
            <a href="farm.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.Farm] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>>Dân cư</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.Farm); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/storage.png" alt="" />
            <a href="warehouse.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.Warehouse] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>">Nhà kho</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.Warehouse); %>
            )
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/hide.png" alt="" />
            <a href="hidden.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.HidingPlace] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>">Kho tàng</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.HidingPlace); %>)
        </td>
    </tr>
    <tr>
        <td width="240">
            <img src="images/wall.png" alt="" />
            <a href="wall.aspx?id=<% Response.Write(this.current.ID); %>" <% if (this.current[beans.BuildingType.Wall] == 0){ %> onclick="jQuery.facebox('Chưa xây dựng công trình này');return false;"<%} %>>Tường thành</a>
            &nbsp;(Cấp
            <% Response.Write(this.current.Buildings.Wall.ToString()); %>)
        </td>
    </tr>
</table>
<br />
<asp:LinkButton ID="bttnSwitchGraphicsVillageOverview" runat="server" 
    onclick="bttnSwitchGraphicsVillageOverview_Click">Hiển thị dạng đồ hoạ</asp:LinkButton>

