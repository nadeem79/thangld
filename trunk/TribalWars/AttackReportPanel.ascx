<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttackReportPanel.ascx.cs"
    Inherits="AttackReportPanel" %>
<table class="vis">
    <tbody>
        <tr>
            <th width="140">
                Subject
            </th>
            <th width="400">
                &nbsp;<span id="label"><span id="labelText"><% Response.Write(this.report.Title); %>
                </span></span><span id="edit" style="display: none;">
                    <input id="editInput" size="40" value="Lastdra attacks 002 Thu Huong (534|701)">
                    <input value="OK" onclick="editSubmit('label', 'labelText', 'edit', 'editInput', '')"
                        type="submit"></span>
            </th>
        </tr>
        <tr>
            <td>
                Sent
            </td>
            <td>
                <% Response.Write(this.report.Time); %>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="border: 1px solid black; padding: 4px;" height="160" valign="top">
                <h3>
                    <% if (this.report.SuccessAttack) Response.Write("Bên tấn công"); else Response.Write("Bên phòng thủ"); %>
                    thắng trận</h3>
                May mắn (phía tấn công):
                <% Response.Write(this.report.Luck.ToString("0.00")); %>
                <br />
                <br />
                <table style="border: 1px solid rgb(222, 211, 185);" width="100%">
                    <tbody>
                        <tr>
                            <th width="100">
                                Tấn công:
                            </th>
                            <th>
                                <a href='user_info.aspx?id=<% Response.Write(this.village.ID); %>&user=<% Response.Write(this.report.From.Owner.ID); %>'>
                                    <% Response.Write(this.report.From.Owner.Username); %></a>
                            </th>
                        </tr>
                        <tr>
                            <td>
                                Thành phố:
                            </td>
                            <td>
                                <a href='village_info.aspx?id=<% Response.Write(this.village.ID); %>&village=<% Response.Write(this.report.From.ID); %>'>
                                    <% Response.Write(this.report.From.Name); %>
                                    (<% Response.Write(this.report.From.X.ToString("000") + "|" + this.report.From.Y.ToString("000")); %>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table class="vis">
                                    <tbody>
                                        <tr class="center">
                                            <td>
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_spear.png" title="Spear fighter" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_sword.png" title="Swordsman" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_axe.png" title="Axeman" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_spy.png" title="Scout" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_light.png" title="Light cavalry" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_heavy.png" title="Heavy cavalry" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_ram.png" title="Ram" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_catapult.png" title="Catapult" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_snob.png" title="Nobleman" alt="">
                                            </td>
                                        </tr>
                                        <tr class="center">
                                            <td>
                                                Số lượng:
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.SpearSent); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.SwordSent); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.AxeSent); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.ScoutSent); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.LightSent); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.HeavySent); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.RamSent); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.CatapultSent); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.NobleSent); %>
                                            </td>
                                        </tr>
                                        <tr class="center">
                                            <td>
                                                Thiệt hại:
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.SpearSent - this.report.SpearReturnt); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.SwordSent - this.report.SwordReturnt); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.AxeSent - this.report.AxeReturnt); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.ScoutSent - this.report.ScoutReturnt); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.LightSent - this.report.LightReturnt); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.HeavySent - this.report.HeavyReturnt); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.RamSent - this.report.RamReturnt); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.CatapultSent - this.report.CatapultReturnt); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.NobleSent - this.report.NobleReturnt); %>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br>
                <table style="border: 1px solid rgb(222, 211, 185);" width="100%">
                    <tbody>
                        <tr>
                            <th width="100">
                                Phòng thủ:
                            </th>
                            <th>
                                <a href='user_info.aspx?id=<% Response.Write(this.village.ID); %>&user=<% Response.Write(this.report.To.Owner.ID); %>'>
                                    <% Response.Write(this.report.To.Owner.Username); %></a>
                            </th>
                        </tr>
                        <tr>
                            <td>
                                Thành phố:
                            </td>
                            <td>
                                <a href='village_info.aspx?id=<% Response.Write(this.village.ID); %>&village=<% Response.Write(this.report.To.ID); %>'>
                                    <% Response.Write(this.report.To.Name); %>
                                    (<% Response.Write(this.report.To.X.ToString("000") + "|" + this.report.To.Y.ToString("000")); %>)</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table class="vis">
                                    <tbody>
                                        <tr class="center">
                                            <td>
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_spear.png" title="Spear fighter" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_sword.png" title="Swordsman" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_axe.png" title="Axeman" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_spy.png" title="Scout" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_light.png" title="Light cavalry" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_heavy.png" title="Heavy cavalry" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_ram.png" title="Ram" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_catapult.png" title="Catapult" alt="">
                                            </td>
                                            <td width="35">
                                                <img src="images/unit_snob.png" title="Nobleman" alt="">
                                            </td>
                                        </tr>
                                        <tr class="center">
                                            <td>
                                                Số lượng:
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.SpearDefense); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.SwordDefense); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.AxeDefense); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.ScoutDefense); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.LightDefense); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.HeavyDefense); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.RamDefense); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.CatapultDefense); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.NobleDefense); %>
                                            </td>
                                        </tr>
                                        <tr class="center">
                                            <td>
                                                Thiệt hại:
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.SpearDefense - this.report.SpearSurvived); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.SwordDefense - this.report.SwordSurvived); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.AxeDefense - this.report.AxeSurvived); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.ScoutDefense - this.report.ScoutSurvived); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.LightDefense - this.report.LightSurvived); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.HeavyDefense - this.report.HeavySurvived); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.RamDefense - this.report.RamSurvived); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.CatapultDefense - this.report.CatapultSurvived); %>
                                            </td>
                                            <td>
                                                <% Response.Write(this.report.NobleDefense - this.report.NobleSurvived); %>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <asp:Panel ID="pResources" runat="server">
                    <h5>
                        Cướp bóc:</h5>
                    <img src="images/lehm.png" /><% Response.Write(this.report.Clay); %>
                    <img src="images/holz.png" /><% Response.Write(this.report.Wood); %>
                    <img src="images/eisen.png" /><% Response.Write(this.report.Iron); %>
            </td>
        </tr>
    </tbody>
</table>
<table class="vis" align="center" width="100%">
    <tbody>
        <tr>
            <td align="center" width="20%">
                <a href="/game.php?village=51549&amp;screen=report&amp;mode=forward&amp;id=17808678">
                    forward</a>
            </td>
            <td align="center" width="20%">
                <a href="/game.php?village=51549&amp;screen=report&amp;mode=all&amp;action=del_one&amp;id=17808678&amp;h=296c">
                    Delete</a>
            </td>
            <td align="center" width="20%">
                <a href="/game.php?village=51549&amp;screen=report&amp;mode=all&amp;view=17919899">&lt;&lt;</a>
            </td>
            <td align="center" width="20%">
                <a href="/game.php?village=51549&amp;screen=report&amp;mode=all&amp;view=17774313">&gt;&gt;</a>
            </td>
        </tr>
    </tbody>
</table>
</asp:Panel> 