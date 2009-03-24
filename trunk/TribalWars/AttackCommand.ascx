<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttackCommand.ascx.cs" Inherits="AttackCommand" %>
<style type="text/css">

body	{ background-color: #d2c09e; background-image:url('images/bg-tile.jpg'); 
font-size:9pt; font-family: Verdana, Arial; width:100%; margin: 0; }
h2		{ font-size:14pt;}
table.vis {border-collapse:separate;}
th		{ font-size:9pt; text-align: left; font-weight:bold; background-color:#DFCCA6; }

input, select { font-size: 8pt; /*background-color:#FDFBF3;*/ }

table.vis td { background-color:#F7EED3; }
td		{ font-size:9pt; }
</style>
    <h2>
        Tấn công thành phố <% Response.Write(this.command.To.Name); %></h2>
    <table class="vis" width="400">
        <tbody>
            <tr>
                <th colspan="3">
                    <span id="label"><span id="labelText">Tấn công</span>
                </th>
            </tr>
            <tr>
                <td rowspan="2">
                    Từ</td>
                <td>
                    Lãnh chúa:
                </td>
                <td>
                    <a href="user_info.aspx?id=<% Response.Write(this.village.ID); %>&player=<% Response.Write(this.command.From.Owner.ID); %>"><%Response.Write(this.command.From.Owner.Username); %></a>
                </td>
            </tr>
            <tr>
                <td>
                    Thành phố:
                </td>
                <td>
                    <a href="village_info.aspx?id=<% Response.Write(this.village.ID); %>&village=<% Response.Write(this.command.From.ID); %>"><% Response.Write(this.command.From.Name); %> (<% Response.Write(this.command.From.X.ToString("000")); %>|<% Response.Write(this.command.From.Y.ToString("000")); %>)</a>
                </td>
            </tr>
            <tr>
                <td rowspan="2">
                    Đến</td>
                <td>
                    Lãnh chúa:
                </td>
                <td>
                   <a href="user_info.aspx?id=<% Response.Write(this.village.ID); %>&player=<% Response.Write(this.command.To.ID); %>"><%Response.Write(this.command.From.To.Username); %></a>
                   
                </td>
            </tr>
            <tr>
                <td>
                    Thành phố:
                </td>
                <td>
                    <a href="village_info.aspx?id=<% Response.Write(this.village.ID); %>&village=<% Response.Write(this.command.To.ID); %>"><% Response.Write(this.command.From.Name); %> (<% Response.Write(this.command.To.X.ToString("000")); %>|<% Response.Write(this.command.To.Y.ToString("000")); %>)</a>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Thời gian:                 </td>
                <td>
                    <% Response.Write(Functions.FormatTime(this.command.LandingTime - DateTime.Now)); %>
                    <asp:Label ID="land_time" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Còn:</td>
                <td>
                    <asp:Label ID="timer" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                <asp:HyperLink ID="rally_url" runat="server">» Rally point</asp:HyperLink>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <asp:Label ID="lblTroop" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblResources" runat="server"></asp:Label>
    