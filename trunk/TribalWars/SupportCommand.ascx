<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SupportCommand.ascx.cs" Inherits="SupportCommand" %>
<h2>
    Hỗ trợ <% if (this.current.To.Owner.ID==(int)Session["user"]) Response.Write("tới "); %>thành phố
    <% Response.Write(this.current.To.Name); %></h2>
<table class="vis" width="400">
    <tbody>
        <tr>
            <th colspan="3">
                <span id="labelText">Tấn công</span>
            </th>
        </tr>
        <tr>
            <td rowspan="2">
                Từ
            </td>
            <td>
                Lãnh chúa:
            </td>
            <td>
                <a href="user_info.aspx?id=<% Response.Write(this.village.ID); %>&player=<% Response.Write(this.current.From.Owner.ID); %>">
                    <%Response.Write(this.current.From.Owner.Username); %></a>
            </td>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href="village_info.aspx?id=<% Response.Write(this.village.ID); %>&village=<% Response.Write(this.current.From.ID); %>">
                    <% Response.Write(this.current.From.Name); %>
                    (<% Response.Write(this.current.From.X.ToString("000")); %>|<% Response.Write(this.current.From.Y.ToString("000")); %>)</a>
            </td>
        </tr>
        <tr>
            <td rowspan="2">
                Đến
            </td>
            <td>
                Lãnh chúa:
            </td>
            <td>
                <a href="user_info.aspx?id=<% Response.Write(this.village.ID); %>&player=<% Response.Write(this.current.To.Owner.ID); %>">
                    <%Response.Write(this.current.To.Owner.Username); %></a>
            </td>
        </tr>
        <tr>
            <td>
                Thành phố:
            </td>
            <td>
                <a href="village_info.aspx?id=<% Response.Write(this.village.ID); %>&village=<% Response.Write(this.current.To.ID); %>">
                    <% Response.Write(this.current.To.Name); %>
                    (<% Response.Write(this.current.To.X.ToString("000")); %>|<% Response.Write(this.current.To.Y.ToString("000")); %>)</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Thời gian:
            </td>
            <td>
                <% Response.Write(this.current.LandingTime.ToString("dd/MM/yyyy HH:mm:ss") + "<span class='small hidden'>:" + this.current.LandingTime.Millisecond.ToString("000") + "</span>"); %>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Còn:
            </td>
            <td>
                <span class="timer">
                    <% Response.Write(Functions.FormatTime(this.current.LandingTime - DateTime.Now)); %></span>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <a href="rally.aspx?id=<% if (this.current.To.Owner.ID == (int)Session["user"]) Response.Write(this.current.To.ID); else Response.Write(this.current.From.ID); %>">
                    » Trại lính</a>
            </td>
        </tr>
    </tbody>
</table>
<br />
<asp:Panel ID="pOwn" runat="server">
    <table>
        <tbody>
            <tr>
                <th width='50'>
                    <img src='images/unit_spear.png' title='Spear fighter' alt=''>
                </th>
                <th width='50'>
                    <img src='images/unit_sword.png' title='Swordsman' alt=''>
                </th>
                <th width='50'>
                    <img src='images/unit_axe.png' title='Axeman' alt=''>
                </th>
                <th width='50'>
                    <img src='images/unit_spy.png' title='Scout' alt=''>
                </th>
                <th width='50'>
                    <img src='images/unit_light.png' title='Light cavalry' alt=''>
                </th>
                <th width='50'>
                    <img src='images/unit_heavy.png' title='Heavy cavalry' alt=''>
                </th>
                <th width='50'>
                    <img src='images/unit_ram.png' title='Ram' alt=''>
                </th>
                <th width='50'>
                    <img src='images/unit_catapult.png' title='Catapult' alt=''>
                </th>
                <th width='50'>
                    <img src='images/unit_snob.png' title='Nobleman' alt=''>
                </th>
            </tr>
            <tr>
                <td>
                    <span <% if (this.current.Spear == 0) Response.Write("class='hidden'"); %>>
                        <% Response.Write(this.current.Spear); %></span>
                </td>
                <td>
                    <span <% if (this.current.Sword == 0) Response.Write("class='hidden'"); %>>
                        <% Response.Write(this.current.Sword); %></span>
                </td>
                <td>
                    <span <% if (this.current.Axe == 0) Response.Write("class='hidden'"); %>>
                        <% Response.Write(this.current.Axe); %></span>
                </td>
                <td>
                    <span <% if (this.current.Scout == 0) Response.Write("class='hidden'"); %>>
                        <% Response.Write(this.current.Scout); %></span>
                </td>
                <td>
                    <span <% if (this.current.Light == 0) Response.Write("class='hidden'"); %>>
                        <% Response.Write(this.current.Light); %></span>
                </td>
                <td>
                    <span <% if (this.current.Heavy == 0) Response.Write("class='hidden'"); %>>
                        <% Response.Write(this.current.Heavy); %></span>
                </td>
                <td>
                    <span <% if (this.current.Ram == 0) Response.Write("class='hidden'"); %>>
                        <% Response.Write(this.current.Ram); %></span>
                </td>
                <td>
                    <span <% if (this.current.Catapult == 0) Response.Write("class='hidden'"); %>>
                        <% Response.Write(this.current.Catapult); %></span>
                </td>
                <td>
                    <span <% if (this.current.Noble == 0) Response.Write("class='hidden'"); %>>
                        <% Response.Write(this.current.Noble); %></span>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>