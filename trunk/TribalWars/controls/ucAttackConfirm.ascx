<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAttackConfirm.ascx.cs"
    Inherits="controls_ucAttackConfirm" %>
<h2>
    Tấn công</h2>
<table class="vis" width="300">
    <tbody>
        <tr>
            <th colspan="2">
                Đặt lệnh
            </th>
        </tr>
        <tr>
            <td>
                Tấn công:
            </td>
            <td>
                <a href="../village_info.aspx?player=<% = this.Command.ToVillage.ID %><% = (object.Equals(Request["id"], null) ? "&id=" + Request["id"] : "") %>"
                    target="_blank">
                    <% = this.Command.ToVillage.Name %></a>
            </td>
        </tr>
        <tr>
            <td>
                Đối thủ:
            </td>
            <td>
                <a href="../user_info.aspx?player=<% = this.Command.ToVillage.Player.ID %><% = (object.Equals(Request["id"], null) ? "&id=" + Request["id"] : "") %>">
                    <% = this.Command.ToVillage.Player.Username%></a>
            </td>
        </tr>
        <tr>
            <td>
                Thời gian:
            </td>
            <td>
                <% = Functions.FormatTime(this.Command.LandingTime - this.Command.StartingTime)%>
            </td>
        </tr>
        <tr>
            <td>
                Đến lúc:
            </td>
            <td id="date_arrival">
                <asp:Label ID="lblLandingTime" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Ghi chú:
            </td>
            <td>
                <asp:Label ID="lblNote" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </tbody>
</table>
<br>
<table class="vis">
    <tbody>
        <tr>
            <th width="50">
                <img src="../images/unit_spear.png" title="Spear fighter" alt="" />
            </th>
            <th width="50">
                <img src="../images/unit_sword.png" title="Swordsman" alt="">
            </th>
            <th width="50">
                <img src="../images/unit_axe.png" title="Axeman" alt="" />
            </th>
            <th width="50">
                <img src="../images/unit_spy.png" title="Scout" alt="" />
            </th>
            <th width="50">
                <img src="../images/unit_light.png" title="Light cavalry" alt="" />
            </th>
            <th width="50">
                <img src="../images/unit_heavy.png" title="Heavy cavalry" alt="" />
            </th>
            <th width="50">
                <img src="../images/unit_ram.png" title="Ram" alt="" />
            </th>
            <th width="50">
                <img src="../images/unit_catapult.png" title="Catapult" alt="" />
            </th>
            <th width="50">
                <img src="../images/unit_snob.png" title="Nobleman" alt="" style="height: 18px; width: 18px" />
            </th>
        </tr>
        <tr>
            <td>
                <span <% if (this.Command.Spear == 0) Response.Write(" class='hidden'"); %>>
                    <% = this.Command.Spear %></span>
            </td>
            <td>
                <span <% if (this.Command.Sword == 0) Response.Write(" class='hidden'"); %>>
                    <% = this.Command.Sword %></span>
            </td>
            <td>
                <span <% if (this.Command.Axe == 0) Response.Write(" class='hidden'"); %>>
                    <% = this.Command.Axe %></span>
            </td>
            <td>
                <span <% if (this.Command.Scout == 0) Response.Write(" class='hidden'"); %>>
                    <% = this.Command.Scout %></span>
            </td>
            <td>
                <span <% if (this.Command.LightCavalry == 0) Response.Write(" class='hidden'"); %>>
                    <% = this.Command.LightCavalry %></span>
            </td>
            <td>
                <span <% if (this.Command.HeavyCavalry == 0) Response.Write(" class='hidden'"); %>>
                    <% = this.Command.HeavyCavalry%></span>
            </td>
            <td>
                <span <% if (this.Command.Ram == 0) Response.Write(" class='hidden'"); %>>
                    <% = this.Command.Ram %></span>
            </td>
            <td>
                <span <% if (this.Command.Catapult == 0) Response.Write(" class='hidden'"); %>>
                    <% = this.Command.Catapult %></span>
            </td>
            <td>
                <span <% if (this.Command.Noble == 0) Response.Write(" class='hidden'"); %>>
                    <% = this.Command.Noble %></span>
            </td>
        </tr>
        <tr>
            <td colspan="9">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="bttnSendAttack" runat="server" Text="OK" OnClick="bttnSendAttack_Click" />
                        </td>
                        <td>
                            <asp:Button ID="bttnCancelAttack" runat="server" Text="Huỷ" OnClick="bttnCancelAttack_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </tbody>
</table>
