<%@ Page Language="C#" MasterPageFile="~/inPage.master" AutoEventWireup="true" CodeFile="report_details.aspx.cs"
    Inherits="report_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pHasReport" runat="server">
        <h2>
            Báo cáo</h2>
        <table>
            <tbody>
                <tr>
                    <td valign="top">
                        <table class="vis" width="100" runat="server" id="navigator">
                            <tbody>
                                <tr>
                                    <td width="100">
                                        <asp:HyperLink ID="urlAllReports" runat="server" NavigateUrl="~/report_details.aspx">Tất cả</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <asp:HyperLink ID="urlAttackReports" runat="server" NavigateUrl="~/report_details.aspx?type=1">Tấn công</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <asp:HyperLink ID="urlDefenseReports" runat="server" NavigateUrl="~/report_details.aspx?type=2">Phòng thủ</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <asp:HyperLink ID="urlSupportReports" runat="server" NavigateUrl="~/report_details.aspx?type=3">Hỗ trợ</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100">
                                        <asp:HyperLink ID="urlMarketReports" runat="server" NavigateUrl="~/report_details.aspx?type=4">Buôn bán</asp:HyperLink>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top" width="100%">
                        <table class="vis">
                            <tbody>
                                <tr>
                                    <th width="140">
                                        Subject
                                    </th>
                                    <th width="400">
                                        &nbsp;<span id="label"><span id="labelText"><% Response.Write(report_info["title"]); %>
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
                                        <% Response.Write(report_info["create_time"]); %>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="border: 1px solid black; padding: 4px;" height="160" valign="top">
                                        <h3><% Response.Write(sWinningSide); %></h3>
                                        May mắn (phía tấn công): <% Response.Write(((double)report_info["luck"]).ToString("0.00")); %>
                                        <br /><br />
                                        <table style="border: 1px solid rgb(222, 211, 185);" width="100%">
                                            <tbody>
                                                <tr>
                                                    <th width="100">
                                                        Tấn công:
                                                    </th>
                                                    <th>
                                                        <a href='user_info.aspx?id=<% Response.Write(Request["id"]); %>&username=<% Response.Write(report_info["user1"]); %>'>
                                                            <% Response.Write(report_info["user1"]); %></a>
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Thành phố:
                                                    </td>
                                                    <td>
                                                        <a href='village_info.aspx?id=<% Response.Write(Request["id"]); %>&village=<% Response.Write(report_info["village_1"]); %>'>
                                                            <% Response.Write(report_info["name1"]); %>
                                                            (<% Response.Write(report_info["x1"].ToString() + "|" + report_info["y1"].ToString()); %>)</a>
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
                                                                        <% Response.Write(report_info["aspear"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["asword"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["aaxe"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["ascout"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["alight"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["aheavy"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["aram"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["acatapult"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["anoble"]); %>
                                                                    </td>
                                                                </tr>
                                                                <tr class="center">
                                                                    <td>
                                                                        Thiệt hại:
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["aspear"] - (int)report_info["saspear"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["asword"] - (int)report_info["sasword"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["aaxe"] - (int)report_info["aaxe"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["ascout"] - (int)report_info["sascout"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["alight"] - (int)report_info["salight"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["aheavy"] - (int)report_info["saheavy"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["aram"] - (int)report_info["aram"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["acatapult"] - (int)report_info["sacatapult"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["anoble"] - (int)report_info["sanoble"]); %>
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
                                                        <a href='user_info.aspx?id=<% Response.Write(Request["id"]); %>&username=<% Response.Write(report_info["user1"]); %>'>
                                                            <% Response.Write(report_info["user2"]); %></a>
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Thành phố:
                                                    </td>
                                                    <td>
                                                        <a href='village_info.aspx?id=<% Response.Write(Request["id"]); %>&village=<% Response.Write(report_info["village_2"]); %>'>
                                                            <% Response.Write(report_info["name2"]); %>
                                                            (<% Response.Write(report_info["x2"].ToString() + "|" + report_info["y2"].ToString()); %>)</a>
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
                                                                        <% Response.Write(report_info["dspear"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["dsword"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["daxe"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["dscout"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["dlight"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["dheavy"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["dram"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["dcatapult"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write(report_info["dnoble"]); %>
                                                                    </td>
                                                                </tr>
                                                                <tr class="center">
                                                                    <td>
                                                                        Thiệt hại:
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["sdspear"] - (int)report_info["dspear"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["sdsword"] - (int)report_info["dsword"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["sdaxe"] - (int)report_info["daxe"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["sdscout"] - (int)report_info["dscout"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["sdlight"] - (int)report_info["dlight"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["sdheavy"] - (int)report_info["dheavy"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["sdram"] - (int)report_info["dram"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["sdcatapult"] - (int)report_info["dcatapult"]); %>
                                                                    </td>
                                                                    <td>
                                                                        <% Response.Write((int)report_info["sdnoble"] - (int)report_info["dnoble"]); %>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <br />
                                        <asp:Panel ID="Panel1" runat="server">
                                        <h5>Cướp phá:</h5>
                                        <img src="images/lehm.png" /><% Response.Write(report_info["clay"]); %>
                                        <img src="images/holz.png" /><% Response.Write(report_info["wood"]); %>
                                        <img src="images/eisen.png" /><% Response.Write(report_info["iron"]); %>
                                            </asp:Panel>
                                        <br>
                                        <br>
                                        
                                        <br>
                                        <hr>
                                        <a href="/game.php?village=51549&amp;screen=report&amp;mode=publish&amp;report_id=17808678">
                                            Publicize this report</a>
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
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    <asp:Panel ID="pNoReport" runat="server">
        <h2>
            Lỗi: không tìm thấy báo cáo</h2>
    </asp:Panel>
</asp:Content>
